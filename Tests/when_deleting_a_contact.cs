using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

using SupportApi;

namespace Tests
{
    [TestFixture]
    public class when_deleting_a_contact
    {
        ContactRepository repository;
        Contact savedContact;

        [SetUp]
        public void create_new_contact_each_time() {
            repository = new ContactRepository();
            Contact testContact = new Contact();
            testContact.Id = -1;
            testContact.Region = "zzzzz";
            testContact.Company = "1212121";
            testContact.LName = "zyzyzyz";
            testContact.FName = "jhsadfljhasfdlkjh";

            savedContact = repository.SaveContact(testContact);
        }
        [Test]
        public void deleted_contact_removed_from_db() {
            var id = savedContact.Id;
            repository.DeleteContact(savedContact);

            var shouldNotExist = DataHelpers.get_contact_by_id(id);
            Assert.IsNull(shouldNotExist);

        }
    }
}
