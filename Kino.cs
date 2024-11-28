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
    public partial class Kino : Form
    {
        Button btn, btn2;

        private void Kino_Load(object sender, EventArgs e)
        {

        }

        public Kino()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Tere tulemast kinno!";
            this.BackgroundImage = Image.FromFile(@"..\..\kino.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            btn= new Button();
            btn.Text = "Kava";
            btn.Font = new Font("Rockwell", 12);
            btn.Location = new Point(80, 90);
            btn.Size = new Size(100, 50);
            Controls.Add(btn);

            btn2 = new Button();
            btn2.Text = "Osta pilet";
            btn2.Font = new Font("Rockwell", 12);
            btn2.Location = new Point(80, 200);
            btn2.Size = new Size(100, 50);
            btn2.Click += Btn2_Click;
            Controls.Add(btn2);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Kasutaja kasutaja = new Kasutaja();
            kasutaja.Show();
        }
    }
}
