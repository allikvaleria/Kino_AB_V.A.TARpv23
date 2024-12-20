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
    public partial class KinoPiletidDB : Form
    {

        Label label, label2, label3, label4, label5;
        ComboBox comboBox1, comboBox2, comboBox3;
        DateTimePicker textBox1, textBox2;
        DataGridView dataGridView1;
        Button button1, button2, button3;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\ValeriaAllikTARpv23\Kino_AB_V.A.TARpv23\Database_RG.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable kinosaal_table, kasutaja_table, filmi_table;
        SqlDataAdapter adapter;
        OpenFileDialog open;
        SaveFileDialog save;
        string extension;

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Piletid", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public KinoPiletidDB()
        {
            this.Height = 550;
            this.Width = 850;
            this.Text = "Piletid andmed";

            // label1
            label = new Label();
            label.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label.Location = new Point(39, 23);
            label.Size = new Size(103, 20);
            label.Text = "Kasutaja_id";

            // label2
            label2 = new Label();
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.Location = new Point(39, 194);
            label2.Size = new Size(133, 20);
            label2.Text = "Seansi lõpuaeg";

            // label3
            label3 = new Label();
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.Location = new Point(39, 152);
            label3.Size = new Size(142, 20);
            label3.Text = "Seansi algusaeg";

            // label4
            label4 = new Label();
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.Location = new Point(39, 66);
            label4.Size = new Size(70, 20);
            label4.Text = "Filmi_id";

            // label5
            label5 = new Label();
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label5.Location = new Point(39, 109);
            label5.Size = new Size(101, 20);
            label5.Text = "Kinosaal_id";

            // comboBox1
            comboBox1 = new ComboBox();
            comboBox1.Location = new Point(222, 65);
            comboBox1.Size = new Size(121, 21);

            

            // comboBox2
            comboBox2 = new ComboBox();
            comboBox2.Location = new Point(222, 25);
            comboBox2.Size = new Size(121, 21);

            // comboBox3
            comboBox3 = new ComboBox();
            comboBox3.Location = new Point(221, 108);
            comboBox3.Size = new Size(121, 21);

            // DateTimePicker1
            textBox1 = new DateTimePicker();
            textBox1.Location = new Point(221, 154);
            textBox1.Size = new Size(122, 20);
            // 
            // DateTimePicker2
            textBox2 = new DateTimePicker();
            textBox2.Location = new Point(221, 196);
            textBox2.Size = new Size(122, 20);
            // 
            // dataGridView1
            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(43, 248);
            dataGridView1.Size = new Size(760, 239);
            // 
            // button1
            button1 = new Button();
            button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            button1.Location = new Point(383, 25);
            button1.Size = new Size(144, 53);
            button1.Text = "Lisa andmed";
            button1.Click += Button1_Click;
            // 
            // button2
            button2 = new Button();
            button2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            button2.Location = new Point(383, 94);
            button2.Size = new Size(144, 53);
            button2.Text = "Kustuta andmed";
            button2.Click += Button2_Click;
            // 
            // button3
            button3 = new Button();
            button3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            button3.Location = new Point(383, 163);
            button3.Size = new Size(144, 53);
            button3.Text = "Uuenda andmed";
            button3.Click += Button3_Click;

            Kinosaalid();
            Kasutaja();
            Filmi();
            // 
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label);
        }

        private void Kinosaalid()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Id, Kinosaal_nimetus FROM Kinosaal", conn);
            adapter = new SqlDataAdapter(cmd);
            kinosaal_table = new DataTable();
            adapter.Fill(kinosaal_table);

            // Привязка значений
            comboBox3.DisplayMember = "Kinosaal_nimetus"; // Отображаемое название кинозала
            comboBox3.ValueMember = "Id"; // Значение, которое будет использоваться в запросах (Id кинозала)
            comboBox3.DataSource = kinosaal_table;
            conn.Close();
        }

        private void Kasutaja()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Id, Nimi FROM Kasutaja", conn);
            adapter = new SqlDataAdapter(cmd);
            kasutaja_table = new DataTable();
            adapter.Fill(kasutaja_table);
            foreach (DataRow item in kasutaja_table.Rows)
            {
                comboBox2.Items.Add(item["Nimi"]);
            }
            conn.Close();
        }

        private void Filmi()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Id, Filmi_nimetus FROM Filmi", conn);
            adapter = new SqlDataAdapter(cmd);
            filmi_table = new DataTable();
            adapter.Fill(filmi_table);
            foreach (DataRow item in filmi_table.Rows)
            {
                comboBox1.Items.Add(item["Filmi_nimetus"]);
            }
            conn.Close();
        }

        private void Button3_Click(object sender, EventArgs e) //update
        {
            if (dataGridView1.SelectedRows.Count > 0 && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty)
            {
                try
                {
                    int piletId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();
                    // SQL command to update Piletid table
                    cmd = new SqlCommand("UPDATE Piletid SET Kasutaja_id=@Kasutaja_id, Filmi_id=@Filmi_id, Kinosaal_id=@Kinosaal_id WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", piletId);
                    cmd.Parameters.AddWithValue("@Kasutaja_id", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Filmi_id", comboBox2.SelectedValue);
                    cmd.Parameters.AddWithValue("@Kinosaal_id", comboBox3.SelectedValue);

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

        private void Button2_Click(object sender, EventArgs e) //delete
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int piletId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    conn.Open();
                    // SQL command to delete from Piletid table
                    cmd = new SqlCommand("DELETE FROM Piletid WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", piletId);

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

        private void Button1_Click(object sender, EventArgs e) // insert
        {
            // Check if all required fields are filled
            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 &&
                !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                try
                {
                    // Open database connection
                    conn.Open();

                    // Get selected values from the ComboBoxes
                    int kasutajaId = Convert.ToInt32(comboBox2.SelectedValue);  // Kasutaja_id
                    int filmiId = Convert.ToInt32(comboBox1.SelectedValue);    // Filmi_id
                    int kinosaalId = Convert.ToInt32(comboBox3.SelectedValue); // Kinosaal_id

                    // Get session start and end times from the DateTimePickers
                    DateTime seansiAlgus = textBox1.Value; // Seansi algusaeg
                    DateTime seansiLopp = textBox2.Value;  // Seansi lõpuaeg

                    // Insert data into the Piletid table
                    cmd = new SqlCommand("INSERT INTO Piletid (Kasutaja_id, Filmi_id, Kinosaal_id, Seansi_algusaeg, Seansi_lopuaeg) " +
                                         "VALUES (@Kasutaja_id, @Filmi_id, @Kinosaal_id, @Seansi_algusaeg, @Seansi_lopuaeg)", conn);
                    cmd.Parameters.AddWithValue("@Kasutaja_id", kasutajaId);
                    cmd.Parameters.AddWithValue("@Filmi_id", filmiId);
                    cmd.Parameters.AddWithValue("@Kinosaal_id", kinosaalId);
                    cmd.Parameters.AddWithValue("@Seansi_algusaeg", seansiAlgus);
                    cmd.Parameters.AddWithValue("@Seansi_lopuaeg", seansiLopp);

                    // Execute the insert command
                    cmd.ExecuteNonQuery();

                    // Close connection
                    conn.Close();

                    // Refresh data grid to show updated list
                    NaitaAndmed();

                    MessageBox.Show("Andmed edukalt lisatud!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Täida kõik väljad!");
            }
        }
    }
}
    
