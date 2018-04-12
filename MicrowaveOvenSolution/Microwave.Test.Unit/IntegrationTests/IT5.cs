using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit.IntegrationTests
{
    class IT5
    {
        private IOutput _output;
        private IDoor _door;
        private ICookController _cookController;
        private ILight _light;
        private IPowerTube _powerTube;
        private IDisplay _display;
        private ITimer _timer;
        private IButton _powerButton;
        private IButton _timeButton;
        private IButton _startCancelButton;
        private IUserInterface _userInterface;

        [SetUp]
        public void SetUp()
        {
            _door = new Door();
            _powerButton = new Button();
            _timeButton = new Button();
            _startCancelButton = new Button();
            _output = Substitute.For<IOutput>();
            _powerTube = new PowerTube(_output);
            _display = new Display(_output);
            _light = new Light(_output);
            _timer = new Timer();
            _cookController = new CookController(_timer, _display, _powerTube);
            _userInterface = new UserInterface(_powerButton, _timeButton, _startCancelButton, _door, _display, _light, _cookController);
        }

        [Test]
        public void CookingActive_DoorOpened_OutputIs()
        {
            _powerButton.Press();
            _timeButton.Press();
            _startCancelButton.Press();
            _door.Open();
            Received.InOrder(() =>
            {
                _output.Received().OutputLine("Display shows: 50 W");
                _output.Received().OutputLine("Display shows: 01:00");
                _output.Received().OutputLine("Display cleared");
                _output.Received().OutputLine("PowerTube turned off");
            });
        }

        [Test]
        public void OpenDoor_OutputIs()
        {
            _door.Open();
            _output.Received().OutputLine("Light is turned on");
        }

        [Test]
        public void OpenCloseDoor_OutputIs()
        {
            _door.Open();
            _door.Close();

            Received.InOrder(() =>
            {
                _output.OutputLine("Light is turned on");
                _output.OutputLine("Light is turned off");
            });

        }

        [Test]
        public void StartCancelPressed_SetupDone_OutputIs()
        {
            _powerButton.Press();
            _timeButton.Press();
            _startCancelButton.Press();

            Received.InOrder(() =>
            {
                _output.OutputLine("Display shows: 50 W");
                _output.OutputLine("Display shows: 01:00");
            });
        }

        [Test]
        public void StartCancelPressed_CookingActive_OutputIs()
        {
            _powerButton.Press();
            _timeButton.Press();
            _startCancelButton.Press();
            _startCancelButton.Press();

            Received.InOrder(() =>
            {
                _output.OutputLine("Display shows: 50 W");
                _output.OutputLine("Display shows: 01:00");
                _output.OutputLine("Display cleared");
                _output.OutputLine("PowerTube turned off");
                _output.OutputLine("Light is turned off");
                _output.OutputLine("Display cleared");
            });
        }

    }
}