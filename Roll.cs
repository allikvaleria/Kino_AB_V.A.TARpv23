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
    public partial class Roll : Form
    {
        private int imageIndex = 0;
        Label lbl_vali;
        Button btn_valiFilm, btn_ostaPilet;
        PictureBox pictureBox;
        public Roll()
        {
            this.Height = 450;
            this.Width = 800;
            this.Text = "Roll";
            this.BackgroundImage = Image.FromFile(@"..\..\fon.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Label - vali
            lbl_vali = new Label();
            lbl_vali.AutoSize = true;
            lbl_vali.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lbl_vali.Location = new Point(315, 20);
            lbl_vali.Size = new Size(195, 29);
            lbl_vali.Text = "Vali kinoseanss";
            
            // Button - valiFilm
            btn_valiFilm = new Button();
            btn_valiFilm.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btn_valiFilm.Location = new Point(105, 68);
            btn_valiFilm.Size = new Size(161, 42);
            btn_valiFilm.Text = "Vali film";
            btn_valiFilm.Click += Btn_valiFilm_Click;

            // Button - ostaPilet 
            btn_ostaPilet = new Button();
            btn_ostaPilet.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btn_ostaPilet.Location = new Point(105, 163);
            btn_ostaPilet.Size = new Size(161, 42);
            btn_ostaPilet.Text = "Osta pilet";
            
            // pictureBox
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(442, 68);
            pictureBox.Size = new Size(327, 359);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(pictureBox);
            Controls.Add(btn_ostaPilet);
            Controls.Add(btn_valiFilm);
            Controls.Add(lbl_vali);
        }

        private void Btn_valiFilm_Click(object sender, EventArgs e)
        {
            if (imageIndex == 0)
            {
                pictureBox.Image = Image.FromFile(@"..\..\film1.png");
                imageIndex = 1;
            }
            else if (imageIndex == 1)
            {
                pictureBox.Image = Image.FromFile(@"..\..\film2.png");
                imageIndex = 2;
            }
            else if (imageIndex == 2)
            {
                pictureBox.Image = Image.FromFile(@"..\..\film3.jpg");
                imageIndex = 3;
            }
            else
            {
                pictureBox.Image = Image.FromFile(@"..\..\film4.jpg");
                imageIndex = 0;  
            }
        }
    }
}
