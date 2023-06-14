using Customer_Registry.ContactFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Registry
{
    public class CustomerManager
    {
        /// <summary>
        /// This class has a list of all of the instances of Customers added by the user:
        /// FormMain -> CustomManager -> Customer -> Contact -> Address, Phone & Email
        /// 
        /// It also contains methods for:
        /// 1. Adding a customer to the list.
        /// 2. Updating edited information of the customer.
        /// 3. Retreiving a Customer.
        /// 4. Deleting a customer in the list
        /// 5. Controlling if an index contains a Customer.
        /// </summary>

        private List<Customer> customerList = new List<Customer>(); // List of instances of Customer.

        /// <summary>
        /// This method:
        /// 1. Creates a customer.
        /// 2. Adds the customer to customerList.
        /// </summary>
        /// <param name="id">Getting unique GuID</param>
        /// <param name="contact">Instance of the Class contact</param>
        public void AddCustomer(Guid id,Contact contact)
        {
            Customer customer = new Customer(id, contact); // Creates a customer.
            customerList.Add(customer); // Adds it to customerList.
        }

        /// <summary>
        /// This method is responsible for retreiving a Customer in customerList, then updating the contact
        /// information of said Customer.
        /// </summary>
        /// <param name="index">Index of the customer´s contact information
        /// to be updated in customerList.</param>
        /// <param name="contact">Contact information to be updated.</param>
        public void EditCustomer(int index, Contact contact)
        {
            Customer customer = customerList[index];
            customer.Contact = contact;
            
        }

        /// <summary>
        /// This method returns the Customer in the index provided by the user.
        /// </summary>
        /// <param name="index">Index of Customer to retreive in customerList</param>
        /// <returns>An instance of Customer.</returns>
        public Customer GetCustomer(int index)
        {
            Customer customer = customerList[index];
            
            return customer;
        }

        /// <summary>
        /// This method removes an Customer in customerList of the index provided by the user.
        /// </summary>
        /// <param name="index">Index of Customer to be removed.</param>
        public void DeleteCustomer(int index)
        {
            customerList.RemoveAt(index);
        }

        /// <summary>
        /// This methods checks if there´s an instance of Customer at the index provided by the user.
        /// </summary>
        /// <param name="index">Index of customerList to check if there´s an instance of Customer</param>
        /// <returns>Returns a boolean value if there´s an instance of Customer at the index.</returns>
        public bool ControlIndexInList(int index)
        {
            if (customerList.Count > index && customerList[index] != null)
                return true;
            return false;
        }
    }
}
