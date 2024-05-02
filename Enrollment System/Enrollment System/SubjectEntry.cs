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
    public partial class SubjectEntry : Form
    {
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79286_CC_APPSDEV22_1030_1230_PM_MW\79286-23220726\Desktop\FINAL\Saguisa.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\arjay\Documents\Github\dbaccesstrial\Saguisa.accdb";
        public SubjectEntry()
        {
            InitializeComponent();
            CenterToScreen();
        }

        //Write
        OleDbConnection dbConnection;
        OleDbDataAdapter dbAdapter;
        OleDbCommandBuilder dbBuilder;
        DataSet dbDataSet;
        DataRow dbRow;

        //Read
        OleDbCommand dbCommand;
        OleDbDataReader dbDataReader;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            WriteDBTableConnection("SELECT * FROM SUBJECTFILE", "SubjectFile");

            dbRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
            dbRow["SFSUBJDESC"] = DescriptionTextBox.Text;
            dbRow["SFSUBJUNITS"] = UnitsTextBox.Text;
            dbRow["SFSUBJREGOFRNG"] = OfferingComboBox.SelectedIndex + 1;
            dbRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3).ToUpper();
            dbRow["SFSUBJSTATUS"] = "AC";
            dbRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
            dbRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

            dbDataSet.Tables["SubjectFile"].Rows.Add(dbRow);
            dbAdapter.Update(dbDataSet, "SubjectFile");

            if(RequisiteTextBox.Text != string.Empty)
            {
                WriteDBTableConnection("SELECT * FROM SUBJECTPREQFILE", "SubjectPreqFile");

                dbRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
                dbRow["SUBJPRECODE"] = RequisiteTextBox.Text;
                if (PreRequisiteRadioButton.Checked)
                    dbRow["SUBJCATEGORY"] = "PR";
                else if (CoRequisiteRadioButton.Checked)
                    dbRow["SUBJCATEGORY"] = "CR";

                dbDataSet.Tables["SubjectPreqFile"].Rows.Add(dbRow);
                dbAdapter.Update(dbDataSet, "SubjectPreqFile");
            }
            PreRequisiteRadioButton.Checked = false;
            CoRequisiteRadioButton.Checked = false;
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

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                ReadDBTableConnection("SELECT * FROM SUBJECTFILE");
                bool found = false;
                string subjectCode = "";
                string description = "";
                string units = "";

                while (dbDataReader.Read())
                {
                    if (dbDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        subjectCode = dbDataReader["SFSUBJCODE"].ToString();
                        description = dbDataReader["SFSUBJDESC"].ToString();
                        units = dbDataReader["SFSUBJUNITS"].ToString();
                        break;
                    //
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Subject Code Not Found");
                    //SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[0].Cells[0].Value = string.Empty;
                    SubjectDataGridView.Rows[0].Cells[1].Value = string.Empty;
                    SubjectDataGridView.Rows[0].Cells[2].Value = string.Empty;
                } 
                else
                {
                    SubjectDataGridView.Rows[0].Cells[0].Value = subjectCode;
                    SubjectDataGridView.Rows[0].Cells[1].Value = description;
                    SubjectDataGridView.Rows[0].Cells[2].Value = units;
                }

                ReadDBTableConnection("SELECT * FROM SUBJECTPREQFILE");
                while (dbDataReader.Read())
                {
                    if (dbDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                    {
                        SubjectDataGridView.Rows[0].Cells[3].Value = dbDataReader["SUBJPRECODE"].ToString().Trim().ToUpper();
                        break;
                    }
                    else
                        SubjectDataGridView.Rows[0].Cells[3].Value = string.Empty;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }
    }
}
