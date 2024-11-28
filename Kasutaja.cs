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
        Label lbl;
        private void Kasutaja_Load(object sender, EventArgs e)
        {

        }

        public Kasutaja()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Registreerimine";

            lbl= new Label();
            lbl.Text = "Sisesta nimi:";
            lbl.Font = new Font("Rockwell", 12);
            lbl.Location = new Point(80, 90);
            lbl.Size = new Size(100, 50);
            Controls.Add(lbl);
        }

        
    }
}
