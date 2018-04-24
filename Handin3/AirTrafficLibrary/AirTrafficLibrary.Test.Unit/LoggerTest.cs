using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;
using AirTrafficLibraryConsole.Classes;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class LoggerTest
    {

        [Test]
        public void Logger_FileExists()
        {
            var uut = new Logger();

            uut.LogWriter("LogWriteTest");

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "SeperationLog.txt";

            Assert.IsTrue(File.Exists(path));
        }

        [Test]
        public void Logger_ThrowIfStringIsEmpty()
        {
            var uut = new Logger();

            string Logger = "";

            Assert.Throws<ArgumentException>(() => { uut.LogWriter(Logger); });
        }
    }
}
