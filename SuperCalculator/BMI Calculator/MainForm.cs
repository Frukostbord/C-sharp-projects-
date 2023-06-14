// The assignments is divided in to four regions. The last assignment has two regions.

using Super_Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Calculator
{


    public partial class MainForm : Form
    {
        private BMICalculator bmiCalc = new BMICalculator();
        private SavingsCalculator savingsCalc = new SavingsCalculator();
        private BMRCalculator bmrCalc = new BMRCalculator();    

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }
        #region BMI Calculator
        private void InitializeGUI()
        {
            // Header text
            this.Text = "Super calculator by Andreas Hägglund";

            // Display information and cosmetics
            lblWeight.Text = "Weight (kg)";
            lblHeight.Text = "Height (cm)";
            lblNormalBMI.Text = "Normal BMI is between 18,50 and 24,9";
            lblNormalBMI.ForeColor = Color.DarkOliveGreen;

            // Clearing text windows
            txtWeightKiloLbs.Text = string.Empty;
            txtHeightFeet.Text = string.Empty;
            txtHeightCmInches.Text = string.Empty;

            // Hiding text window
            txtHeightFeet.Visible = false;
        }

        private void btnCalculateBMI_Click(object sender, EventArgs e)
        {
            // Checking user name
            ReadNameBMI();

            // Checking if input is correct
            bool ok = ReadNumericalInputBMI();
            
            // Displaying result
            if (ok)                
                DisplayResult();
        }
       

        private void ReadNameBMI()
        {
            // Trims string
            string name = txtName.Text.Trim();

            // Sets user´s name
            bmiCalc.SetName(name);
        }

        private bool ReadNumericalInputBMI()
        {
            // Local variables to be used for controlling user input
            bool height = ReadHeightBMI();
            bool weight = ReadWeightBMI();

            if (!height)
                MessageBox.Show("Something went wrong with the height input.");
            if (!weight)
                MessageBox.Show("Something went wrong with the weight input.");

            return height && weight;
        }

        private bool ReadHeightBMI()
        {           
            double height = 0;
            bool ok;

            // Trimming input text
            txtHeightFeet.Text = txtHeightFeet.Text.Trim();
            txtHeightCmInches.Text = txtHeightCmInches.Text.Trim();

            // Checking for correct input            
            ok = double.TryParse(txtHeightCmInches.Text, out height);

            // 1. Check if input is correct and Unittype
            // 2. Set height
            // 3. Return boolean value
            if (ok)
            {
                double feet;
                bool okFeet = double.TryParse(txtHeightFeet.Text, out feet);

                if (bmiCalc.GetUnit() == UnitTypes.Imperial && okFeet)
                {
                    height = feet * 12 + height;
                }     
            }

            // Set height
            bmiCalc.SetHeight(height);

            return ok;    
        }

        private bool ReadWeightBMI()
        {
            // Local variable
            double weight;

            // Trimming input text
            txtWeightKiloLbs.Text = txtWeightKiloLbs.Text.Trim();

            // Checking for correct input
            bool ok = double.TryParse(txtWeightKiloLbs.Text, out weight);

            // Set weight
            bmiCalc.SetWeight(weight);

            // If input is correct return true, else false
            return ok;

        }
        
        private void DisplayResult()
        {
            // Local variables
            double bmi = bmiCalc.CalculateBMI();
            string minWeight = bmiCalc.GetMinimumWeight().ToString("f2");
            string maxWeight = bmiCalc.GetMaximumWeight().ToString("f2");
            string unit;

            if (bmiCalc.GetUnit() == UnitTypes.Imperial)
                unit = "lbs";
            else
                unit = "kg";

            // Formatting healthy weight
            string normalWeightSpan = String.Format("Normal weight is between {0} {1} and {2} {3}",
                minWeight, unit, maxWeight, unit);



            // Displaying results to the user
            lblBMIResult.Text = bmi.ToString("f2");
            lblWeightCategory.Text = bmiCalc.BMIWeightCategory().ToString();
            grpBMIResult.Text = "Results for " + bmiCalc.GetName();
            lblNormalWeight.Text = normalWeightSpan;



        }
  

        private void radMetric_CheckedChanged(object sender, EventArgs e)
        {
            // Hiding textbox
            txtHeightFeet.Visible = false;

            // Changing label information to Metric
            lblWeight.Text = "Weight (kg)";
            lblHeight.Text = "Height (cm)";
            bmiCalc.SetUnit(UnitTypes.Metric);
        }

        private void radImperial_CheckedChanged(object sender, EventArgs e)
        {
            // Showing textbox
            txtHeightFeet.Visible = true;

            // Changing label information to Imperial
            lblWeight.Text = "Weight (lbs)";
            lblHeight.Text = "Height (ft and in)";
            bmiCalc.SetUnit(UnitTypes.Imperial);
        }


        #endregion

        #region Savings calculator        
        
        //1. Read information for each input
        //2. Check if information is valid
        //3. Set information
        //4. Retreive information if input is correct
        private void btnCalculateSaving_Click(object sender, EventArgs e)
        {
            // Check input
            bool correctInput = CheckInputSavings();

            if (correctInput)
                DisplaySavings();

        }



        private bool CheckInputSavings()
        {

            // Checking input
            bool start = ReadStartingAmount();
            bool deposit = ReadMonthlyDeposit();
            bool monthly = ReadInterestRate();
            bool years = ReadYears();
            bool fees = ReadFees();

            bool ok = (start && deposit && monthly && years && fees);

            return ok;

        }

        private bool ReadStartingAmount()
        {
            double startingMoney;

            bool ok = double.TryParse(txtStartingAmount.Text, out startingMoney);

            if (ok)
                savingsCalc.StartingAmount = startingMoney;
            else
                MessageBox.Show("Please look over your input for starting money");

            return ok;

        }
        private bool ReadMonthlyDeposit()
        {
            double deposit;

            bool ok = double.TryParse(txtMonthlyDeposit.Text, out deposit);

            if (ok)
                savingsCalc.MonthlyDeposit = deposit;
            else
                MessageBox.Show("Please look over your input for monthly deposit");

            return ok;

        }

        private bool ReadYears()
        {
            int years;

            bool ok = int.TryParse(txtYears.Text, out years);

            if (ok)
                savingsCalc.Years = years;
            else
                MessageBox.Show("Please look over your input for years");

            return ok;

        }

        private bool ReadInterestRate()
        {
            double interest;

            bool ok = double.TryParse(txtInterest.Text, out interest);

            if (ok)
                savingsCalc.Interest = interest;
            else
                MessageBox.Show("Please look over your input for interest");


            return ok;

        }

        private bool ReadFees()
        {
            double fee;

            bool ok = double.TryParse(txtFees.Text, out fee);

            if (ok)
                savingsCalc.Fees = fee;
            else
                MessageBox.Show("Please look over your input for fees");

            return ok;
        }


        private void DisplaySavings()
        {
            lblAmountPaid.Text = savingsCalc.AmountPaid().ToString("f2");
            lblAmountEarned.Text = savingsCalc.AmountEarned().ToString("f2");
            lblFinalBalance.Text = savingsCalc.FinalBalance().ToString("f2");
            lblTotalFees.Text = savingsCalc.TotalFees().ToString("f2");


        }

        #endregion

        #region BMR Calculator - Read Input

        // 1. Reads all input once the "Calculate BMR" is clicked
        // 2. Check if numeric input is correct
        // 3. Set all data for radio buttons (with enums) and from textboxes
        // 4. Calculate and display BMR from the data that´s been read

        // Main button for calculating BMR
        private void btnCalculateBMR_Click(object sender, EventArgs e)
        {
            // Input via radiobuttons
            ReadNameBMR();
            ReadGender();
            ReadActivityLevel();
            ReadUnitTypeBMR();

            // Check input in textboxes from user
            bool ok = ReadInputBMR(); 

            if (ok)
                CalculateAndDisplayResultBMR();
        }


        // Checking numerical input is correct
        private bool ReadInputBMR()
        {
            bool ok = ReadAge() && ReadWeightBMR() && ReadHeightBMR();

            if (!ReadHeightBMR())
                MessageBox.Show("Please look over your input for Height");
            if (!ReadWeightBMR())
                MessageBox.Show("Please look over your input for Weight");
            if (!ReadAge())
                MessageBox.Show("Please look over your input for Age");

            return ok;
        }

        // Sets and checks for correct input of age for future calculations
        private bool ReadAge()
        {
            int age;
            bool ok = int.TryParse(txtAge.Text, out age);

            if (ok)
                return true;
            return false;
        }

        // Set and control weight for future calculation
        private bool ReadWeightBMR()
        {
            double weight;

            txtWeightKiloLbs.Text = txtWeightKiloLbs.Text.Trim();
            bool ok = double.TryParse(txtWeightKiloLbs.Text, out weight);
            
            // Converting to kilograms
            if (bmrCalc.Unit == UnitTypes.Imperial)
                bmrCalc.Weight = weight* 0.45359237;
            else
                bmrCalc.Weight = weight;

            if (ok)
                return ok;
            return false;       
        }
        // Sets username
        private void ReadNameBMR()
        {
            string name = txtName.Text.Trim();
            bmrCalc.Name = txtName.Text;
        }

        // Set and control height for future calculation
        private bool ReadHeightBMR()
        {
            double height = 0;
            bool ok;

            txtHeightFeet.Text = txtHeightFeet.Text.Trim();
            txtHeightCmInches.Text = txtHeightCmInches.Text.Trim();
         
            ok = double.TryParse(txtHeightCmInches.Text, out height);
            
            // Calculating height depending on unit type (Metric or Imperial)
            if (ok)
            {
                double feet;
                bool okFeet = double.TryParse(txtHeightFeet.Text, out feet);

                if (bmiCalc.GetUnit() == UnitTypes.Imperial && okFeet)
                {
                    // Converting to cm
                    height = 2.54 * (feet * 12 + height);
                }
            }

            // Set height
            bmrCalc.Height = height;

            if (ok)
                return true;
            return false;
        }

        // Set enum value (Gender) in BMRCalc class depending on radiobutton chosen.
        private void ReadGender()
        {
            if (rbtnMale.Checked)
                bmrCalc.Gender = Gender.Male;
            else
                bmrCalc.Gender = Gender.Female;
        }

        // Set enum value (Activity level) in BMRCalc class depending on radiobutton chosen.
        private void ReadActivityLevel()
        {
            if (rbtnSedentary.Checked)
                bmrCalc.ActivityLevel = Activity_Level.Sedentary;
            else if (rbtnLightActive.Checked)
                bmrCalc.ActivityLevel = Activity_Level.Lightly_Active;
            else if (rbtnModerateActive.Checked)
                bmrCalc.ActivityLevel = Activity_Level.Moderately_Active;
            else if (rbtnVeryActive.Checked)
                bmrCalc.ActivityLevel = Activity_Level.Very_Active;
            else
                bmrCalc.ActivityLevel = Activity_Level.Extra_Active;
        }
        
        // Set enum value (Imperial or Metric) in BMRCalc class depending on radiobutton chosen
        private void ReadUnitTypeBMR()
        {
            if (radImperial.Checked)
                bmrCalc.Unit = UnitTypes.Imperial;
            else
                bmrCalc.Unit = UnitTypes.Metric;
        }


        #endregion


        #region BMR Calculator - Calculate & Display result

        // Calculating and displaying result
        // Just adding values from an method that returns an array (see method in BMRCalculator)
        private void CalculateAndDisplayResultBMR()
        {
            // Method for calorie intake needed to maintain, lose or gain weight
            double[] bmr_array = bmrCalc.CalculateBMR();

            lstBMRResult.Items.Clear();

            
            lstBMRResult.Items.Add($"BMR result for: " + bmrCalc.Name.ToUpper());
            lstBMRResult.Items.Add("");
            lstBMRResult.Items.Add("");
            lstBMRResult.Items.Add(string.Format("** Your BMR (calories/day):" + "{0,20}", bmr_array[0].ToString("f1")));
            lstBMRResult.Items.Add(string.Format("* Calories to maintain your weight:" + "{0,12}", bmr_array[1].ToString("f1")));
            lstBMRResult.Items.Add(string.Format("* Calories to lose 0,5 kg per week:" + "{0,12}", bmr_array[2].ToString("f1")));
            lstBMRResult.Items.Add(string.Format("* Calories to lose 1 kg per week:" + "{0,14}", bmr_array[3].ToString("f1")));
            lstBMRResult.Items.Add(string.Format("* Calories to gain 0,5 kg per week: {0,11}", bmr_array[4].ToString("f1")));
            lstBMRResult.Items.Add(string.Format("* Calories to gain 1 kg per week: {0,13}", bmr_array[5].ToString("f1")));
            lstBMRResult.Items.Add("");
            lstBMRResult.Items.Add("Don´t exceed more than a 1000 calorie deficit");

            lstBMRResult.Update();

        }
        #endregion
    }


}
