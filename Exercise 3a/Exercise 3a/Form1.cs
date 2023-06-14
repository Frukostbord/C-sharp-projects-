using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_3a
{
    public partial class MainForm : Form
    {

        TextConverter textConverter = new TextConverter();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            lblName.Text = String.Empty;
            lblName.ForeColor = Color.Black;
            lblName.BackColor = Color.Teal;
            lblName.Size = new Size(100, 25);
            this.Text = "First exercise with GUI";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            // Read and control input
            bool ok = CheckText();

            // If input is correct
            // 1. Manipulate string
            // 2. Show string
            if (ok)
            {
                lblName.Visible = true;
                lblName.Text = txtName.Text.Trim().ToUpper();
            }
            else
            {
                lblName.Visible = false;
                MessageBox.Show("You have to write something!");
            }

        }


        private bool CheckText()
        {
            if (txtName.Text.Length == 0)
                return false;
            return true;
        }

    }
}
