using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


namespace Microwave.Test.Unit.IntegrationTests
{
    [TestFixture]
    class IT2
    {
        //Vi tester Userinterface, powertube, cookcontroller, timer og display
        private UserInterface _uut1;
        private PowerTube _uut2;
        private CookController _uut3;
        private Timer _uut4;
        private Display _uut5;

        private IButton _powerButton, _timeButton, _startCancelButton;

        private IDoor _door;

        private IOutput _output;

        private ILight _light;

        [SetUp]
        public void Setup()
        {
            //UI og light har brug for disse, vi stubber dem bare
            _output = Substitute.For<IOutput>();
            _light = Substitute.For<ILight>();
            _door = Substitute.For<IDoor>();
            _powerButton = Substitute.For<IButton>();
            _timeButton = Substitute.For<IButton>();
            _startCancelButton = Substitute.For<IButton>();
    
            _uut5 = new Display(_output);
            _uut4 = new Timer();
            _uut3 = new CookController(_uut4, _uut5, _uut2); //Timer, Display, Powertube
            _uut2 = new PowerTube(_output);
            _uut1 = new UserInterface(
                _powerButton, _timeButton, _startCancelButton,
                _door,
                _uut5,
                _light,
                _uut3); //buttons, door, display, light, cooker

            _uut3.UI = _uut1; //Laver userinterface ved afbenyttelse af property injection

        }

        [Test]
        public void UI_ShowPower_Display()
        {
            //Trykker på powerknappen
            _uut1.OnPowerPressed(_powerButton, new EventArgs());
            
            
            _output.Received().OutputLine("Display shows: 50 W");
        }

        [Test]
        public void UI_ShowTime_Display()
        {
            //Trykker på showtimeknappen
            _uut1.OnTimePressed(_timeButton, new EventArgs());

            _output.Received().OutputLine("Display shows: 00:00");
        }
        
        //[Test]
        //public void UserInterface_ReadyState_OpenDoor_LightWritesOnToLog()
        //{
        //    //Arrange
        //    //State is already correct

        //    //Act
        //    _uutUserInterface.OnDoorOpened(_door, new EventArgs());

        //    //Assert
        //    _lightOutput.Received().OutputLine("Light is turned on");
        //}

        //[Test]
        //public void UserInterface_ReadyState_PressPowerButton_DisplayWritesPowerToLog()
        //{
        //    //Arrange
        //    //State is already correct

        //    //Act
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display shows: 50 W");
        //}
      

        
        //[Test]
        //public void UserInterface_DoorIsOpenState_CloseDoor_LightWritesOffToLog()
        //{
        //    //Arrange
        //    _uutUserInterface.OnDoorOpened(_door, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnDoorClosed(_door, new EventArgs());

        //    //Assert
        //    _lightOutput.Received().OutputLine("Light is turned off");
        //}

       

        
        //[Test]
        //public void UserInterface_SetPowerState_PressPowerButton_DisplayWritesPowerToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display shows: 100 W");
        //}

        //[Test]
        //public void UserInterface_SetPowerState_PressPowerButtonTwice_DisplayWritesPowerToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display shows: 150 W");
        //}

        //[Test]
        //public void UserInterface_SetPowerState_PressStartCancelButton_DisplayWritesClearedToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnStartCancelPressed(_startCancelButton, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display cleared");
        //}

        //[Test]
        //public void UserInterface_SetPowerState_OpenDoor_DisplayWritesClearedToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnDoorOpened(_door, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display cleared");
        //}

        //[Test]
        //public void UserInterface_SetPowerState_OpenDoor_LightWritesOnToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnDoorOpened(_door, new EventArgs());

        //    //Assert
        //    _lightOutput.Received().OutputLine("Light is turned on");
        //}

        //[Test]
        //public void UserInterface_SetPowerState_PressTimeButton_DisplayWritesTimeToLog()
        //{
        //    //Arrange
        //    //Get to state
        //    _uutUserInterface.OnPowerPressed(_powerButton, new EventArgs());

        //    //Act
        //    _uutUserInterface.OnTimePressed(_timeButton, new EventArgs());

        //    //Assert
        //    _displayOutput.Received().OutputLine("Display shows: 01:00");
        //}

    }
}
