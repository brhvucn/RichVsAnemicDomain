using Rich.Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich.Example.Application
{
    public class CreateCustomerCommandHandler
    {
        public void Save(Customer customer)
        {
            //save the customer and save any new contacts (they might not have an ID)
            //contacts can not be saved on their own, because they cannot live without a Customer
        }
    }
}
