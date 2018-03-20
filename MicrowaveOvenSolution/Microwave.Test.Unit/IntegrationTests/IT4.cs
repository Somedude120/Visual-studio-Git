using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Intergration
{
    [TestFixture]
    class IT4
    {
        private IOutput _output;


        private IButton _powerButton, _timerButton, _startButton;
        
        private IDoor _door;

        //Testing powertube
        private IPowerTube _powerTube;
        //Testing cookcontroller
        private ICookController _cookController;
        //Stuff for cookcontroller (Gonna be substituted)
        private IUserInterface _ui;
        private ITimer _timer;
        private IDisplay _display;

        private IUserInterface _userInterface;

        [SetUp]
        public void Setup()
        {
            _timer = Substitute.For<ITimer>();
            _display = Substitute.For<IDisplay>();
            _ui = Substitute.For<IUserInterface>();

            _powerTube = new PowerTube(_output);

            _cookController = new CookController(_timer, _display, _powerTube, _ui);

            _powerButton = new Button();
            _timerButton = new Button();
            _startButton = new Button();

            _output = new Output();

            IDisplay display = new Display(_output);
            _userInterface = new UserInterface(_powerButton, _timerButton, _startButton, _door = new Door(), display, new Light(_output), new CookController(new Timer(), display, new PowerTube(_output)));
        }

        [Test]
        public void output_openDoor_OutputCorrect()
        {
            //Arrange
            var consoleOutput = new ConsoleOutput();

            //Act
            _door.Open();

            //Assert
            Assert.IsTrue(consoleOutput.GetOuput().Contains("Light") && consoleOutput.GetOuput().Contains("turned on"));
        }
        [Test]
        public void output_closeDoor_OutputCorrect()
        {
            //Arrange
            var consoleOutput = new ConsoleOutput();

            //Act
            _door.Close();

            //Assert
            Assert.IsTrue(consoleOutput.GetOuput().Contains("Light") && consoleOutput.GetOuput().Contains("turned off"));
        }



        [TestCase(1)]
        [TestCase(5)]
        public void output_PowerbuttonPress_OutputCorrect(int timesToPress)
        {
            //Arrange
            var consoleOutput = new ConsoleOutput();

            //Act
            for (int i = 0; i < timesToPress; i++)
            {
                _powerButton.Press();
            }

            //Assert
            Assert.IsTrue(consoleOutput.GetOuput().Contains("Display") && consoleOutput.GetOuput().Contains($"{timesToPress * 50} W"));
        }

        [TestCase(1)]
        [TestCase(5)]
        public void output_timebuttonPress_OutputCorrect(int timesToPress) //virker ikke
        {
            //Arrange
            var consoleOutput = new ConsoleOutput();
            //Act
            for (int i = 0; i < timesToPress; i++)
            {
                _timerButton.Press();
            }
            //Assert
            Assert.IsTrue(consoleOutput.GetOuput().Contains("Display") && consoleOutput.GetOuput().Contains($"{timesToPress:D2}:00"));
        }


        public class ConsoleOutput : IDisposable
        {
            //From https://stackoverflow.com/questions/2139274/grabbing-the-output-sent-to-console-out-from-within-a-unit-test
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOuput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }

        //Step 4, powertube to cookcontroller
        [Test]
        public void powerTube_Cookcontrollertest()
        {
            _cookController.StartCooking(50,60);
            _powerTube.Received().TurnOn(50);
        }
    }
}