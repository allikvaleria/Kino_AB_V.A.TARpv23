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
    public partial class Kinosaal : Form
    {
        Label kinosaal_lbl, kinosaal_kirjeldau_lbl, kinosaal_rida_lbl, kinosaal_koht_lbl, saal_lbl;
        TextBox kinosaal_txt, kinosaal_kirjeldau_txt, kinosaal_rida_txt, kinosaal_koht_txt;
        Button lisa_poster_btn, insert_btn, delete_btn, update_btn;
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

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Kinosaal", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }

        public Kinosaal()
        {
            this.Height = 550;
            this.Width = 800;
            this.Text = "Kinosaal";

            // kinosaal_lbl
            kinosaal_lbl = new Label();
            kinosaal_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kinosaal_lbl.Location = new Point(24, 22);
            kinosaal_lbl.AutoSize = true;
            kinosaal_lbl.Text = "Kinosaal nimetus";

            // kinosaal_kirjeldau_lbl
            kinosaal_kirjeldau_lbl = new Label();
            kinosaal_kirjeldau_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kinosaal_kirjeldau_lbl.Location = new Point(24, 67);
            kinosaal_kirjeldau_lbl.AutoSize = true;
            kinosaal_kirjeldau_lbl.Text = "Kinosaal kirjeldus";

            // kinosaal_rida_lbl
            kinosaal_rida_lbl = new Label();
            kinosaal_rida_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kinosaal_rida_lbl.Location = new Point(24, 112);
            kinosaal_rida_lbl.AutoSize = true;
            kinosaal_rida_lbl.Text = "Kinosaal rida";

            // kinosaal_koht_lbl
            kinosaal_koht_lbl = new Label();
            kinosaal_koht_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            kinosaal_koht_lbl.Location = new Point(24, 157);
            kinosaal_koht_lbl.Size = new Size(96, 20);
            kinosaal_koht_lbl.Text = "Kinosaal koht";

            // kinosaal_txt
            kinosaal_txt = new TextBox();
            kinosaal_txt.Location = new Point(180, 22);
            kinosaal_txt.Size = new Size(152, 20);

            // kinosaal_kirjeldau_txt
            kinosaal_kirjeldau_txt = new TextBox();
            kinosaal_kirjeldau_txt.Location = new Point(180, 67);
            kinosaal_kirjeldau_txt.Size = new Size(152, 20);

            // kinosaal_rida_txt
            kinosaal_rida_txt = new TextBox();
            kinosaal_rida_txt.Location = new Point(180, 112);
            kinosaal_rida_txt.Size = new Size(152, 20);

            // kinosaal_koht_txt
            kinosaal_koht_txt = new TextBox();
            kinosaal_koht_txt.Location = new Point(180, 157);
            kinosaal_koht_txt.Size = new Size(152, 20);

            // dataGridView
            dataGridView = new DataGridView();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(28, 245);
            dataGridView.Size = new Size(737, 210);

            // insert_btn
            insert_btn = new Button();
            insert_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            insert_btn.Location = new Point(28, 180);
            insert_btn.Size = new Size(136, 44);
            insert_btn.Text = "Lisa andmed";
            insert_btn.Click += Insert_btn_Click;

            // delete_btn
            delete_btn = new Button();
            delete_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            delete_btn.Location = new Point(180, 180);
            delete_btn.Size = new Size(136, 44);
            delete_btn.Text = "Kustuta";
            delete_btn.Click += Delete_btn_Click;

            // update_btn
            update_btn = new Button();
            update_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            update_btn.Location = new Point(333, 180);
            update_btn.Size = new Size(135, 44);
            update_btn.Text = "Uuenda";
            update_btn.Click += Update_btn_Click;

            //Kinosaalid();
            NaitaAndmed();

            Controls.Add(update_btn);
            Controls.Add(delete_btn);
            Controls.Add(insert_btn);

            Controls.Add(dataGridView);
            Controls.Add(kinosaal_kirjeldau_txt);
            Controls.Add(kinosaal_rida_txt);
            Controls.Add(kinosaal_koht_txt);
            Controls.Add(kinosaal_txt);
            Controls.Add(kinosaal_kirjeldau_lbl);
            Controls.Add(kinosaal_lbl); 
            Controls.Add(kinosaal_rida_lbl); 
            Controls.Add(kinosaal_koht_lbl); 
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && kinosaal_txt.Text.Trim() != string.Empty && kinosaal_kirjeldau_txt.Text.Trim() != string.Empty && kinosaal_rida_txt.Text.Trim() != string.Empty && kinosaal_koht_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    int kinosaalId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();
                    cmd = new SqlCommand("UPDATE Kinosaal SET Kinosaal_nimetus=@nimetus, Kinosaal_kirjeldus=@kirjeldus, Kinosaal_rida=@rida, Kinosaal_koht=@koht WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", kinosaalId);
                    cmd.Parameters.AddWithValue("@nimetus", kinosaal_txt.Text);
                    cmd.Parameters.AddWithValue("@kirjeldus", kinosaal_kirjeldau_txt.Text);
                    cmd.Parameters.AddWithValue("@rida", Convert.ToInt32(kinosaal_rida_txt.Text));
                    cmd.Parameters.AddWithValue("@koht", Convert.ToInt32(kinosaal_koht_txt.Text));

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
                    int kinosaalId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM Kinosaal WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", kinosaalId);

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

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            if (kinosaal_txt.Text.Trim() != string.Empty && kinosaal_kirjeldau_txt.Text.Trim() != string.Empty && kinosaal_rida_txt.Text.Trim() != string.Empty && kinosaal_koht_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand("INSERT INTO Kinosaal (Kinosaal_nimetus, Kinosaal_kirjeldus, Kinosaal_rida, Kinosaal_koht) " +
                                         "VALUES (@kinosaal_nimetus, @kinosaal_kirjeldus, @kinosaal_rida, @kinosaal_koht)", conn);

                    cmd.Parameters.AddWithValue("@kinosaal_nimetus", kinosaal_txt.Text);
                    cmd.Parameters.AddWithValue("@kinosaal_kirjeldus", kinosaal_kirjeldau_txt.Text);
                    cmd.Parameters.AddWithValue("@kinosaal_rida", kinosaal_rida_txt.Text);
                    cmd.Parameters.AddWithValue("@kinosaal_koht", kinosaal_koht_txt.Text);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    NaitaAndmed();

                    MessageBox.Show("Kinosaal edukalt lisatud");
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga");
                }
            }
            else
            {
                MessageBox.Show("Sisesta kõik andmed");
            }
        }


    }
}
