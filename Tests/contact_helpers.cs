using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace Tests
{
    public class contact_helpers
    {

        static public int create_test_user()
        {
            ContactRepository _repository = new ContactRepository();
            Contact test = new Contact();
            test.Id = -1;
            test.Region = "zzzzz";
            test.Company = "1212121";
            test.LName = "zyzyzyz";
            test.FName = "jhsadfljhasfdlkjh";
            return _repository.SaveContact(test ).Id;
        }
    }
}
