using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        int ID = 0;
        PictureBox pictureBox;


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
            lisa_poster_btn.Click += Lisa_poster_btn_Click;
            
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

            //
            pictureBox= new PictureBox();
            pictureBox.Location = new Point(190, 10);
            pictureBox.Size = new Size(327, 359);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            Kinosaalid();
            NaitaAndmed();
            
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
            Controls.Add(pictureBox);
        }

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

        private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            filimi_nimi_txt.Text = dataGridView.Rows[e.RowIndex].Cells["Filmi_nimetus"].Value.ToString();
            filmi_aasta_txt.Text = dataGridView.Rows[e.RowIndex].Cells["Filmi aasta"].Value.ToString();
            try
            {
                pictureBox.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Pildid"),
                    dataGridView.Rows[e.RowIndex].Cells["Pildid"].Value.ToString()));
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception)
            {
                pictureBox.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Pildid"), "cross1.jpg"));
            }
        }

        private void Lisa_poster_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\Pictures\";
            open.Multiselect = false;
            open.Filter = "Images Files(*.jpeg;*.png;*.bmp;*.jpg)|*.jpeg;*.png;*.bmp;*.jpg";
            FileInfo openfile = new FileInfo(@"C:\Users\opilane\Pictures\" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && filimi_nimi_txt.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\..\Pildid");
                extension = Path.GetExtension(open.FileName);
                save.FileName = "filimi_nimi_txt.Text" + extension;
                save.Filter = "Images" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && filimi_nimi_txt != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    pictureBox.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või ole Cancel vajutatud");
            }
        }

    
        private void Kinosaalid()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Id, Kinosaal_nimetus FROM Kinosaal", conn);
            adapter = new SqlDataAdapter(cmd);
            kinosaal_table = new DataTable();
            adapter.Fill(kinosaal_table);
            foreach (DataRow item in kinosaal_table.Rows)
            {
                comboBox1.Items.Add(item["Kinosaal_nimetus"]);
            }
            conn.Close();
        }
        private void Insert_btn_Click(object sender, EventArgs e)
        {
            if (filimi_nimi_txt.Text.Trim() != string.Empty && filmi_aasta_txt.Text.Trim() != string.Empty && comboBox1.SelectedIndex >= 0)
            {
                try
                {
                    conn.Open();

                    // Get the ID of the selected Kinosaal
                    cmd = new SqlCommand("SELECT Id FROM Kinosaal WHERE Kinosaal_nimetus=@kinosaal_nimetus", conn);
                    cmd.Parameters.AddWithValue("@kinosaal_nimetus", comboBox1.SelectedItem.ToString()); // Use SelectedItem, not SelectedValue
                    int kinosaalId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Save the poster image to the specified location
                    string posterFileName = filimi_nimi_txt.Text + extension;
                    string posterPath = Path.Combine(@"C:\Users\opilane\Pictures\", posterFileName); // Or your desired directory

                    // Copy the poster to the folder
                    File.Copy(open.FileName, posterPath, true); // true will overwrite the file if it already exists

                    // Insert new film data into the database
                    cmd = new SqlCommand("INSERT INTO Filmi (Filmi_nimetus, Aasta, Poster, Kinosaal_Id) VALUES (@filmi_nimetus, @aasta, @poster, @kinosaal_id)", conn);
                    cmd.Parameters.AddWithValue("@filmi_nimetus", filimi_nimi_txt.Text);
                    cmd.Parameters.AddWithValue("@aasta", filmi_aasta_txt.Text);
                    cmd.Parameters.AddWithValue("@poster", posterFileName);  // Store the poster file name, not the path
                    cmd.Parameters.AddWithValue("@kinosaal_id", kinosaalId);  // Use the Kinosaal ID

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    // Refresh data grid
                    NaitaAndmed();

                    MessageBox.Show("Film edukalt lisatud");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid");
            }
        }


        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (filimi_nimi_txt.Text.Trim() != string.Empty && filmi_aasta_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand("UPDATE Filmi SET Filmi_nimetus=@filmi_nimetus, Aasta=@aasta WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@filmi_nimetus", filimi_nimi_txt.Text);
                    cmd.Parameters.AddWithValue("@aasta", filmi_aasta_txt.Text);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    NaitaAndmed();

                    MessageBox.Show("Andmed edukalt uuendatud", "Uuendamine");

                    filimi_nimi_txt.Text = "";
                    filmi_aasta_txt.Text = "";

                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid");
            }
        }
        

        private void Kustuta_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    int deletedId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();

                    cmd = new SqlCommand("DELETE FROM Filmi WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", deletedId);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    NaitaAndmed();

                    MessageBox.Show("Kirje kustutatud");
                }
                catch (Exception)
                {
                    MessageBox.Show("Viga kustutamisel");
                }
            }
            else
            {
                MessageBox.Show("Valige kustutamiseks kirje");
            }
        }
    }
}
