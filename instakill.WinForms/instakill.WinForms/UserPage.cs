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

namespace instakill.WinForms
{
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            this.FormClosed += UserPageClosing;
        }

        public string photopath = "";
        public bool pressed = false;
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
            Publish.Visible = false;
            PreviewPhoto.Visible = false;
            
            

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://instagram20161204020526.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var url = "api/users/" + Program.userId;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Users user = response.Content.ReadAsAsync<Users>().Result;
                labelNick.Text = user.Nickname;
                labelInfo.Text = user.Info;
                labelUsername.Text = user.Username;
            }
            else
            {
                
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            photopath = openFileDialog1.FileName;
            PreviewPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            PreviewPhoto.Load(photopath);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://instagram20161204020526.azurewebsites.net/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Posts post = new Posts();
            post.Photo = photopath;
            post.UserId = Program.userId;
            var response = client.PostAsJsonAsync("api/posts", post).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Post Added");
                PreviewPhoto.Load(photopath);
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Publish.Visible =true;
            PreviewPhoto.Visible = true;
            

            
                


        }
    }
}
