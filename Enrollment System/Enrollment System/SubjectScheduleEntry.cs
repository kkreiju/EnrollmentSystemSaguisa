using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SubjectScheduleEntry : Form
    {
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23220726\Desktop\FINAL\Saguisa.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\arjay\Documents\Github\dbaccesstrial\Saguisa.accdb";

        //Write
        OleDbConnection dbConnection;
        OleDbDataAdapter dbAdapter;
        OleDbCommandBuilder dbBuilder;
        DataSet dbDataSet;
        DataRow dbRow;

        //Read
        OleDbCommand dbCommand;
        OleDbDataReader dbDataReader;

        public SubjectScheduleEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SubjectCodeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ReadDBTableConnection("SELECT * FROM SUBJECTFILE");

                bool found = false;
                string description = "";

                while (dbDataReader.Read())
                {
                    if (dbDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextbox.Text.Trim().ToUpper())
                    {
                        found = true;
                        description = dbDataReader["SFSUBJDESC"].ToString();
                    }

                    if (found)
                       DescriptionLabel.Text = description;
                }
                if (!found)
                    MessageBox.Show("Not Found");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            WriteDBTableConnection("SELECT * FROM SUBJECTSCHEDULEFILE", "SubjectScheduleFile");

            dbRow["SSFEDPCODE"] = EDPCodeTextbox.Text;
            dbRow["SSFSUBJCODE"] = SubjectCodeTextbox.Text;
            dbRow["SSFSTARTTIME"] = StartTimeDatePicker.Text;
            dbRow["SSFENDTIME"] = EndTimeDatePicker.Text;
            dbRow["SSFXM"] = AMPMCombobox.Text;
            dbRow["SSFDAYS"] = DaysTextbox.Text;
            dbRow["SSFSECTION"] = SectionTextbox.Text;
            dbRow["SSFROOM"] = RoomTextbox.Text;
            dbRow["SSFSCHOOLYEAR"] = SchoolYearTextbox.Text;

            dbDataSet.Tables["SubjectScheduleFile"].Rows.Add(dbRow);
            dbAdapter.Update(dbDataSet, "SubjectScheduleFile");

            MessageBox.Show("Recorded");
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
    }
}
