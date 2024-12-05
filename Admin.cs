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
    public partial class Admin : Form
    {
        DataGridView dataGridView1;
        PictureBox pictureBox_admin;
        TextBox filmiNimi_txt, filmiImg_txt, filmiAasta_txt;
        Button kustuta_btn, lisa_btn, uuenda_btn;

        public Admin()
        {
            this.Height = 450;
            this.Width = 800;
            this.Text = "Admin";

            // dataGridView1
            dataGridView1 = new DataGridView();
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 208);
            dataGridView1.Size = new Size(471, 230);
             
            // pictureBox_admin
            pictureBox_admin = new PictureBox();
            pictureBox_admin.Location = new Point(527, 78);
            pictureBox_admin.Size = new Size(261, 360);
             
            // filmiNimi_txt
            filmiNimi_txt = new TextBox();
            filmiNimi_txt.Location = new Point(44, 33);
            filmiNimi_txt.Size = new Size(100, 20);
            
            // filmiImg_txt
            filmiImg_txt = new TextBox();
            filmiImg_txt.Location = new Point(44, 126);
            filmiImg_txt.Size = new Size(100, 20);

            // filmiAasta_txt
            filmiAasta_txt = new TextBox();
            filmiAasta_txt.Location = new Point(44, 78);
            filmiAasta_txt.Size = new Size(100, 20);
            
            // kustuta_btn
            kustuta_btn = new Button();
            kustuta_btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            kustuta_btn.Location = new Point(214, 33);
            kustuta_btn.Size = new Size(100, 20);
            kustuta_btn.Text = "Kustutamine";
            
            // lisa_btn
            lisa_btn = new Button();
            lisa_btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            lisa_btn.Location = new Point(214, 126);
            lisa_btn.Size = new Size(100, 20);
            lisa_btn.Text = "Lisamine";
            
            // uuenda_btn
            uuenda_btn = new Button();
            uuenda_btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            uuenda_btn.Location = new Point(214, 78);
            uuenda_btn.Size = new Size(100, 20);
            uuenda_btn.Text = "Uuendamine";
            
            // Add
            Controls.Add(uuenda_btn);
            Controls.Add(lisa_btn);
            Controls.Add(kustuta_btn);
            Controls.Add(filmiAasta_txt);
            Controls.Add(filmiImg_txt);
            Controls.Add(filmiNimi_txt);
            Controls.Add(pictureBox_admin);
            Controls.Add(dataGridView1);
        }
    }
}
