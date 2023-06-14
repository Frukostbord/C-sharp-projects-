using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale
{
    public class Adress
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string street;
        private string zipCode;
        private string city;
        private Countries country;
        private string errorMsg;          //error messages 


        /// <summary>
        /// Default constructor. All strings empty, country is set to Sweden
        /// </summary>
        public Adress()
        {
            street = string.Empty;
            zipCode = string.Empty;
            city = string.Empty;
            country = Countries.Sverige;
            errorMsg = string.Empty;
        }

        //copy consructor Exercise:  http://msdn.microsoft.com/en-us/library/ms173116(VS.80).aspx
        
        /// <summary>
        /// Copy constructor: Use this when yoy are copying
        /// from one object to another of this class
        /// </summary>
        /// <param name="other"></param>
        public Adress(Adress other)
        {
            this.street = other.street;
            this.zipCode = other.zipCode;
            this.city = other.city;
            this.country = other.country;
        }
#region properties
        public string Street
        {
            get { return street; }
            set { street = value; }
        }


        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Zip
        {
            get { return zipCode; }
            set { zipCode = value; }
        }



        public Countries Country
        {
            get { return country; }

            set { country = value; }
        }

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }

        public Countries Countries
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Countries Countries1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        // Methods

        /// <summary>
        /// Checks that the address must at least have a city and zip code
        /// </summary>
        /// <returns></returns>
 
        public bool CheckData()
        {
            errorMsg = "";
            if ((city == string.Empty || zipCode == string.Empty))
            {
                errorMsg = "Address must have a city and a zip code.";
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This function simply deletes the '_'s from country names as saved in the enum
        /// </summary>
        /// <returns></returns> 
        public string GetCountryString()
        {
            string strCountry = country.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }
        #endregion

        /// <summary>
        /// Formatting text into several lines
        /// </summary>
        /// <returns></returns>
        public string GetAdressEtiketten()
        { 
            string strOut = street + Environment.NewLine;
            strOut += zipCode + " " + city + Environment.NewLine;
            strOut += country.ToString().ToUpper();  //format country in upper case
            return strOut;
 
        }

        /// <summary>
        /// Formatting text into one line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strOut = string.Format("{0, -20}{1,-10}{2, -10}{3, -10}", 
                street, zipCode, city, GetCountryString());

            return strOut;

        }
    }//class
}
