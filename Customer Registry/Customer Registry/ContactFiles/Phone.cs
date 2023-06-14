using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Registry.ContactFiles
{
    public class Phone

    {
        /// <summary>
        /// This Class has information about the Customer´s business and private phone number.
        /// This Class responsibility is to hold aforementioned information in the instance of Contact 
        /// in the instance Customer:
        /// Customer -> Contact -> Phone. 
        /// This class also has setters and getters, as well as a method to retreive
        /// relevant information in a formatted string.
        /// </summary>

        // Instance variables
        private string privatePhone;
        private string officePhone;

        #region Constructor
        // Chain-calling constructors
        public Phone()
        {

        }

        public Phone(string homePhone): this(homePhone, string.Empty)
        {
         
        }

        public Phone(string homePhone, string cellPhone)
        {
            this.privatePhone = homePhone;
            this.officePhone = cellPhone;
        }
        
        #endregion

        /// <summary>
        /// This method returns a formatted string to the user of the 
        /// Customer´s private and office phone number.
        /// </summary>
        /// <returns>A formatted string of the user´s private and office phone number.</returns>
        public string PhonesToString()
        {
            string phone = String.Format("{0}{1,-16}{2}{3,-16}{4}",
                "Phone numbers\n"," Private", privatePhone+"\n"," Office", officePhone);
            return phone;
        }

        #region Setters & Getters
        public string PrivatePhone
            { get { return privatePhone; } set { privatePhone = value; } }

        public string OfficePhone
            { get { return officePhone; } set { officePhone = value; } }

        #endregion
    }
}
