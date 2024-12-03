using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_AB_V.A.TARpv23
{
    public partial class Kasutaja : Form
    {
        public Kasutaja()
        {
            this.Height = 450;
            this.Width = 800;
            this.Text = "Registreerimine";
            this.BackgroundImage = Image.FromFile(@"..\..\cinema.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Label - nimi
            lbl_nimi = new Label();
            lbl_nimi.AutoSize = true;
            lbl_nimi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            lbl_nimi.Location = new Point(73, 124);
            lbl_nimi.Size = new Size(98, 20);
            lbl_nimi.Text = "Sisesta nimi:";

            //  Label - parool
            lbl_parool = new Label();
            lbl_parool.AutoSize = true;
            lbl_parool.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            lbl_parool.Location = new Point(73, 274);
            lbl_parool.Size = new Size(114, 20);
            lbl_parool.Text = "Sisesta parool:";

            //  Label - email
            lbl_email = new Label();
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            lbl_email.Location = new Point(73, 199);
            lbl_email.Size = new Size(107, 20);
            lbl_email.Text = "Sisesta email:";

            // Taxt box - nimi
            txt_nimi = new TextBox();
            txt_nimi.Location = new Point(218, 124);
            txt_nimi.Size = new Size(122, 20);

            // Taxt box - parool
            txt_parool = new TextBox();
            txt_parool.Location = new Point(218, 274);
            txt_parool.Size = new Size(122, 20);

            // Taxt box - email
            txt_email = new TextBox();
            txt_email.Location = new Point(218, 199);
            txt_email.Size = new Size(122, 20);

            // Label - tere
            lbl_tere = new Label();
            lbl_tere.AutoSize = true;
            lbl_tere.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lbl_tere.Location = new Point(282, 47);
            lbl_tere.Size = new Size(244, 29);
            lbl_tere.Text = "Teretulemast kinno!";
    
            // Button - login
            btn_login = new Button();
            btn_login.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic);
            btn_login.Location = new Point(77, 364);
            btn_login.Size = new Size(192, 40);
            btn_login.Text = "Logi sisse";
            btn_login.Click += Btn_login_Click;
            
            // Button - Login
            btn_noLogin = new Button();
            btn_noLogin.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic);
            btn_noLogin.Location = new Point(519, 364);
            btn_noLogin.Size = new Size(192, 40);
            btn_noLogin.Text = "Jätka külalisega";
            
            // Add
            Controls.Add(btn_noLogin);
            Controls.Add(btn_login);
            Controls.Add(lbl_tere);
            Controls.Add(txt_email);
            Controls.Add(txt_parool);
            Controls.Add(txt_nimi);
            Controls.Add(lbl_email);
            Controls.Add(lbl_parool);
            Controls.Add(lbl_nimi);
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            Roll roll = new Roll();
            roll.Show();
        }
    }
}
