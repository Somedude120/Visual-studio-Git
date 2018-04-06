
using System.Collections.Generic;
using NUnit.Framework;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    class DateTest
    {

        int a;
        int b;

        [SetUp]
        public void Setup()
        {
            a = 2;
            b = 2;
        }
        [Test]
        public void test()
        {
            Assert.That(a+b,Is.EqualTo(4));
        }
    }

}
