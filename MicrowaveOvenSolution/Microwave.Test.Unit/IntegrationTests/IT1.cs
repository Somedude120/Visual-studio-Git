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
using NSubstitute.ExceptionExtensions;
using Assert = NUnit.Framework.Assert;

//Vi skal teste mellem Light og UI, vi afbenytter os af buttons, display, door, output, cooker som stubbe imens vi tester light og UI.
namespace Microwave.Test.Unit.Tests
{
    [TestFixture]
    public class IntegrationTest1
    {
        //Vi tester Userinterface og light
        private UserInterface _uut1;
        private Light _uut2;

        private IButton _powerButton, _timeButton, _startCancelButton;

        private IDoor _door;

        private IDisplay _display;

        private IOutput _output;

        private ICookController _cooker;



        [SetUp]
        public void Setup()
        {
            //UI og light har brug for disse, vi stubber dem bare
            _output = Substitute.For<IOutput>();
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _powerButton = Substitute.For<IButton>();
            _timeButton = Substitute.For<IButton>();
            _startCancelButton = Substitute.For<IButton>();
            _cooker = Substitute.For<ICookController>();

            _uut2 = new Light(_output);
            _uut1 = new UserInterface(
                _powerButton, _timeButton, _startCancelButton,
                _door,
                _display,
                _uut2,
                _cooker);

        }

        [Test]
        public void UI_turningOn_Light()
        {
            
            //Åbner døren
            _uut1.OnDoorOpened(_door, new EventArgs());
            //Checker om output fra lys er tændt
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("on")));
        }

        [Test]
        public void UI_turningOff_Light()
        {
            //Åbner døren
            _uut1.OnDoorOpened(_door,new EventArgs());
            //Lukker døren
            _uut1.OnDoorClosed(_door, new EventArgs());
            //Checker om output fra lys er slukket
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("off")));

        }

        [Test]
        public void UI_pressButtonStartCancel_Lighton()
        {
            //Lukker døren
            _uut1.OnDoorClosed(_door, new EventArgs());
            //Trykker på powerknappen
            _uut1.OnPowerPressed(_powerButton, new EventArgs());
            //Trykker på timerknappen
            _uut1.OnTimePressed(_timeButton,new EventArgs());
            //Trykker på cancelstartbutton
            _uut1.OnStartCancelPressed(_startCancelButton,new EventArgs());


            //Checker om output fra lys er tændt
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("on")));

        }

        [Test]
        public void UI_CookingIsDone_Light()
        {
            //Trykker på powerknappen
            _uut1.OnPowerPressed(_powerButton, new EventArgs());
            //Trykker på timerknappen
            _uut1.OnTimePressed(_timeButton, new EventArgs());
            //Trykker på cancelstartbutton
            _uut1.OnStartCancelPressed(_startCancelButton, new EventArgs());
            //Færdig med at nuke din mad
            _uut1.CookingIsDone();
            
            //Tjek lyset om den er slukket
            _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("off")));
            
        }
    }
}
