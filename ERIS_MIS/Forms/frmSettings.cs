using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmSettings : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        string _title = "ERIS MIS";

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            displayData();
            tabControl1.SelectedIndex = 0;
            label7.Hide();
            label8.Hide();
            label9.Hide();
            hideButtons();

        }

        private void hideButtons ()
        {
            schoolNameTextBox.ReadOnly = true;
            schoolCodeTextbox.ReadOnly = true;
            telNoTextbox.ReadOnly = true;
            addressTextBox.ReadOnly = true;
            principalTextbox.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            button1.Hide();
            button2.Hide();
            button3.Hide();

        }
        private void showButtons()
        {
            schoolNameTextBox.ReadOnly = false;
            schoolCodeTextbox.ReadOnly = false;
            telNoTextbox.ReadOnly = false;
            addressTextBox.ReadOnly = false;
            principalTextbox.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            button1.Show();
            button3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Save Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string name1;
                    string description;
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("INSERT table_settings (name, description)VALUES (@name, @description)", connection);
                    if (tabControl1.Controls[0] == tabControl1.SelectedTab)//your specific tabname
                    {
                        MessageBox.Show("Mission");
                        name1 = "Mission";
                        description = textBox6.Text.ToString();
                    }

                    else if (tabControl1.Controls[1] == tabControl1.SelectedTab)//your specific tabname
                    {
                        MessageBox.Show("Vision");
                        name1 = "Vision";
                        description = textBox7.Text.ToString();
                    }

                    else 
                    {
                        MessageBox.Show("Core Values");
                        name1 = "Core Values";
                        description = textBox8.Text.ToString();
                    }

                    command.Parameters.AddWithValue("@name", name1);
                    command.Parameters.AddWithValue("@description", description);
                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                    connection.Close();


                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateVal()
        {
            
            try
            {
                
                
                if (MessageBox.Show("Update Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description = textBox6.Text.ToString();
                    string id = label7.Text.ToString();
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                    MySqlCommand command1 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description1 = textBox7.Text.ToString();
                    string id1 = label8.Text.ToString();
                    command1.Parameters.AddWithValue("@description", description1);
                    command1.Parameters.AddWithValue("@id", id1);
                    command1.ExecuteNonQuery();

                    MySqlCommand command2 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description2 = textBox8.Text.ToString();
                    string id2 = label9.Text.ToString();
                    command2.Parameters.AddWithValue("@description", description2);
                    command2.Parameters.AddWithValue("@id", id2);
                    command2.ExecuteNonQuery();

                    MySqlCommand command3 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description3 = schoolNameTextBox.Text.ToString();
                    string id3 = label10.Text.ToString();
                    command3.Parameters.AddWithValue("@description", description3);
                    command3.Parameters.AddWithValue("@id", id3);
                    command3.ExecuteNonQuery();

                    MySqlCommand command4 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description4 = schoolCodeTextbox.Text.ToString();
                    string id4 = label11.Text.ToString();
                    command4.Parameters.AddWithValue("@description", description4);
                    command4.Parameters.AddWithValue("@id", id4);
                    command4.ExecuteNonQuery();

                    MySqlCommand command5 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description5 = telNoTextbox.Text.ToString();
                    string id5 = label12.Text.ToString();
                    command5.Parameters.AddWithValue("@description", description5);
                    command5.Parameters.AddWithValue("@id", id5);
                    command5.ExecuteNonQuery();

                    MySqlCommand command6 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description6 = addressTextBox.Text.ToString();
                    string id6 = label13.Text.ToString();
                    command6.Parameters.AddWithValue("@description", description6);
                    command6.Parameters.AddWithValue("@id", id6);
                    command6.ExecuteNonQuery();

                    MySqlCommand command7 = new MySqlCommand("UPDATE table_settings SET description=@description WHERE id=@id", connection);
                    string description7 = principalTextbox.Text.ToString();
                    string id7 = label14.Text.ToString();
                    command7.Parameters.AddWithValue("@description", description7);
                    command7.Parameters.AddWithValue("@id", id7);
                    command7.ExecuteNonQuery();




                    connection.Close();
                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormAdmin.admin.genSettingsOpen();

                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void displayData()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM table_settings", connection);
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            if (sdr["name"].ToString() == "Mission")
                            {
                                textBox6.Text = sdr["description"].ToString();
                                label7.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Vision")
                            {
                                textBox7.Text = sdr["description"].ToString();
                                label8.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Core Values")
                            {
                                textBox8.Text = sdr["description"].ToString();
                                label9.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "School Name")
                            {
                                schoolNameTextBox.Text = sdr["description"].ToString();
                                label10.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "School Code")
                            {
                                schoolCodeTextbox.Text = sdr["description"].ToString();
                                label11.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Tel No")
                            {
                                telNoTextbox.Text = sdr["description"].ToString();
                                label12.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Address")
                            {
                                addressTextBox.Text = sdr["description"].ToString();
                                label13.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Principal")
                            {
                                principalTextbox.Text = sdr["description"].ToString();
                                label14.Text = sdr["id"].ToString();
                            }

                        }

                           
                       
                        
                        
                    }
                    

                }
                connection.Close();
            }
            textBox6.ScrollBars = ScrollBars.Vertical;
            textBox6.TextAlign = HorizontalAlignment.Center;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateVal();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showButtons();
        }
    }
}
