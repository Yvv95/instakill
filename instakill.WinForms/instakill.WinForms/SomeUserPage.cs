using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using instakill.Model;
using System.Globalization;

namespace instakill.WinForms
{
    public partial class SomeUserPage : Form
    {
        public SomeUserPage()
        {
            InitializeComponent();
            this.FormClosed += UserPageClosing;
        }
        void UserPageClosing(object sender, FormClosedEventArgs e)
        {   
            Hide();  
        }

        public static string photopath = "", connectionString = "http://localhost:1432/";
        public bool tofollow = false;//не подписан
        private void SomeUserPage_Load(object sender, EventArgs e)
        {
            labelNick.Text = UserPage.watchUser.Nickname;
            labelInfo.Text = UserPage.watchUser.Info;
            labelUsername.Text = UserPage.watchUser.Username;
            Text = UserPage.watchUser.Nickname;
            List<Posts> loadPosts = new List<Posts>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(connectionString);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = "api/posts/user/" + UserPage.watchUser.UserId;
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                loadPosts = response.Content.ReadAsAsync<List<Posts>>().Result;
                publs.Text = loadPosts.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке постов пользователя");
            }
            
            List<int> postLikes = new List<int>();

            url = "api/followers/" + UserPage.watchUser.UserId;
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                followers.Text = response.Content.ReadAsAsync<List<Users>>().Result.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке подписчиков");
            }

            url = "api/subs/" + UserPage.watchUser.UserId;
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                subcrs.Text = response.Content.ReadAsAsync<List<Users>>().Result.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке друзей");
            }



            

            DateTime g;
            for (int i = 0; i < (loadPosts.Count); i++)
            {
                //загрузка лайков поста
                url = "/api/likes/" + loadPosts[i].PostId + "/users";
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    postLikes.Add(response.Content.ReadAsAsync<List<Users>>().Result.Count);
                }
                //

                //инициализация toolbox
                Label time = new Label(), likes = new Label();
                PictureBox photo = new PictureBox();
                //

                //их заполнение
                string total = "";
                g = new DateTime((DateTime.Now - loadPosts[i].Date).Ticks);
                if (((g.Year - 1) > 0) || ((g.Month - 1) > 0) || (g.Day - 1) > 14)
                { total = loadPosts[i].Date.ToString(CultureInfo.InvariantCulture); }
                else
                if ((g.Day - 1) > 0)
                { total = $"{(g.Day - 1)} дней назад"; }
                else
                if ((g.Hour - 1) > 0)
                { total = $"{(g.Hour - 1)} часов назад"; }
                else
                if ((g.Minute - 1) > 0)
                { total = $"{(g.Minute - 1)} минут назад"; }
                else
                {
                    total = "Только что";
                }

                photo.Image = UserPage.stringToImage(loadPosts[i].Photo);
                time.Text = total;
                likes.Text = @"❤" + postLikes[i];
                photo.SizeMode = PictureBoxSizeMode.StretchImage;
                photo.Click += UserPage.Pic_Click;

                //задание им местоположения
                photo.Location = new Point(10, scrollPanel.Controls.Count*20);
                likes.Location = new Point(110, scrollPanel.Controls.Count*20);
                time.Location = new Point(160, scrollPanel.Controls.Count*20);
                //

                //добавление в контрол
                scrollPanel.Controls.Add(photo);
                scrollPanel.Controls.Add(time);
                scrollPanel.Controls.Add(likes);
                //
            }

            if (UserPage.watchUser.UserId == Program.userId)
            {
                subcribe.Visible = false;
            }
            else
                foreach (Users t in UserPage.subscrList)
                    if (t.UserId == UserPage.watchUser.UserId)
                    //if (t.UserId == Program.userId)
                    //if (UserPage.followList.Contains(UserPage.watchUser))
                    {
                        subcribe.Text = "Отписаться";
                        tofollow = true;
                        break;
                    }
                    else
                    {
                        subcribe.Text = "Подписаться";
                        tofollow = false;
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(connectionString);

            if (!tofollow)
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                //var response = client.PostAsJsonAsync("api/followers/" + Program.userId, UserPage.watchUser).Result;
                Users temp = new Users();
                temp.UserId = Program.userId;
                var response = client.PostAsJsonAsync("api/followers/" + UserPage.watchUser.UserId, temp).Result;
                if (response.IsSuccessStatusCode)
                {
                    subcribe.Text = "Отписаться";
                    tofollow = true;
                }
                else
                {

                }
            }
            SomeUserPage frm = new SomeUserPage();
            this.Hide();
            frm.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
