using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MISLibrary;
using System.Diagnostics;
using ERIS_MIS.Config;


namespace ERIS_MIS.UserControls
{
    public partial class Scheduling : UserControl
    {

        //Needed variables:
        SchoolYear Sy { set; get; }
        GradeLevel GrLvlSelected { set; get; }
        ClassInf ClassSelected { set; get; }
        LevelSection SectionSelected { set; get; }



        SchedulingQueries data = new SchedulingQueries();

        List<Teacher> AdviserSelection = new List<Teacher>();

        SchedLabel currentlySelected = new SchedLabel();
        


        // LABELS
        List<TimeLabel> timeLabels = new List<TimeLabel>();
        List<SchedLabel> schedLabels = new List<SchedLabel>();
        List<SubjectLabel> subjectLabels = new List<SubjectLabel>();





        public Scheduling()
        {
            InitializeComponent();

            // Add grades to comboBox
            cbGradeLevel.Items.Clear();
            foreach (GradeLevel x in data.GradeLvls)
            {
                cbGradeLevel.Items.Add(x.Level);
            }

            
            cbGradeLevel.SelectedIndex = 0; //select grade 7


            // Add subjects to comboBox
            foreach (Subject x in data.Subjects)
            {
                cbSubjects.Items.Add(x.Name);
            }

            Sy = data.GetSy();
            SetupLabels();
            
        }




        private class SubjectLabel
        {
            public Label SubjNameLabel { set; get; }
            public Label FrequencyLabel { set; get; }
            public Label CountLabel { set; get; }

            public int Counter { set; get; }

            public SubjectLabel()
            {
                Counter = 0;
            }
        }


        private class TimeLabel
        {
            public Label Label { set; get; }
        }


        private class SchedLabel
        {
            public Label Label { set; get; }
            public DaySched Day { set; get; }
            public int TimeIndex { set; get; }
            public int Index { set; get; }
            public Time Time { set; get; }
            public SubjectAssignment Assign { set; get; }
            public bool Active { set; get; }


            public string Display
            {
                get
                {
                    return string.Format("DAY: {0} \nTIME: {1}", Day.Display, Time.Display);
                }
            }

            public SchedLabel()
            {
                Active = false; //para san to? 
            }


            public string CheckContent
            {
                get
                {
                    return string.Format("day: {0}\ntime: {1}\nassign: {2}\nactive: {3}",
                        ((Day != null) ? Day.Display : "null"), ((Time != null) ? ((Time.IsRecess == true) ? "Recess" : Time.Display) : "null"), ((Assign != null) ? Assign.Display : "null"), Active);
                }
            }
        }





        private void SetupLabels()
        {
            timeLabels.Clear();
            timeLabels.Add(new TimeLabel { Label = labelT1 });
            timeLabels.Add(new TimeLabel { Label = labelT2 });
            timeLabels.Add(new TimeLabel { Label = labelT3 });
            timeLabels.Add(new TimeLabel { Label = labelT4 });
            timeLabels.Add(new TimeLabel { Label = labelT5 });
            timeLabels.Add(new TimeLabel { Label = labelT6 });
            timeLabels.Add(new TimeLabel { Label = labelT7 });

            subjectLabels.Clear();
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel1, CountLabel = subjCountLabel1, FrequencyLabel = maxFreqLabel1 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel2, CountLabel = subjCountLabel2, FrequencyLabel = maxFreqLabel2 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel3, CountLabel = subjCountLabel3, FrequencyLabel = maxFreqLabel3 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel4, CountLabel = subjCountLabel4, FrequencyLabel = maxFreqLabel4 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel5, CountLabel = subjCountLabel5, FrequencyLabel = maxFreqLabel5 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel6, CountLabel = subjCountLabel6, FrequencyLabel = maxFreqLabel6 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel7, CountLabel = subjCountLabel7, FrequencyLabel = maxFreqLabel7 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel8, CountLabel = subjCountLabel8, FrequencyLabel = maxFreqLabel8 });
            subjectLabels.Add(new SubjectLabel { SubjNameLabel = subjLabel9, CountLabel = subjCountLabel9, FrequencyLabel = maxFreqLabel9 });

            schedLabels.Clear();
            schedLabels.Add(new SchedLabel { Index = 0, Label = labelA1, Day = data.Days[0], TimeIndex = 0 });
            schedLabels.Add(new SchedLabel { Index = 1, Label = labelA2, Day = data.Days[0], TimeIndex = 1 });
            schedLabels.Add(new SchedLabel { Index = 2, Label = labelA3, Day = data.Days[0], TimeIndex = 2 });
            schedLabels.Add(new SchedLabel { Index = 3, Label = labelA4, Day = data.Days[0], TimeIndex = 3 });
            schedLabels.Add(new SchedLabel { Index = 4, Label = labelA5, Day = data.Days[0], TimeIndex = 4 });
            schedLabels.Add(new SchedLabel { Index = 5, Label = labelA6, Day = data.Days[0], TimeIndex = 5 });
            schedLabels.Add(new SchedLabel { Index = 6, Label = labelA7, Day = data.Days[0], TimeIndex = 6 });
            schedLabels.Add(new SchedLabel { Index = 7, Label = labelB1, Day = data.Days[1], TimeIndex = 0 });
            schedLabels.Add(new SchedLabel { Index = 8, Label = labelB2, Day = data.Days[1], TimeIndex = 1 });
            schedLabels.Add(new SchedLabel { Index = 9, Label = labelB3, Day = data.Days[1], TimeIndex = 2 });
            schedLabels.Add(new SchedLabel { Index = 10, Label = labelB4, Day = data.Days[1], TimeIndex = 3 });
            schedLabels.Add(new SchedLabel { Index = 11, Label = labelB5, Day = data.Days[1], TimeIndex = 4 });
            schedLabels.Add(new SchedLabel { Index = 12, Label = labelB6, Day = data.Days[1], TimeIndex = 5 });
            schedLabels.Add(new SchedLabel { Index = 13, Label = labelB7, Day = data.Days[1], TimeIndex = 6 });
            schedLabels.Add(new SchedLabel { Index = 14, Label = labelC1, Day = data.Days[2], TimeIndex = 0 });
            schedLabels.Add(new SchedLabel { Index = 15, Label = labelC2, Day = data.Days[2], TimeIndex = 1 });
            schedLabels.Add(new SchedLabel { Index = 16, Label = labelC3, Day = data.Days[2], TimeIndex = 2 });
            schedLabels.Add(new SchedLabel { Index = 17, Label = labelC4, Day = data.Days[2], TimeIndex = 3 });
            schedLabels.Add(new SchedLabel { Index = 18, Label = labelC5, Day = data.Days[2], TimeIndex = 4 });
            schedLabels.Add(new SchedLabel { Index = 19, Label = labelC6, Day = data.Days[2], TimeIndex = 5 });
            schedLabels.Add(new SchedLabel { Index = 20, Label = labelC7, Day = data.Days[2], TimeIndex = 6 });
            schedLabels.Add(new SchedLabel { Index = 21, Label = labelD1, Day = data.Days[3], TimeIndex = 0 });
            schedLabels.Add(new SchedLabel { Index = 22, Label = labelD2, Day = data.Days[3], TimeIndex = 1 });
            schedLabels.Add(new SchedLabel { Index = 23, Label = labelD3, Day = data.Days[3], TimeIndex = 2 });
            schedLabels.Add(new SchedLabel { Index = 24, Label = labelD4, Day = data.Days[3], TimeIndex = 3 });
            schedLabels.Add(new SchedLabel { Index = 25, Label = labelD5, Day = data.Days[3], TimeIndex = 4 });
            schedLabels.Add(new SchedLabel { Index = 26, Label = labelD6, Day = data.Days[3], TimeIndex = 5 });
            schedLabels.Add(new SchedLabel { Index = 27, Label = labelD7, Day = data.Days[3], TimeIndex = 6 });
            schedLabels.Add(new SchedLabel { Index = 28, Label = labelE1, Day = data.Days[4], TimeIndex = 0 });
            schedLabels.Add(new SchedLabel { Index = 29, Label = labelE2, Day = data.Days[4], TimeIndex = 1 });
            schedLabels.Add(new SchedLabel { Index = 30, Label = labelE3, Day = data.Days[4], TimeIndex = 2 });
            schedLabels.Add(new SchedLabel { Index = 31, Label = labelE4, Day = data.Days[4], TimeIndex = 3 });
            schedLabels.Add(new SchedLabel { Index = 32, Label = labelE5, Day = data.Days[4], TimeIndex = 4 });
            schedLabels.Add(new SchedLabel { Index = 33, Label = labelE6, Day = data.Days[4], TimeIndex = 5 });
            schedLabels.Add(new SchedLabel { Index = 34, Label = labelE7, Day = data.Days[4], TimeIndex = 6 });
        }



        //OK
        private void MirrorScheduleToLabels()
        {
            // SCHED ASSIGN IS MIRRORED TO THE SELECTED CLASS SCHEDULE.
            // SUBJ FREQUENCY IS ALSO COUNTED.
            // TEACHERS SELECTED ARE ALSO ADDED TO ADVISER'S COMBOBOX.

            int i = 0;
            AdviserSelection.Clear();

            List<SubjectAssignment> AdviserAssign = data.AllAssign.Where(x => x.Subject.Id == 1 && x.GradeLevel.Id == GrLvlSelected.Id).ToList(); //ok

            foreach (SchedLabel sched in schedLabels)
            {
                try
                {
                        sched.Assign = ClassSelected.Schedule[i].SubjectAssignment;

                    if (sched.Assign != null)
                    {
                        // Add 1 to subject frequency for each subject assigned in a schedule.
                        subjectLabels[sched.Assign.Subject.Id - 1].Counter++;

                        // Add to AdviserSelection if it is not in the list yet.
                        if (!AdviserSelection.Contains(sched.Assign.Teacher) && sched.Assign.Teacher != null)
                        {
                            bool ifAdviser = (AdviserAssign.Find(x => x.Teacher == sched.Assign.Teacher) != null ? true : false);
                            if (ifAdviser)
                                AdviserSelection.Add(sched.Assign.Teacher);
                        }
                    }
                    else
                    {
                        sched.Assign = new SubjectAssignment();
                    }
                }
                catch
                {
                    sched.Assign = new SubjectAssignment();
                }
                i++;
            }

            FillComboAdviser();
        }

        private void ResetAndFillAdviserSelection()
        {
            // RESET AND ADD TEACHERS SELECTED TO ADVISER'S COMBOBOX.

            AdviserSelection.Clear();

            List<SubjectAssignment> AdviserAssign = data.AllAssign.Where(x => x.Subject.Id == 1 && x.GradeLevel.Id == GrLvlSelected.Id).ToList(); //ok

            foreach (SchedLabel sched in schedLabels)
            {
                try
                {
                   if (sched.Assign != null)
                    {
                        //MessageBox.Show("ResetAndFill " + sched.Index.ToString() + " " + sched.Assign.Id);   //COMMENTED

                        if (!AdviserSelection.Contains(sched.Assign.Teacher) && sched.Assign.Teacher != null)
                        {
                            bool ifAdviser = (AdviserAssign.Find(x => x.Teacher == sched.Assign.Teacher) != null ? true : false);
                            if (ifAdviser)
                                AdviserSelection.Add(sched.Assign.Teacher);
                        }
                    }
                }
                catch
                {
                }
            }

            //MessageBox.Show(AdviserSelection.Count + " count"); // COMMENTED
            FillComboAdviser();

                    //if (AdviserSelection.Count > 0)
                    //{
                    //    //cbAdviser.Enabled = true;
                    //    cbAdviser.Items.Clear();
                    //    cbAdviser.Items.Add("Select Adviser");
                    //    foreach (Teacher tc in AdviserSelection)
                    //    {
                    //        MessageBox.Show(tc.Id + " " + tc.Display);
                    //        cbAdviser.Items.Add(tc.Display);
                    //    }

                    //    if (ClassSelected.Adviser != null)
                    //    {
                    //        cbAdviser.SelectedItem = ClassSelected.Adviser.Display;
                    //        AdviserLabel.Text = ClassSelected.Adviser.Display;
                    //    }
                    //    else
                    //    {
                    //        cbAdviser.SelectedIndex = 0;
                    //    }

                    //}
                    //else
                    //{
                    //    //cbAdviser.Enabled = false; // COMMENTED
                    //    cbAdviser.Items.Clear();
                    //}
        }

        private const string defaultText = "Select to add Subject and Teacher Schedule";
        private void SetTimeEnableAndColorToLabels()
        {
            // TIME AND SCHED UPDATED BY THE TIME SCHEDULES.
            // TIME AND SCHED BACKCOLOR = (TO YELLOW) WHEN ACTIVE, BUT ONLY SCHED IS ENABLED.
            // SCHED TEXT IS ALSO DISPLAYED.

            int i = 0; /*i as index*/
            bool TimeschedIsEmpty = data.GetClassSchedule(ClassSelected.Id, 1);

            foreach (TimeLabel time in timeLabels)
            {
                time.Label.Text = data.TimeList[i].Display;
                //time.Label.Enabled = false; 
                //time.Label.BackColor = SetColor(2);

                ChangeState(4, time.Label);

                foreach (SchedLabel sched in schedLabels.Where(y => y.TimeIndex == i))
                {
                    sched.Time = data.TimeList[i];

                    if (sched.Time.IsRecess == true)
                    {
                        //sched.Label.Text = "BREAK";
                        //sched.Label.Enabled = false;
                        //sched.Label.BackColor = SetColor(3); /*Because sched labels of recess is set to Red.*/

                        ChangeState(3, sched.Label);
                    }

                    else
                    {
                        if (TimeschedIsEmpty == false)
                        {
                            if (sched.Assign.Teacher != null && sched.Assign.Subject != null)
                            {
                                sched.Label.Text = sched.Assign.DisplayTeacherAndSubject;
                                //sched.Label.Enabled = true;
                                //sched.Label.BackColor = SetColor(2);

                                ChangeState(2, sched.Label);

                            }
                            else if (sched.Assign.Teacher == null && sched.Assign.Subject != null)
                            {
                                sched.Label.Text = sched.Assign.DisplaySubject;
                                //sched.Label.Enabled = true;
                                //sched.Label.BackColor = SetColor(2);

                                ChangeState(2, sched.Label);
                            }
                            else if (sched.Assign.Teacher == null && sched.Assign.Subject == null)
                            {
                                //sched.Label.Text = defaultText;
                                //sched.Label.Enabled = true;
                                //sched.Label.BackColor = SetColor(1);

                                ChangeState(1, sched.Label);
                            }
                        }
                        else
                        {
                            //sched.Label.Text = defaultText;
                            //sched.Label.Enabled = true;
                            //sched.Label.BackColor = SetColor(1);

                            ChangeState(1, sched.Label);
                        }
                    }
                }

                i++;
            }

        }


        private Color SetColor(int colorCode)
        {
            if (colorCode == 2) //ACTIVE
            {
                return Color.FromArgb(255, 214, 98);
            }
            else if (colorCode == 3) //BREAK OR RECESS
            {
                return Color.OrangeRed;
            }
            else //DEFAULT
            {
                return Color.Gainsboro;
            }
        }


        private void ChangeState (int state, Label label)
        {
            if (state == 2) //ACTIVE
            {
                Label schedLabel = label;

                schedLabel.Enabled = true;
                schedLabel.BackColor = Color.FromArgb(255, 214, 98);
            }
            else if (state == 3) //BREAK OR RECESS
            {
                Label schedLabel = label;

                schedLabel.Text = "BREAK";
                schedLabel.Enabled = false;
                schedLabel.BackColor = Color.OrangeRed;
            }
            else if (state == 4) //TIME LABELS
            {
                Label timeLabel = label;

                timeLabel.Enabled = false;
                timeLabel.BackColor = Color.FromArgb(255, 214, 98);
            }
            else //DEFAULT
            {
                Label schedLabel = label;

                schedLabel.Text = defaultText;
                schedLabel.Enabled = true;
                schedLabel.BackColor = Color.Gainsboro;
            }
        }


        private void scheduleLabels_Click(object sender, EventArgs e)
        {
            panelSubjectTeacher.Show();

            SchedLabel selectedSchedLabel = schedLabels.Find(y => y.Label == (Label)sender);
            currentlySelected = selectedSchedLabel;

            label4.Text = selectedSchedLabel.Display;
        }


        private void ShowSubjDetails()
        {
            //selectedClass.Subjects
            int i = 0;
            foreach (SubjectLabel x in subjectLabels)
            {
                x.SubjNameLabel.Text = data.Subjects[i].Name;
                x.CountLabel.Text = x.Counter.ToString();
                x.FrequencyLabel.Text = data.Subjects[i].Frequency.ToString();
                i++;
            }

        }


        private void cbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = cbSection;

            cb.Items.Clear();
            cb.Items.Add("Select Section");
            cb.SelectedIndex = 0;

            //set selected grade level
            GrLvlSelected = data.GradeLvls.Find(y => y.Level.Equals(cbGradeLevel.Text));

            //get all section, all assignment, & timelist under selected grade level.
            data.Sections = data.GetAllSection(GrLvlSelected.Id);
            data.AllAssign = data.GetAllAssign(GrLvlSelected.Id).Where(x => x.Subject != null).ToList();

            data.TimeList = data.GetTimeList(GrLvlSelected.Id);

            foreach (LevelSection x in data.Sections)
            {
                cb.Items.Add(x.Section);
            }
        }



        private void cbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            SectionSelected = data.Sections.Find(y => y.Section.Equals(cbSection.Text));
            
            if (cbSection.SelectedIndex == 0)
            {
                openClassScheduleButton.Enabled = false;
            }
            else
            {
                openClassScheduleButton.Enabled = true;
            }
        }








        private void InsertClassSchedule(int classId, int timeId, int assignId, int day)
        {
            string query = $"INSERT INTO table_timesched(class_id, time_id, assignment_id, day) VALUES('{classId}','{timeId}','{assignId}','{day}')";

            ExecuteQuery(query);
        }

        private void UpdateClassSchedule(int timeschedId, int assignId)
        {
            string query = $"UPDATE table_timesched SET assignment_id='{assignId}' WHERE timesched_id = '{timeschedId}';";

           // MessageBox.Show(query);
            ExecuteQuery(query);

        }

        private void InsertClass(int syId, int teacherId, int levelSectionId)
        {
            string query = $"INSERT INTO table_class(sy_id, teacher_id, level_section_id) VALUES('{syId}','{teacherId}','{levelSectionId}')";

            ExecuteQuery(query);
        }

        private void InsertEnrollmentSettings(int syId, int levelSectionId)
        {
            int max = 50;
            string query = $"INSERT INTO table_enrollment_settings(sy_id, max_students, level_section_id) VALUES('{syId}','{max}','{levelSectionId}')";

            ExecuteQuery(query);
        }

        private void UpdateClass(int classId, int teacherId)
        {
            string query = $"UPDATE table_class SET teacher_id='{teacherId}' WHERE class_id='{classId}'";

            ExecuteQuery(query);
        }


        //OK
        public void ExecuteQuery(string sql)
        {
            MySqlConnection con = new MySqlConnection(Config1.connectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 60;

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                //MessageBox.Show(rowsAffected == 0 ? "Query Not Executed" : "Query Executed " + rowsAffected + " rows.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }




        private void openClassScheduleButton_Click(object sender, EventArgs e)
        {
            //Reset all to ZERO (0) Frequency.
            foreach (SubjectLabel subj in subjectLabels)
            {
                subj.Counter = 0;
            }

            ClassSelected = null;
            bool ClassIsEmpty = data.GetClass(Sy.Id, SectionSelected.Id, 1); // (if false) GET from db; (if true) INSERT new class


            if (ClassIsEmpty == false)
            {
                ClassSelected = data.GetClass(Sy.Id, SectionSelected.Id);
                ClassSelected.Subjects = data.Subjects; //Get Subjects for Frequency count


                bool TimeschedIsEmpty = data.GetClassSchedule(ClassSelected.Id, 1);

                if (TimeschedIsEmpty == false)
                {
                    ClassSelected.Schedule = data.GetClassSchedule(ClassSelected.Id);

                    MirrorScheduleToLabels();
                }

                ShowSubjDetails();

                SetTimeEnableAndColorToLabels();

                //DisplayDefaultToLabels();

                
                //MessageBox.Show(TimeschedIsEmpty + "   " + ClassSelected.Schedule.Count + "");
                //MessageBox.Show("Class id is " + ClassSelected.Id);
            }

            else if (ClassIsEmpty == true)
            {

                DialogResult dialogResult = MessageBox.Show("The class selected does not exist. Create class?", SectionSelected.Display, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    InsertClass(Sy.Id, 0, SectionSelected.Id);
                    InsertEnrollmentSettings(Sy.Id, SectionSelected.Id);

                    ClassSelected = data.GetClass(Sy.Id, SectionSelected.Id);
                    ClassSelected.Subjects = data.Subjects; //Get Subjects for Frequency count

                    bool TimeschedIsEmpty = data.GetClassSchedule(ClassSelected.Id, 1);

                    if (TimeschedIsEmpty == false)
                    {
                        ClassSelected.Schedule = data.GetClassSchedule(ClassSelected.Id);

                        MirrorScheduleToLabels();
                    }

                    ShowSubjDetails();
                    
                    SetTimeEnableAndColorToLabels();

                    //DisplayDefaultToLabels();

                   
                    //MessageBox.Show(TimeschedIsEmpty + "   " + ClassSelected.Schedule.Count + "");
                    //MessageBox.Show("Class id is " + ClassSelected.Id);

                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    Reset();
                    cbSection.SelectedIndex = 0;

                }

            }

        }


        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubjects.Text == "Homeroom")
            {
                cbTeachers.Hide();
                cbAdviser.Show();
                ResetAndFillAdviserSelection();

                    //cbAdviser.Enabled = true;
                    //Subject selectedSubject = data.Subjects.Find(y => y.Display.Equals(cbSubjects.Text)); //get selected Subject
                    //GradeLevel selectedGrade = data.GradeLvls.Find(y => y.Level.Equals(cbGradeLevel.Text)); //get selected Grade

                    //////PREVIOUS CODE --- WORKS
                    //cbTeachers.Items.Clear();
                    //cbTeachers.Items.Add("Select Teacher");
                    //cbTeachers.SelectedIndex = 0;

                    //List<SubjectAssignment> dataAllAssign = (data.AllAssign.Where(y => y.GradeLevel.Equals(selectedGrade) && y.Subject != null)).Where(x => x.Subject.Equals(selectedSubject)).ToList();
                

                    //foreach (SchedLabel sched in schedLabels)
                    //{
                    //    // MessageBox.Show(x.Section);
                    //    try
                    //    {
                    //        if (sched.Assign != null)
                    //        {
                    //            MessageBox.Show(sched.Index.ToString()); //
                    //            if (sched.Assign.Subject != null)
                    //            {
                    //                if (sched.Assign.Subject.Id == 1)
                    //                {
                    //                    cbAdviser.Items.Add(sched.Assign.Teacher.Display);
                    //                }
                    //            }
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        //MessageBox.Show("cbSubjects_SelectedIndexChanged " + selectedSubject.Display);
                    //    }
                    //}

            }

            else if (cbSubjects.Text != null && cbSubjects.Text != "Select Subject")
            {
                cbAdviser.Hide();
                cbTeachers.Show();
                cbTeachers.Enabled = true;
                Subject selectedSubject = data.Subjects.Find(y => y.Display.Equals(cbSubjects.Text)); //get selected Subject
                GradeLevel selectedGrade = data.GradeLvls.Find(y => y.Level.Equals(cbGradeLevel.Text)); //get selected Grade

                ////PREVIOUS CODE --- WORKS
                cbTeachers.Items.Clear();
                cbTeachers.Items.Add("Select Teacher");
                cbTeachers.SelectedIndex = 0;

                List<SubjectAssignment> dataAllAssign = (data.AllAssign.Where(y => y.GradeLevel.Equals(selectedGrade) && y.Subject != null)).Where(x => x.Subject.Equals(selectedSubject)).ToList();

                foreach (SubjectAssignment x in dataAllAssign)
                {
                    // MessageBox.Show(x.Section);
                    try
                    {
                        cbTeachers.Items.Add(x.Teacher.Display);
                    }
                    catch
                    {
                        //MessageBox.Show("cbSubjects_SelectedIndexChanged " + selectedSubject.Display);
                    }
                }
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
           
                if (cbSubjects.Text != null && cbSubjects.Text != "Select Subject" && cbSubjects.Text == "Homeroom" && cbAdviser.Text != null && cbAdviser.Text != "Select Adviser" && cbAdviser.Text != "")
                {
                            Subject selectedSubject = ClassSelected.Subjects.Find(y => y.Display.Equals(cbSubjects.Text)); //get selected Subject
                            Teacher adviser = data.Teachers.Find(x => x.Display == cbAdviser.Text);
                            SubjectAssignment subjAssign = data.AllAssign.Find(x => x.Subject.Id == selectedSubject.Id && x.Teacher.Display == cbAdviser.Text && x.GradeLevel.Id == GrLvlSelected.Id); //ok

                            Subject prevSubject = new Subject();


                            //check kung mas mababa ang frequency ng subject sa selected
                            if (selectedSubject.Frequency > subjectLabels[selectedSubject.Id - 1].Counter)
                            {

                                SchedLabel n = schedLabels[currentlySelected.Index];
                                bool scheduleConflict = data.GetScheduleConflictChecker(ClassSelected.Id, adviser.Id, data.TimeList[n.TimeIndex].Id, n.Day.Id, Sy.Id); // conflict checker


                                //pag may conflict detected, eexit na
                                if (scheduleConflict == true)
                                {
                                    MessageBox.Show("Teacher schedule conflict!!!");
                                    scheduleConflict = false;

                                    panelSubjectTeacher.Hide();
                                    return;
                                }
                                else
                                {
                                    bool checker = false;


                                    if (schedLabels[currentlySelected.Index].Assign == null || schedLabels[currentlySelected.Index].Assign.Id == 0)
                                    {
                                        schedLabels[currentlySelected.Index].Assign = subjAssign;
                                        subjectLabels[selectedSubject.Id - 1].Counter++;

                                        checker = true;
                                    }
                                    else
                                    {

                                        //same ang subject at teacher --- NAULIT LANG
                                        if (schedLabels[currentlySelected.Index].Assign == subjAssign)
                                        {
                                            //Do nothing.
                                        }
                                        //same subj magkaibang teacher --- SUBJ ASSIGN lang papalitan.
                                        else if (schedLabels[currentlySelected.Index].Assign.Subject == selectedSubject && schedLabels[currentlySelected.Index].Assign.Teacher != adviser)
                                        {
                                            schedLabels[currentlySelected.Index].Assign = subjAssign;

                                            checker = true;
                                        }
                                        //magkaibang subj at teacher --- SUBJ ASSIGN at COUNT papalitan.
                                        else
                                        {
                                            prevSubject = schedLabels[currentlySelected.Index].Assign.Subject;
                                            schedLabels[currentlySelected.Index].Assign = subjAssign;

                                            subjectLabels[selectedSubject.Id - 1].Counter++;
                                            subjectLabels[prevSubject.Id - 1].Counter--;

                                            checker = true;
                                        }
                                    }

                                    if (checker)
                                    {
                                        AdviserLabel.Text = cbAdviser.Text;
                                        ClassSelected.Adviser = adviser;

                                    }

                                    //Display ko si subject at teacher sa label


                                    currentlySelected.Label.Text = schedLabels[currentlySelected.Index].Assign.DisplayTeacherAndSubject;
                                    schedLabels[currentlySelected.Index].Label.BackColor = SetColor(2);

                                    ShowSubjDetails();
                                }
                            }
                            else if (cbTeachers.Text != null && cbTeachers.Text != "Select Teacher")
                            {
                                MessageBox.Show("Subject Reached Max Frequency!");
                            }

                            ResetAndFillAdviserSelection();
                            panelSubjectTeacher.Hide();
                            return;
                }
                else if (cbSubjects.Text != null && cbSubjects.Text != "Select Subject" && cbSubjects.Text != "Homeroom" && cbTeachers.Text != null && cbTeachers.Text != "Select Teacher" && cbTeachers.Text != "")
                {
                        Subject selectedSubject = ClassSelected.Subjects.Find(y => y.Display.Equals(cbSubjects.Text)); //get selected Subject
                        Teacher selectedTeacher = data.Teachers.Find(y => y.Display.Equals(cbTeachers.Text)); //get selected Grade

                        // KAILANGAN LANG TO KAPAG MAY PREV SELECTION
                        Subject prevSubject = new Subject();

                        SubjectAssignment subjAssign = data.AllAssign.Find(y => y.Subject.Equals(selectedSubject) && y.Teacher.Equals(selectedTeacher)); //get selected Grade



                        //check kung mas mababa ang frequency ng subject sa selected
                        if (selectedSubject.Frequency > subjectLabels[selectedSubject.Id - 1].Counter)
                        {
                            SchedLabel n = schedLabels[currentlySelected.Index];
                            bool scheduleConflict = data.GetScheduleConflictChecker(ClassSelected.Id, selectedTeacher.Id, data.TimeList[n.TimeIndex].Id, n.Day.Id, Sy.Id);


                            //pag may conflict detected, eexit na
                            if (scheduleConflict == true)
                            {
                                MessageBox.Show("Teacher schedule conflict!!!");
                                scheduleConflict = false;

                                panelSubjectTeacher.Hide();
                                return;
                            }
                            else
                            {
                                //
                                // DITO CONDITION KAPAG MAY LAMAN NA, TAPOS PAPALITAN UNG SELECTION.
                                //

                                bool checker = false;

                                if (schedLabels[currentlySelected.Index].Assign != null && schedLabels[currentlySelected.Index].Assign.Id != 0)
                                {
                                    //same ang subject at teacher --- NAULIT LANG
                                    if (schedLabels[currentlySelected.Index].Assign == subjAssign)
                                    {
                                        //Do nothing.
                                    }
                                    //same subj magkaibang teacher --- SUBJ ASSIGN lang papalitan.
                                    else if (schedLabels[currentlySelected.Index].Assign.Subject == selectedSubject && schedLabels[currentlySelected.Index].Assign.Teacher != selectedTeacher)
                                    {
                                        schedLabels[currentlySelected.Index].Assign = subjAssign;

                                        checker = true;
                                    }
                                    //magkaibang subj at teacher --- SUBJ ASSIGN at COUNT papalitan.
                                    else
                                    {
                                        prevSubject = schedLabels[currentlySelected.Index].Assign.Subject;
                                        schedLabels[currentlySelected.Index].Assign = subjAssign;

                                        subjectLabels[selectedSubject.Id - 1].Counter++;
                                        subjectLabels[prevSubject.Id - 1].Counter--;

                                        checker = true;
                                        if (prevSubject.Id == 1)
                                        {
                                            AdviserLabel.Text = "";
                                            ClassSelected.Adviser = null;
                                        }
                                    }
                                }
                                else if (schedLabels[currentlySelected.Index].Assign == null || schedLabels[currentlySelected.Index].Assign.Id == 0)
                                {
                                    schedLabels[currentlySelected.Index].Assign = subjAssign;

                                    checker = true;

                                    // MessageBox.Show("Subject assign ng schedlabel: " + schedLabels[currentlySelected.Index].SubjectAssignment.Display);

                                    //FREQ COUNTER
                                    subjectLabels[selectedSubject.Id - 1].Counter++;
                                }

                                if (checker)
                                {
                                    ResetAndFillAdviserSelection();
                                }
                                else
                                {

                                }

                                //Display subject at teacher sa label
                                currentlySelected.Label.Text = subjAssign.DisplayTeacherAndSubject;
                                schedLabels[currentlySelected.Index].Label.BackColor = SetColor(2);


                                ShowSubjDetails();
                         }
                        }
                        else
                        {
                            MessageBox.Show("Subject Reached Max Frequency!");
                        }
            }
                else
                {

                    MessageBox.Show(" No selected subject or teacher");
                    panelSubjectTeacher.Hide();
                }
            panelSubjectTeacher.Hide();
        }



        private void FillComboAdviser()
        {
            if (AdviserSelection.Count > 0)
            {
                //cbAdviser.Enabled = true;
                cbAdviser.Items.Clear();
                cbAdviser.Items.Add("Select Adviser");
                foreach (Teacher tc in AdviserSelection)
                {
                   // MessageBox.Show(tc.Id + " " + tc.Display);
                    cbAdviser.Items.Add(tc.Display);
                }

                if (ClassSelected.Adviser != null)
                {
                    cbAdviser.SelectedItem = ClassSelected.Adviser.Display;
                    AdviserLabel.Text = ClassSelected.Adviser.Display;
                }
                else
                {
                    cbAdviser.SelectedIndex = 0;
                }

            }
            else
            {
                //cbAdviser.Enabled = false; // COMMENTED
                cbAdviser.Items.Clear();
            }
        }

        private int GetAdviserIdSelected()
        {
            if (cbAdviser.Text != null && cbAdviser.Text != "Select Adviser" && cbAdviser.Text != "")
            {
                Teacher teacher = data.Teachers.Find(x => x.Display.Equals(cbAdviser.Text));
                return teacher.Id;
            }
            else
            {
                return 0;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (currentlySelected.Label.Text != defaultText)
            {
                schedLabels[currentlySelected.Index].Label.Text = defaultText;
                cbSubjects.SelectedIndex = 0;
                cbTeachers.SelectedIndex = 0;
                panelSubjectTeacher.Hide();



                AdviserSelection.Remove(schedLabels[currentlySelected.Index].Assign.Teacher); // Remove from adviser selection.
                MessageBox.Show("Adviser remove " + schedLabels[currentlySelected.Index].Assign.Teacher.Display);
                ResetAndFillAdviserSelection();

                //bawasan freq;  delete subjectAssignment;  change color to gainsboro.
                subjectLabels[schedLabels[currentlySelected.Index].Assign.Subject.Id - 1].Counter--;
                schedLabels[currentlySelected.Index].Assign = new SubjectAssignment();
                schedLabels[currentlySelected.Index].Label.BackColor = SetColor(1);

                ShowSubjDetails();
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ClassSelected != null)
            {

                SaveSchedule();


                DialogResult dialogResult = MessageBox.Show("Exit?", SectionSelected.Display, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Reset();
                    cbSection.SelectedIndex = 0;
                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    ClassSelected = data.GetClass(Sy.Id, SectionSelected.Id);
                    ClassSelected.Subjects = data.Subjects; //Get Subjects for Frequency count
                    ClassSelected.Schedule = data.GetClassSchedule(ClassSelected.Id);
                    return;
                }
            }
        }

        private void SaveSchedule()
        {
                int advId = GetAdviserIdSelected();
                bool adviserConflict = data.GetAdviserConflictChecker(ClassSelected.Id, advId);
                bool TimeschedIsEmpty = data.GetClassSchedule(ClassSelected.Id, 1);

                //MessageBox.Show("adv id " + advId);
                if (advId != 0)
                {
                    if (adviserConflict == true)
                    {
                        MessageBox.Show("Adviser Conflict!");
                    }
                    else
                    {
                        UpdateClass(ClassSelected.Id, advId);
                    }
                }
                else
                {
                    UpdateClass(ClassSelected.Id, advId);
                }
                if (TimeschedIsEmpty == true)
                {
                    foreach (SchedLabel sched in schedLabels)
                    {
                        int classId = ClassSelected.Id;
                        int timeId = sched.Time.Id;

                        int assignId = 0;
                        try
                        {
                            if (sched.Assign != null)
                            {
                                assignId = sched.Assign.Id; // kapag wala pa selected == 0 ,, pag break time, 0 din. 
                            }
                            else
                            {
                                assignId = 0;
                            }
                        }
                        catch
                        {
                            assignId = 0;
                        }
                        int day = sched.Day.Id;

                        InsertClassSchedule(classId, timeId, assignId, day);
                        //MessageBox.Show("INSERT:  class " + classId + ", time " + timeId + ", assign " + assignId + ", day " + day);
                    }
                    MessageBox.Show("Class Schedule inserted successfully.");

                }
                /* KAPAG MAY EXISTING TIMESCHED RECORD */
                else if (TimeschedIsEmpty == false)
                {
                    int i = 0;
                    foreach (TimeSchedModified t in ClassSelected.Schedule)
                    {
                        if (i < schedLabels.Count())
                        {
                            SchedLabel s = schedLabels[i];

                            int saId = 0;       //AssignId of Class
                            int slabelId = 0;   //AssignId of Label -> MODIFIED VERSION. IF THERE'S ANY.
                            try
                            {
                                if (t.SubjectAssignment != null)
                                {
                                    saId = t.SubjectAssignment.Id;
                                }
                                else
                                {
                                    saId = 0;
                                }
                            }

                            catch
                            {
                                saId = 0;
                            }

                            try
                            {
                                if (s.Assign != null)
                                {
                                    slabelId = s.Assign.Id;
                                }
                                else
                                {
                                    slabelId = 0;
                                }
                            }
                            catch
                            {
                                slabelId = 0;
                            }

                            if (saId != slabelId)
                            {
                                int timeschedId = t.Id;
                                UpdateClassSchedule(timeschedId, slabelId);
                            }
                        }
                        i++;
                    }
                    MessageBox.Show("Class Schedule updated successfully.");
                }
            
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            if (SectionSelected != null)
            {
                DialogResult dialogResult = MessageBox.Show("Exit without saving?", (SectionSelected != null ? SectionSelected.Display : ""), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Reset();
                    cbSection.SelectedIndex = 0;
                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    SaveSchedule();

                    Reset();
                    cbSection.SelectedIndex = 0;
                    return;
                }
            }
        }

        private void Reset()
        {
            //syId
            //GrLvlSelected
            SectionSelected = null; //cbSection.SelectedIndex = 0; /*default value is "Select Section" */
            ClassSelected = null;


            //RESET TIMELABELS
            foreach (TimeLabel time in timeLabels)
            {
                time.Label.Text = "";
                time.Label.BackColor = SetColor(1);
            }

            //RESET SCHEDLABELS
            foreach (SchedLabel sched in schedLabels)
            {
                sched.Label.Text = "";
                sched.Label.Enabled = false;
                sched.Label.BackColor = SetColor(1);
                sched.Time = null;
                sched.Assign = null;
                /*sched.Index       is fixed*/
                /*sched.Label       is fixed*/
                /*sched.Day         is fixed*/
                /*sched.TimeIndex   is fixed*/
            }

            //RESET TO ZERO (0) FREQUENCY.
            foreach (SubjectLabel subj in subjectLabels)
            {
                subj.Counter = 0;
            }
            ShowSubjDetails();

            AdviserSelection.Clear();
            cbAdviser.Items.Clear();
            cbAdviser.Text = "";
            cbAdviser.Hide();
            AdviserLabel.Text = "";

        }

     
        private void button4_Click(object sender, EventArgs e)
        {

            foreach (SchedLabel sched in schedLabels)
            {
                sched.Label.Text = sched.CheckContent;
                sched.Label.Font = new Font("Arial Narrow", 8.2F, (FontStyle.Bold | FontStyle.Italic), GraphicsUnit.Point, ((byte)(0)));
            }
        }




        private void cbAdviser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int advId = GetAdviserIdSelected();

            if (advId != 0)
            {
                bool adviserConflict = data.GetAdviserConflictChecker(ClassSelected.Id, advId);

                if (adviserConflict != true)
                {
                    // 
                }
                else
                {
                    MessageBox.Show("Adviser Conflict!");
                    cbAdviser.SelectedIndex = 0;
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
