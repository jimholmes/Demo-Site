using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Services;

namespace WebApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ContactService : IContactService
    {
        public IList<Contact>GetData()
        {
            ContactRepository repository = new ContactRepository();
            return repository.GetAllContacts();
        }

        public CompositeContact GetDataUsingDataContract(CompositeContact composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            
            return composite;
        }

        public int SaveData(Contact contact)
        {
            ContactRepository repository = new ContactRepository();
            return repository.SaveContact(contact).Id;
        }
    }
}
