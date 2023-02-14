using Anemic.Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemic.Example.Repository
{
    /// <summary>
    /// Sample interface to mimic the behavior of a repository. 
    /// </summary>
    public interface IRepository
    {
        void AttachContactToCustomer(Customer customer, Contact contact);
        Contact GetContact(int id);
        Contact GetContactForCustomer(int id1, int id2);
        Customer GetCustomer(int id);
        void SaveContact(Contact contact);
        void SaveCustomer(Customer customer);
        void UpdateContact(Contact contact);
    }
}
