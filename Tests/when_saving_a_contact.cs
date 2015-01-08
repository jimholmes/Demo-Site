using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApi.Models;
using WebApi.Services;

namespace Tests
{
    [TestFixture]
    public class when_saving_a_contact
    {
        [Test]
        public void saving_a_valid_contact_returns_an_id()
        {
            ContactRepository repository = new ContactRepository();
            Contact test = new Contact();
            test.Id = -1;
            test.Region = "zzzzz";
            test.Company = "1212121";
            test.LName = "zyzyzyz";
            test.FName = "jhsadfljhasfdlkjh";

            Assert.IsTrue(repository.SaveContact(test).Id>0);
        }
    }
}