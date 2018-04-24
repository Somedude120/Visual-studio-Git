using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Classes;
using NUnit.Framework;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    class LoggerTest
    {
        [Test]
        public void FileExists()
        {
            var uut = new Logger();

            uut.LogWriter("LogWriteTest");

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "SeperationLog.txt";

            Assert.IsTrue(File.Exists(path));
        }
    }
}
