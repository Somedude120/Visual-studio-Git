using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Microwave.Test.Unit.Tests
{
    [TestFixture]
    class IT1_Display
    {
        private Display display;
        private IOutput output;
        private CookControllerTest cooker;
        private Timer uut;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            display = new Display(output);
            cooker = new CookControllerTest();
            uut = new Timer();
        }

        [Test]
        public void S()
        {
            display.ShowTime(0,0);
            Assert.That(() => uut.Start(0), Throws.Nothing );
        }

        
    }
}
