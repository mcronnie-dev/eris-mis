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
    public partial class frmEventInfo : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        string _title = "ERIS MIS";

        public frmEventInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmEventInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Save Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("INSERT table_events (event_name, event_description)VALUES (@event_name, @event_description )", connection);
                    command.Parameters.AddWithValue("@event_name", eventNameTextBox.Text);
                    command.Parameters.AddWithValue("@event_description", eventDescriptionTextBox.Text);
                    MessageBox.Show("Record has been saved succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                    connection.Close();
                    frmEvents.events.LoadData();
                    this.Dispose();


                }

            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Update Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new MySqlCommand("UPDATE table_events SET event_name=@event_name, event_description=@event_description WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@event_name", eventNameTextBox.Text);
                    command.Parameters.AddWithValue("@event_description", eventDescriptionTextBox.Text);
                    command.Parameters.AddWithValue("@id", eventIDTextbox.Text);
                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                    
                    connection.Close();
                    
                    this.Dispose();


                }
                
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            frmEvents f = new frmEvents();
            f.LoadData();
        }
    }
}
