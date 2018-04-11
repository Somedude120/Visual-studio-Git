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
    public class IT4
    {
        //Ændret til test af timer, cookcontroller, UI
        private IDisplay _display;
        private IPowerTube _powerTube;
        private IUserInterface _ui;
        private IOutput _output;


        private ITimer _uut1;
        private ICookController _uut2;
        


        [SetUp]
        public void SetUp()
        {
            _output = Substitute.For<IOutput>();
            _powerTube = Substitute.For<IPowerTube>();
            _ui = Substitute.For<IUserInterface>();
            _display = Substitute.For<IDisplay>();
            
            _uut1 = new Timer();
            _uut2 = new CookController(_uut1, _display, _powerTube);

        }


        //Her testes om at CC kalder UI korrekt når tiden udløber
        [Test]
        public void TimerOnExpire_CookControllerCallsTurnOff()
        {
            //Lav en manual reset pause
            ManualResetEvent pause = new ManualResetEvent(false);

            //Start cookeren
            _uut2.StartCooking(50, 1);

            //Sæt en pause på 1500 sekunder
            pause.WaitOne(1500);

            //Se at den faktisk slukker derefter
            _powerTube.Received().TurnOff();
        }
        [Test]
        public void TimerOnTimerTick_CookControllerCallsShowTime()
        {
            //Lav en manual reset pause
            ManualResetEvent pause = new ManualResetEvent(false);

            //Start timeren
            _uut1.Start(4);

            //Sæt en pause på 1500 sekunder
            pause.WaitOne(1500);

            //Se at displayed viser en tid på at der er gået 1 sekund
            _display.Received().ShowTime(0, 3);
        }
    }
}