using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using SupportApi;

namespace Tests.SupportApi
{
    [TestFixture]
    public class when_reading_from_database
    {
        [Test]
        public void get_high_contact_id_returns_good_value()
        {
            int id = DataHelpers.get_high_contact_id();
            Assert.IsTrue(id > 0);
        }
    }
}
