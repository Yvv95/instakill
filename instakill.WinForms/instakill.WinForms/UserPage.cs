using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using instakill.Model;

namespace instakill.WinForms
{
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            this.FormClosed += UserPageClosing;
        }

        public static string photopath = "", connectionString= "http://localhost:1432/";
        public static Users watchUser  = new Users();
        public static List<Users> followList = new List<Users>(), subscrList = new List<Users>();
        //followList - подписчики, subscrList - на кого подписан
        void UserPageClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            

            //чтобы сделать кнопку круглой
            /*
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, OpenAddPost.Width, OpenAddPost.Height);
            Region myRegion = new Region(myPath);
            OpenAddPost.Region = myRegion;
            */
            //


            //user load
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(connectionString);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var url = "api/users/" + Program.userId;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Users user = response.Content.ReadAsAsync<Users>().Result;
                labelNick.Text = user.Nickname;
                labelInfo.Text = user.Info;
                labelUsername.Text = user.Username;
                Text = user.Nickname;
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке пользователя");
            }
           
            //followers load
            url = "api/followers/" + Program.userId;
             response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                followList = response.Content.ReadAsAsync<List<Users>>().Result;
                followers.Text = followList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке подписчиков");
            }

            url = "api/subs/" + Program.userId;
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                subscrList = response.Content.ReadAsAsync<List<Users>>().Result;
                subcrs.Text = subscrList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке друзей");
            }
       
            //загрузка публикаций     
            url = "api/posts/user/" + Program.userId;
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                publs.Text = response.Content.ReadAsAsync<List<Posts>>().Result.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке постов пользователя");
            }

            //загрузка ленты
            List<Posts> loadPosts=new List<Posts>();
            url = "api/posts/feed/" + Program.userId;
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                loadPosts = response.Content.ReadAsAsync<List<Posts>>().Result;
            }
            List<int> postLikes = new List<int>();

            DateTime g;
            for (int i = 0; i < (loadPosts.Count); i++)
            {

                //инициализация toolbox
                Label time = new Label(), likes = new Label(), nick = new Label();
                PictureBox photo = new PictureBox();
                //

                url = "/api/likes/" + loadPosts[i].PostId + "/users";
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    postLikes.Add(response.Content.ReadAsAsync<List<Users>>().Result.Count);
                }

                url = "/api/users/" + loadPosts[i].UserId;
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    nick.Text = response.Content.ReadAsAsync<Users>().Result.Nickname;
                }
                else
                {
                    nick.Text = "Ошибка";
                }
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

                photo.Image = stringToImage(loadPosts[i].Photo);
                time.Text = total;
                //nick.Text = loadPosts[i].UserId.ToString();
                nick.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Bold);
                likes.Text = @"❤" + postLikes[i];
                photo.SizeMode = PictureBoxSizeMode.StretchImage;
                photo.Click += Pic_Click;//для приближения фото


                //задание им местоположения
                photo.Location = new Point(10, scrollPanel.Controls.Count * 30+30);
                likes.Location = new Point(110, scrollPanel.Controls.Count * 30+30);
                nick.Location = new Point(10, scrollPanel.Controls.Count * 30);
                time.Location = new Point(150, scrollPanel.Controls.Count * 30+30);
                //

                //добавление в контрол
                scrollPanel.Controls.Add(photo);
                scrollPanel.Controls.Add(time);
                scrollPanel.Controls.Add(likes);
                scrollPanel.Controls.Add(nick);
                //
            }
        }

        //для приближения фото
        public static void Pic_Click(object sender, EventArgs args)
        {
            var pic = (PictureBox)sender;
            var f = new Zoom
            {
                WindowState = FormWindowState.Normal,
                BackgroundImage = pic.Image,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            photopath = openFileDialog1.FileName;
            PreviewPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            PreviewPhoto.Load(photopath);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(connectionString);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Image newPhoto = PreviewPhoto.Image;

            Posts post = new Posts();
            MemoryStream ms = new MemoryStream();
            newPhoto.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();
            post.Photo = Convert.ToBase64String(bytes);

            post.UserId = Program.userId;
            var response = client.PostAsJsonAsync("api/posts", post).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Пост добавлен");
                PreviewPhoto.Load(photopath);
            }
            else
            {
                MessageBox.Show("Ошибка " + response.StatusCode + " : подробнее - " + response.ReasonPhrase);
            }

            UserPage frm = new UserPage();
            this.Hide();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (searchBox.Text != "")
            {
                var userNick = searchBox.Text;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(connectionString);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/users/name/" + userNick;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Users user = response.Content.ReadAsAsync<Users>().Result;
                    if (user.UserId==Guid.Empty)
                        MessageBox.Show("Пользователь не найден");
                    else
                    {
                        watchUser = user;
                        SomeUserPage frm = new SomeUserPage();
                        frm.Show();
                    }
                }
            }
        }

        public static Image stringToImage(string inputString)
        {
            byte[] NewBytes = Convert.FromBase64String(inputString);
            MemoryStream ms1 = new MemoryStream(NewBytes);
            Image NewImage = Image.FromStream(ms1);
            return NewImage;
        }
    }
}
