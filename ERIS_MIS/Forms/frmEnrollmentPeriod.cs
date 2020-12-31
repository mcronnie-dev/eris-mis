using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERIS_MIS.Forms
{
    public partial class frmEnrollmentPeriod : Form
    {
        SystemGeneralData data = new SystemGeneralData();
        DateTime now = DateTime.Now;
        DateTime startEnrollmentDate;
        DateTime endEnrollmentDate;

        public frmEnrollmentPeriod()
        {
            InitializeComponent();
        }
        
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            startEnrollmentDate = dateTimePicker1.Value;
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker2.MaxDate = dateTimePicker1.Value.AddDays(15);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            endEnrollmentDate = dateTimePicker2.Value;
        }

        private void frmEnrollmentPeriod_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = dateTimePicker1.Value.AddDays(7);

            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.SetIsEnrollmentActive(now, startEnrollmentDate, endEnrollmentDate);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
