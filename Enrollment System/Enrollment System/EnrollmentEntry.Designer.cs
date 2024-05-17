namespace Enrollment_System
{
    partial class EnrollmentEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubjectDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.EDPCodeTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UnitsLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackButton.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(19, 9);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(65, 20);
            this.BackButton.TabIndex = 41;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Engravers MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(100, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 31);
            this.label1.TabIndex = 42;
            this.label1.Text = "Enrollment Entry Form";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.YearLabel);
            this.groupBox1.Controls.Add(this.CourseLabel);
            this.groupBox1.Controls.Add(this.NameLabel);
            this.groupBox1.Controls.Add(this.IDNumberTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Bright", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(648, 105);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // YearLabel
            // 
            this.YearLabel.BackColor = System.Drawing.Color.Honeydew;
            this.YearLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.YearLabel.Location = new System.Drawing.Point(368, 67);
            this.YearLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(238, 23);
            this.YearLabel.TabIndex = 7;
            // 
            // CourseLabel
            // 
            this.CourseLabel.BackColor = System.Drawing.Color.Honeydew;
            this.CourseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.CourseLabel.Location = new System.Drawing.Point(99, 67);
            this.CourseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(161, 23);
            this.CourseLabel.TabIndex = 6;
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Honeydew;
            this.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.NameLabel.Location = new System.Drawing.Point(368, 28);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(238, 23);
            this.NameLabel.TabIndex = 5;
            // 
            // IDNumberTextBox
            // 
            this.IDNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.IDNumberTextBox.Location = new System.Drawing.Point(99, 28);
            this.IDNumberTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IDNumberTextBox.MaxLength = 10;
            this.IDNumberTextBox.Name = "IDNumberTextBox";
            this.IDNumberTextBox.Size = new System.Drawing.Size(162, 20);
            this.IDNumberTextBox.TabIndex = 4;
            this.IDNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDNumberTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(330, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Number:";
            // 
            // SubjectDataGridView
            // 
            this.SubjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.SubjectDataGridView.Location = new System.Drawing.Point(71, 232);
            this.SubjectDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubjectDataGridView.Name = "SubjectDataGridView";
            this.SubjectDataGridView.RowHeadersWidth = 62;
            this.SubjectDataGridView.RowTemplate.Height = 28;
            this.SubjectDataGridView.Size = new System.Drawing.Size(572, 174);
            this.SubjectDataGridView.TabIndex = 44;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "EDP Code";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Subject Code";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.HeaderText = "Start Time";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.HeaderText = "End Time";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column5.HeaderText = "Days";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 54;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.HeaderText = "Room";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 58;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column7.HeaderText = "Units";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Honeydew;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(116, 213);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 45;
            this.label6.Text = "EDP Code:";
            // 
            // EDPCodeTextbox
            // 
            this.EDPCodeTextbox.Location = new System.Drawing.Point(184, 210);
            this.EDPCodeTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDPCodeTextbox.MaxLength = 8;
            this.EDPCodeTextbox.Name = "EDPCodeTextbox";
            this.EDPCodeTextbox.Size = new System.Drawing.Size(162, 20);
            this.EDPCodeTextbox.TabIndex = 46;
            this.EDPCodeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EDPCodeTextbox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Honeydew;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(386, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 47;
            this.label7.Text = "Total Units:";
            // 
            // UnitsLabel
            // 
            this.UnitsLabel.BackColor = System.Drawing.Color.Honeydew;
            this.UnitsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.UnitsLabel.Location = new System.Drawing.Point(457, 210);
            this.UnitsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UnitsLabel.Name = "UnitsLabel";
            this.UnitsLabel.Size = new System.Drawing.Size(79, 19);
            this.UnitsLabel.TabIndex = 8;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelButton.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(381, 420);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(56, 21);
            this.CancelButton.TabIndex = 48;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(285, 420);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(50, 21);
            this.SaveButton.TabIndex = 49;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label8.Location = new System.Drawing.Point(64, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 217);
            this.label8.TabIndex = 50;
            // 
            // EnrollmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BackgroundImage = global::Enrollment_System.Properties.Resources.greenbgbgbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UnitsLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EDPCodeTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SubjectDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EnrollmentEntry";
            this.Text = "Enrollment Entry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDNumberTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.DataGridView SubjectDataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EDPCodeTextbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label UnitsLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label8;
    }
}