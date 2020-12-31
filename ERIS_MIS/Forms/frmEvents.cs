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
    public partial class frmEvents : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        internal static frmEvents events;
        string _title = "ERIS MIS";
        private int i = 0;

        public frmEvents()
        {
            
            InitializeComponent();
            events = this;
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData1();
            label3.Text = dataGridView2.Rows.Count.ToString();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            dataGridView2.Hide();
            textBox1.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEventInfo f = new frmEventInfo();
            
            f.button1.Hide();
            f.ShowDialog();
        }

        public void LoadData()
        {

            string query = "SELECT id as'Event ID',event_name as 'Event Name', event_description as 'Event Description', event_status as 'Event Status' FROM table_events ";


            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["colEdit"].DisplayIndex = 5;
            dataGridView1.Columns["colDelete"].DisplayIndex = 5;


        }

        public void LoadData1()
        {

            string query = "SELECT id as'Event ID',event_name as 'Event Name', event_description as 'Event Description', event_status as 'Event Status' FROM table_events where event_status = 0 ";


            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           


        }

        private void editButton()
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DataTable dt = new DataTable();
            MySqlDataReader myReader = null;
            frmEventInfo f = new frmEventInfo();

            f.button2.Hide();
            f.button1.Location = new System.Drawing.Point(434, 500);



            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM table_events WHERE id='" + textBox1.Text + "'", connection);
            myReader = myCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
            {
                f.eventIDTextbox.Text = textBox1.Text;
                f.eventNameTextBox.Text = (myReader["event_name"].ToString());
                f.eventDescriptionTextBox.Text = (myReader["event_description"].ToString());
                //f.eventDescriptionTextBox = (myReader["event_description"].ToString());


            }
            myReader.Close();
            connection.Close();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                editButton();
                
            }
            else if (colName == "colDelete")
            {
                
                try
                {

                    if (MessageBox.Show("Open Event? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            int i = 0;
                            if (connection.State != ConnectionState.Open)
                            {
                                connection.Open();
                            }
                            command = new MySqlCommand("UPDATE table_events  SET event_status=@event_status WHERE id=@id  ", connection);
                            command.Parameters.AddWithValue("@event_status", row.Cells["Event Status"].Value);
                            command.Parameters.AddWithValue("@id", row.Cells["Event ID"].Value);

                            command.ExecuteNonQuery();

                            connection.Close();

                        }
                        MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }

                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadData1();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < dataGridView2.Rows.Count)
            {
                label1.Text = i.ToString();
                label2.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                i++;
                if (i == dataGridView2.Rows.Count)
                {
                    i = 0;

                }

            }

            else
            {
                label1.Text = "No";
                label2.Text = "No";
            }
        }

        public void DisplayEvent ()
        {
            if (i <= dataGridView2.Rows.Count)
            {
                frmHome f = new frmHome();

                f.label6.Text = i.ToString();
                f.eventTitle.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                i++;
                if (i == dataGridView2.Rows.Count)
                {
                    i = 0;

                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
