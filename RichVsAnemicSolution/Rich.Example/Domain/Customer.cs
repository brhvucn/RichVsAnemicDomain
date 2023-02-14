namespace Rich.Example.Domain
{
    //Customer has a responsibility for maintaining its state and behavior
    public class Customer
    {
        public Customer(string name)
        {
            //we are protecting object state
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public CustomerState State { get; private set; }
        public List<Contact> Contacts { get; private set; }

        public void AddContact(Contact contact)
        {
            if(this.State == CustomerState.Active)
            {
                //the customer has a correct state
                if(!this.Contacts.Any(x=>x.Id == contact.Id))
                {
                    //we dont already have this contact on the company, add it
                    this.Contacts.Add(contact);
                }
                else
                {
                    throw new Exception("Contact already exists.");
                }
            }
        }

        public void ChangeState(CustomerState newState) 
        {
            if(newState == CustomerState.None) 
            {
                throw new Exception("Illegal state - a customer may not be set to 'none'");
            }
            this.State = newState;
        }
    }

    public enum CustomerState
    {
        None = 0,
        Disabled,
        Active
    }
}