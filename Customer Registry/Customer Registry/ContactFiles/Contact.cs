using System;

namespace Customer_Registry.ContactFiles
{
    public class Contact

    {
        /// <summary>
        /// This class is responsible to containing all contact information of the Customer.
        /// Customer -> Contact -> Address, Email & Phone
        /// Information kept:
        /// 1. First and last name as instance variables
        /// 2. Instances of Address, Email and Phone - which all have contact information in them.
        /// 
        /// This class also have following methods:
        /// 1. Controlling minimum user input before trying to save information in the form.
        /// 2. Returning formatted string of first and last name.
        /// 3. Returning first and last name.
        /// 
        /// This class also contains getters and setters for instance variables.
        /// </summary>
         

        // Instance variables
        private string firstName;
        private string lastName;

        private Address address;
        private Email email;
        private Phone phone;

        #region Constructor
        /// <summary>
        /// Default constructor with no parameters.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Constructor for deep copying a contact. It takes each Class (Email, Phone & Adress) and the
        /// first and last name as arguments for perfoming the deep copy.
        /// </summary>

        public Contact(string firstName, string lastName, Email email, Phone phone, Address address)
        {
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        #endregion

        /// <summary>
        /// This method controls if the user has put in the minimum amount of information
        /// in to the form to create a new user. Minimum amount of information:
        /// First or last name, city and country.
        /// </summary>
        /// <returns>Boolean value if minimum amount of input for a new contact is reached</returns>
        public bool CheckUserInput()
        {
            // Checks if required minimum input by the user is met.
            bool nameBool = !String.IsNullOrEmpty(firstName) | !String.IsNullOrEmpty(lastName);
            bool cityBool = !String.IsNullOrEmpty(address.City);
            bool countryBool = !String.IsNullOrEmpty(address.Country);

            return nameBool && cityBool && countryBool;
        }


        /// <summary>
        /// This methods controls the instance variables of this instance of Contact and returns only the names
        /// in which have entered. If no information has been entered, that first or last name
        /// will not be returned.
        /// </summary>
        /// <returns>A string of names that, if the value != null or empty</returns>
        public string NamesToListBox()
        {
            if (String.IsNullOrEmpty(firstName))
                return lastName.ToUpper();
            else if (String.IsNullOrEmpty(lastName))
                return firstName;
            else
                return $"{firstName.ToUpper()}, {lastName}\n";
        }

        /// <summary>
        /// This method returns first and last name to the user.
        /// </summary>
        /// <returns>A string containing first and last name.</returns>
        public string NamesToString()
        {
           return $"{firstName} {lastName}\n";
        }

        #region Setters & Getters

        // Setters & Getters
        public Address Address
            { get { return address; } set { address = value; } }

        public Email EmailData
            { get { return email; } set { email = value; } }

        public Phone PhoneData
            { get { return phone; } set { phone = value; } }

        public string NameFirst
            { get { return firstName; } set { firstName = value; } }

        public string NameLast
            { get { return lastName; } set { lastName = value; } }

        #endregion
    }
}
