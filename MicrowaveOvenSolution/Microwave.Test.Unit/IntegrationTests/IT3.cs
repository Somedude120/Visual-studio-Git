using System;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Intergration
{
    [TestFixture]
    class IT3
    {
        //Stubs
        private IDisplay _display;
        private ILight _light;
        private ITimer _timer;
        private IPowerTube _powerTube;

        //Real
        private IButton _powerButton;
        private IButton _timeButton;
        private IButton _startCancelButton;
        private IDoor _door;

        //UUT
        private IUserInterface _uut_userInterface;
        private CookController _uut_cookController;

        [SetUp]
        public void Setup()
        {
            //Stubs
            _display = Substitute.For<IDisplay>();
            _light = Substitute.For<ILight>();
            _timer = Substitute.For<ITimer>();
            _powerTube = Substitute.For<IPowerTube>();

            //Real
            _powerButton = new Button();
            _timeButton = new Button();
            _startCancelButton = new Button();
            _door = new Door();

            //UUT
            _uut_cookController = new CookController(_timer, _display, _powerTube);
            _uut_userInterface = new UserInterface(_powerButton, _timeButton, _startCancelButton, _door, _display, _light, _uut_cookController);
            _uut_cookController.UI = _uut_userInterface;
        }

        [Test]
        public void UI_SetPowerTest_DisplayShowsPower()
        {
            _powerButton.Press();
            _display.Received(1).ShowPower(50);
            _powerButton.Press();
            _display.Received(1).ShowPower(100);
            _powerButton.Press();
            _display.Received(1).ShowPower(150);
        }

        [Test]
        public void UI_PowerOver700_PowerResets()
        {
            UI_SetPowerTest_DisplayShowsPower();
            for (int i = 150; i < 700; i += 50)
            {
                _powerButton.Press();
                _display.Received(1).ShowPower(i);
            }
            _powerButton.Press();
            _display.ShowPower(50);
        }

        [Test]
        public void UI_SetTimeTest_DisplayShowsTime()
        {
            _powerButton.Press();
            _display.Received(1).ShowPower(50);
            _timeButton.Press();
            _display.Received(1).ShowTime(1, 0);
            _timeButton.Press();
            _display.Received(1).ShowTime(2, 0);
            _timeButton.Press();
            _display.Received(1).ShowTime(3, 0);
        }

        [Test]
        public void UI_CC_StartCookingTest_LightPowerTimerOn()
        {
            UI_SetTimeTest_DisplayShowsTime();
            _startCancelButton.Press();
            _light.Received(1).TurnOn();
            _powerTube.Received(1).TurnOn(7);
            _timer.Received(1).Start(3 * 60);
        }
    }
}