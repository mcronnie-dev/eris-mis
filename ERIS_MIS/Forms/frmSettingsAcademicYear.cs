﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERIS_MIS.Config;



namespace ERIS_MIS.Forms
{
    public partial class frmSettingsAcademicYear : Form

    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        private string _title = "Activate Academic Year";
        
        //private string activeAcademicYear = "2020";
        //private string activeGradingPeriod = "1st";
        //public static string  activeSYID ="";

        SystemGeneralData data = new SystemGeneralData();



        public frmSettingsAcademicYear()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        //Fill the academic year combobox with data
        

        

        private void frmSettingsAcademicYear_Load(object sender, EventArgs e)
        {
            SystemGeneralData data = new SystemGeneralData();
            //academicYearComboBox.Text = data.GetActiveAcademicYear();  replaced by a label control
            LoadActiveData();
           
           
            

        }

        private void LoadActiveData() {

            label3.Text = data.GetActiveAcademicYear(); //new
            label1.Text = data.GetActiveGradingPeriod(); //new
            
            loadData();

        }
        

        private void loadData ()
        {
            string query = "SELECT CONCAT(start_year,' - ',end_year) as 'School Year', CONCAT(start_month,' - ',end_month) as 'Star & End Month', status as 'Status'  FROM table_sy";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void gradingPeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSettingsGradingDate f = new frmSettingsGradingDate();
            f.ShowDialog();
            LoadActiveData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (MessageBox.Show("Do you want to deactivate the current Academic Year and activate new one? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSettingsAddAY f = new frmSettingsAddAY();
                f.ShowDialog();
                LoadActiveData();

            }
            else
            {
                MessageBox.Show("Current acaemic year is not changed!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        
    }
}
