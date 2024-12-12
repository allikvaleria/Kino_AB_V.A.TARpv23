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
    public partial class Admin : Form
    {
        Label Filmi_pealkiri_lbl, Filmi_aasta_lbl, saal_lbl;
        TextBox filimi_nimi_txt, filmi_aasta_txt;
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


        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Filmi", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }

        public Admin()
        {
            this.Height = 550;
            this.Width = 800;
            this.Text = "Admin";

            // Filmi_pealkiri_lbl
            Filmi_pealkiri_lbl = new Label();
            Filmi_pealkiri_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Filmi_pealkiri_lbl.Location = new Point(24, 22);
            Filmi_pealkiri_lbl.Size = new Size(108, 20);
            Filmi_pealkiri_lbl.Text = "Filmi pealkiri";
            
            // Filmi_aasta_lbl
            Filmi_aasta_lbl = new Label();
            Filmi_aasta_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Filmi_aasta_lbl.Location = new Point(24, 67);
            Filmi_aasta_lbl.Size = new Size(96, 20);
            Filmi_aasta_lbl.Text = "Filmi aasta";
            
            // filimi_nimi_txt
            filimi_nimi_txt = new TextBox();
            filimi_nimi_txt.Location = new Point(164, 22);
            filimi_nimi_txt.Size = new Size(152, 20);
            
            // filmi_aasta_txt
            filmi_aasta_txt = new TextBox();
            filmi_aasta_txt.Location = new Point(164, 67);
            filmi_aasta_txt.Size = new Size(152, 20);
             
            // lisa_poster_btn
            lisa_poster_btn = new Button();
            lisa_poster_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            lisa_poster_btn.Location = new Point(485, 164);
            lisa_poster_btn.Size = new Size(135, 44);
            lisa_poster_btn.Text = "Lisa poster";
            
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
            
            // update_btn
            update_btn = new Button();
            update_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            update_btn.Location = new Point(333, 164);
            update_btn.Size = new Size(135, 44);
            update_btn.Text = "Uuenda";
            
            // saal_lbl
            saal_lbl = new Label();
            saal_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            saal_lbl.Location = new Point(24, 112);
            saal_lbl.Size = new Size(77, 20);
            saal_lbl.Text = "Kinosaal";
            
            // comboBox1
            comboBox1 = new ComboBox();
            comboBox1.Location = new Point(164, 111);
            comboBox1.Size = new Size(152, 21);

            Kinosaalid();
            NaitaAndmed();
            //
            Controls.Add(comboBox1);
            Controls.Add(saal_lbl);
            Controls.Add(update_btn);
            Controls.Add(delete_btn);
            Controls.Add(insert_btn);
            Controls.Add(dataGridView);
            Controls.Add(lisa_poster_btn);
            Controls.Add(filmi_aasta_txt);
            Controls.Add(filimi_nimi_txt);
            Controls.Add(Filmi_aasta_lbl);
            Controls.Add(Filmi_pealkiri_lbl);
        }

       

        private void Kinosaalid()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Kinosaal_nimetus FROM Kinosaal WHERE Kinosaal_nimetus IN ('Kinosaal 1', 'Kinosaal 2')", conn);
            adapter = new SqlDataAdapter(cmd);
            kinosaal_table = new DataTable();
            adapter.Fill(kinosaal_table);

            comboBox1.Items.Clear();  // Clear any existing items in ComboBox

            // Add cinema halls from the database (if they exist)
            foreach (DataRow item in kinosaal_table.Rows)
            {
                comboBox1.Items.Add(item["Kinosaal_nimetus"]);
            }

            // If for some reason they aren't in the database, add them manually
            if (!comboBox1.Items.Contains("Kinosaal 1"))
            {
                comboBox1.Items.Add("Kinosaal 1");
            }
            if (!comboBox1.Items.Contains("Kinosaal 2"))
            {
                comboBox1.Items.Add("Kinosaal 2");
            }

            conn.Close();
        }
        private void Insert_btn_Click(object sender, EventArgs e)
        {
            if (filimi_nimi_txt.Text.Trim() != string.Empty && filmi_aasta_txt.Text.Trim() != string.Empty && comboBox1.SelectedItem != null)
            {
                try
                {
                    conn.Open();

                    // Get the selected cinema hall's ID
                    cmd = new SqlCommand("SELECT Id FROM Kinosaal WHERE Kinosaal_nimetus=@kinosaal", conn);
                    cmd.Parameters.AddWithValue("@kinosaal", comboBox1.SelectedItem.ToString());
                    int kinosaalId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Check if the Kinosaal Id was retrieved successfully
                    if (kinosaalId > 0)
                    {
                        cmd = new SqlCommand("INSERT INTO Filmi (Filmi_nimetus, Aasta, Poster, Kinosaal_Id) VALUES (@filmiNimetus, @aasta, @poster, @kinosaalId)", conn);
                        cmd.Parameters.AddWithValue("@filmiNimetus", filimi_nimi_txt.Text);
                        cmd.Parameters.AddWithValue("@aasta", filmi_aasta_txt.Text);
                        cmd.Parameters.AddWithValue("@poster", filimi_nimi_txt.Text + extension);  // If extension is set
                        cmd.Parameters.AddWithValue("@kinosaalId", kinosaalId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Film added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid cinema hall selected!");
                    }

                    conn.Close();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields and select a cinema hall.");
            }
        }

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Kustuta_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
