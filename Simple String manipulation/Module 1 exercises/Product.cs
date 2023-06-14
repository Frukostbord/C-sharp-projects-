using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    public class Products
    {
        //Variables
        private string? productname;
        private double productprice;
        private short productquantity;


        public void Start()
        {
            //Create variables & get input
            //Calculate
            //Return value
            GetName();
            GetPrice();
            GetQuantity();
            ReturnValue();
        }

        private void GetName()
        {
            Console.WriteLine("What is the name of the product?");
            productname = Console.ReadLine();
         
        }

        private void GetPrice()
        {
            Console.WriteLine("What is the price of the product?");
            string strprice = Console.ReadLine();
            productprice = double.Parse(strprice);

        }

        private void GetQuantity()
        {
            Console.WriteLine("What is the quantity of the product?");
            string strquantity = Console.ReadLine();
            productquantity = short.Parse(strquantity);

        }

        public void ReturnValue()
        {
            Console.WriteLine("++++++++++++++++++++");
            Console.WriteLine($"The product name is: {productname}");
            Console.WriteLine($"The product price is: {productprice}$");
            Console.WriteLine($"The product count is: {productquantity}");
            Console.WriteLine("++++++++++++++++++++");
            Console.ReadLine();
        }

    }
}
