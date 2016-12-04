using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using instakill.Model;



namespace instakill.WinForms
{
    public partial class Start : Form
    {

        
        public Start()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signUpbutton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.signIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.signIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

        }

        private void signIn_Click(object sender, EventArgs e)
        {         
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://instagram20161204020526.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Guid id = Guid.Empty;
            try
            {
                id = Guid.Parse(signIntext.Text);
            }
            catch (ArgumentNullException)
            {
                id = Guid.Empty;
            }
            catch (FormatException)
            {
                id = Guid.Empty;
            }


            var url = "api/users/"+id;
            Program.userId = id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Users user = response.Content.ReadAsAsync<Users>().Result;
                signIntext.Text = user.Nickname;
                UserPage frm = new UserPage();
                this.Hide();
                frm.Show();
            }
            else
            {
                signIntext.Text="Неверные данные";
            }          
        }
       
    }
}
