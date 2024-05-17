namespace Enrollment_System
{
    partial class MainForm
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
            this.SubjectEntryButton = new System.Windows.Forms.Button();
            this.SubjectScheduleEntryButton = new System.Windows.Forms.Button();
            this.EnrollmentEntryButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StudentEntryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubjectEntryButton
            // 
            this.SubjectEntryButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.SubjectEntryButton.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectEntryButton.Location = new System.Drawing.Point(214, 216);
            this.SubjectEntryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubjectEntryButton.Name = "SubjectEntryButton";
            this.SubjectEntryButton.Size = new System.Drawing.Size(261, 60);
            this.SubjectEntryButton.TabIndex = 3;
            this.SubjectEntryButton.Text = "Subject Entry";
            this.SubjectEntryButton.UseVisualStyleBackColor = false;
            this.SubjectEntryButton.Click += new System.EventHandler(this.SubjectEntryButton_Click);
            // 
            // SubjectScheduleEntryButton
            // 
            this.SubjectScheduleEntryButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.SubjectScheduleEntryButton.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectScheduleEntryButton.Location = new System.Drawing.Point(214, 297);
            this.SubjectScheduleEntryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubjectScheduleEntryButton.Name = "SubjectScheduleEntryButton";
            this.SubjectScheduleEntryButton.Size = new System.Drawing.Size(261, 60);
            this.SubjectScheduleEntryButton.TabIndex = 4;
            this.SubjectScheduleEntryButton.Text = "Subject Schedule Entry";
            this.SubjectScheduleEntryButton.UseVisualStyleBackColor = false;
            this.SubjectScheduleEntryButton.Click += new System.EventHandler(this.SubjectScheduleEntryButton_Click);
            // 
            // EnrollmentEntryButton
            // 
            this.EnrollmentEntryButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.EnrollmentEntryButton.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnrollmentEntryButton.Location = new System.Drawing.Point(214, 383);
            this.EnrollmentEntryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnrollmentEntryButton.Name = "EnrollmentEntryButton";
            this.EnrollmentEntryButton.Size = new System.Drawing.Size(261, 60);
            this.EnrollmentEntryButton.TabIndex = 5;
            this.EnrollmentEntryButton.Text = "Enrollment Entry";
            this.EnrollmentEntryButton.UseVisualStyleBackColor = false;
            this.EnrollmentEntryButton.Click += new System.EventHandler(this.EnrollmentEntryButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Enrollment_System.Properties.Resources.UCC;
            this.pictureBox1.Location = new System.Drawing.Point(233, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // StudentEntryButton
            // 
            this.StudentEntryButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.StudentEntryButton.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentEntryButton.Location = new System.Drawing.Point(214, 458);
            this.StudentEntryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentEntryButton.Name = "StudentEntryButton";
            this.StudentEntryButton.Size = new System.Drawing.Size(261, 60);
            this.StudentEntryButton.TabIndex = 7;
            this.StudentEntryButton.Text = "Student Entry";
            this.StudentEntryButton.UseVisualStyleBackColor = false;
            this.StudentEntryButton.Click += new System.EventHandler(this.StudentEntryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BackgroundImage = global::Enrollment_System.Properties.Resources.greenbgbgbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(692, 554);
            this.Controls.Add(this.StudentEntryButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EnrollmentEntryButton);
            this.Controls.Add(this.SubjectScheduleEntryButton);
            this.Controls.Add(this.SubjectEntryButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SubjectEntryButton;
        private System.Windows.Forms.Button SubjectScheduleEntryButton;
        private System.Windows.Forms.Button EnrollmentEntryButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button StudentEntryButton;
    }
}