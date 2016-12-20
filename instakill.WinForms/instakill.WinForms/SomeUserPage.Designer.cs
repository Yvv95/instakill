namespace instakill.WinForms
{
    partial class SomeUserPage
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
            this.publs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subcrs = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.followers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelNick = new System.Windows.Forms.Label();
            this.PostsBox = new System.Windows.Forms.GroupBox();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.subcribe = new System.Windows.Forms.Button();
            this.PostsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // publs
            // 
            this.publs.AutoSize = true;
            this.publs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publs.Location = new System.Drawing.Point(169, 75);
            this.publs.Name = "publs";
            this.publs.Size = new System.Drawing.Size(17, 18);
            this.publs.TabIndex = 21;
            this.publs.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(169, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Публикаций";
            // 
            // subcrs
            // 
            this.subcrs.AutoSize = true;
            this.subcrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subcrs.Location = new System.Drawing.Point(429, 75);
            this.subcrs.Name = "subcrs";
            this.subcrs.Size = new System.Drawing.Size(17, 18);
            this.subcrs.TabIndex = 19;
            this.subcrs.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(429, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Подписок";
            // 
            // followers
            // 
            this.followers.AutoSize = true;
            this.followers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.followers.Location = new System.Drawing.Point(297, 75);
            this.followers.Name = "followers";
            this.followers.Size = new System.Drawing.Size(17, 18);
            this.followers.TabIndex = 17;
            this.followers.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(297, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Подписчиков";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(180, 170);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(32, 18);
            this.labelInfo.TabIndex = 15;
            this.labelInfo.Text = "Info";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(179, 137);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(69, 23);
            this.labelUsername.TabIndex = 14;
            this.labelUsername.Text = "Name";
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Script MT Bold", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNick.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelNick.Location = new System.Drawing.Point(272, 9);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(95, 46);
            this.labelNick.TabIndex = 13;
            this.labelNick.Text = "Nick";
            // 
            // PostsBox
            // 
            this.PostsBox.Controls.Add(this.scrollPanel);
            this.PostsBox.Location = new System.Drawing.Point(39, 208);
            this.PostsBox.Name = "PostsBox";
            this.PostsBox.Size = new System.Drawing.Size(706, 333);
            this.PostsBox.TabIndex = 22;
            this.PostsBox.TabStop = false;
            this.PostsBox.Text = "Записи пользователя";
            this.PostsBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Location = new System.Drawing.Point(6, 21);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(679, 306);
            this.scrollPanel.TabIndex = 0;
            // 
            // subcribe
            // 
            this.subcribe.Location = new System.Drawing.Point(13, 31);
            this.subcribe.Name = "subcribe";
            this.subcribe.Size = new System.Drawing.Size(139, 62);
            this.subcribe.TabIndex = 23;
            this.subcribe.Text = "Подписаться?";
            this.subcribe.UseVisualStyleBackColor = true;
            this.subcribe.Click += new System.EventHandler(this.button1_Click);
            // 
            // SomeUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.subcribe);
            this.Controls.Add(this.PostsBox);
            this.Controls.Add(this.publs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subcrs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.followers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelNick);
            this.Name = "SomeUserPage";
            this.Text = "Страница пользователя";
            this.Load += new System.EventHandler(this.SomeUserPage_Load);
            this.PostsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label publs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label subcrs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label followers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.GroupBox PostsBox;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.Button subcribe;
    }
}