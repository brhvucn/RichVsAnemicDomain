using Anemic.Example.Domain;
using Anemic.Example.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemic.Example.Services
{
    /// <summary>
    /// Example of a "service" or a "manager" class. This encapsulates the state and behavior of the domain object
    /// The repositories are not "marker" repositories, they are the same interface with the mixed methods, just to show the example
    /// not to make fully working implementation of a repository.
    /// </summary>
    public class CustomerService
    {
        private IRepository customerRepository;
        private IRepository contactRepository;
        public CustomerService(IRepository customerRepository, IRepository contactRepository)
        {
            this.customerRepository = customerRepository;
            this.contactRepository = contactRepository;
        }

        public void SaveCustomer(Customer customer)
        {
            var existingCustomer = this.customerRepository.GetCustomer(customer.Id);
            if (existingCustomer != null)
            {
                //customer exists, update the customer
                if(existingCustomer.State == CustomerState.Active)
                {
                    //the customer has the right state, update it
                }
                else
                {
                    //the customer is not in the right state, do not update it
                }
            }
            else
            {
                //customer does not exist create a new one
                customer.State = CustomerState.Active;
                //save the customer
                this.customerRepository.SaveCustomer(customer);
            }
        }       

        //adding/attaching a contact to a customer
        //who is responsible for this when it is both a customer and a contact?
        //do we need services injected in services? 
        //do we need multiple repositories in each service?
        //do we have dublicated implementations? Getting/Saving/Attaching
        public void AddContactToCustomer(Customer customer, Contact contact)
        {
            var existingCustomer = this.customerRepository.GetCustomer(customer.Id);
            if (existingCustomer != null)
            {
                //we can add it, since the customer exists in the database
                if(existingCustomer.State == CustomerState.Active)
                {
                    //the customer exists, now check the contact
                    var existingContact = this.contactRepository.GetContactForCustomer(customer.Id, contact.Id);
                    if(existingContact != null)
                    {
                        //if we add it without it exists we get FK constraint exception
                        this.contactRepository.AttachContactToCustomer(customer, contact);
                    }
                    else
                    {
                        //someone forgot to save the contact before attaching it to the customer                        
                    }
                }
            }
            else
            {
                //what to do? Exception? Log?
                throw new Exception("The customer does not exist");
            }
        }
    }
}
