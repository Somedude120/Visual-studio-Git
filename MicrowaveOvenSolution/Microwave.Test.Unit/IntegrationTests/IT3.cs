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
        // Classes that have an interface which is under test
        private Door _door;
        private Button _powerButton;
        private Button _startCancelButton;
        private Button _timeButton;

        // Stubs
        private IOutput _fakeDisplayOutput;
        private IOutput _fakePowerTubeOutput;
        private IOutput _fakeLightOutput;

        // Classes that have been tested
        private Timer _timer;
        private Display _display;
        private PowerTube _powerTube;
        private Light _light;
        private CookController _cookController;
        private UserInterface _userInterface;

        [SetUp]
        public void Setup()
        {
            _door = new Door();
            _powerButton = new Button();
            _startCancelButton = new Button();
            _timeButton = new Button();

            _fakeDisplayOutput = Substitute.For<IOutput>();
            _fakePowerTubeOutput = Substitute.For<IOutput>();
            _fakeLightOutput = Substitute.For<IOutput>();

            _timer = new Timer();
            _display = new Display(_fakeDisplayOutput);
            _powerTube = new PowerTube(_fakePowerTubeOutput);
            _light = new Light(_fakeLightOutput);
            _cookController = new CookController(_timer, _display,
                _powerTube, _userInterface);
            _userInterface = new UserInterface(_powerButton,
                _timeButton, _startCancelButton, _door, _display,
                _light, _cookController);
        }

        [Test]
        public void Door_OpenDoor_OutputIsCalled()
        {
            // Act
            _door.Open();

            // Assert
            _fakeLightOutput.Received().OutputLine(Arg.Any<string>());
        }

        [TestCase(1)]
        [TestCase(5)]
        public void PowerButton_PressButton_OutputIsCalled(int timesToPress)
        {
            // Arrange
            _door.Open();
            _door.Close();

            // Act
            for (int i = 0; i < timesToPress; i++)
            {
                _powerButton.Press();
            }

            // Assert
            _fakeDisplayOutput.Received(timesToPress).OutputLine(Arg.Any<string>());
        }

        [TestCase(1)]
        [TestCase(5)]
        public void TimerButton_PressButton_OutputIsCalled(int timesToPress)
        {
            // Arrange
            _door.Open();
            _door.Close();
            _powerButton.Press();

            // Act
            for (int i = 0; i < timesToPress; i++)
            {
                _timeButton.Press();
            }

            // Assert
            // timesToPress + 1 -> as Power-button will generate one call
            _fakeDisplayOutput.Received(timesToPress + 1).OutputLine(Arg.Any<string>());
        }

        [Test]
        public void StartCancelButton_PressButon_OutputIsCalled()
        {
            // Arrange
            _door.Open();
            _door.Close();
            _powerButton.Press();
            _timeButton.Press();

            // Act
            _startCancelButton.Press();

            // Assert
            _fakePowerTubeOutput.Received().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void Door_OpenDoorWhenRunning_OutputIsCalled()
        {
            // Arrange
            _door.Open();
            _door.Close();
            _powerButton.Press();
            _timeButton.Press();
            _startCancelButton.Press();

            // Act
            _door.Open();

            // Assert
            _fakePowerTubeOutput.Received().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void StartCancelButton_PressButtonWhenRunning_OutputIsCalled()
        {
            // Arrange
            _door.Open();
            _door.Close();
            _powerButton.Press();
            _timeButton.Press();
            _startCancelButton.Press();

            // Act
            _startCancelButton.Press();

            // Assert
            _fakePowerTubeOutput.Received().OutputLine(Arg.Any<string>());
        }

        //Test between output and display
        [Test]
        public void Output_Displaytest()
        {
            //Testshowtime
            _display.ShowTime(10,5);
            _fakeDisplayOutput.OutputLine("10:05");

            //Testclear
            _display.Clear();
            _fakeDisplayOutput.OutputLine("cleared");
            
            //Testshowpower
            _display.ShowPower(100);
            _fakeDisplayOutput.OutputLine("W 100");

        }
    }
}