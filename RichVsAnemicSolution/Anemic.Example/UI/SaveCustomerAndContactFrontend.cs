using Anemic.Example.Domain;
using Anemic.Example.Repository;
using Anemic.Example.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemic.Example.UI
{
    /// <summary>
    /// This is a sample class to represent a UI. This is not a real UI but an implementation to show how this might be implemented
    /// </summary>
    public class SaveCustomerAndContactFrontend
    {
        private IRepository repository;
        public SaveCustomerAndContactFrontend(IRepository repository)
        {
            this.repository = repository;
        }
        public void SaveCustomer(Customer customer)
        {
            CustomerService customerService = new CustomerService(this.repository, this.repository);
            customerService.SaveCustomer(customer);
        }

        public void SaveContact(Contact contact)
        {
            //saving the contact in db without attaching it to a customer            
        }
    }
}
