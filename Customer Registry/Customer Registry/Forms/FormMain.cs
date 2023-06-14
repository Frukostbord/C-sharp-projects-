using Customer_Registry.ContactFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Customer_Registry
{

    /// <summary>
    /// Main form of the program.
    /// Function: The programs main function is to facilitate, add, edit and delete
    /// information of customers and their contact info.
    /// 
    /// Class Diagram:
    /// 1. FormMain -> FormContact -> Contact -> Adress, Email & Phone
    /// 2. FormMain -> CustomerManager -> Customer -> Contact -> Adress, Email & Phone
    /// 
    /// The program lets you input new contacts and manipulate added contacts by opening another form (FormContacts). 
    /// Once the actions is complete, the information is sent CustomerManager which pertains all the customers 
    /// and displayed in the listbox of the Main form.
    /// </summary>
    public partial class FormMain : Form
    {
        
        CustomerManager customerManager = new CustomerManager(); // Instance variable, contains all customers

        public FormMain()
        {
            InitializeComponent();
        }
        #region Manipulating listbox text

        /// <summary>
        /// This method updates the listbox with the edited information from the user.
        /// </summary>
        /// <param name="customer">Selected instance of Customer by the user.</param>
        /// <param name="contact">Instance of contact in the selected instance of Customer.</param>
        private void EditCustomerList(Customer customer, Contact contact)
        {
            // Formatting string in the listbox
            string stringID = customer.GetIDTruncated();
            string name = contact.NamesToListBox();

            // Adding edited Customer to the listbox
            lstCustomers.Items.Insert(lstCustomers.SelectedIndex, String.Format("{0,-8}{1,-30}{2,-21}{3}",
                stringID, name, contact.PhoneData.OfficePhone.ToString(),
                contact.EmailData.EmailBusiness.ToString()));

            lstCustomers.Items.RemoveAt(lstCustomers.SelectedIndex);
            lblCustomerInfo.Text = "";
            lstCustomers.ClearSelected();
        }

        /// <summary>
        /// This method deletes a Customer in the listbox.
        /// </summary>
        /// <param name="index">Index of the Customer to be deleted.</param>

        private void DeleteCustomerList(int index)
        {
            lstCustomers.Items.RemoveAt(index);
            lblCustomerInfo.Text = "";
            lstCustomers.Update();
        }

        /// <summary>
        /// This method formats and then adds a Customer to the listbox in FormMain.
        /// </summary>
        /// <param name="id">GuID related to the customer.</param>
        /// <param name="contact">Instance of the class Contact.</param>
        private void AddCustomerList(Guid id, Contact contact)
        {
            string stringID = id.ToString().Substring(0, 3);

            // Formatting string in the listbox
            string name = contact.NamesToListBox();
            lstCustomers.Items.Add(String.Format("{0,-8}{1,-30}{2,-21}{3}",
                stringID, name, contact.PhoneData.OfficePhone.ToString(),
                contact.EmailData.EmailBusiness.ToString()));

            lstCustomers.Update();
        }
        #endregion

        /// <summary>
        /// 1. Opens up FormContacts for the user to put in information of the new customer. 
        /// 2. If DialogResult == OK: retreive the contact from formContact.
        /// 3. Create a new Guid and add the contact info to a new Customer in class Customer.
        /// 4. Add info about the Customer in the listbox.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(); // Creating a new customer to be added
            using (FormContact formContact = new FormContact("Adding a new customer to the roster"))
            {
                formContact.ShowDialog(); // Shows form for information to be put in

                if (formContact.DialogResult == DialogResult.OK)
                {
                    contact = formContact.GetContact; // Getting contact through getter in formContact

                    Guid id = Guid.NewGuid();
                    customerManager.AddCustomer(id, contact); // Adding the contact to customManager
                    
                    AddCustomerList(id, contact); // Adding customer to the listbox
                                   
                }
                else if(formContact.DialogResult == DialogResult.Cancel)
                    formContact.Close();                
            }
        }

        /// <summary>
        /// This methods edits a Customer in the listbox.
        /// 1. Controls if an Customer is selected and is an valid index in customManager.
        /// 2. Retreives the customer and contact information.
        /// 3. Opens formContacts and adds information in there to be edited.
        /// 4. If DialogResult == OK, then add the edited information. If DialogResult == Cancel, 
        /// save no changes made.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex != -1 && customerManager.ControlIndexInList(lstCustomers.SelectedIndex))
            {                
                Customer customer = customerManager.GetCustomer(lstCustomers.SelectedIndex);
                Contact contact = customer.Contact; // Retreives Contact information from listbox index

                using (FormContact formContact = new FormContact($"Editing {contact.NamesToString()}",contact))
                {
                    formContact.ShowDialog();
                    if (formContact.DialogResult == DialogResult.OK)
                    {
                        contact = formContact.GetContact; // Getting contact through getter in formContact
                        customerManager.EditCustomer(lstCustomers.SelectedIndex,contact); // Adding the contact
                                              
                        EditCustomerList(customer,contact); // Edits listbox
                    }
                    else if (formContact.DialogResult == DialogResult.Cancel)
                        formContact.Close();
                }
            }
            else
                MessageBox.Show("You have to select a user before trying to edit it!","Error!");
        }


        /// <summary>
        /// This methods deletes a Customer in the listbox.
        /// 1. Controls if an Customer is selected and is an valid index in customManager.
        /// 2. Deletes the customer in customManager and listbox.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex != -1 && customerManager.ControlIndexInList(lstCustomers.SelectedIndex))
            {
                // Deletes customer in CustomManager at the selected index
                customerManager.DeleteCustomer(lstCustomers.SelectedIndex);

                // Deletes the customer in the listbox
                DeleteCustomerList(lstCustomers.SelectedIndex);
                lstCustomers.ClearSelected();
            }
            else
                MessageBox.Show("You have to select an item in the listbox to delete it!","Error!");
        }


        /// <summary>
        /// This method is responsible for showing Customer information in the label to the right of
        /// FormMain. It´s updated on each click. It uses methods in the Classes of Contact, Address, Email and 
        /// Phone to get formatted strings of relevant information.
        /// </summary>
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex != -1)
            {
                Customer customer = customerManager.GetCustomer(lstCustomers.SelectedIndex);
                Contact contact = customer.Contact;

                // Using methods from other Classes.
                lblCustomerInfo.Text =
                    contact.NamesToString() +
                    contact.Address.AddressToString() +
                    contact.EmailData.EmailsToString() +
                    contact.PhoneData.PhonesToString();
            }
        }

    }
}
