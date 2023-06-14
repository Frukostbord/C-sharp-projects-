using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment_1
{
    class Carvinal
    {
        static void Main()
        {
            // Creating objects
            Pet petobj = new Pet();
            TicketSeller ticketobj = new TicketSeller();
            Album albumobj = new Album();

            // Initializing main method in each class
            petobj.Start();
            ticketobj.Start();
            albumobj.Start();
           
        }
    }
}
