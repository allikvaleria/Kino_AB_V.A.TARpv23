namespace Kino_AB_V.A.TARpv23
{
    partial class Kasutaja
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
            this.lbl_nimi = new System.Windows.Forms.Label();
            this.lbl_parool = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_nimi = new System.Windows.Forms.TextBox();
            this.txt_parool = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_tere = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_noLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_nimi
            // 
            this.lbl_nimi.AutoSize = true;
            this.lbl_nimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbl_nimi.Location = new System.Drawing.Point(73, 124);
            this.lbl_nimi.Name = "lbl_nimi";
            this.lbl_nimi.Size = new System.Drawing.Size(98, 20);
            this.lbl_nimi.TabIndex = 0;
            this.lbl_nimi.Text = "Sisesta nimi:";
            // 
            // lbl_parool
            // 
            this.lbl_parool.AutoSize = true;
            this.lbl_parool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbl_parool.Location = new System.Drawing.Point(73, 274);
            this.lbl_parool.Name = "lbl_parool";
            this.lbl_parool.Size = new System.Drawing.Size(114, 20);
            this.lbl_parool.TabIndex = 1;
            this.lbl_parool.Text = "Sisesta parool:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbl_email.Location = new System.Drawing.Point(73, 199);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(107, 20);
            this.lbl_email.TabIndex = 2;
            this.lbl_email.Text = "Sisesta email:";
            // 
            // txt_nimi
            // 
            this.txt_nimi.Location = new System.Drawing.Point(218, 124);
            this.txt_nimi.Name = "txt_nimi";
            this.txt_nimi.Size = new System.Drawing.Size(122, 20);
            this.txt_nimi.TabIndex = 3;
            // 
            // txt_parool
            // 
            this.txt_parool.Location = new System.Drawing.Point(218, 274);
            this.txt_parool.Name = "txt_parool";
            this.txt_parool.Size = new System.Drawing.Size(122, 20);
            this.txt_parool.TabIndex = 4;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(218, 199);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(122, 20);
            this.txt_email.TabIndex = 5;
            // 
            // lbl_tere
            // 
            this.lbl_tere.AutoSize = true;
            this.lbl_tere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbl_tere.Location = new System.Drawing.Point(282, 47);
            this.lbl_tere.Name = "lbl_tere";
            this.lbl_tere.Size = new System.Drawing.Size(244, 29);
            this.lbl_tere.TabIndex = 6;
            this.lbl_tere.Text = "Teretulemast kinno!";
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btn_login.Location = new System.Drawing.Point(77, 364);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(192, 40);
            this.btn_login.TabIndex = 7;
            this.btn_login.Text = "Logi sisse";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // btn_noLogin
            // 
            this.btn_noLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btn_noLogin.Location = new System.Drawing.Point(519, 364);
            this.btn_noLogin.Name = "btn_noLogin";
            this.btn_noLogin.Size = new System.Drawing.Size(192, 40);
            this.btn_noLogin.TabIndex = 8;
            this.btn_noLogin.Text = "Jätka külalisega";
            this.btn_noLogin.UseVisualStyleBackColor = true;
            // 
            // Kasutaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_noLogin);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_tere);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_parool);
            this.Controls.Add(this.txt_nimi);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_parool);
            this.Controls.Add(this.lbl_nimi);
            this.Name = "Kasutaja";
            this.Text = "Kasutaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nimi;
        private System.Windows.Forms.Label lbl_parool;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_nimi;
        private System.Windows.Forms.TextBox txt_parool;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_tere;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_noLogin;
    }
}