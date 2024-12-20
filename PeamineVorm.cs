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
    public partial class PeamineVorm : Form
    {
        Button button1, button2, button3, button4;
        PictureBox pictureBox1;
        public PeamineVorm()
        {

            this.Height = 550;
            this.Width = 800;
            this.Text = "Peamine vorm";

            //Filmid
            button1 = new Button();
            button1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button1.Location = new Point(90, 32);
            button1.Size = new Size(162, 50);
            button1.Text = "Filmid";
            button1.Click += Button1_Click;

            //Piletid
            button2 = new Button();
            button2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold); 
            button2.Location = new Point(90, 343);
            button2.Size = new Size(162, 50);
            button2.Text = "Piletid";
            button2.Click += Button2_Click;

            //Kinosaalid
            button3 = new Button();
            button3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold); 
            button3.Location = new Point(90, 237);
            button3.Size = new Size(162, 50);
            button3.Text = "Kinosaalid";
            button3.Click += Button3_Click;

            //Kasutajad
            button4 = new Button();
            button4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold); 
            button4.Location = new Point(90, 132);
            button4.Size = new Size(162, 50);
            button4.Text = "Kasutajad";
            button4.Click += Button4_Click;
            
            // pictureBox1
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(430, 32);
            pictureBox1.Size = new Size(267, 361);
            
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            KinoPiletidDB kinoPiletidDB = new KinoPiletidDB();
            kinoPiletidDB.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            KasutajaDB kasutajaDB = new KasutajaDB();
            kasutajaDB.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Kinosaal kinosaal = new Kinosaal();
            kinosaal.Show();
        }

        private void Button1_Click(object sender, EventArgs e) //Filimid
        {
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
