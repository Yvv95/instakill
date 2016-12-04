namespace instakill.WinForms
{
    partial class Start
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
            this.signIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.signIntext = new System.Windows.Forms.TextBox();
            this.signUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signIn
            // 
            this.signIn.Font = new System.Drawing.Font("Script MT Bold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signIn.Location = new System.Drawing.Point(275, 220);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(137, 58);
            this.signIn.TabIndex = 0;
            this.signIn.Text = "Sign in";
            this.signIn.UseVisualStyleBackColor = true;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "User id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // signIntext
            // 
            this.signIntext.Location = new System.Drawing.Point(275, 192);
            this.signIntext.Name = "signIntext";
            this.signIntext.Size = new System.Drawing.Size(137, 22);
            this.signIntext.TabIndex = 2;
            // 
            // signUp
            // 
            this.signUp.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUp.Location = new System.Drawing.Point(677, 12);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(104, 53);
            this.signUp.TabIndex = 3;
            this.signUp.Text = "Sign up";
            this.signUp.UseVisualStyleBackColor = true;
            this.signUp.Click += new System.EventHandler(this.signUpbutton_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(787, 413);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.signIntext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signIn);
            this.Name = "Start";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox signIntext;
        private System.Windows.Forms.Button signUp;
    }
}

