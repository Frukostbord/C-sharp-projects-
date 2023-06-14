using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_3b
{
    public partial class MainForm : Form
    {

        Calculate calculate = new Calculate();
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }
        
        private void InitializeGUI()
        {
            // Header
            this.Text = "Root/square root calculator";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Check if value is inserted
            // 2. Check if value is correct
            // 3. Calculate
            // 4. Display result

            bool ok = CheckInput();

            // Displays answer
            if (ok)
            {
                lblAnswer.Visible = true;
                double number = double.Parse(txtNumber.Text);

                {
                    if (radSqr.Checked)
                    {
                        lblAnswer.Text = (calculate.Square(number).ToString());
                    }

                    else if (radSqrRoot.Checked)
                    { 
                        lblAnswer.Text = (calculate.SquareRoot(number).ToString());
                    }
                }
                   
            }

            else
            {
                lblAnswer.Visible = false;
                MessageBox.Show("Please look over your input");
            }
                        

        }

        private bool CheckInput()
        {
            // Control for input length and value
            // Calls other method to control for value

            bool value = CheckValue();
            if (txtNumber.Text.Length != 0 && value)
                return true;
            else
                return false;
            

        }

        private bool CheckValue()
        {
            // Check if number is correctly put in.

            double number;
            txtNumber.Text = txtNumber.Text.Trim();
            bool ok = double.TryParse(txtNumber.Text, out number);

            if (ok)
                return true;

            return false;
            

        }

    }
}
