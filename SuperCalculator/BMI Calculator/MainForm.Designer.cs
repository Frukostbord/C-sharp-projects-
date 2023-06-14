namespace Super_Calculator
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeightKiloLbs = new System.Windows.Forms.TextBox();
            this.grpInputBMI = new System.Windows.Forms.GroupBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtHeightCmInches = new System.Windows.Forms.TextBox();
            this.txtHeightFeet = new System.Windows.Forms.TextBox();
            this.btnCalculateBMI = new System.Windows.Forms.Button();
            this.grpBMIResult = new System.Windows.Forms.GroupBox();
            this.lblNormalWeight = new System.Windows.Forms.Label();
            this.lblWeightCategory = new System.Windows.Forms.Label();
            this.lblNormalBMI = new System.Windows.Forms.Label();
            this.lblBMIResult = new System.Windows.Forms.Label();
            this.lblWeightCategoryText = new System.Windows.Forms.Label();
            this.lblBMI = new System.Windows.Forms.Label();
            this.grpUnitType = new System.Windows.Forms.GroupBox();
            this.radImperial = new System.Windows.Forms.RadioButton();
            this.radMetric = new System.Windows.Forms.RadioButton();
            this.btnCalculateSaving = new System.Windows.Forms.Button();
            this.grpSavingPlan = new System.Windows.Forms.GroupBox();
            this.lblMonthlyDeposit = new System.Windows.Forms.Label();
            this.lblYears = new System.Windows.Forms.Label();
            this.lblInterest = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartingAmount = new System.Windows.Forms.TextBox();
            this.txtMonthlyDeposit = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.grpFutureValue = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblFinalBalance = new System.Windows.Forms.Label();
            this.lblAmountEarned = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblAmountEarnedtxt = new System.Windows.Forms.Label();
            this.lblFinalBalancetxt = new System.Windows.Forms.Label();
            this.lblTotalFeestxt = new System.Windows.Forms.Label();
            this.lblAmountPaidtxt = new System.Windows.Forms.Label();
            this.grpBMRCalculator = new System.Windows.Forms.GroupBox();
            this.lstBMRResult = new System.Windows.Forms.ListBox();
            this.btnCalculateBMR = new System.Windows.Forms.Button();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblBMRAge = new System.Windows.Forms.Label();
            this.grpActivityLevel = new System.Windows.Forms.GroupBox();
            this.rbtnExtraActive = new System.Windows.Forms.RadioButton();
            this.rbtnVeryActive = new System.Windows.Forms.RadioButton();
            this.rbtnModerateActive = new System.Windows.Forms.RadioButton();
            this.rbtnLightActive = new System.Windows.Forms.RadioButton();
            this.rbtnSedentary = new System.Windows.Forms.RadioButton();
            this.grpBMRGender = new System.Windows.Forms.GroupBox();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.grpInputBMI.SuspendLayout();
            this.grpBMIResult.SuspendLayout();
            this.grpUnitType.SuspendLayout();
            this.grpSavingPlan.SuspendLayout();
            this.grpFutureValue.SuspendLayout();
            this.grpBMRCalculator.SuspendLayout();
            this.grpActivityLevel.SuspendLayout();
            this.grpBMRGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtWeightKiloLbs
            // 
            this.txtWeightKiloLbs.Location = new System.Drawing.Point(192, 108);
            this.txtWeightKiloLbs.Name = "txtWeightKiloLbs";
            this.txtWeightKiloLbs.Size = new System.Drawing.Size(87, 20);
            this.txtWeightKiloLbs.TabIndex = 4;
            // 
            // grpInputBMI
            // 
            this.grpInputBMI.Controls.Add(this.lblWeight);
            this.grpInputBMI.Controls.Add(this.lblHeight);
            this.grpInputBMI.Controls.Add(this.lblName);
            this.grpInputBMI.Controls.Add(this.txtHeightCmInches);
            this.grpInputBMI.Controls.Add(this.txtHeightFeet);
            this.grpInputBMI.Controls.Add(this.txtWeightKiloLbs);
            this.grpInputBMI.Controls.Add(this.txtName);
            this.grpInputBMI.Location = new System.Drawing.Point(12, 12);
            this.grpInputBMI.Name = "grpInputBMI";
            this.grpInputBMI.Size = new System.Drawing.Size(285, 170);
            this.grpInputBMI.TabIndex = 3;
            this.grpInputBMI.TabStop = false;
            this.grpInputBMI.Text = "BMI Calculator";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(6, 115);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(62, 13);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(6, 65);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(93, 13);
            this.lblHeight.TabIndex = 6;
            this.lblHeight.Text = "Height (m and cm)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // txtHeightCmInches
            // 
            this.txtHeightCmInches.Location = new System.Drawing.Point(203, 65);
            this.txtHeightCmInches.Name = "txtHeightCmInches";
            this.txtHeightCmInches.Size = new System.Drawing.Size(76, 20);
            this.txtHeightCmInches.TabIndex = 3;
            // 
            // txtHeightFeet
            // 
            this.txtHeightFeet.Location = new System.Drawing.Point(113, 65);
            this.txtHeightFeet.Name = "txtHeightFeet";
            this.txtHeightFeet.Size = new System.Drawing.Size(76, 20);
            this.txtHeightFeet.TabIndex = 2;
            // 
            // btnCalculateBMI
            // 
            this.btnCalculateBMI.Location = new System.Drawing.Point(81, 188);
            this.btnCalculateBMI.Name = "btnCalculateBMI";
            this.btnCalculateBMI.Size = new System.Drawing.Size(210, 37);
            this.btnCalculateBMI.TabIndex = 5;
            this.btnCalculateBMI.Text = "Calculate BMI";
            this.btnCalculateBMI.UseVisualStyleBackColor = true;
            this.btnCalculateBMI.Click += new System.EventHandler(this.btnCalculateBMI_Click);
            // 
            // grpBMIResult
            // 
            this.grpBMIResult.Controls.Add(this.lblNormalWeight);
            this.grpBMIResult.Controls.Add(this.lblWeightCategory);
            this.grpBMIResult.Controls.Add(this.lblNormalBMI);
            this.grpBMIResult.Controls.Add(this.lblBMIResult);
            this.grpBMIResult.Controls.Add(this.lblWeightCategoryText);
            this.grpBMIResult.Controls.Add(this.lblBMI);
            this.grpBMIResult.Location = new System.Drawing.Point(12, 270);
            this.grpBMIResult.Name = "grpBMIResult";
            this.grpBMIResult.Size = new System.Drawing.Size(372, 168);
            this.grpBMIResult.TabIndex = 6;
            this.grpBMIResult.TabStop = false;
            this.grpBMIResult.Text = "Results for <name>";
            // 
            // lblNormalWeight
            // 
            this.lblNormalWeight.AutoSize = true;
            this.lblNormalWeight.Location = new System.Drawing.Point(86, 134);
            this.lblNormalWeight.Name = "lblNormalWeight";
            this.lblNormalWeight.Size = new System.Drawing.Size(0, 13);
            this.lblNormalWeight.TabIndex = 8;
            // 
            // lblWeightCategory
            // 
            this.lblWeightCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeightCategory.Location = new System.Drawing.Point(192, 71);
            this.lblWeightCategory.Name = "lblWeightCategory";
            this.lblWeightCategory.Size = new System.Drawing.Size(155, 22);
            this.lblWeightCategory.TabIndex = 7;
            this.lblWeightCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNormalBMI
            // 
            this.lblNormalBMI.AutoSize = true;
            this.lblNormalBMI.Location = new System.Drawing.Point(86, 113);
            this.lblNormalBMI.Name = "lblNormalBMI";
            this.lblNormalBMI.Size = new System.Drawing.Size(0, 13);
            this.lblNormalBMI.TabIndex = 7;
            // 
            // lblBMIResult
            // 
            this.lblBMIResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBMIResult.Location = new System.Drawing.Point(192, 37);
            this.lblBMIResult.Name = "lblBMIResult";
            this.lblBMIResult.Size = new System.Drawing.Size(91, 22);
            this.lblBMIResult.TabIndex = 2;
            this.lblBMIResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeightCategoryText
            // 
            this.lblWeightCategoryText.AutoSize = true;
            this.lblWeightCategoryText.Location = new System.Drawing.Point(6, 76);
            this.lblWeightCategoryText.Name = "lblWeightCategoryText";
            this.lblWeightCategoryText.Size = new System.Drawing.Size(86, 13);
            this.lblWeightCategoryText.TabIndex = 1;
            this.lblWeightCategoryText.Text = "Weight Category";
            // 
            // lblBMI
            // 
            this.lblBMI.AutoSize = true;
            this.lblBMI.Location = new System.Drawing.Point(6, 42);
            this.lblBMI.Name = "lblBMI";
            this.lblBMI.Size = new System.Drawing.Size(26, 13);
            this.lblBMI.TabIndex = 0;
            this.lblBMI.Text = "BMI";
            // 
            // grpUnitType
            // 
            this.grpUnitType.Controls.Add(this.radImperial);
            this.grpUnitType.Controls.Add(this.radMetric);
            this.grpUnitType.Location = new System.Drawing.Point(331, 31);
            this.grpUnitType.Name = "grpUnitType";
            this.grpUnitType.Size = new System.Drawing.Size(163, 100);
            this.grpUnitType.TabIndex = 7;
            this.grpUnitType.TabStop = false;
            this.grpUnitType.Text = "Unit";
            // 
            // radImperial
            // 
            this.radImperial.AutoSize = true;
            this.radImperial.Location = new System.Drawing.Point(18, 52);
            this.radImperial.Name = "radImperial";
            this.radImperial.Size = new System.Drawing.Size(95, 17);
            this.radImperial.TabIndex = 1;
            this.radImperial.Text = "Imperial (lbs, ft)";
            this.radImperial.UseVisualStyleBackColor = true;
            this.radImperial.CheckedChanged += new System.EventHandler(this.radImperial_CheckedChanged);
            // 
            // radMetric
            // 
            this.radMetric.AutoSize = true;
            this.radMetric.Checked = true;
            this.radMetric.Location = new System.Drawing.Point(18, 29);
            this.radMetric.Name = "radMetric";
            this.radMetric.Size = new System.Drawing.Size(89, 17);
            this.radMetric.TabIndex = 0;
            this.radMetric.TabStop = true;
            this.radMetric.Text = "Metric (kg, m)";
            this.radMetric.UseVisualStyleBackColor = true;
            this.radMetric.CheckedChanged += new System.EventHandler(this.radMetric_CheckedChanged);
            // 
            // btnCalculateSaving
            // 
            this.btnCalculateSaving.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCalculateSaving.Location = new System.Drawing.Point(531, 237);
            this.btnCalculateSaving.Name = "btnCalculateSaving";
            this.btnCalculateSaving.Size = new System.Drawing.Size(210, 37);
            this.btnCalculateSaving.TabIndex = 8;
            this.btnCalculateSaving.Text = "Calculate Saving";
            this.btnCalculateSaving.UseVisualStyleBackColor = false;
            this.btnCalculateSaving.Click += new System.EventHandler(this.btnCalculateSaving_Click);
            // 
            // grpSavingPlan
            // 
            this.grpSavingPlan.Controls.Add(this.lblMonthlyDeposit);
            this.grpSavingPlan.Controls.Add(this.lblYears);
            this.grpSavingPlan.Controls.Add(this.lblInterest);
            this.grpSavingPlan.Controls.Add(this.lblFees);
            this.grpSavingPlan.Controls.Add(this.label1);
            this.grpSavingPlan.Controls.Add(this.txtStartingAmount);
            this.grpSavingPlan.Controls.Add(this.txtMonthlyDeposit);
            this.grpSavingPlan.Controls.Add(this.txtYears);
            this.grpSavingPlan.Controls.Add(this.txtInterest);
            this.grpSavingPlan.Controls.Add(this.txtFees);
            this.grpSavingPlan.Location = new System.Drawing.Point(500, 34);
            this.grpSavingPlan.Name = "grpSavingPlan";
            this.grpSavingPlan.Size = new System.Drawing.Size(270, 168);
            this.grpSavingPlan.TabIndex = 9;
            this.grpSavingPlan.TabStop = false;
            this.grpSavingPlan.Text = "Saving plan";
            // 
            // lblMonthlyDeposit
            // 
            this.lblMonthlyDeposit.AutoSize = true;
            this.lblMonthlyDeposit.Location = new System.Drawing.Point(6, 52);
            this.lblMonthlyDeposit.Name = "lblMonthlyDeposit";
            this.lblMonthlyDeposit.Size = new System.Drawing.Size(81, 13);
            this.lblMonthlyDeposit.TabIndex = 13;
            this.lblMonthlyDeposit.Text = "Monthly deposit";
            // 
            // lblYears
            // 
            this.lblYears.AutoSize = true;
            this.lblYears.Location = new System.Drawing.Point(6, 80);
            this.lblYears.Name = "lblYears";
            this.lblYears.Size = new System.Drawing.Size(71, 13);
            this.lblYears.TabIndex = 12;
            this.lblYears.Text = "Period (years)";
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Location = new System.Drawing.Point(6, 106);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(118, 13);
            this.lblInterest.TabIndex = 11;
            this.lblInterest.Text = "Growth (or interest) in %";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Location = new System.Drawing.Point(6, 132);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(52, 13);
            this.lblFees.TabIndex = 10;
            this.lblFees.Text = "Fees in %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Starting amount";
            // 
            // txtStartingAmount
            // 
            this.txtStartingAmount.Location = new System.Drawing.Point(188, 19);
            this.txtStartingAmount.Name = "txtStartingAmount";
            this.txtStartingAmount.Size = new System.Drawing.Size(76, 20);
            this.txtStartingAmount.TabIndex = 0;
            // 
            // txtMonthlyDeposit
            // 
            this.txtMonthlyDeposit.Location = new System.Drawing.Point(188, 49);
            this.txtMonthlyDeposit.Name = "txtMonthlyDeposit";
            this.txtMonthlyDeposit.Size = new System.Drawing.Size(76, 20);
            this.txtMonthlyDeposit.TabIndex = 1;
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(187, 77);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(76, 20);
            this.txtYears.TabIndex = 2;
            // 
            // txtInterest
            // 
            this.txtInterest.Location = new System.Drawing.Point(187, 103);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(76, 20);
            this.txtInterest.TabIndex = 3;
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(188, 129);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(76, 20);
            this.txtFees.TabIndex = 4;
            // 
            // grpFutureValue
            // 
            this.grpFutureValue.Controls.Add(this.lblTotalFees);
            this.grpFutureValue.Controls.Add(this.lblFinalBalance);
            this.grpFutureValue.Controls.Add(this.lblAmountEarned);
            this.grpFutureValue.Controls.Add(this.lblAmountPaid);
            this.grpFutureValue.Controls.Add(this.lblAmountEarnedtxt);
            this.grpFutureValue.Controls.Add(this.lblFinalBalancetxt);
            this.grpFutureValue.Controls.Add(this.lblTotalFeestxt);
            this.grpFutureValue.Controls.Add(this.lblAmountPaidtxt);
            this.grpFutureValue.Location = new System.Drawing.Point(500, 300);
            this.grpFutureValue.Name = "grpFutureValue";
            this.grpFutureValue.Size = new System.Drawing.Size(270, 138);
            this.grpFutureValue.TabIndex = 10;
            this.grpFutureValue.TabStop = false;
            this.grpFutureValue.Text = "Future value";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalFees.Location = new System.Drawing.Point(172, 99);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(91, 22);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinalBalance
            // 
            this.lblFinalBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFinalBalance.Location = new System.Drawing.Point(172, 74);
            this.lblFinalBalance.Name = "lblFinalBalance";
            this.lblFinalBalance.Size = new System.Drawing.Size(91, 22);
            this.lblFinalBalance.TabIndex = 17;
            this.lblFinalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountEarned
            // 
            this.lblAmountEarned.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountEarned.Location = new System.Drawing.Point(172, 50);
            this.lblAmountEarned.Name = "lblAmountEarned";
            this.lblAmountEarned.Size = new System.Drawing.Size(91, 22);
            this.lblAmountEarned.TabIndex = 16;
            this.lblAmountEarned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountPaid.Location = new System.Drawing.Point(172, 24);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(91, 22);
            this.lblAmountPaid.TabIndex = 15;
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountEarnedtxt
            // 
            this.lblAmountEarnedtxt.AutoSize = true;
            this.lblAmountEarnedtxt.Location = new System.Drawing.Point(6, 55);
            this.lblAmountEarnedtxt.Name = "lblAmountEarnedtxt";
            this.lblAmountEarnedtxt.Size = new System.Drawing.Size(79, 13);
            this.lblAmountEarnedtxt.TabIndex = 13;
            this.lblAmountEarnedtxt.Text = "Amount earned";
            // 
            // lblFinalBalancetxt
            // 
            this.lblFinalBalancetxt.AutoSize = true;
            this.lblFinalBalancetxt.Location = new System.Drawing.Point(6, 79);
            this.lblFinalBalancetxt.Name = "lblFinalBalancetxt";
            this.lblFinalBalancetxt.Size = new System.Drawing.Size(70, 13);
            this.lblFinalBalancetxt.TabIndex = 12;
            this.lblFinalBalancetxt.Text = "Final balance";
            // 
            // lblTotalFeestxt
            // 
            this.lblTotalFeestxt.AutoSize = true;
            this.lblTotalFeestxt.Location = new System.Drawing.Point(6, 104);
            this.lblTotalFeestxt.Name = "lblTotalFeestxt";
            this.lblTotalFeestxt.Size = new System.Drawing.Size(54, 13);
            this.lblTotalFeestxt.TabIndex = 11;
            this.lblTotalFeestxt.Text = "Total fees";
            // 
            // lblAmountPaidtxt
            // 
            this.lblAmountPaidtxt.AutoSize = true;
            this.lblAmountPaidtxt.Location = new System.Drawing.Point(6, 29);
            this.lblAmountPaidtxt.Name = "lblAmountPaidtxt";
            this.lblAmountPaidtxt.Size = new System.Drawing.Size(66, 13);
            this.lblAmountPaidtxt.TabIndex = 9;
            this.lblAmountPaidtxt.Text = "Amount paid";
            // 
            // grpBMRCalculator
            // 
            this.grpBMRCalculator.Controls.Add(this.lstBMRResult);
            this.grpBMRCalculator.Controls.Add(this.btnCalculateBMR);
            this.grpBMRCalculator.Controls.Add(this.txtAge);
            this.grpBMRCalculator.Controls.Add(this.lblBMRAge);
            this.grpBMRCalculator.Controls.Add(this.grpActivityLevel);
            this.grpBMRCalculator.Controls.Add(this.grpBMRGender);
            this.grpBMRCalculator.Location = new System.Drawing.Point(12, 444);
            this.grpBMRCalculator.Name = "grpBMRCalculator";
            this.grpBMRCalculator.Size = new System.Drawing.Size(758, 270);
            this.grpBMRCalculator.TabIndex = 12;
            this.grpBMRCalculator.TabStop = false;
            this.grpBMRCalculator.Text = "BMR Calculator";
            // 
            // lstBMRResult
            // 
            this.lstBMRResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBMRResult.FormattingEnabled = true;
            this.lstBMRResult.ItemHeight = 14;
            this.lstBMRResult.Location = new System.Drawing.Point(353, 20);
            this.lstBMRResult.Name = "lstBMRResult";
            this.lstBMRResult.Size = new System.Drawing.Size(398, 172);
            this.lstBMRResult.TabIndex = 7;
            // 
            // btnCalculateBMR
            // 
            this.btnCalculateBMR.Location = new System.Drawing.Point(141, 227);
            this.btnCalculateBMR.Name = "btnCalculateBMR";
            this.btnCalculateBMR.Size = new System.Drawing.Size(206, 37);
            this.btnCalculateBMR.TabIndex = 6;
            this.btnCalculateBMR.Text = "Calculate BMR";
            this.btnCalculateBMR.UseVisualStyleBackColor = true;
            this.btnCalculateBMR.Click += new System.EventHandler(this.btnCalculateBMR_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(69, 158);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(49, 20);
            this.txtAge.TabIndex = 4;
            // 
            // lblBMRAge
            // 
            this.lblBMRAge.AutoSize = true;
            this.lblBMRAge.Location = new System.Drawing.Point(6, 161);
            this.lblBMRAge.Name = "lblBMRAge";
            this.lblBMRAge.Size = new System.Drawing.Size(26, 13);
            this.lblBMRAge.TabIndex = 3;
            this.lblBMRAge.Text = "Age";
            // 
            // grpActivityLevel
            // 
            this.grpActivityLevel.Controls.Add(this.rbtnExtraActive);
            this.grpActivityLevel.Controls.Add(this.rbtnVeryActive);
            this.grpActivityLevel.Controls.Add(this.rbtnModerateActive);
            this.grpActivityLevel.Controls.Add(this.rbtnLightActive);
            this.grpActivityLevel.Controls.Add(this.rbtnSedentary);
            this.grpActivityLevel.Location = new System.Drawing.Point(141, 20);
            this.grpActivityLevel.Name = "grpActivityLevel";
            this.grpActivityLevel.Size = new System.Drawing.Size(206, 194);
            this.grpActivityLevel.TabIndex = 2;
            this.grpActivityLevel.TabStop = false;
            this.grpActivityLevel.Text = "Weekly activity level";
            // 
            // rbtnExtraActive
            // 
            this.rbtnExtraActive.AutoSize = true;
            this.rbtnExtraActive.Location = new System.Drawing.Point(6, 166);
            this.rbtnExtraActive.Name = "rbtnExtraActive";
            this.rbtnExtraActive.Size = new System.Drawing.Size(184, 17);
            this.rbtnExtraActive.TabIndex = 5;
            this.rbtnExtraActive.TabStop = true;
            this.rbtnExtraActive.Text = "Extra active, hard exercises or job";
            this.rbtnExtraActive.UseVisualStyleBackColor = true;
            // 
            // rbtnVeryActive
            // 
            this.rbtnVeryActive.AutoSize = true;
            this.rbtnVeryActive.Location = new System.Drawing.Point(6, 132);
            this.rbtnVeryActive.Name = "rbtnVeryActive";
            this.rbtnVeryActive.Size = new System.Drawing.Size(142, 17);
            this.rbtnVeryActive.TabIndex = 4;
            this.rbtnVeryActive.TabStop = true;
            this.rbtnVeryActive.Text = "Very Active (6 to 7 times)";
            this.rbtnVeryActive.UseVisualStyleBackColor = true;
            // 
            // rbtnModerateActive
            // 
            this.rbtnModerateActive.AutoSize = true;
            this.rbtnModerateActive.Checked = true;
            this.rbtnModerateActive.Location = new System.Drawing.Point(6, 98);
            this.rbtnModerateActive.Name = "rbtnModerateActive";
            this.rbtnModerateActive.Size = new System.Drawing.Size(173, 17);
            this.rbtnModerateActive.TabIndex = 3;
            this.rbtnModerateActive.TabStop = true;
            this.rbtnModerateActive.Text = "Moderately Active (3 to 5 times)";
            this.rbtnModerateActive.UseVisualStyleBackColor = true;
            // 
            // rbtnLightActive
            // 
            this.rbtnLightActive.AutoSize = true;
            this.rbtnLightActive.Location = new System.Drawing.Point(6, 63);
            this.rbtnLightActive.Name = "rbtnLightActive";
            this.rbtnLightActive.Size = new System.Drawing.Size(150, 17);
            this.rbtnLightActive.TabIndex = 2;
            this.rbtnLightActive.TabStop = true;
            this.rbtnLightActive.Text = "Lightly active (1 to 3 times)";
            this.rbtnLightActive.UseVisualStyleBackColor = true;
            // 
            // rbtnSedentary
            // 
            this.rbtnSedentary.AutoSize = true;
            this.rbtnSedentary.Location = new System.Drawing.Point(6, 30);
            this.rbtnSedentary.Name = "rbtnSedentary";
            this.rbtnSedentary.Size = new System.Drawing.Size(169, 17);
            this.rbtnSedentary.TabIndex = 1;
            this.rbtnSedentary.TabStop = true;
            this.rbtnSedentary.Text = "Sedentary (little to no exercise)";
            this.rbtnSedentary.UseVisualStyleBackColor = true;
            // 
            // grpBMRGender
            // 
            this.grpBMRGender.Controls.Add(this.rbtnFemale);
            this.grpBMRGender.Controls.Add(this.rbtnMale);
            this.grpBMRGender.Location = new System.Drawing.Point(9, 19);
            this.grpBMRGender.Name = "grpBMRGender";
            this.grpBMRGender.Size = new System.Drawing.Size(125, 81);
            this.grpBMRGender.TabIndex = 1;
            this.grpBMRGender.TabStop = false;
            this.grpBMRGender.Text = "Gender";
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(6, 42);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(59, 17);
            this.rbtnFemale.TabIndex = 1;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Checked = true;
            this.rbtnMale.Location = new System.Drawing.Point(6, 19);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(48, 17);
            this.rbtnMale.TabIndex = 0;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 726);
            this.Controls.Add(this.grpBMRCalculator);
            this.Controls.Add(this.grpFutureValue);
            this.Controls.Add(this.grpSavingPlan);
            this.Controls.Add(this.btnCalculateSaving);
            this.Controls.Add(this.grpUnitType);
            this.Controls.Add(this.grpBMIResult);
            this.Controls.Add(this.btnCalculateBMI);
            this.Controls.Add(this.grpInputBMI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Calculator by Andreas Hägglund";
            this.grpInputBMI.ResumeLayout(false);
            this.grpInputBMI.PerformLayout();
            this.grpBMIResult.ResumeLayout(false);
            this.grpBMIResult.PerformLayout();
            this.grpUnitType.ResumeLayout(false);
            this.grpUnitType.PerformLayout();
            this.grpSavingPlan.ResumeLayout(false);
            this.grpSavingPlan.PerformLayout();
            this.grpFutureValue.ResumeLayout(false);
            this.grpFutureValue.PerformLayout();
            this.grpBMRCalculator.ResumeLayout(false);
            this.grpBMRCalculator.PerformLayout();
            this.grpActivityLevel.ResumeLayout(false);
            this.grpActivityLevel.PerformLayout();
            this.grpBMRGender.ResumeLayout(false);
            this.grpBMRGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWeightKiloLbs;
        private System.Windows.Forms.GroupBox grpInputBMI;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtHeightCmInches;
        private System.Windows.Forms.TextBox txtHeightFeet;
        private System.Windows.Forms.Button btnCalculateBMI;
        private System.Windows.Forms.GroupBox grpBMIResult;
        private System.Windows.Forms.Label lblNormalWeight;
        private System.Windows.Forms.Label lblWeightCategory;
        private System.Windows.Forms.Label lblNormalBMI;
        private System.Windows.Forms.Label lblBMIResult;
        private System.Windows.Forms.Label lblWeightCategoryText;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.GroupBox grpUnitType;
        private System.Windows.Forms.RadioButton radImperial;
        private System.Windows.Forms.RadioButton radMetric;
        private System.Windows.Forms.Button btnCalculateSaving;
        private System.Windows.Forms.GroupBox grpSavingPlan;
        private System.Windows.Forms.Label lblMonthlyDeposit;
        private System.Windows.Forms.Label lblYears;
        private System.Windows.Forms.Label lblInterest;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartingAmount;
        private System.Windows.Forms.TextBox txtMonthlyDeposit;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.GroupBox grpFutureValue;
        private System.Windows.Forms.Label lblAmountEarnedtxt;
        private System.Windows.Forms.Label lblFinalBalancetxt;
        private System.Windows.Forms.Label lblTotalFeestxt;
        private System.Windows.Forms.Label lblAmountPaidtxt;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblFinalBalance;
        private System.Windows.Forms.Label lblAmountEarned;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.GroupBox grpBMRCalculator;
        private System.Windows.Forms.Button btnCalculateBMR;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblBMRAge;
        private System.Windows.Forms.GroupBox grpActivityLevel;
        private System.Windows.Forms.GroupBox grpBMRGender;
        private System.Windows.Forms.ListBox lstBMRResult;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnExtraActive;
        private System.Windows.Forms.RadioButton rbtnVeryActive;
        private System.Windows.Forms.RadioButton rbtnModerateActive;
        private System.Windows.Forms.RadioButton rbtnLightActive;
        private System.Windows.Forms.RadioButton rbtnSedentary;
        private System.Windows.Forms.RadioButton rbtnFemale;
    }
}

