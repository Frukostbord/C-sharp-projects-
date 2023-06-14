using Customer_Registry.ContactFiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Registry.ContactFiles
{

    /// <summary>
    /// This Class has information about the Customer´s street address, city, zipcode and country.
    /// This Class responsibility is to hold aforementioned information in the instance of Contact 
    /// in the instance Customer:
    /// Customer -> Contact -> Address. 
    /// This class also has setters and getters, as well as a method to retreive
    /// relevant information in a formatted string.
    /// </summary>
    public class Address
    {
        // Instance variables
        private string street;
        private string city;
        private string zipCode;
        private string country;

        #region Constructors

        /*Chain-calling Constructors:
         * Arguments used are, Street, City, ZipCode and Country. Each Chain-calling increases 
         * the amount of arguments for one and keeps the other parameters arguments as "string.Empty".
         * (It´s not clear from the assignment if you want us to check each textbox for null or empty and then
         * call the constructor with textboxes with only text in them.)
         * 
        */
        public Address()
        {

        }

        public Address(string street): this(street, string.Empty, string.Empty, string.Empty)
        { 
        }

        public Address(string street, string city): this(street, city, string.Empty, string.Empty)
        { 
        }

        public Address(string street, string city, string zipCode): this(street, city, zipCode, string.Empty)
        {
        }

        public Address(string street, string city, string zipCode, string country)
        {
            this.street = street;
            this.city = city;
            this.zipCode = zipCode;
            this.country = country;
        }

        #endregion

        /// <summary>
        /// This method formats all the instance variables in the Class and returns them to the user.
        /// </summary>
        /// <returns>A formatted string of all the instance variables.</returns>
        public string AddressToString()
        {
            string address = $"{street}\n{zipCode} {city}\n{country}\n\n";
            return address;
        }

        #region Setters & Getters
        // Setters & Getters
        public string Street
            { get { return street; } set { street = value; } }

        public string City
            { get { return city; } set { city = value; } }

        public string ZipCode
            { get { return zipCode; } set { zipCode = value; } }
        public string Country
        { get { return country; } set { country = value; } }

        #endregion
    }
}
