using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class StudentEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23220726\Desktop\FINAL\Saguisa.accdb";
        //Write
        OleDbConnection dbConnection;
        OleDbDataAdapter dbAdapter;
        OleDbCommandBuilder dbBuilder;
        DataSet dbDataSet;
        DataRow dbRow;

        //Read
        OleDbCommand dbCommand;
        OleDbDataReader dbDataReader;

        public StudentEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IDNumberTextBox.Text == string.Empty || FirstNameTextBox.Text == string.Empty || MiddleNameTextBox.Text == string.Empty || LastNameTextBox.Text == string.Empty || CourseTextBox.Text == string.Empty ||
            YearTextBox.Text == string.Empty || RemarksComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the details!");
                return;
            }

            ReadDBTableConnection("SELECT * FROM STUDENTFILE");
            while (dbDataReader.Read())
            {
                if (dbDataReader["STFSTUDID"].ToString().Trim() == IDNumberTextBox.Text.Trim())
                {
                    MessageBox.Show("Student ID already existed!");
                    return;
                }
            }
            

            WriteDBTableConnection("SELECT * FROM STUDENTFILE", "StudentFile");

            dbRow["STFSTUDID"] = IDNumberTextBox.Text;
            dbRow["STFSTUDLNAME"] = FirstNameTextBox.Text;
            dbRow["STFSTUDFNAME"] = LastNameTextBox.Text;
            dbRow["STFSTUDMNAME"] = MiddleNameTextBox.Text;
            dbRow["STFSTUDCOURSE"] = CourseTextBox.Text;
            dbRow["STFSTUDYEAR"] = YearTextBox.Text;
            dbRow["STFSTUDSTATUS"] = "AC";

            dbDataSet.Tables["StudentFile"].Rows.Add(dbRow);
            dbAdapter.Update(dbDataSet, "StudentFile");

            MessageBox.Show("Recorded!");
            IDNumberTextBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            CourseTextBox.Text = string.Empty;
            YearTextBox.Text = string.Empty;
            RemarksComboBox.SelectedIndex = -1;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            IDNumberTextBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            CourseTextBox.Text = string.Empty;
            YearTextBox.Text = string.Empty;
            RemarksComboBox.SelectedIndex = -1;
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
    }
}
