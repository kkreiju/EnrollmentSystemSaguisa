using System;
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

        int datagridindex = -1;


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
                        if(datagridindex == -1)
                        {
                            DisplayToDataGrid();
                        }
                        else
                        {
                            /* 
                             ------i will list as many thoughts as i can-----
                            1. datagridindex comparison on 24hr time and for date is idk how pa
                            2. maybe mag use ug daghan arrays for the date, time
                            3. for loop for comparison (maybe nested)
                            4. compare verifiedstarttime > comparedstarttime < verifiedendtime 
                            5. maybe unahon ug compare ang days if kapareha ba before number 4
                            6. if kapareho ang days, mo proceed siya sa number 4
                            7. if pasar sa conflict verifier, DisplayToDataGrid() na dayon
                            8. continue sa saving file sa EnrollmentHeaderFile & EnrollmentDetailFile
                            9. paminaw sa vm nga naa sa ip6+
                             */

                            //verifier
                            ConflictVerifier(dbDataReader["SSFDAYS"].ToString(), TwentyFourHourFormat(TimeFormat(dbDataReader["SSFSTARTTIME"].ToString())), TwentyFourHourFormat(TimeFormat(dbDataReader["SSFENDTIME"].ToString())));

                            //if the subject is not conflict (pls temporary pani)
                            DisplayToDataGrid();
                        }
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
                    SubjectDataGridView.Rows[datagridindex].Cells[6].Value = dbDataReader["SFSUBJUNITS"].ToString();
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
            for(int i = 0; i <= datagridindex; i++)
            {
                units += Convert.ToInt16(SubjectDataGridView.Rows[datagridindex].Cells[6].Value);
            }
            return units;
        }

        private double TwentyFourHourFormat(string time)
        {
            double twentyfourhrtime;
            twentyfourhrtime = Convert.ToDouble(time.Substring(0, time.IndexOf(':')));
            if (Convert.ToDouble(time.Substring(time.IndexOf(':') + 1, 2)) >= 30)
                twentyfourhrtime += .30;
            if (time.Substring(time.IndexOf(' ') + 1) == "PM")
                twentyfourhrtime += 12;
            return twentyfourhrtime;
        }

        private void ConflictVerifier(string days, double starttime, double endtime)
        {
            MessageBox.Show(starttime.ToString());
            if (days == "MON")
                MessageBox.Show("Monday");
            else if(days == "TUE")
                MessageBox.Show("Tuesday");
            else if (days == "WED")
                MessageBox.Show("Wednesday");
            else if (days == "THU")
                MessageBox.Show("Thursday");
            else if (days == "FRI")
                MessageBox.Show("Friday");
            else if (days == "SAT")
                MessageBox.Show("Saturday");
            else if (days == "MW")
                MessageBox.Show("Monday, Wednesday");
            else if (days == "TTH")
                MessageBox.Show("Tuesday, Thursday");
            else if (days == "FS")
                MessageBox.Show("Friday, Saturday");
            else if (days == "MWF")
                MessageBox.Show("Monday, Wednesday, Friday");
        }

        private void DisplayToDataGrid()
        {
            datagridindex++;
            SubjectDataGridView.Rows.Add();
            SubjectDataGridView.Rows[datagridindex].Cells[0].Value = dbDataReader["SSFEDPCODE"].ToString();
            SubjectDataGridView.Rows[datagridindex].Cells[1].Value = dbDataReader["SSFSUBJCODE"].ToString();
            SubjectDataGridView.Rows[datagridindex].Cells[2].Value = TimeFormat(dbDataReader["SSFSTARTTIME"].ToString());
            SubjectDataGridView.Rows[datagridindex].Cells[3].Value = TimeFormat(dbDataReader["SSFENDTIME"].ToString());
            SubjectDataGridView.Rows[datagridindex].Cells[4].Value = dbDataReader["SSFDAYS"].ToString();
            SubjectDataGridView.Rows[datagridindex].Cells[5].Value = dbDataReader["SSFROOM"].ToString();

            //display units
            FindUnits(dbDataReader["SSFSUBJCODE"].ToString());
            UnitsLabel.Text = CalculateTotalUnits().ToString();
        }
    }
}
