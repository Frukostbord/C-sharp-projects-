namespace HouseholdChores
{
    partial class FormChores
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
            this.lstChoresOverview = new System.Windows.Forms.ListBox();
            this.grpChore = new System.Windows.Forms.GroupBox();
            this.lblTimesPerWeek = new System.Windows.Forms.Label();
            this.lblWeekdays = new System.Windows.Forms.Label();
            this.btnDeleteChore = new System.Windows.Forms.Button();
            this.cmbChores = new System.Windows.Forms.ComboBox();
            this.btnEditChore = new System.Windows.Forms.Button();
            this.btnAddChore = new System.Windows.Forms.Button();
            this.lblChore = new System.Windows.Forms.Label();
            this.lstWeekdays = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpChoresOverview = new System.Windows.Forms.GroupBox();
            this.lblChoresWeekdays = new System.Windows.Forms.Label();
            this.lblChoresOverview = new System.Windows.Forms.Label();
            this.grpChore.SuspendLayout();
            this.grpChoresOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChoresOverview
            // 
            this.lstChoresOverview.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChoresOverview.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstChoresOverview.FormattingEnabled = true;
            this.lstChoresOverview.ItemHeight = 14;
            this.lstChoresOverview.Location = new System.Drawing.Point(6, 64);
            this.lstChoresOverview.Name = "lstChoresOverview";
            this.lstChoresOverview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstChoresOverview.Size = new System.Drawing.Size(406, 172);
            this.lstChoresOverview.TabIndex = 0;
            // 
            // grpChore
            // 
            this.grpChore.Controls.Add(this.lblTimesPerWeek);
            this.grpChore.Controls.Add(this.lblWeekdays);
            this.grpChore.Controls.Add(this.btnDeleteChore);
            this.grpChore.Controls.Add(this.cmbChores);
            this.grpChore.Controls.Add(this.btnEditChore);
            this.grpChore.Controls.Add(this.btnAddChore);
            this.grpChore.Controls.Add(this.lblChore);
            this.grpChore.Controls.Add(this.lstWeekdays);
            this.grpChore.Location = new System.Drawing.Point(12, 26);
            this.grpChore.Name = "grpChore";
            this.grpChore.Size = new System.Drawing.Size(271, 243);
            this.grpChore.TabIndex = 2;
            this.grpChore.TabStop = false;
            this.grpChore.Text = "Chores";
            // 
            // lblTimesPerWeek
            // 
            this.lblTimesPerWeek.AutoSize = true;
            this.lblTimesPerWeek.Location = new System.Drawing.Point(165, 51);
            this.lblTimesPerWeek.Name = "lblTimesPerWeek";
            this.lblTimesPerWeek.Size = new System.Drawing.Size(0, 13);
            this.lblTimesPerWeek.TabIndex = 14;
            // 
            // lblWeekdays
            // 
            this.lblWeekdays.AutoSize = true;
            this.lblWeekdays.Location = new System.Drawing.Point(15, 90);
            this.lblWeekdays.Name = "lblWeekdays";
            this.lblWeekdays.Size = new System.Drawing.Size(58, 13);
            this.lblWeekdays.TabIndex = 13;
            this.lblWeekdays.Text = "Weekdays";
            // 
            // btnDeleteChore
            // 
            this.btnDeleteChore.Location = new System.Drawing.Point(164, 139);
            this.btnDeleteChore.Name = "btnDeleteChore";
            this.btnDeleteChore.Size = new System.Drawing.Size(86, 27);
            this.btnDeleteChore.TabIndex = 12;
            this.btnDeleteChore.Text = "Delete chore";
            this.btnDeleteChore.UseVisualStyleBackColor = true;
            this.btnDeleteChore.Click += new System.EventHandler(this.btnDeleteChore_Click);
            // 
            // cmbChores
            // 
            this.cmbChores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChores.FormattingEnabled = true;
            this.cmbChores.Location = new System.Drawing.Point(9, 48);
            this.cmbChores.Name = "cmbChores";
            this.cmbChores.Size = new System.Drawing.Size(144, 21);
            this.cmbChores.TabIndex = 11;
            this.cmbChores.SelectedIndexChanged += new System.EventHandler(this.cmbChores_SelectedIndexChanged);
            // 
            // btnEditChore
            // 
            this.btnEditChore.Location = new System.Drawing.Point(164, 172);
            this.btnEditChore.Name = "btnEditChore";
            this.btnEditChore.Size = new System.Drawing.Size(86, 27);
            this.btnEditChore.TabIndex = 10;
            this.btnEditChore.Text = "Edit chore";
            this.btnEditChore.UseVisualStyleBackColor = true;
            this.btnEditChore.Click += new System.EventHandler(this.btnEditChore_Click);
            // 
            // btnAddChore
            // 
            this.btnAddChore.Location = new System.Drawing.Point(164, 106);
            this.btnAddChore.Name = "btnAddChore";
            this.btnAddChore.Size = new System.Drawing.Size(86, 27);
            this.btnAddChore.TabIndex = 9;
            this.btnAddChore.Text = "Add chore";
            this.btnAddChore.UseVisualStyleBackColor = true;
            this.btnAddChore.Click += new System.EventHandler(this.btnAddChore_Click);
            // 
            // lblChore
            // 
            this.lblChore.AutoSize = true;
            this.lblChore.Location = new System.Drawing.Point(15, 32);
            this.lblChore.Name = "lblChore";
            this.lblChore.Size = new System.Drawing.Size(35, 13);
            this.lblChore.TabIndex = 6;
            this.lblChore.Text = "Chore";
            // 
            // lstWeekdays
            // 
            this.lstWeekdays.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWeekdays.FormattingEnabled = true;
            this.lstWeekdays.ItemHeight = 14;
            this.lstWeekdays.Location = new System.Drawing.Point(9, 106);
            this.lstWeekdays.Name = "lstWeekdays";
            this.lstWeekdays.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWeekdays.Size = new System.Drawing.Size(144, 116);
            this.lstWeekdays.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(180, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 38);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 38);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpChoresOverview
            // 
            this.grpChoresOverview.Controls.Add(this.lblChoresWeekdays);
            this.grpChoresOverview.Controls.Add(this.lblChoresOverview);
            this.grpChoresOverview.Controls.Add(this.lstChoresOverview);
            this.grpChoresOverview.Location = new System.Drawing.Point(305, 26);
            this.grpChoresOverview.Name = "grpChoresOverview";
            this.grpChoresOverview.Size = new System.Drawing.Size(418, 243);
            this.grpChoresOverview.TabIndex = 5;
            this.grpChoresOverview.TabStop = false;
            this.grpChoresOverview.Text = "Chores overview";
            // 
            // lblChoresWeekdays
            // 
            this.lblChoresWeekdays.AutoSize = true;
            this.lblChoresWeekdays.Location = new System.Drawing.Point(196, 48);
            this.lblChoresWeekdays.Name = "lblChoresWeekdays";
            this.lblChoresWeekdays.Size = new System.Drawing.Size(131, 13);
            this.lblChoresWeekdays.TabIndex = 8;
            this.lblChoresWeekdays.Text = "Weekday(s) chore is done";
            // 
            // lblChoresOverview
            // 
            this.lblChoresOverview.AutoSize = true;
            this.lblChoresOverview.Location = new System.Drawing.Point(16, 48);
            this.lblChoresOverview.Name = "lblChoresOverview";
            this.lblChoresOverview.Size = new System.Drawing.Size(40, 13);
            this.lblChoresOverview.TabIndex = 7;
            this.lblChoresOverview.Text = "Chores";
            // 
            // FormChores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 348);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpChore);
            this.Controls.Add(this.grpChoresOverview);
            this.Name = "FormChores";
            this.grpChore.ResumeLayout(false);
            this.grpChore.PerformLayout();
            this.grpChoresOverview.ResumeLayout(false);
            this.grpChoresOverview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChoresOverview;
        private System.Windows.Forms.GroupBox grpChore;
        private System.Windows.Forms.Label lblChore;
        private System.Windows.Forms.ListBox lstWeekdays;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddChore;
        private System.Windows.Forms.Button btnEditChore;
        private System.Windows.Forms.ComboBox cmbChores;
        private System.Windows.Forms.Button btnDeleteChore;
        private System.Windows.Forms.GroupBox grpChoresOverview;
        private System.Windows.Forms.Label lblWeekdays;
        private System.Windows.Forms.Label lblChoresWeekdays;
        private System.Windows.Forms.Label lblChoresOverview;
        private System.Windows.Forms.Label lblTimesPerWeek;
    }
}