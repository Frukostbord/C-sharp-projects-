using Customer_Registry.ContactFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Registry
{
    /// <summary>
    /// This class contains all the Contact info of a customer. It uses several other Classes to acheive this:
    /// Customer -> Contact -> Address, Email & Phone.
    /// 
    /// This class also contains a unique GuID and a method to retreive a truncated version of said GuID.
    /// </summary>
    public class Customer

    {
        private Contact contact;
        private Guid id;

        #region Constructor
        // Constructors
        public Customer()
        {   
        }

        /// <summary>
        /// Constructor for creating a new Customer. It deep copies the arguments.
        /// </summary>
        /// <param name="id">Unique GuID</param>
        /// <param name="contact">Contact information representing this Customer.</param>
        public Customer(Guid id, Contact contact)
        {
            this.contact = contact;
            this.id = id;
        }
        #endregion

        #region Setters & Getters

        // Setters & Getters
        public Contact Contact
            { get { return contact; } set { contact = value; } }

        #endregion

        /// <summary>
        /// Retreiving a 3-character long truncated version of the customer´s ID.
        /// </summary>
        /// <returns>3-character long version of the Customer´s GuID.</returns>

        public string GetIDTruncated()
        {
            return id.ToString().Substring(0, 3);
        }
    }
}
