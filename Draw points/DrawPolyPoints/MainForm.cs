using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPolyPoints
{
    public partial class mainForm : Form
    {

        // Add graphics later. Rest is done bro!

        /*
         *** Program that traces coordinates clicked in the GUI ***
         
         1. Get and control user input
         2. Hide groupbox for user input and show groupbox with listbox
         3. Add a coordinate for each click in the listbox
         4. Check that the amount of clicks =< number put in by user.
         5. Reset is hit, all information is cleared.
        */

        private SavedCoordinates savedCoordinates;


        public mainForm()
        {
            InitializeComponent();
        }

        // Create an object with "x" length of SavedCoordinates, from the user input
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ReadInteger(txtNumberInput.Text))
            {
                int nrOfInput = int.Parse(txtNumberInput.Text);

                MessageBox.Show("Move your mouse and left-click to save the coordinates");
                this.savedCoordinates = new SavedCoordinates(nrOfInput);
                InitializeCoordinates();
            }
        }

        // Resets form, so the user can put in maximum amount of clicks again
        private void btnReset_Click(object sender, EventArgs e)
        {
            InitializeInput();
        }

        // Shows a listbox of coordinates and hides groupbox for maximum
        // amount of coordinates
        private void InitializeCoordinates()
        {
            grpInput.Visible = false;
            lblCoordinates.Visible = false;
            grpResult.Visible = true;
            btnReset.Visible = true;
            lstResult.Items.Clear();
        }

        // Shows groupbox for input and hides listbox with coordinates
        private void InitializeInput()
        {
            grpResult.Visible = false;
            btnReset.Visible = false;
            lblCoordinates.Visible = false;
            lblListFull.Visible = false;
            grpInput.Visible = true;
            Invalidate();
            txtNumberInput.Clear();
        }

        // Checking if user input for number is correct
        private bool ReadInteger(string numberText)
         {
            int numberOfPoints;

            bool ok = int.TryParse(numberText,out numberOfPoints);
            if (ok)            
                return (ok);
            
            MessageBox.Show("Wrong input!");
            return ok;
        }
        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!grpInput.Visible)
            {

                lblCoordinates.Text = "X = " + e.X + " ; Y = " + e.Y;
                lblCoordinates.Location = new Point(e.X + 10, e.Y + 10);
                Invalidate();
            }
        }

        // Adds the coordinates to the list box when left mouse button is clicked
        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!savedCoordinates.CheckListFull())
            {
                lblCoordinates.Text = "Saved!";
                savedCoordinates.SetCoordinate(e.X, e.Y);
                Invalidate();
                DrawListBox();
            }
            else
                lblListFull.Visible = true;

        }

        // Add information to listbox
        // We get the index and coordinate [x,y]
        // Then we update the information in the listbox
        private void DrawListBox()
        {
            int index = savedCoordinates.CurrIndex;
            int[] coordinate = savedCoordinates.GetCoordinate(index);

            string formated = String.Format("{0,0}{1,12}{2,24}",
                index.ToString(),
                coordinate[0].ToString(),
                coordinate[1].ToString());

            lstResult.Items.Add(formated);
            lstResult.Update();
        }

        // 1. Check that a valid number has been given
        // 2. Get coordinates and check so that atleast two coordinates have been given.
        // 3. Draw between previous and current coordinate
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (!grpInput.Visible)
            {
                int highestIndex = savedCoordinates.CurrIndex;

                int x1, y1, x2, y2;

                if (highestIndex > 1)
                    for(int index = 1; index < highestIndex; index++)
                    {
                        x1 = savedCoordinates.GetCoordinate(index)[0];
                        y1 = savedCoordinates.GetCoordinate(index)[1];
                        x2 = savedCoordinates.GetCoordinate(index+1)[0];
                        y2 = savedCoordinates.GetCoordinate(index+1)[1];

                        e.Graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
                    }
            }
        }

    }
}
