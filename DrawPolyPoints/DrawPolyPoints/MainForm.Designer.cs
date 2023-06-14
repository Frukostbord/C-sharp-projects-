namespace DrawPolyPoints
{
    partial class mainForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtNumberInput = new System.Windows.Forms.TextBox();
            this.lblPointsToSave = new System.Windows.Forms.Label();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblYCoordinate = new System.Windows.Forms.Label();
            this.lblXcoordinate = new System.Windows.Forms.Label();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblListFull = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.grpInput.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(65, 69);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtNumberInput);
            this.grpInput.Controls.Add(this.lblPointsToSave);
            this.grpInput.Controls.Add(this.btnOK);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(233, 107);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // txtNumberInput
            // 
            this.txtNumberInput.Location = new System.Drawing.Point(152, 32);
            this.txtNumberInput.Name = "txtNumberInput";
            this.txtNumberInput.Size = new System.Drawing.Size(75, 20);
            this.txtNumberInput.TabIndex = 2;
            this.txtNumberInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPointsToSave
            // 
            this.lblPointsToSave.AutoSize = true;
            this.lblPointsToSave.Location = new System.Drawing.Point(6, 35);
            this.lblPointsToSave.Name = "lblPointsToSave";
            this.lblPointsToSave.Size = new System.Drawing.Size(113, 13);
            this.lblPointsToSave.TabIndex = 1;
            this.lblPointsToSave.Text = "Num of Points to Save";
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lblYCoordinate);
            this.grpResult.Controls.Add(this.lblXcoordinate);
            this.grpResult.Controls.Add(this.lstResult);
            this.grpResult.Location = new System.Drawing.Point(251, 22);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(200, 335);
            this.grpResult.TabIndex = 2;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Registered points";
            this.grpResult.Visible = false;
            // 
            // lblYCoordinate
            // 
            this.lblYCoordinate.AutoSize = true;
            this.lblYCoordinate.Location = new System.Drawing.Point(132, 19);
            this.lblYCoordinate.Name = "lblYCoordinate";
            this.lblYCoordinate.Size = new System.Drawing.Size(14, 13);
            this.lblYCoordinate.TabIndex = 4;
            this.lblYCoordinate.Text = "Y";
            // 
            // lblXcoordinate
            // 
            this.lblXcoordinate.AutoSize = true;
            this.lblXcoordinate.Location = new System.Drawing.Point(76, 19);
            this.lblXcoordinate.Name = "lblXcoordinate";
            this.lblXcoordinate.Size = new System.Drawing.Size(14, 13);
            this.lblXcoordinate.TabIndex = 3;
            this.lblXcoordinate.Text = "X";
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(6, 41);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(188, 277);
            this.lstResult.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(297, 363);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 25);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblListFull
            // 
            this.lblListFull.AutoSize = true;
            this.lblListFull.Location = new System.Drawing.Point(327, 428);
            this.lblListFull.Name = "lblListFull";
            this.lblListFull.Size = new System.Drawing.Size(70, 13);
            this.lblListFull.TabIndex = 4;
            this.lblListFull.Text = "The list is full!";
            this.lblListFull.Visible = false;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinates.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCoordinates.Location = new System.Drawing.Point(126, 260);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(0, 16);
            this.lblCoordinates.TabIndex = 5;
            this.lblCoordinates.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.lblListFull);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.grpInput);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "mainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "                                                                                 " +
    "                             Draw point";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseUp);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtNumberInput;
        private System.Windows.Forms.Label lblPointsToSave;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lblYCoordinate;
        private System.Windows.Forms.Label lblXcoordinate;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblListFull;
        private System.Windows.Forms.Label lblCoordinates;
    }
}

