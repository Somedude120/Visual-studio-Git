using System;
using System.Threading;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.Test.Intergration
{
    [TestFixture]
    public class IT3
    {
        //Ændret til test af UI, Cookcontroller og timer
        private IDisplay _display;
        private ITimer _timer;
        private IUserInterface _ui;

        private ICookController _uut1;
        private IPowerTube _powerTube;


        [SetUp]
        public void SetUp()
        {
            //Det er en nødvendighed at bruge substitutioner pga. tests af aktuelle kald og kan ikke blive set på displayet
            _ui = Substitute.For<IUserInterface>();
            _timer = Substitute.For<ITimer>();
            _display = Substitute.For<IDisplay>();
            _powerTube = Substitute.For<IPowerTube>();

            _uut1 = new CookController(_timer, _display, _powerTube, _ui);
        }


        
        [Test]
        public void CookControllerOnTimerExpired_PowerTube()
        {
            //Start cookcontroller med cooker
            _uut1.StartCooking(50, 0);

            //Se om når tiden er gået at den hæver et flag
            _timer.Expired += Raise.EventWith(this, EventArgs.Empty);

            //den skulle modtage noget fra powertube
            _powerTube.Received().TurnOff();
        }

        //Test fra UI, cookcontroller til timer om når tiden går ud efter 1 sekund at den siger cooking is done
        [Test]
        public void CookControllerOnTimerExpired_UI()
        {
            //Start cookcontroller med at cooke
            _uut1.StartCooking(50, 1000);
            //Event flag
            _timer.Expired += Raise.EventWith(this, EventArgs.Empty);
            //Check om UI modtager cooking is done
            _ui.Received().CookingIsDone();
        }


        //Checker om displayet viser en ny tid efter at blive startet fra CC, husk på at det er sekunder (6000), derfor skulle den helst vise 10 minutter
        [Test]
        public void CookControllerOnTimerTick_Display()
        {
            //Start cookcontroller med at cooke
            _uut1.StartCooking(50, 600);

            //display hvad der er på displayed når der er 600 sekunder tilbage
            _timer.TimeRemaining.Returns(600);
            //Event flag
            _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);

            //Check om det bliver vist på displayet
            _display.Received().ShowTime(10, 0);
            
        }

        //Test af timeren
        [Test]
        public void CookControllerStartCooking_Timer()
        {
            //Start cookcontroller med at cooke
            _uut1.StartCooking(50, 30);

            //Check om timer modtager Start(30)
            _timer.Received().Start(30);
        }

        [Test]
        public void CookControllerStopCooking_Timer()
        {
            //Stop cookcontroller
            _uut1.Stop();

            //Check om timer har modtaget stop()
            _timer.Received().Stop();
        }
    }
}