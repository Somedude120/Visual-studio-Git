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
    public class IT2
    {
        private IOutput _outputDisplay;
        private IOutput _outputPower;

        private IDisplay _display;
        private ITimer _timer;
        private IPowerTube _powerTube;
        private ICookController _cookController;
    }
}
