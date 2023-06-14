namespace HouseholdChores
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menMainMenu = new System.Windows.Forms.MenuStrip();
            this.ttpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFamilyMembers = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChoresFamilyMember = new System.Windows.Forms.Button();
            this.btnEditFamilyMember = new System.Windows.Forms.Button();
            this.btnDeleteFamilyMember = new System.Windows.Forms.Button();
            this.lstFamilyMembers = new System.Windows.Forms.ListBox();
            this.lblNameFamilyMember = new System.Windows.Forms.Label();
            this.btnAddFamilyMember = new System.Windows.Forms.Button();
            this.txtFamilyMemberName = new System.Windows.Forms.TextBox();
            this.grpChores = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTimesPerWeek = new System.Windows.Forms.Label();
            this.cmbTimesPerWeek = new System.Windows.Forms.ComboBox();
            this.lblListBoxTimesPerWeek = new System.Windows.Forms.Label();
            this.lblListboxChoreName = new System.Windows.Forms.Label();
            this.btnEditChore = new System.Windows.Forms.Button();
            this.btnDeleteChore = new System.Windows.Forms.Button();
            this.lstChores = new System.Windows.Forms.ListBox();
            this.lblChoreName = new System.Windows.Forms.Label();
            this.btnAddChore = new System.Windows.Forms.Button();
            this.txtChoreName = new System.Windows.Forms.TextBox();
            this.grpChoresOverview = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWeekDay = new System.Windows.Forms.ComboBox();
            this.lblFamilyNames = new System.Windows.Forms.Label();
            this.lblWeekdays = new System.Windows.Forms.Label();
            this.lblNamesOverview = new System.Windows.Forms.Label();
            this.lstChoresOverview = new System.Windows.Forms.ListBox();
            this.ttpFormMain = new System.Windows.Forms.ToolTip(this.components);
            this.menMainMenu.SuspendLayout();
            this.grpFamilyMembers.SuspendLayout();
            this.grpChores.SuspendLayout();
            this.grpChoresOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // menMainMenu
            // 
            this.menMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttpMenu});
            this.menMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menMainMenu.Name = "menMainMenu";
            this.menMainMenu.Size = new System.Drawing.Size(812, 24);
            this.menMainMenu.TabIndex = 1;
            this.menMainMenu.Text = "menuStrip1";
            // 
            // ttpMenu
            // 
            this.ttpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewFile,
            this.toolStripSeparator1,
            this.tsmOpenFile,
            this.tsmSaveFile,
            this.toolStripSeparator2,
            this.tsmExit});
            this.ttpMenu.Name = "ttpMenu";
            this.ttpMenu.Size = new System.Drawing.Size(50, 20);
            this.ttpMenu.Text = "Menu";
            this.ttpMenu.ToolTipText = "Click here to Create, Save and Open a new file as well as to exit the application" +
    ".";
            // 
            // tsmNewFile
            // 
            this.tsmNewFile.Name = "tsmNewFile";
            this.tsmNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmNewFile.Size = new System.Drawing.Size(180, 22);
            this.tsmNewFile.Text = "New File";
            this.tsmNewFile.Click += new System.EventHandler(this.ttpNewFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmOpenFile
            // 
            this.tsmOpenFile.Name = "tsmOpenFile";
            this.tsmOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpenFile.Size = new System.Drawing.Size(180, 22);
            this.tsmOpenFile.Text = "Open File";
            this.tsmOpenFile.Click += new System.EventHandler(this.tsmOpenFile_Click);
            // 
            // tsmSaveFile
            // 
            this.tsmSaveFile.Name = "tsmSaveFile";
            this.tsmSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSaveFile.Size = new System.Drawing.Size(180, 22);
            this.tsmSaveFile.Text = "Save file";
            this.tsmSaveFile.Click += new System.EventHandler(this.tsmSaveFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmExit.Size = new System.Drawing.Size(180, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExitMenuItem_Click);
            // 
            // grpFamilyMembers
            // 
            this.grpFamilyMembers.Controls.Add(this.label2);
            this.grpFamilyMembers.Controls.Add(this.btnChoresFamilyMember);
            this.grpFamilyMembers.Controls.Add(this.btnEditFamilyMember);
            this.grpFamilyMembers.Controls.Add(this.btnDeleteFamilyMember);
            this.grpFamilyMembers.Controls.Add(this.lstFamilyMembers);
            this.grpFamilyMembers.Controls.Add(this.lblNameFamilyMember);
            this.grpFamilyMembers.Controls.Add(this.btnAddFamilyMember);
            this.grpFamilyMembers.Controls.Add(this.txtFamilyMemberName);
            this.grpFamilyMembers.Location = new System.Drawing.Point(12, 40);
            this.grpFamilyMembers.Name = "grpFamilyMembers";
            this.grpFamilyMembers.Size = new System.Drawing.Size(327, 281);
            this.grpFamilyMembers.TabIndex = 0;
            this.grpFamilyMembers.TabStop = false;
            this.grpFamilyMembers.Text = "Family members";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Family member names";
            // 
            // btnChoresFamilyMember
            // 
            this.btnChoresFamilyMember.Location = new System.Drawing.Point(208, 238);
            this.btnChoresFamilyMember.Name = "btnChoresFamilyMember";
            this.btnChoresFamilyMember.Size = new System.Drawing.Size(75, 23);
            this.btnChoresFamilyMember.TabIndex = 6;
            this.btnChoresFamilyMember.Text = "Edit chores";
            this.ttpFormMain.SetToolTip(this.btnChoresFamilyMember, "Click here to edit chores for currently selected famliy member.");
            this.btnChoresFamilyMember.UseVisualStyleBackColor = true;
            this.btnChoresFamilyMember.Click += new System.EventHandler(this.btnChoresFamilyMember_Click);
            // 
            // btnEditFamilyMember
            // 
            this.btnEditFamilyMember.Location = new System.Drawing.Point(107, 238);
            this.btnEditFamilyMember.Name = "btnEditFamilyMember";
            this.btnEditFamilyMember.Size = new System.Drawing.Size(75, 23);
            this.btnEditFamilyMember.TabIndex = 5;
            this.btnEditFamilyMember.Text = "Edit name";
            this.btnEditFamilyMember.UseVisualStyleBackColor = true;
            this.btnEditFamilyMember.Click += new System.EventHandler(this.btnEditFamilyMember_Click);
            // 
            // btnDeleteFamilyMember
            // 
            this.btnDeleteFamilyMember.Location = new System.Drawing.Point(10, 238);
            this.btnDeleteFamilyMember.Name = "btnDeleteFamilyMember";
            this.btnDeleteFamilyMember.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFamilyMember.TabIndex = 4;
            this.btnDeleteFamilyMember.Text = "Delete";
            this.btnDeleteFamilyMember.UseVisualStyleBackColor = true;
            this.btnDeleteFamilyMember.Click += new System.EventHandler(this.btnDeleteFamilyMember_Click);
            // 
            // lstFamilyMembers
            // 
            this.lstFamilyMembers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFamilyMembers.FormattingEnabled = true;
            this.lstFamilyMembers.ItemHeight = 14;
            this.lstFamilyMembers.Location = new System.Drawing.Point(10, 111);
            this.lstFamilyMembers.Name = "lstFamilyMembers";
            this.lstFamilyMembers.Size = new System.Drawing.Size(297, 116);
            this.lstFamilyMembers.TabIndex = 3;
            this.lstFamilyMembers.SelectedIndexChanged += new System.EventHandler(this.lstFamilyMembers_SelectedIndexChanged);
            // 
            // lblNameFamilyMember
            // 
            this.lblNameFamilyMember.AutoSize = true;
            this.lblNameFamilyMember.Location = new System.Drawing.Point(7, 22);
            this.lblNameFamilyMember.Name = "lblNameFamilyMember";
            this.lblNameFamilyMember.Size = new System.Drawing.Size(35, 13);
            this.lblNameFamilyMember.TabIndex = 2;
            this.lblNameFamilyMember.Text = "Name";
            // 
            // btnAddFamilyMember
            // 
            this.btnAddFamilyMember.Location = new System.Drawing.Point(122, 45);
            this.btnAddFamilyMember.Name = "btnAddFamilyMember";
            this.btnAddFamilyMember.Size = new System.Drawing.Size(75, 23);
            this.btnAddFamilyMember.TabIndex = 1;
            this.btnAddFamilyMember.Text = "Add";
            this.btnAddFamilyMember.UseVisualStyleBackColor = true;
            this.btnAddFamilyMember.Click += new System.EventHandler(this.btnAddFamilyMember_Click);
            // 
            // txtFamilyMemberName
            // 
            this.txtFamilyMemberName.Location = new System.Drawing.Point(48, 19);
            this.txtFamilyMemberName.Name = "txtFamilyMemberName";
            this.txtFamilyMemberName.Size = new System.Drawing.Size(248, 20);
            this.txtFamilyMemberName.TabIndex = 0;
            // 
            // grpChores
            // 
            this.grpChores.Controls.Add(this.label4);
            this.grpChores.Controls.Add(this.label3);
            this.grpChores.Controls.Add(this.lblTimesPerWeek);
            this.grpChores.Controls.Add(this.cmbTimesPerWeek);
            this.grpChores.Controls.Add(this.lblListBoxTimesPerWeek);
            this.grpChores.Controls.Add(this.lblListboxChoreName);
            this.grpChores.Controls.Add(this.btnEditChore);
            this.grpChores.Controls.Add(this.btnDeleteChore);
            this.grpChores.Controls.Add(this.lstChores);
            this.grpChores.Controls.Add(this.lblChoreName);
            this.grpChores.Controls.Add(this.btnAddChore);
            this.grpChores.Controls.Add(this.txtChoreName);
            this.grpChores.Location = new System.Drawing.Point(391, 40);
            this.grpChores.Name = "grpChores";
            this.grpChores.Size = new System.Drawing.Size(409, 281);
            this.grpChores.TabIndex = 1;
            this.grpChores.TabStop = false;
            this.grpChores.Text = "Chore";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Done weekly";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 11;
            // 
            // lblTimesPerWeek
            // 
            this.lblTimesPerWeek.AutoSize = true;
            this.lblTimesPerWeek.Location = new System.Drawing.Point(14, 50);
            this.lblTimesPerWeek.Name = "lblTimesPerWeek";
            this.lblTimesPerWeek.Size = new System.Drawing.Size(71, 13);
            this.lblTimesPerWeek.TabIndex = 10;
            this.lblTimesPerWeek.Text = "Times weekly";
            // 
            // cmbTimesPerWeek
            // 
            this.cmbTimesPerWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimesPerWeek.FormattingEnabled = true;
            this.cmbTimesPerWeek.Location = new System.Drawing.Point(91, 47);
            this.cmbTimesPerWeek.Name = "cmbTimesPerWeek";
            this.cmbTimesPerWeek.Size = new System.Drawing.Size(121, 21);
            this.cmbTimesPerWeek.TabIndex = 1;
            // 
            // lblListBoxTimesPerWeek
            // 
            this.lblListBoxTimesPerWeek.AutoSize = true;
            this.lblListBoxTimesPerWeek.Location = new System.Drawing.Point(175, 81);
            this.lblListBoxTimesPerWeek.Name = "lblListBoxTimesPerWeek";
            this.lblListBoxTimesPerWeek.Size = new System.Drawing.Size(98, 13);
            this.lblListBoxTimesPerWeek.TabIndex = 7;
            this.lblListBoxTimesPerWeek.Text = "To be done weekly";
            // 
            // lblListboxChoreName
            // 
            this.lblListboxChoreName.AutoSize = true;
            this.lblListboxChoreName.Location = new System.Drawing.Point(19, 81);
            this.lblListboxChoreName.Name = "lblListboxChoreName";
            this.lblListboxChoreName.Size = new System.Drawing.Size(35, 13);
            this.lblListboxChoreName.TabIndex = 6;
            this.lblListboxChoreName.Text = "Chore";
            // 
            // btnEditChore
            // 
            this.btnEditChore.Location = new System.Drawing.Point(107, 238);
            this.btnEditChore.Name = "btnEditChore";
            this.btnEditChore.Size = new System.Drawing.Size(75, 23);
            this.btnEditChore.TabIndex = 5;
            this.btnEditChore.Text = "Edit";
            this.btnEditChore.UseVisualStyleBackColor = true;
            this.btnEditChore.Click += new System.EventHandler(this.btnEditChore_Click);
            // 
            // btnDeleteChore
            // 
            this.btnDeleteChore.Location = new System.Drawing.Point(10, 238);
            this.btnDeleteChore.Name = "btnDeleteChore";
            this.btnDeleteChore.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteChore.TabIndex = 4;
            this.btnDeleteChore.Text = "Delete";
            this.btnDeleteChore.UseVisualStyleBackColor = true;
            this.btnDeleteChore.Click += new System.EventHandler(this.btnDeleteChore_Click);
            // 
            // lstChores
            // 
            this.lstChores.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChores.FormattingEnabled = true;
            this.lstChores.ItemHeight = 14;
            this.lstChores.Location = new System.Drawing.Point(10, 111);
            this.lstChores.Name = "lstChores";
            this.lstChores.Size = new System.Drawing.Size(393, 116);
            this.lstChores.TabIndex = 3;
            this.lstChores.SelectedIndexChanged += new System.EventHandler(this.lstChores_SelectedIndexChanged);
            // 
            // lblChoreName
            // 
            this.lblChoreName.AutoSize = true;
            this.lblChoreName.Location = new System.Drawing.Point(14, 25);
            this.lblChoreName.Name = "lblChoreName";
            this.lblChoreName.Size = new System.Drawing.Size(35, 13);
            this.lblChoreName.TabIndex = 2;
            this.lblChoreName.Text = "Name";
            // 
            // btnAddChore
            // 
            this.btnAddChore.Location = new System.Drawing.Point(258, 45);
            this.btnAddChore.Name = "btnAddChore";
            this.btnAddChore.Size = new System.Drawing.Size(75, 23);
            this.btnAddChore.TabIndex = 2;
            this.btnAddChore.Text = "Add";
            this.btnAddChore.UseVisualStyleBackColor = true;
            this.btnAddChore.Click += new System.EventHandler(this.btnAddChore_Click);
            // 
            // txtChoreName
            // 
            this.txtChoreName.Location = new System.Drawing.Point(91, 18);
            this.txtChoreName.Name = "txtChoreName";
            this.txtChoreName.Size = new System.Drawing.Size(289, 20);
            this.txtChoreName.TabIndex = 0;
            // 
            // grpChoresOverview
            // 
            this.grpChoresOverview.Controls.Add(this.label1);
            this.grpChoresOverview.Controls.Add(this.cmbWeekDay);
            this.grpChoresOverview.Controls.Add(this.lblFamilyNames);
            this.grpChoresOverview.Controls.Add(this.lblWeekdays);
            this.grpChoresOverview.Controls.Add(this.lblNamesOverview);
            this.grpChoresOverview.Controls.Add(this.lstChoresOverview);
            this.grpChoresOverview.Location = new System.Drawing.Point(12, 328);
            this.grpChoresOverview.Name = "grpChoresOverview";
            this.grpChoresOverview.Size = new System.Drawing.Size(788, 269);
            this.grpChoresOverview.TabIndex = 2;
            this.grpChoresOverview.TabStop = false;
            this.grpChoresOverview.Text = "Chores overview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Weekday";
            // 
            // cmbWeekDay
            // 
            this.cmbWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeekDay.FormattingEnabled = true;
            this.cmbWeekDay.Location = new System.Drawing.Point(76, 31);
            this.cmbWeekDay.Name = "cmbWeekDay";
            this.cmbWeekDay.Size = new System.Drawing.Size(121, 21);
            this.cmbWeekDay.TabIndex = 0;
            this.ttpFormMain.SetToolTip(this.cmbWeekDay, "Select a weekday to see all the family members chores the selected weekday.");
            this.cmbWeekDay.SelectedIndexChanged += new System.EventHandler(this.cmbWeekDay_SelectedIndexChanged);
            // 
            // lblFamilyNames
            // 
            this.lblFamilyNames.AutoSize = true;
            this.lblFamilyNames.Location = new System.Drawing.Point(6, 79);
            this.lblFamilyNames.Name = "lblFamilyNames";
            this.lblFamilyNames.Size = new System.Drawing.Size(70, 13);
            this.lblFamilyNames.TabIndex = 5;
            this.lblFamilyNames.Text = "Family names";
            // 
            // lblWeekdays
            // 
            this.lblWeekdays.AutoSize = true;
            this.lblWeekdays.Location = new System.Drawing.Point(348, 50);
            this.lblWeekdays.Name = "lblWeekdays";
            this.lblWeekdays.Size = new System.Drawing.Size(40, 13);
            this.lblWeekdays.TabIndex = 4;
            this.lblWeekdays.Text = "Chores";
            // 
            // lblNamesOverview
            // 
            this.lblNamesOverview.AutoSize = true;
            this.lblNamesOverview.Location = new System.Drawing.Point(21, 31);
            this.lblNamesOverview.Name = "lblNamesOverview";
            this.lblNamesOverview.Size = new System.Drawing.Size(0, 13);
            this.lblNamesOverview.TabIndex = 3;
            // 
            // lstChoresOverview
            // 
            this.lstChoresOverview.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChoresOverview.FormattingEnabled = true;
            this.lstChoresOverview.ItemHeight = 14;
            this.lstChoresOverview.Location = new System.Drawing.Point(76, 79);
            this.lstChoresOverview.Name = "lstChoresOverview";
            this.lstChoresOverview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstChoresOverview.Size = new System.Drawing.Size(706, 158);
            this.lstChoresOverview.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 613);
            this.Controls.Add(this.grpChoresOverview);
            this.Controls.Add(this.grpChores);
            this.Controls.Add(this.grpFamilyMembers);
            this.Controls.Add(this.menMainMenu);
            this.MainMenuStrip = this.menMainMenu;
            this.Name = "FormMain";
            this.Text = "Household chores by Andreas Hägglund";
            this.menMainMenu.ResumeLayout(false);
            this.menMainMenu.PerformLayout();
            this.grpFamilyMembers.ResumeLayout(false);
            this.grpFamilyMembers.PerformLayout();
            this.grpChores.ResumeLayout(false);
            this.grpChores.PerformLayout();
            this.grpChoresOverview.ResumeLayout(false);
            this.grpChoresOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menMainMenu;
        private System.Windows.Forms.ToolStripMenuItem ttpMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenFile;
        private System.Windows.Forms.GroupBox grpFamilyMembers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChoresFamilyMember;
        private System.Windows.Forms.Button btnEditFamilyMember;
        private System.Windows.Forms.Button btnDeleteFamilyMember;
        private System.Windows.Forms.ListBox lstFamilyMembers;
        private System.Windows.Forms.Label lblNameFamilyMember;
        private System.Windows.Forms.Button btnAddFamilyMember;
        private System.Windows.Forms.TextBox txtFamilyMemberName;
        private System.Windows.Forms.GroupBox grpChores;
        private System.Windows.Forms.Label lblTimesPerWeek;
        private System.Windows.Forms.ComboBox cmbTimesPerWeek;
        private System.Windows.Forms.Label lblListBoxTimesPerWeek;
        private System.Windows.Forms.Label lblListboxChoreName;
        private System.Windows.Forms.Button btnEditChore;
        private System.Windows.Forms.Button btnDeleteChore;
        private System.Windows.Forms.ListBox lstChores;
        private System.Windows.Forms.Label lblChoreName;
        private System.Windows.Forms.Button btnAddChore;
        private System.Windows.Forms.TextBox txtChoreName;
        private System.Windows.Forms.GroupBox grpChoresOverview;
        private System.Windows.Forms.Label lblWeekdays;
        private System.Windows.Forms.Label lblNamesOverview;
        private System.Windows.Forms.ListBox lstChoresOverview;
        private System.Windows.Forms.Label lblFamilyNames;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWeekDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolTip ttpFormMain;
    }
}

