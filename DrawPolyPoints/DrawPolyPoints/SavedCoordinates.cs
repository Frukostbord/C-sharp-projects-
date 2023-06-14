using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPolyPoints
{
    /*
    This class creates a list for x,y coordinates and updates them
    */
    public class SavedCoordinates
    {
        private int[,] coordinates;
        private int currIndex;

        // Constructor creating the list of coordinates and sets index to 0
        public SavedCoordinates(int size)
        {
            coordinates = new int[size, 2];
            currIndex = 0;
        }

        // Sets a coordinate in the list
        public void SetCoordinate(int x, int y)
        {
                coordinates[currIndex, 0] = x;
                coordinates[currIndex, 1] = y;
                currIndex += 1;
        }

        // Checks if the list is full
        public bool CheckListFull()
        {
            if(currIndex < coordinates.GetLength(0))
                return false;
            return true;
        }

        // Returns a coordinate to the user depending on the index given
        public int[] GetCoordinate(int index)
        {
            int[] Coordinates =
            {
                coordinates[index-1, 0],
                coordinates[index-1, 1],
            };
            return Coordinates;
        }

        // Getter for current index
        public int CurrIndex
        {
            get { return currIndex; }
        }
  
    }
}
