using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Registry.ContactFiles
{
    public class Email

    {
        /// <summary>
        /// This Class has information about the Customer´s business and private email.
        /// This Class responsibility is to hold aforementioned information in the instance of Contact 
        /// in the instance Customer:
        /// Customer -> Contact -> Email. 
        /// This class also has setters and getters, as well as a method to retreive
        /// relevant information in a formatted string.
        /// </summary>
        
        // Instance variables
        private string emailBusiness;
        private string emailPrivate;

        #region Constructor

        // Chain-calling constructors
        public Email()
        {

        }
        public Email(string emailBusiness): this(emailBusiness, string.Empty)
        {
  
        }

        public Email(string emailBusiness, string emailPrivate)
        {
            this.emailBusiness = emailBusiness;
            this.emailPrivate = emailPrivate;
        }

        #endregion

        /// <summary>
        /// This method returns a formatted string of all of the instance variables in the instance.
        /// </summary>
        /// <returns>A formatted string of the contact´s business and private email.</returns>
        public string EmailsToString()
        {
            string email = String.Format("{0}{1,-16}{2}{3,-16}{4}",
                "Email\n"," Private", emailPrivate + "\n", " Office", emailBusiness + "\n\n");
            return email;

        }

        #region Setters & Getters
        // Setters & Getters
        public string EmailBusiness
            { get { return emailBusiness; } set { emailBusiness = value; } }

        public string EmailPrivate
            { get { return emailPrivate; } set { emailPrivate = value; } }

        #endregion

    }
}
