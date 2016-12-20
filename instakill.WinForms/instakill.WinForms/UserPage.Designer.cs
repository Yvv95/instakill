namespace instakill.WinForms
{
    partial class UserPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenAddPost = new System.Windows.Forms.Button();
            this.labelNick = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PreviewPhoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.followers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subcrs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.publs = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.PostsBox = new System.Windows.Forms.GroupBox();
            this.scrollPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhoto)).BeginInit();
            this.PostsBox.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenAddPost
            // 
            this.OpenAddPost.BackColor = System.Drawing.Color.DodgerBlue;
            this.OpenAddPost.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenAddPost.FlatAppearance.BorderSize = 0;
            this.OpenAddPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenAddPost.Font = new System.Drawing.Font("Adobe Arabic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenAddPost.Location = new System.Drawing.Point(604, 20);
            this.OpenAddPost.Margin = new System.Windows.Forms.Padding(0);
            this.OpenAddPost.Name = "OpenAddPost";
            this.OpenAddPost.Size = new System.Drawing.Size(44, 43);
            this.OpenAddPost.TabIndex = 0;
            this.OpenAddPost.Text = "+";
            this.OpenAddPost.UseVisualStyleBackColor = false;
            this.OpenAddPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Script MT Bold", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNick.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelNick.Location = new System.Drawing.Point(109, 62);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(95, 46);
            this.labelNick.TabIndex = 1;
            this.labelNick.Text = "Nick";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(43, 181);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(69, 23);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Name";
            this.labelUsername.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(350, 181);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(32, 18);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "Info";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PreviewPhoto
            // 
            this.PreviewPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewPhoto.Location = new System.Drawing.Point(620, 13);
            this.PreviewPhoto.Name = "PreviewPhoto";
            this.PreviewPhoto.Size = new System.Drawing.Size(150, 128);
            this.PreviewPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPhoto.TabIndex = 6;
            this.PreviewPhoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(172, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Подписчиков";
            // 
            // followers
            // 
            this.followers.AutoSize = true;
            this.followers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.followers.Location = new System.Drawing.Point(172, 123);
            this.followers.Name = "followers";
            this.followers.Size = new System.Drawing.Size(17, 18);
            this.followers.TabIndex = 8;
            this.followers.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(304, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Подписок";
            // 
            // subcrs
            // 
            this.subcrs.AutoSize = true;
            this.subcrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subcrs.Location = new System.Drawing.Point(304, 123);
            this.subcrs.Name = "subcrs";
            this.subcrs.Size = new System.Drawing.Size(17, 18);
            this.subcrs.TabIndex = 10;
            this.subcrs.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Публикаций";
            // 
            // publs
            // 
            this.publs.AutoSize = true;
            this.publs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publs.Location = new System.Drawing.Point(44, 123);
            this.publs.Name = "publs";
            this.publs.Size = new System.Drawing.Size(17, 18);
            this.publs.TabIndex = 12;
            this.publs.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "🔍";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(249, 18);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(192, 31);
            this.searchBox.TabIndex = 14;
            // 
            // PostsBox
            // 
            this.PostsBox.Controls.Add(this.scrollPanel);
            this.PostsBox.Location = new System.Drawing.Point(22, 216);
            this.PostsBox.Name = "PostsBox";
            this.PostsBox.Size = new System.Drawing.Size(723, 316);
            this.PostsBox.TabIndex = 23;
            this.PostsBox.TabStop = false;
            this.PostsBox.Text = "Новости";
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.OpenAddPost);
            this.scrollPanel.Location = new System.Drawing.Point(6, 21);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(679, 306);
            this.scrollPanel.TabIndex = 0;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.PreviewPhoto);
            this.Controls.Add(this.PostsBox);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.publs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subcrs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.followers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelNick);
            this.Name = "UserPage";
            this.Text = "Страница пользователя";
            this.Load += new System.EventHandler(this.UserPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhoto)).EndInit();
            this.PostsBox.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenAddPost;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox PreviewPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label followers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label subcrs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label publs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.GroupBox PostsBox;
        private System.Windows.Forms.Panel scrollPanel;
    }
}