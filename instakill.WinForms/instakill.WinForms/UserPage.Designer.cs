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
            this.Publish = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PreviewPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenAddPost
            // 
            this.OpenAddPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenAddPost.Location = new System.Drawing.Point(176, 465);
            this.OpenAddPost.Name = "OpenAddPost";
            this.OpenAddPost.Size = new System.Drawing.Size(61, 46);
            this.OpenAddPost.TabIndex = 0;
            this.OpenAddPost.Text = "+";
            this.OpenAddPost.UseVisualStyleBackColor = true;
            this.OpenAddPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Script MT Bold", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNick.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelNick.Location = new System.Drawing.Point(242, 9);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(93, 46);
            this.labelNick.TabIndex = 1;
            this.labelNick.Text = "Ник";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(119, 59);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(63, 23);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Имя ";
            this.labelUsername.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(192, 104);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(45, 17);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "Инфо";
            // 
            // Publish
            // 
            this.Publish.Location = new System.Drawing.Point(511, 367);
            this.Publish.Name = "Publish";
            this.Publish.Size = new System.Drawing.Size(140, 43);
            this.Publish.TabIndex = 4;
            this.Publish.Text = "Опубликовать";
            this.Publish.UseVisualStyleBackColor = true;
            this.Publish.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PreviewPhoto
            // 
            this.PreviewPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewPhoto.Location = new System.Drawing.Point(511, 218);
            this.PreviewPhoto.Name = "PreviewPhoto";
            this.PreviewPhoto.Size = new System.Drawing.Size(140, 89);
            this.PreviewPhoto.TabIndex = 6;
            this.PreviewPhoto.TabStop = false;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(790, 523);
            this.Controls.Add(this.PreviewPhoto);
            this.Controls.Add(this.Publish);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.OpenAddPost);
            this.Name = "UserPage";
            this.Text = "Страница пользователя";
            this.Load += new System.EventHandler(this.UserPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenAddPost;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button Publish;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox PreviewPhoto;
    }
}