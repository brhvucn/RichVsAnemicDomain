using Anemic.Example.Domain;
using Anemic.Example.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemic.Example.Services
{
    public class ContactService
    {
        private IRepository contactRepository;
        public ContactService(IRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public void SaveContact(Contact contact)
        {
            var existingContact = GetContact(contact.Id);
            if (existingContact == null)
            {
                //only save if it does not exist, business rule
                this.contactRepository.SaveContact(contact);
            }
            else
            {
                //else update, business rule
                this.contactRepository.UpdateContact(contact);
            }
        }
        
        public Contact GetContact(int id)
        {
            return this.contactRepository.GetContact(id);
        }
    }
}
