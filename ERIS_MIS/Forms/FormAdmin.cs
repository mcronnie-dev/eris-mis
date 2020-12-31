using ERIS_MIS.UserControls;
using ERIS_MIS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERIS_MIS
{
    public partial class FormAdmin : Form
    {
        internal static FormAdmin admin;
        public FormAdmin()
        {
            InitializeComponent();
            admin = this;
           
            //DashboardPanel.AutoScroll = true;
            //DashboardPanel.VerticalScroll.Visible = false;
            //DashboardPanel.HorizontalScroll.Visible = false;
            
            linkLabel1.Text = UserInfo.teacherFullName;
            label4.Text = UserInfo.teacherNo;
            hideSubMenu();




        }

        private void userAccess()
        {
            

            if (UserInfo.accessID == 1 && UserInfo.positionID == 1)
            {
                //hide grading
                button5.Visible = false;
                
            }
            else if (UserInfo.accessID == 1 && UserInfo.positionID == 2)
            {
                button5.Visible = false;
                button26.Visible = false;
                button15.Visible = false;
                button27.Visible = false;
            }
            else if (UserInfo.accessID == 2 && UserInfo.positionID == 3)
            {
                button2.Visible = false;
                button6.Visible = false;
                button26.Visible = false;
                button15.Visible = false;
                button27.Visible = false;
            }
            else if (UserInfo.accessID == 0 && UserInfo.positionID == 0)
            {
            }

            else
            { // catch}

            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            frmHome f = new frmHome();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            sidePanel.AutoScroll = false;
            sidePanel.HorizontalScroll.Visible = false;
            sidePanel.HorizontalScroll.Enabled = false ;
            sidePanel.AutoScroll = true;
            userAccess();

            button20.Hide();
        }

        //Hide sub menu
        private void hideSubMenu ()
        {
            enrollmentSubmenu.Visible = false;
            studentSubmenu.Visible = false;
            facultySubmenu.Visible = false;
            settingSubmenu.Visible = false;
            archivesSubmenu.Visible = false;
            gradingSubmenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //Add to dashboardpanel
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Left;
            DashboardPanel.Controls.Clear();
            DashboardPanel.Controls.Add(c);
        }
        
        
        

       
        //Close Side Panel
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (sidePanel.Width == 90)
            {
                sidePanel.Visible = true;
                sidePanel.Width = 259;
                this.Width = 1300 ;
                bunifuTransitionOnShow.ShowSync(sidePanel);
                bunifuLogoTransition1.ShowSync(logo);
               

            }
            else
            {
                bunifuLogoTransition1.HideSync(logo);
                sidePanel.Width = 90;
                this.Width = 1300 - 90;
                sidePanel.Visible = false;
                bunifuTransitionOnHide.ShowSync(sidePanel);
               
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //Form2 fs = new Form2();
            //fs.TopLevel = false;
            //DashboardPanel.Controls.Add(fs);
            //fs.BringToFront();
            //fs.Show();
        }

        //Home Button
        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            frmHome f = new frmHome();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            panelLeft.Height = button8.Height;
            panelLeft.Top = button8.Top;

            sideButton(button8);
            Active(button8);


        }

        //EnrollmentControl Button
        private void button2_Click(object sender, EventArgs e)
        {
            frmEnrollmentStudentInfo f = new frmEnrollmentStudentInfo();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            //EnrollmentControl uce = new EnrollmentControl();
            //AddControlsToPanel(uce);

            showSubMenu(enrollmentSubmenu);
            panelLeft.Height = button2.Height;
            panelLeft.Top = button2.Top;


            sideButton(button2);
            Active(button11);

        }

        //FormStudent Button
        private void button3_Click(object sender, EventArgs e)
        {
            frmStudent f = new frmStudent();
            f.button2.Hide();
            f.button1.Hide();
            f.HorizontalScroll.Enabled = false;
            
            openStudents();
        }
        
        public void openStudents ()
        {
            
            newVar = 1;
            DashboardPanel.Controls.Clear();
           
            frmStudent f = new frmStudent();
            f.GetData(newVar);
            //f.label7.Text = button17clicked.ToString();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();


            showSubMenu(studentSubmenu);

            sideButton(button3);
            Active(button17);

            panelLeft.Height = button3.Height;
            panelLeft.Top = button3.Top;


        }

        //Form Faculty Button
        private void button4_Click(object sender, EventArgs e)
        {
            frmFaculty1 f = new frmFaculty1();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            showSubMenu(facultySubmenu);

            sideButton(button4);
            Active(button21);

            panelLeft.Height = button4.Height;
            panelLeft.Top = button4.Top;
        }

        //Form Grading Button
        private void button5_Click(object sender, EventArgs e)
        {
            
            frmGrading3 f = new frmGrading3();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            showSubMenu(gradingSubmenu);
            sideButton(button5);
            Active(button28);

            panelLeft.Height = button5.Height;
            panelLeft.Top = button5.Top;


        }

        //Scheduling Control Button

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Scheduling sc = new Scheduling();
            AddControlsToPanel(sc);

            sideButton(button6);

            panelLeft.Height = button6.Height;
            panelLeft.Top = button6.Top;


        }

        //Reports Button
        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            Reports ucr = new Reports();
            AddControlsToPanel(ucr);

            sideButton(button7);

            panelLeft.Height = button7.Height;
            panelLeft.Top = button7.Top;
        }


        //Transaction Button
        private void button16_Click(object sender, EventArgs e)
        {
           


        }

        //Form Archives Button
        private void button12_Click(object sender, EventArgs e)
        {
            

            frmArchive f = new frmArchive();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            showSubMenu(archivesSubmenu);

            sideButton(button12);
            Active(button31);
            

            panelLeft.Height = button12.Height;
            panelLeft.Top = button12.Top;
        }

        //Events Button
        private void button26_Click(object sender, EventArgs e)
        {
            
            openEvents();
            sideButton(button26);

            panelLeft.Height = button26.Height;
            panelLeft.Top = button26.Top;
        }
        public void openEvents ()
        {
            hideSubMenu();
            frmEvents f = new frmEvents();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();


        }

        //USer Management Button
        private void button15_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            UserManagement um = new UserManagement();
            AddControlsToPanel(um);

            sideButton(button15);

            panelLeft.Height = button15.Height;
            panelLeft.Top = button15.Top;
        }

        //Settings Button
        private void button27_Click(object sender, EventArgs e)
        {


            showSubMenu(settingSubmenu);

            sideButton(button27);
            Active(button25);

            frmSettings f = new frmSettings();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            panelLeft.Height = button27.Height;
            panelLeft.Top = button27.Top;
        }



        //Enrollment Sub Menu 
        //New Student
        private void button11_Click_1(object sender, EventArgs e)
        {
            Active(button11);

            //StudentInfo sc = new StudentInfo();
            //AddControlsToPanel(sc);

            newEnrollmentOpen();

            //EnrollmentControl uce = new EnrollmentControl();
            //AddControlsToPanel(uce);
        }

        public void newEnrollmentOpen()
        {
            frmEnrollmentStudentInfo f = new frmEnrollmentStudentInfo();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //Existing Student
        private void button10_Click_3(object sender, EventArgs e)
        {
            Active(button10);
            openEnrollment();


        }
        public void openEnrollment ()
        {
            frmEnrollment f = new frmEnrollment();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
            
        }

       
        public void openEnrollment1 ()
        {
            
            frmEnrollment f = new frmEnrollment();
            f.panel2.Show();
            f.panel2.Location = new System.Drawing.Point(40, 12);
            f.panel4.Location = new System.Drawing.Point(36, 8);
            f.dataGridView2.Size = new System.Drawing.Size(826, 184);
            f.dataGridView2.Location = new System.Drawing.Point(36, 82); 
            //f.button2.Location = new System.Drawing.Point(692, 460);
            f.panel1.Hide();
            
            f.dataGridView1.Hide();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //Settings
        private void button9_Click_1(object sender, EventArgs e)
        {
            Active(button9);

            frmEnrollmentSettings f = new frmEnrollmentSettings();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //Student Sub Menu
        //All Students
        public int newVar = 1;
        private void button17_Click(object sender, EventArgs e)
        {
            Active(button17);

            newVar = 1;

            frmStudent f = new frmStudent();
            f.button2.Hide();
            f.button1.Hide();
            f.GetData(newVar);
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

        }

        //Enrolleds Student
        private void button14_Click_1(object sender, EventArgs e)
        {
            newVar = 2;

            frmStudent f = new frmStudent();
            f.button2.Hide();
            f.button1.Hide();
            f.GetData(newVar);
            //f.label7.Text = button17clicked.ToString();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            Active(button14);
        }

        //Class List
        private void button13_Click_1(object sender, EventArgs e)
        {

            Active(button13);

            newVar = 3;

            frmStudent f = new frmStudent();
            f.button2.Show();
            f.button1.Show();
            f.GetData(newVar);

            f.label10.Hide();
            f.textBox1.Hide();
            f.label1.Hide();
            f.textBox2.Hide();
            f.label5.Hide();
            f.textBox3.Hide();
            f.button3.Hide();
            f.button4.Hide();
            
            f.label2.Location = new System.Drawing.Point(142, 39);
            f.comboBox1.Location = new System.Drawing.Point(232, 40);
            f.label3.Location = new System.Drawing.Point(414, 35);
            f.comboBox2.Location = new System.Drawing.Point(517, 33);
            f.groupBox1.Size = new System.Drawing.Size(1251, 110);
            f.button2.Location = new System.Drawing.Point(741, 34);
            f.button1.Location = new System.Drawing.Point(954, 35);
            //f.panel2.Location = new System.Drawing.Point(79, 120);
            f.panel2.Hide();




            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

        }

        //Faculty Sub menu
        //All Department
        private void button21_Click(object sender, EventArgs e)
        {
            Active(button21);

            frmFaculty1 f = new frmFaculty1();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //All Teacher
        private void button19_Click(object sender, EventArgs e)
        {
            Active(button19);

            frmFacultyAllDepartment f = new frmFacultyAllDepartment();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //Transaction Submenu
        //Added Info
        private void button20_Click(object sender, EventArgs e)
        {
          
        }

        //Edited Info
        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        //Deleted Info
        private void button22_Click(object sender, EventArgs e)
        {
           
        }

        //Settings Button
        //General Settings
        private void button25_Click(object sender, EventArgs e)
        {

            genSettingsOpen();

            Active(button25);
        }

        public void genSettingsOpen()
        {
            frmSettings f = new frmSettings();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        //Academic Year Calendar
        private void button24_Click(object sender, EventArgs e)
        {
            frmSettingsAcademicYear f = new frmSettingsAcademicYear();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            Active(button24);


        }

        //Archive SubMenu
        //Graduated Student
        private void button31_Click(object sender, EventArgs e)
        {
            Active(button31);
        }

        //Transaction Archive
        private void button30_Click(object sender, EventArgs e)
        {
            Active(button30);
        }




        //To higlight selected button
        private void sideButton(Button b)
        {
            foreach (Control ctr in sidePanel.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        //change color
                        b.BackColor = Color.FromArgb(13, 99, 188);
                    }

                    else
                    {
                        //default
                        ctr.BackColor = Color.FromArgb(11, 83, 157);
                    }
                }

            }
        }
        private void Active(Button b)
        {
            foreach (Control ctr in studentSubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
            foreach (Control ctr in enrollmentSubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
            foreach (Control ctr in facultySubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
           
            foreach (Control ctr in settingSubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
            foreach (Control ctr in archivesSubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
            foreach (Control ctr in gradingSubmenu.Controls)
            {
                if (ctr.GetType() == typeof(Button))
                {
                    if (ctr.Name == b.Name)
                    {
                        b.BackColor = Color.FromArgb(255, 204, 59);
                    }

                    else
                    {
                        ctr.BackColor = Color.FromArgb(12, 94, 176);
                    }
                }

            }
            //new


        }

        //Mouse Hove Chage color to Yellow
        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.White;
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            button15.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.ForeColor = Color.White;
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            button12.ForeColor = Color.FromArgb(255, 214, 98);
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.ForeColor = Color.White;
        }
        private void panel5_MouseLeave(object sender, EventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }



        private void button10_Click_1(object sender, EventArgs e)
        {

        }



        private void button12_Click_2(object sender, EventArgs e)
        {

        }



        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void triangle_MouseLeave(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }


        private void DashboardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {


        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }
        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {




        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {



        }
        private void logo_Click(object sender, EventArgs e)
        {

        }

        

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button10_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            
            
            

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Active(button16);
            facultyOpen();


        }
        public void facultyOpen ()
        {
            frmFacultyNew f = new frmFacultyNew();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }
        private void button18_Click_1(object sender, EventArgs e)
        {
            frmEnrollmentStudentInfo f = new frmEnrollmentStudentInfo();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            //frmEnrollment f = new frmEnrollment();
            //f.TopLevel = false;
            //DashboardPanel.Controls.Add(f);
            //f.BringToFront();
            //f.Show();
        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void logo_Click_1(object sender, EventArgs e)
        {

        }

        private void button20_Click_1(object sender, EventArgs e)
        {

            this.Dispose();
            LogInForm lf = new LogInForm();
            // lf.Show();
            lf.Activate();

            //frmUserManagement f = new frmUserManagement();
            //f.TopLevel = false;
            //DashboardPanel.Controls.Add(f);
            //f.BringToFront();
            //f.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            LogInForm lf = new LogInForm();
            // lf.Show();
            lf.Activate();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            Active(button22);

            frmFacultyAssignment f = new frmFacultyAssignment();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            frmGradingViewClass f = new frmGradingViewClass();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();

            Active(button23);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Active(button28);

            frmGrading3 f = new frmGrading3();
            f.TopLevel = false;
            DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }
    }
}
