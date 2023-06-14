namespace HomeForSale
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLandSize = new System.Windows.Forms.Label();
            this.txtLandSize = new System.Windows.Forms.TextBox();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.txtPris = new System.Windows.Forms.TextBox();
            this.rbtnOwnership = new System.Windows.Forms.RadioButton();
            this.rbtnInsats = new System.Windows.Forms.RadioButton();
            this.rbtnHyres = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTyp = new System.Windows.Forms.Label();
            this.cmbTyp = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFloor);
            this.groupBox1.Controls.Add(this.lblFloor);
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.txtStreet);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(433, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 202);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(111, 127);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(41, 26);
            this.txtFloor.TabIndex = 37;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.ForeColor = System.Drawing.Color.Black;
            this.lblFloor.Location = new System.Drawing.Point(7, 130);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(45, 20);
            this.lblFloor.TabIndex = 36;
            this.lblFloor.Text = "Floor";
            // 
            // txtZipCode
            // 
            this.txtZipCode.ForeColor = System.Drawing.Color.Black;
            this.txtZipCode.Location = new System.Drawing.Point(111, 85);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(83, 26);
            this.txtZipCode.TabIndex = 34;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(8, 81);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(95, 17);
            this.Label7.TabIndex = 29;
            this.Label7.Text = "ZipCode";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCity
            // 
            this.txtCity.ForeColor = System.Drawing.Color.Black;
            this.txtCity.Location = new System.Drawing.Point(111, 51);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(316, 26);
            this.txtCity.TabIndex = 33;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(8, 56);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(95, 17);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "City";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStreet
            // 
            this.txtStreet.ForeColor = System.Drawing.Color.Black;
            this.txtStreet.Location = new System.Drawing.Point(111, 20);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(316, 26);
            this.txtStreet.TabIndex = 32;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(8, 25);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(95, 17);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "Street";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 16;
            this.lstResults.Location = new System.Drawing.Point(23, 284);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(857, 292);
            this.lstResults.TabIndex = 35;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(303, 231);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(282, 33);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLandSize);
            this.groupBox2.Controls.Add(this.txtLandSize);
            this.groupBox2.Controls.Add(this.txtRooms);
            this.groupBox2.Controls.Add(this.txtPris);
            this.groupBox2.Controls.Add(this.rbtnOwnership);
            this.groupBox2.Controls.Add(this.rbtnInsats);
            this.groupBox2.Controls.Add(this.rbtnHyres);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblTyp);
            this.groupBox2.Controls.Add(this.cmbTyp);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 202);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Register new object";
            // 
            // lblLandSize
            // 
            this.lblLandSize.AutoSize = true;
            this.lblLandSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLandSize.Location = new System.Drawing.Point(18, 178);
            this.lblLandSize.Name = "lblLandSize";
            this.lblLandSize.Size = new System.Drawing.Size(113, 20);
            this.lblLandSize.TabIndex = 41;
            this.lblLandSize.Text = "Land size (m2)";
            // 
            // txtLandSize
            // 
            this.txtLandSize.Location = new System.Drawing.Point(250, 170);
            this.txtLandSize.Name = "txtLandSize";
            this.txtLandSize.Size = new System.Drawing.Size(121, 26);
            this.txtLandSize.TabIndex = 40;
            // 
            // txtRooms
            // 
            this.txtRooms.Location = new System.Drawing.Point(328, 104);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(43, 26);
            this.txtRooms.TabIndex = 39;
            this.txtRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPris
            // 
            this.txtPris.Location = new System.Drawing.Point(250, 136);
            this.txtPris.Name = "txtPris";
            this.txtPris.Size = new System.Drawing.Size(121, 26);
            this.txtPris.TabIndex = 39;
            this.txtPris.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnOwnership
            // 
            this.rbtnOwnership.AutoSize = true;
            this.rbtnOwnership.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOwnership.ForeColor = System.Drawing.Color.Black;
            this.rbtnOwnership.Location = new System.Drawing.Point(272, 65);
            this.rbtnOwnership.Name = "rbtnOwnership";
            this.rbtnOwnership.Size = new System.Drawing.Size(102, 24);
            this.rbtnOwnership.TabIndex = 37;
            this.rbtnOwnership.TabStop = true;
            this.rbtnOwnership.Text = "Ownership";
            this.rbtnOwnership.UseVisualStyleBackColor = true;
            // 
            // rbtnInsats
            // 
            this.rbtnInsats.AutoSize = true;
            this.rbtnInsats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnInsats.ForeColor = System.Drawing.Color.Black;
            this.rbtnInsats.Location = new System.Drawing.Point(130, 65);
            this.rbtnInsats.Name = "rbtnInsats";
            this.rbtnInsats.Size = new System.Drawing.Size(99, 24);
            this.rbtnInsats.TabIndex = 37;
            this.rbtnInsats.TabStop = true;
            this.rbtnInsats.Text = "Tenement";
            this.rbtnInsats.UseVisualStyleBackColor = true;
            // 
            // rbtnHyres
            // 
            this.rbtnHyres.AutoSize = true;
            this.rbtnHyres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHyres.ForeColor = System.Drawing.Color.Black;
            this.rbtnHyres.Location = new System.Drawing.Point(12, 65);
            this.rbtnHyres.Name = "rbtnHyres";
            this.rbtnHyres.Size = new System.Drawing.Size(74, 24);
            this.rbtnHyres.TabIndex = 38;
            this.rbtnHyres.TabStop = true;
            this.rbtnHyres.Text = "Rental";
            this.rbtnHyres.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Number of rooms";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Price";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyp.ForeColor = System.Drawing.Color.Black;
            this.lblTyp.Location = new System.Drawing.Point(12, 31);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(110, 20);
            this.lblTyp.TabIndex = 36;
            this.lblTyp.Text = "Type of estate";
            // 
            // cmbTyp
            // 
            this.cmbTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTyp.ForeColor = System.Drawing.Color.Black;
            this.cmbTyp.FormattingEnabled = true;
            this.cmbTyp.Location = new System.Drawing.Point(154, 31);
            this.cmbTyp.Name = "cmbTyp";
            this.cmbTyp.Size = new System.Drawing.Size(217, 28);
            this.cmbTyp.TabIndex = 35;
            this.cmbTyp.SelectedIndexChanged += new System.EventHandler(this.cmbTyp_SelectedIndexChanged);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(271, 582);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(146, 33);
            this.btnChange.TabIndex = 36;
            this.btnChange.Text = "&Change";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(481, 582);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 33);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Homes for sale";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtZipCode;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnInsats;
        private System.Windows.Forms.RadioButton rbtnHyres;
        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.ComboBox cmbTyp;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLandSize;
        private System.Windows.Forms.TextBox txtLandSize;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.RadioButton rbtnOwnership;
    }
}

