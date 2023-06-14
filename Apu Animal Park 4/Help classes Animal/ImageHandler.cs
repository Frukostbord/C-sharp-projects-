using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This class is responsible for retreiving and checking if a file is a valid picture.
    /// 
    /// 1. Asks user to select a picture of an animal
    /// 2. Primitive check if the file is of correct format, if so, return the path
    /// </summary>

    internal class ImageHandler
    {

        /// <summary>
        /// Method controls to see if image in selected path is of a valid extension with a primitive file ending control.
        /// </summary>
        /// <param name="path">Path to return that contains the image file, if extension is correct</param>
        /// <returns>True if image has correct extension</returns>
        internal static bool GetImagePath(out string path)
        {
            path = "";

            OpenFileDialog openFileDialog = new OpenFileDialog(); // Creating a instance of OpenFileDialog
            openFileDialog.Title = "Animal picture"; // Title

            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {
                // Primitive check of file ending
                List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

                // If the file is an image, return path
                if (ImageExtensions.Contains(Path.GetExtension(openFileDialog.FileName).ToUpperInvariant()))
                {
                    path = openFileDialog.FileName;

                    return true;
                }

                // If image type is invalid
                MessageBox.Show("Something went wrong whilst trying to add a picture.\n" +
                "Please look over the selected file!");
            }


            return false;
        }
    }
}
