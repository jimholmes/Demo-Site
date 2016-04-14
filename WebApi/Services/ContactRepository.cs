using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        string conn_str;


        public ContactRepository()
        {
            //conn_str = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn_str = "Data Source=S12R2\\SQLEXPRESS; Trusted_Connection=Yes;Database=Demos";
        }

        //private string conn_str ="Data Source=(localDB)\\v11.0;Integrated Security=True";
        public IList<Contact> GetAllContacts()
        {

            DataContext db = 
                new DataContext(conn_str);
            Table<Contact>from_db = db.GetTable<Contact>();
            
            IList<Contact>contacts = new List<Contact>();

            foreach (Contact contact in from_db)
            {
                contacts.Add(contact);
            }

            return ShuffleContacts(contacts);
        }

        private IList<Contact> ShuffleContacts(IList<Contact> contacts)
        {
            //var shuffled = contacts.OrderBy(a => a.Id);
            var shuffled = contacts.OrderBy(a => a.LName);
            IList<Contact> output = new List<Contact>();
            foreach (var contact in shuffled)
            {
                output.Add(contact);    
            }
            return output;
        }

        public Contact GetOneContact(int id)
        {
            ContactDataContext db = new ContactDataContext(conn_str);
            var contact = (from c in db.Contacts
                                   where c.Id == id
                                   select c).FirstOrDefault();
            return contact;
        }

        public Contact SaveContact(Contact contact)
        {
            ContactDataContext db = new ContactDataContext(conn_str);
            db.Contacts.InsertOnSubmit(contact);            
            try {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return contact;
        }

        public bool UpdateContact(Contact contact)
        {
            ContactDataContext db = new ContactDataContext(conn_str);

            var contactToUpdate= (from c in db.Contacts
                           where c.Id == contact.Id
                           select c).FirstOrDefault();
            contactToUpdate.Company = contact.Company;
            contactToUpdate.Region = contact.Region;
            contactToUpdate.LName = contact.LName;
            contactToUpdate.FName = contact.FName;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

    public class ContactDataContext : DataContext
    {
        public Table<Contact> Contacts;

        public ContactDataContext(string connection) : base(connection) { }
    }
}