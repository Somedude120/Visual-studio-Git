using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;
using AirTrafficLibraryConsole.Classes;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class VelocityTest
    {
        private CalculateVelocity uut;
        private double _x1, _y1, _x2, _y2, _time;

        [SetUp]
        public void Setup()
        {
            _x1 = 1000;
            _x2 = 9000;
            _y1 = 3000;
            _y2 = 9000;
            _time = 40;
            
            uut = new CalculateVelocity();

        }

        [Test]
        public void RightSpeedCalculation()
        {
            double output = uut.CalcVelocity(_x1, _x2, _y1, _y2, _time);

            Assert.AreEqual(output, 250);

        }
    }
}
