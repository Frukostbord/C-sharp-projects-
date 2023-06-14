namespace Customer_Registry
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
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOfficePhone = new System.Windows.Forms.Label();
            this.lblContactDetails = new System.Windows.Forms.Label();
            this.lblOfficeEmail = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCustomers
            // 
            this.lstCustomers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 14;
            this.lstCustomers.Location = new System.Drawing.Point(12, 59);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(571, 298);
            this.lstCustomers.TabIndex = 4;
            this.lstCustomers.SelectedIndexChanged += new System.EventHandler(this.lstCustomers_SelectedIndexChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.ForeColor = System.Drawing.Color.Green;
            this.lblID.Location = new System.Drawing.Point(20, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 42);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblCustomerInfo.Location = new System.Drawing.Point(589, 59);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(289, 303);
            this.lblCustomerInfo.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Green;
            this.lblName.Location = new System.Drawing.Point(67, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(137, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name (Surname, first name)";
            // 
            // lblOfficePhone
            // 
            this.lblOfficePhone.AutoSize = true;
            this.lblOfficePhone.ForeColor = System.Drawing.Color.Green;
            this.lblOfficePhone.Location = new System.Drawing.Point(277, 33);
            this.lblOfficePhone.Name = "lblOfficePhone";
            this.lblOfficePhone.Size = new System.Drawing.Size(69, 13);
            this.lblOfficePhone.TabIndex = 6;
            this.lblOfficePhone.Text = "Office Phone";
            // 
            // lblContactDetails
            // 
            this.lblContactDetails.AutoSize = true;
            this.lblContactDetails.ForeColor = System.Drawing.Color.Green;
            this.lblContactDetails.Location = new System.Drawing.Point(705, 33);
            this.lblContactDetails.Name = "lblContactDetails";
            this.lblContactDetails.Size = new System.Drawing.Size(79, 13);
            this.lblContactDetails.TabIndex = 7;
            this.lblContactDetails.Text = "Contact Details";
            // 
            // lblOfficeEmail
            // 
            this.lblOfficeEmail.AutoSize = true;
            this.lblOfficeEmail.ForeColor = System.Drawing.Color.Green;
            this.lblOfficeEmail.Location = new System.Drawing.Point(429, 33);
            this.lblOfficeEmail.Name = "lblOfficeEmail";
            this.lblOfficeEmail.Size = new System.Drawing.Size(67, 13);
            this.lblOfficeEmail.TabIndex = 8;
            this.lblOfficeEmail.Text = "Office E-Mail";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(201, 383);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 42);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(383, 383);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 449);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblOfficeEmail);
            this.Controls.Add(this.lblContactDetails);
            this.Controls.Add(this.lblOfficePhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCustomerInfo);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lstCustomers);
            this.Name = "FormMain";
            this.Text = "Customer Registry By Andreas Hägglund";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOfficePhone;
        private System.Windows.Forms.Label lblContactDetails;
        private System.Windows.Forms.Label lblOfficeEmail;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}

