using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_AB_V.A.TARpv23
{
    public partial class KasutajaDB : Form
    {
        Label knimi_lbl, kemail, kparool_lbl;
        TextBox knimi_txt, kemail_txt, kparool_txt;
        Button lisa_kasutaja_btn, insert_btn, delete_btn, update_btn;
        DataGridView dataGridView;
        ComboBox comboBox1;
        DataTable kinosaal_table;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\ValeriaAllikTARpv23\Kino_AB_V.A.TARpv23\Database_RG.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        OpenFileDialog open;
        SaveFileDialog save;
        string extension;
        int ID = 0;
        PictureBox pictureBox;
        public KasutajaDB()
        {
            this.Height = 550;
            this.Width = 800;
            this.Text = "Kasutaja andmed";

            // knimi_lbl
            knimi_lbl = new Label();
            knimi_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            knimi_lbl.Location = new Point(24, 22);
            knimi_lbl.AutoSize = true;
            knimi_lbl.Text = "Kasutaja nimi";

            // kemail
            kemail = new Label();
            kemail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kemail.Location = new Point(24, 67);
            kemail.AutoSize = true;
            kemail.Text = "Kasutaja email";

            // saal_lbl
            kparool_lbl = new Label();
            kparool_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kparool_lbl.Location = new Point(24, 112);
            kparool_lbl.AutoSize = true;
            kparool_lbl.Text = "Kasutaja parool";

            // knimi_txt
            knimi_txt = new TextBox();
            knimi_txt.Location = new Point(190, 22);
            knimi_txt.Size = new Size(152, 20);

            // kemail_txt
            kemail_txt = new TextBox();
            kemail_txt.Location = new Point(190, 67);
            kemail_txt.Size = new Size(152, 20);

            // kparool_txt
            kparool_txt= new TextBox();
            kparool_txt.Location = new Point(190, 112);
            kparool_txt.Size = new Size(152, 20);


            // dataGridView
            dataGridView = new DataGridView();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(28, 228);
            dataGridView.Size = new Size(737, 210);

            // insert_btn
            insert_btn = new Button();
            insert_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            insert_btn.Location = new Point(28, 164);
            insert_btn.Size = new Size(136, 44);
            insert_btn.Text = "Lisa andmed";
            insert_btn.Click += Insert_btn_Click;

            // delete_btn
            delete_btn = new Button();
            delete_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            delete_btn.Location = new Point(180, 164);
            delete_btn.Size = new Size(136, 44);
            delete_btn.Text = "Kustuta";
            delete_btn.Click += Delete_btn_Click;

            // update_btn
            update_btn = new Button();
            update_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            update_btn.Location = new Point(333, 164);
            update_btn.Size = new Size(135, 44);
            update_btn.Text = "Uuenda";
            update_btn.Click += Update_btn_Click;
            
            NaitaAndmed();

            Controls.Add(comboBox1);
            Controls.Add(kparool_lbl);
            Controls.Add(update_btn);
            Controls.Add(delete_btn);
            Controls.Add(insert_btn);
            Controls.Add(dataGridView);
            Controls.Add(lisa_kasutaja_btn);
            Controls.Add(kemail_txt);
            Controls.Add(knimi_txt);
            Controls.Add(kemail);
            Controls.Add(knimi_lbl);
            Controls.Add(pictureBox);
            Controls.Add(kparool_txt);
        }

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Kasutaja", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            if (knimi_txt.Text.Trim() != string.Empty && kemail_txt.Text.Trim() != string.Empty && kparool_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand("INSERT INTO Kasutaja (Nimi, Email, Parool) VALUES (@nimi, @email, @parool)", conn);
                    cmd.Parameters.AddWithValue("@nimi", knimi_txt.Text);
                    cmd.Parameters.AddWithValue("@email", kemail_txt.Text);
                    cmd.Parameters.AddWithValue("@parool", kparool_txt.Text);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Kasutaja edukalt lisatud");
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Sisesta kõik andmed");
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && knimi_txt.Text.Trim() != string.Empty && kemail_txt.Text.Trim() != string.Empty && kparool_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    int userId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();

                    cmd = new SqlCommand("UPDATE Kasutaja SET Nimi=@nimi, Email=@email, Parool=@parool WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.Parameters.AddWithValue("@nimi", knimi_txt.Text);
                    cmd.Parameters.AddWithValue("@email", kemail_txt.Text);
                    cmd.Parameters.AddWithValue("@parool", kparool_txt.Text);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Andmed edukalt uuendatud");
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Valige kirje ja täitke kõik väljad");
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    int userId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();

                    cmd = new SqlCommand("DELETE FROM Kasutaja WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Kirje edukalt kustutatud");
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Valige kirje kustutamiseks");
            }
        }
    }
}
