using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Microwave.Test.Intergration
{
    [TestFixture]
    public class UnitTest1
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

            _outputPower.When(x=> x.OutputLine(Arg.Any<string>()))
                .Do(x => ++i);

            _cookController.StartCooking(50, 2000);

            Assert.That(() => (i == 2), Is.True.After(2500));
        }
    }
}
