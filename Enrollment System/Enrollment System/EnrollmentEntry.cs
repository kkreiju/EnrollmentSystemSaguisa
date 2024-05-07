﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class EnrollmentEntry : Form
    {

        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23220726\Desktop\FINAL\Saguisa.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\arjay\Documents\Github\EnrollmentSystemSaguisa\Saguisa.accdb";

        //Write
        OleDbConnection dbConnection;
        OleDbDataAdapter dbAdapter;
        OleDbCommandBuilder dbBuilder;
        DataSet dbDataSet;
        DataRow dbRow;

        //Read
        OleDbCommand dbCommand;
        OleDbDataReader dbDataReader;

        int dataGridIndex = -1;
        List<List<string>> dateArray = new List<List<string>>();
        List<List<double>> timeArray = new List<List<double>>();

        public EnrollmentEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ReadDBTableConnection("SELECT * FROM STUDENTFILE");

                bool found = false;
                string name = "";
                string course = "";
                string year = "";

                while (dbDataReader.Read())
                {
                    if (dbDataReader["STFSTUDID"].ToString().Trim().ToUpper() == IDNumberTextBox.Text.Trim().ToUpper())
                    {
                        string middlename = "";
                        found = true;
                        //if student's middle name is not applicable or student's middle name has space
                        if (dbDataReader["STFSTUDMNAME"].ToString().Equals(string.Empty))
                            middlename = "";
                        else if (dbDataReader["STFSTUDMNAME"].ToString().Contains(' '))
                            middlename = dbDataReader["STFSTUDMNAME"].ToString()[0] + dbDataReader["STFSTUDMNAME"].ToString().Substring(dbDataReader["STFSTUDMNAME"].ToString().IndexOf(' ') + 1, 1) + ".";
                        else
                            middlename = dbDataReader["STFSTUDMNAME"].ToString()[0] + ".";

                        name = dbDataReader["STFSTUDLNAME"].ToString() + ", " + dbDataReader["STFSTUDFNAME"].ToString() + " " + middlename;
                        course = dbDataReader["STFSTUDCOURSE"].ToString();
                        year = dbDataReader["STFSTUDYEAR"].ToString();
                    }

                    if (found)
                    {
                        NameLabel.Text = name;
                        CourseLabel.Text = course;
                        YearLabel.Text = year;
                    }
                        
                }
                if (!found)
                    MessageBox.Show("Not Found");
            }
        }

        private void WriteDBTableConnection(string AccessTable, string AdapterFill)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbAdapter = new OleDbDataAdapter(AccessTable, dbConnection);
            dbBuilder = new OleDbCommandBuilder(dbAdapter);
            dbDataSet = new DataSet();
            dbAdapter.Fill(dbDataSet, AdapterFill);

            dbRow = dbDataSet.Tables[AdapterFill].NewRow();
        }

        private void ReadDBTableConnection(string AccessTable)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = AccessTable;
            dbDataReader = dbCommand.ExecuteReader();
        }

        private void UpdateDBTableConnection(string AccessTable, string value, string ForeignAccessField, string PrimaryAccessField, string recordvalue)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.Connection = dbConnection;
            string query = "UPDATE " + AccessTable + " SET " + ForeignAccessField + " = '" + value + "' WHERE " + PrimaryAccessField + " = '" + recordvalue + "'";
            dbCommand.CommandText = query;
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void EDPCodeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ReadDBTableConnection("SELECT * FROM SUBJECTSCHEDULEFILE");

                bool found = false;

                while (dbDataReader.Read())
                {
                    if (dbDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextbox.Text.Trim().ToUpper())
                    {
                        found = true;

                        //verifier
                        dataGridIndex++;
                        if (ConflictVerifier(dbDataReader["SSFDAYS"].ToString(), TwentyFourHourFormat(TimeFormat(dbDataReader["SSFSTARTTIME"].ToString())), TwentyFourHourFormat(TimeFormat(dbDataReader["SSFENDTIME"].ToString()))))
                            //if the subject is not in conflict
                            DisplayToDataGrid();
                        else
                            MessageBox.Show("Conflict");

                        UnitsLabel.Text = CalculateTotalUnits().ToString();
                    }

                }
                if (!found)
                    MessageBox.Show("Not Found");
            }
        }

        private void FindUnits(string subjectcode)
        {
            ReadDBTableConnection("SELECT * FROM SUBJECTFILE");
            while (dbDataReader.Read())
            {
                if (dbDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == subjectcode.Trim().ToUpper())
                {
                    SubjectDataGridView.Rows[dataGridIndex].Cells[6].Value = dbDataReader["SFSUBJUNITS"].ToString();
                }

            }
        }

        private string TimeFormat(string fulldate)
        {
            string time = fulldate.Substring(fulldate.IndexOf(' ') + 1);
            int removeindex = time.IndexOf(' ');
            time = time.Substring(0, removeindex - 3) + time.Substring(removeindex);
            return time;
        }

        private int CalculateTotalUnits()
        {
            int units = 0;
            for(int i = 0; i <= dataGridIndex; i++)
            {
                units += Convert.ToInt16(SubjectDataGridView.Rows[i].Cells[6].Value);
            }
            return units;
        }

        private double TwentyFourHourFormat(string time)
        {
            double twentyfourhrtime;
            twentyfourhrtime = Convert.ToDouble(time.Substring(0, time.IndexOf(':')));
            if (Convert.ToDouble(time.Substring(time.IndexOf(':') + 1, 2)) >= 30)
                twentyfourhrtime += .30;
            if (time.Substring(time.IndexOf(' ') + 1) == "PM" && twentyfourhrtime + 12 != 24)
                twentyfourhrtime += 12;
            return twentyfourhrtime;
        }

        private bool ConflictVerifier(string days, double starttime, double endtime)
        {
            if (days == "MON")
                dateArray.Add(new List<string>() { "Monday" });
            else if (days == "TUE")
                dateArray.Add(new List<string>() { "Tuesday" });
            else if (days == "WED")
                dateArray.Add(new List<string>() { "Wednesday" });
            else if (days == "THU")
                dateArray.Add(new List<string>() { "Thursday" });
            else if (days == "FRI")
                dateArray.Add(new List<string>() { "Friday" });
            else if (days == "SAT")
                dateArray.Add(new List<string>() { "Saturday" });
            else if (days == "MW")
                dateArray.Add(new List<string>() { "Monday", "Wednesday" });
            else if (days == "TTH")
                dateArray.Add(new List<string>() { "Tuesday", "Thursday" });
            else if (days == "FS")
                dateArray.Add(new List<string>() { "Friday", "Saturday" });
            else if (days == "MWF")
                dateArray.Add(new List<string>() { "Monday", "Wednesday", "Friday" });

            timeArray.Add(new List<double>() { starttime, endtime });

            /*
            MessageBox.Show("Row: " + dataGridIndex + "\nTime: " + starttime + "-" + endtime);
            string display = "Date Array:\n";
            for(int i = 0; i < dateArray.Count; i++)
            {
                for(int j = 0 ; j < dateArray[i].Count; j++)
                {
                    display += dateArray[i][j].ToString() + " ";
                }
                display += "\n";
            }
            display += "\nTime Array:\n";
            for (int i = 0; i < timeArray.Count; i++)
            {
                for (int j = 0; j < timeArray[i].Count; j++)
                {
                    display += timeArray[i][j].ToString() + " ";
                }
                display += "\n";
            }
            MessageBox.Show(display);
            */

            for (int i = 0; i < dataGridIndex; i++)
            {
                for(int j = 0; j < dateArray[i].Count; j++)
                {
                    for(int k = 0; k < dateArray[dataGridIndex].Count; k++)
                    {
                        if (dateArray[i][j] == dateArray[dataGridIndex][k])
                            if (timeArray[i][0] < starttime && starttime < timeArray[i][1] && timeArray[i][0] < endtime && endtime > timeArray[i][1] || timeArray[i][0] > starttime && starttime < timeArray[i][1] && timeArray[i][0] < endtime && endtime < timeArray[i][1] ||
                                timeArray[i][0] == starttime && endtime == timeArray[i][1] || timeArray[i][0] < starttime && endtime < timeArray[i][1] ||
                                timeArray[i][0] > starttime && endtime > timeArray[i][1] || timeArray[i][0] == starttime && endtime < timeArray[i][1] ||
                                timeArray[i][0] < starttime && endtime == timeArray[i][1])
                            {
                                //REVISED VERSION
                                //first instance: 10 < 10:30 && 12 > 11:30
                                //second instance: 10 > 7 && 10:30 < 11:30
                                //third instance: 10 == 10 && 11 == 11
                                //fourth instance: 10 < 10:30 && 11 < 11:30
                                //fifth instance: 10 > 7 && 12 > 11:30
                                //sixth instance: 10 == 10 && 10:30 < 11:30
                                //seventh instance: 10 < 10:30 && 11:30 == 11:30

                                //if (timeArray[i][0] < starttime && starttime < timeArray[i][1] && timeArray[i][0] < endtime && endtime > timeArray[i][1])
                                //    MessageBox.Show("First Instance");
                                //if (timeArray[i][0] > starttime && starttime < timeArray[i][1] && timeArray[i][0] < endtime && endtime < timeArray[i][1])
                                //    MessageBox.Show("Second Instance");
                                //if (timeArray[i][0] == starttime && endtime == timeArray[i][1])
                                //    MessageBox.Show("Third Instance");
                                //if (timeArray[i][0] < starttime && endtime < timeArray[i][1])
                                //    MessageBox.Show("Fourth Instance");
                                //if (timeArray[i][0] > starttime && endtime > timeArray[i][1])
                                //    MessageBox.Show("Fifth Instance");
                                //if (timeArray[i][0] == starttime && endtime < timeArray[i][1])
                                //    MessageBox.Show("Sixth Instance");
                                //if (timeArray[i][0] < starttime && endtime == timeArray[i][1])
                                //    MessageBox.Show("Seventh Instance");

                                //MessageBox.Show("Day of Conflict: " + dateArray[dataGridIndex][k] + "\nRow: " + i + "\n\nExisting Data\nStart Time: " + timeArray[i][0] + "\nEnd Time: " + timeArray[i][1] + "\nCurrent Data\nStart Time: " + starttime + "\nEnd Time: " + endtime);

                                dateArray.RemoveAt(dataGridIndex);
                                timeArray.RemoveAt(dataGridIndex);
                                dataGridIndex--;
                                return false;
                            }
                    }
                }
            }
            return true;
        }

        private void DisplayToDataGrid()
        {
            EDPCodeTextbox.Text = string.Empty;
            SubjectDataGridView.Rows.Add();
            SubjectDataGridView.Rows[dataGridIndex].Cells[0].Value = dbDataReader["SSFEDPCODE"].ToString();
            SubjectDataGridView.Rows[dataGridIndex].Cells[1].Value = dbDataReader["SSFSUBJCODE"].ToString();
            SubjectDataGridView.Rows[dataGridIndex].Cells[2].Value = TimeFormat(dbDataReader["SSFSTARTTIME"].ToString());
            SubjectDataGridView.Rows[dataGridIndex].Cells[3].Value = TimeFormat(dbDataReader["SSFENDTIME"].ToString());
            SubjectDataGridView.Rows[dataGridIndex].Cells[4].Value = dbDataReader["SSFDAYS"].ToString();
            SubjectDataGridView.Rows[dataGridIndex].Cells[5].Value = dbDataReader["SSFROOM"].ToString();

            //display units
            FindUnits(dbDataReader["SSFSUBJCODE"].ToString());
            UnitsLabel.Text = CalculateTotalUnits().ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            dataGridIndex = -1;
            SubjectDataGridView.Rows.Clear();
            dateArray.Clear();
            timeArray.Clear();
            UnitsLabel.Text = string.Empty;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool enrolled = false;
            if(IDNumberTextBox.Text != string.Empty)
            {
                //ENROLLMENT DETAIL
                for (int i = 0; i <= dataGridIndex; i++)
                {
                    //get subject schedule edp code classsize
                    ReadDBTableConnection("SELECT * FROM SUBJECTSCHEDULEFILE");
                    while (dbDataReader.Read())
                    {
                        if (dbDataReader["SSFEDPCODE"].ToString() == SubjectDataGridView.Rows[dataGridIndex].Cells[0].Value.ToString() && Convert.ToInt32(dbDataReader["SSFCLASSSIZE"]) < Convert.ToInt32(dbDataReader["SSFMAXSIZE"]))
                        {
                            //increment classsize
                            UpdateDBTableConnection("SubjectScheduleFile", (Convert.ToInt32(dbDataReader["SSFCLASSSIZE"]) + 1).ToString(), "SSFCLASSSIZE", "SSFEDPCODE", SubjectDataGridView.Rows[dataGridIndex].Cells[0].Value.ToString());

                            WriteDBTableConnection("SELECT * FROM ENROLLMENTDETAILFILE", "EnrollmentDetailFile");

                            dbRow["ENRDFSTUDID"] = IDNumberTextBox.Text;
                            dbRow["ENRDFSTUDSUBJCDE"] = SubjectDataGridView.Rows[dataGridIndex].Cells[1].Value.ToString();
                            dbRow["ENRDFSTUDEDPCODE"] = SubjectDataGridView.Rows[dataGridIndex].Cells[0].Value.ToString();

                            dbDataSet.Tables["EnrollmentDetailFile"].Rows.Add(dbRow);
                            dbAdapter.Update(dbDataSet, "EnrollmentDetailFile");

                            enrolled = true;
                            MessageBox.Show("Enrolled");
                        }
                        else if(dbDataReader["SSFEDPCODE"].ToString() == SubjectDataGridView.Rows[dataGridIndex].Cells[0].Value.ToString() && Convert.ToInt32(dbDataReader["SSFCLASSSIZE"]) == Convert.ToInt32(dbDataReader["SSFMAXSIZE"]))
                        {
                            MessageBox.Show("Class " + dbDataReader["SSFEDPCODE"].ToString() + " is full");
                            enrolled = false;
                            break;
                        }
                    }
                }

                if (enrolled)
                {
                    WriteDBTableConnection("SELECT * FROM ENROLLMENTHEADERFILE", "EnrollmentHeaderFile");

                    //ENROLLMENT HEADER
                    dbRow["ENRHFSTUDID"] = IDNumberTextBox.Text;
                    dbRow["ENRHFSTUDDATEENROLL"] = DateTime.Now.ToString();
                    dbRow["ENRHFSTUDSCHLYR"] = "2023-2024";
                    dbRow["ENRHFSTUDENCODER"] = "Saguisa";
                    dbRow["ENRHFSTUDTOTALUNITS"] = UnitsLabel.Text;

                    dbDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(dbRow);
                    dbAdapter.Update(dbDataSet, "EnrollmentHeaderFile");
                }

            }
            else
            {
                MessageBox.Show("Please enter your ID");
            }
        }
    }
}
