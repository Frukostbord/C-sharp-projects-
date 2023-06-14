using Customer_Registry.ContactFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Registry
{
    /// <summary>
    /// This Class function controls FormContacts. The functions are: 
    /// To retreive data of a Customer to be edited or to create a new Customer.
    /// 
    /// 1. The class has two different constructors, one for editing or one for adding a new customer.
    /// 
    /// Adding:
    /// If the purpose is to add a customer, all textboxes are blank.
    /// 
    /// Editing:
    /// If the purpose is to edit a customer, all information that´s previously been put in is added
    /// to the textboxes.
    /// 
    /// 2. The form has two options: OK or Cancel
    /// 
    /// OK:
    /// The form controls to see if minimum amount of information has been put in by the user, else it
    /// shows a error message. If the information is adequate, the form sends a DialogResult.OK.
    /// 
    /// Cancel:
    /// A confirm message is showed. If the user presses "Yes", a DialogResult.Cancel is sent. Else it 
    /// returns to the form.
    /// </summary>


    public partial class FormContact : Form
    {
        private Contact contact;

        #region Constructor

        /// <summary>
        /// Constructor for adding a new contact.
        /// It takes a string as the title for the form.
        /// </summary>
        public FormContact(string title)
        {
            InitializeComponent();
            GetCountryCodes(); // Add countries to combobox

            Text = title; // Adding title to the form
        }

        /// <summary>
        /// Constructor for editing an existing contact.
        /// It takes a string as the title for the form.
        /// </summary>

        public FormContact(string title, Contact contact)
        {
            InitializeComponent();
            GetCountryCodes(); // Add countries to combobox

            Text = title; // Adding title to the form
            this.contact = contact; // Adding contact to local variable to be edited

            ReadName();
            ReadAddress();
            ReadEmail();
            ReadPhone();

        }

        #endregion

        /// <summary>
        /// 1. Loops through each culture in class CultureInfo. 
        /// 2. Gets the name for each culture.
        /// 3. Adds each English name to the combobox in the form.
        /// 4. Sorts countries alphabetically.
        /// </summary>
        public void GetCountryCodes()
        {
            foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(cultureInfo.Name);
                if (!cmbCountry.Items.Contains(region.EnglishName))
                {
                    cmbCountry.Items.Add(region.EnglishName);                             
                }
            }
            cmbCountry.Sorted = true;
        }
        
        #region Reading info for editing customer
        /// <summary>
        /// This method reads the Customer´s First and Last name, then puts them in the relevant textboxes.
        /// </summary>
        private void ReadName()
        {
            txtFirstName.Text = contact.NameFirst;
            txtLastName.Text = contact.NameLast;
        }

        /// <summary>
        /// This method reads the Customer´s Country, Zipcode, Street and City, 
        /// then puts them in the relevant textboxes.
        /// </summary>
        private void ReadAddress()
        {
            cmbCountry.SelectedItem = contact.Address.Country;
            txtZipCode.Text = contact.Address.ZipCode;
            txtStreet.Text = contact.Address.Street;
            txtCity.Text = contact.Address.City;
        }

        /// <summary>
        /// This method reads the Customer´s Private and Business Email, then puts them in the relevant textboxes.
        /// </summary>
        private void ReadEmail()
        {
            txtEmailPrivate.Text = contact.EmailData.EmailPrivate;
            txtEmailBusiness.Text = contact.EmailData.EmailBusiness;

        }

        /// <summary>
        /// This method reads the Customer´s Office and Private phone number, 
        /// then puts them in the relevant textboxes.
        /// </summary>
        private void ReadPhone()
        {
            txtOfficePhone.Text = contact.PhoneData.OfficePhone;
            txtHomePhone.Text = contact.PhoneData.PrivatePhone;
        }

        #endregion
        #region Buttons

        /// <summary>
        /// Adds all existing data in the form to the local instance of Contact.
        /// The button has DialogResult == OK:
        /// </summary>

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Setting all information in the form to the different objects, to create instances
            Address address = new Address(street: txtStreet.Text, city: txtCity.Text, zipCode: txtZipCode.Text, 
                cmbCountry.Text);
            Email email = new Email(emailBusiness: txtEmailBusiness.Text, emailPrivate: txtEmailPrivate.Text);
            Phone phone = new Phone(homePhone: txtHomePhone.Text, cellPhone: txtOfficePhone.Text);

            // Creates a final instance with, that can be retreived by setters and getters
            contact = new Contact(firstName: txtFirstName.Text, lastName: txtLastName.Text, email, phone, address);

            // Checks to see if information put in by user is correct
            if (contact.CheckUserInput())
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("You have to atleast:\n\n1. Provide a first or last name." +
                    "\n2. Provide a city.\n3. Provide a Country.", "Minimum required information not met!");
            
        }

        /// <summary>
        /// 1. Shows a Yes/No message, to double confirm that the user wants to cancel and discard all changes.
        /// 2. If DialogResult==Yes, the form closes and discards all changes. Else it stays open.
        /// </summary>

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to discard all changes?", 
                "Please confirm your action", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes) // If the user presses "Yes"
            {
                DialogResult = DialogResult.Cancel;
            }

        }
        #endregion

        #region Setters & Getters

        
        public Contact GetContact // Setter and getter for Contact
        { get { return contact; } set { contact = value; } }

        #endregion


    }
}

