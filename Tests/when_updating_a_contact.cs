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
    public class when_updating_a_contact
    {
        [Test]
        public void existing_contact_updates_properly()
        {
            int id = contact_helpers.create_test_user();
            ContactRepository repos = new ContactRepository();
            Contact toUpdate = repos.GetOneContact(id);
            toUpdate.LName = "UPDATED";

            repos.UpdateContact(toUpdate);

            Contact actual = repos.GetOneContact(id);
            Assert.AreEqual("UPDATED", actual.LName, "ID: " + actual.Id);
        }


    }
}
