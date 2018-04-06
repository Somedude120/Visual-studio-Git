using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class AirTrafficLibraryTestUnit
    {
        //
        [Test]
        public void test()
        {
            Assert.That(2+2,Is.EqualTo(4));
        }
    }
}
