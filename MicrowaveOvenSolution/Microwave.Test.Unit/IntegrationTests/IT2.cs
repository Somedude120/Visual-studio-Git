using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
            
            //Sætter timeknappen
            _uut5.ShowTime(10,0);
            //Trykker på showtimeknappen
            //_uut1.OnTimePressed(_timeButton, new EventArgs());

            //Man kan også hænge det hele sammen og få det til at virke med UI construktoren
            _uut3.UI.OnTimePressed(_timeButton, new EventArgs());

            _output.Received().OutputLine("Display shows: 10:00");
        }

        [Test]
        public void UI_StartCooking_CookController_StartTimer_Timer_Output()
        {
            //Trykker startcancelknappen
            //_uut1.OnStartCancelPressed(_startCancelButton, new EventArgs());
            _uut3.UI.OnStartCancelPressed(_startCancelButton, new EventArgs());
            //Starter cookcontroller
            _uut4.Start(10);
            //Event på timeren viser hvor meget der står i displayet
            _uut3.OnTimerTick(_timeButton, new EventArgs());
            _output.Received().OutputLine("Display shows: 00:10");


        }

        [Test]
        public void UI_Clear_Display()
        {
            //Tryk powerknappen
            _uut1.OnPowerPressed(_powerButton, new EventArgs());

            //Tryk på start eller cancel knappen
            _uut1.OnStartCancelPressed(_startCancelButton, new EventArgs());
            

            _output.Received().OutputLine("Display cleared");



        }

        [Test]
        public void UI_CookController_PowerTube_Output()
        {


        }
    }
}
