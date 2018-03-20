using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NSubstitute;
using MicrowaveOvenClasses.Controllers;
using Assert = NUnit.Framework.Assert;

namespace Microwave.Test.Unit.Tests
{
    [TestFixture]
    public class IntegrationTest1
    {
        private IOutput _outputDisplay;
        private IOutput _outputPower;

        private IDisplay _display;
        private ITimer _timer;
        private IPowerTube _powerTube;
        private ICookController _cookController;

        [SetUp]
        public void Setup()
        {
            _outputDisplay = Substitute.For<IOutput>();
            _outputPower = Substitute.For<IOutput>();
            _display = new Display(_outputDisplay);
            _timer = new Timer();
            _powerTube = new PowerTube(_outputPower);
            _cookController = new CookController(_timer, _display, _powerTube);
        }

        [Test]
        public void Cookcontroller_Startcooking_OutputPowerRecieved()
        {
            int i = 0;

            _outputPower.When(x => x.OutputLine(Arg.Any<string>()))
                .Do(x => ++i);

            _cookController.StartCooking(50, 2000);

            Assert.That(() => (i == 2), Is.True.After(2500));
        }


        [Test]
        public void CookController_StartCooking_OutputDisplayRecievedFiveTimes()
        {
            //Arrange
            int timesCalled = 0;
            //Act
            _cookController.StartCooking(50, 5000);

            _outputDisplay.When(x => x.OutputLine(Arg.Any<string>()))
                .Do(x => ++timesCalled);

            //Assert
            Assert.That(() => (timesCalled == 5), Is.True.After(5500));
        }
    }
}
