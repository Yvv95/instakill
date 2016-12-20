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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            this.FormClosed += PageClosing;
        }
        void PageClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start frm = new Start();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users newUser = new Users();
            newUser.Nickname = Nick.Text;
            newUser.Username = Fullname.Text;
            newUser.Info = Info.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UserPage.connectionString);
            // Add an Accept header for JSON format.


            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));        
            var response = client.PostAsJsonAsync("api/users", newUser).Result;
           
            if (response.IsSuccessStatusCode)
            {
                returnId.Visible = true;
                labelId.Visible = true;
                //returnId.Text = newUser.UserId.ToString();
            }
            else
            {
                MessageBox.Show("Error in registration " + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

            var url = "api/users/name/" + newUser.Nickname;
            HttpResponseMessage _response = client.GetAsync(url).Result; ;
            if (_response.IsSuccessStatusCode)
            {
                Users user = _response.Content.ReadAsAsync<Users>().Result;
                returnId.Text = user.UserId.ToString();
            }
            else
            {
                MessageBox.Show("Error in registration " + _response.StatusCode + " : Message - " + _response.ReasonPhrase);
            }



        }


        private void SignUp_Load(object sender, EventArgs e)
        {
            returnId.Visible = false;
            labelId.Visible = false;



        }

        private void Nick_TextChanged(object sender, EventArgs e)
        {
            returnId.Visible = false;
            labelId.Visible = false;
        }

        private void Fullname_TextChanged(object sender, EventArgs e)
        {
            returnId.Visible = false;
            labelId.Visible = false;
        }

        private void Info_TextChanged(object sender, EventArgs e)
        {
            returnId.Visible = false;
            labelId.Visible = false;
        }

        
    }
}
