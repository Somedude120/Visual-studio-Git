using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class DateTest
    {
        [Test]
        public void testing()
        {
            Assert.That(2+2,Is.EqualTo(4));
        }
    }
}
