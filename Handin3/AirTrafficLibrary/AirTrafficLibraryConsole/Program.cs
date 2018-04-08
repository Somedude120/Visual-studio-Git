using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficLibrary
{
    class Program
    {

        static void Main()
        {

            ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TransponderReceiver.TransponderDataReady += TransponderReceiverOnTransponderDataReady;
            
            DateTime time = new DateTime(2015,10,06,21,34,56,789);
            //string timestamp = DateTime.Parse("20151006213456789", null).ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
            string format = "MMMM MM, yyyy, HH:mm:ss fff";
            string time1 = time.ToString(format, CultureInfo.CurrentUICulture);
            Console.WriteLine(time1);

            while (true)
            {
            }
        }

        private static void TransponderReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            string Hans;
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in rawTransponderDataEventArgs.TransponderData)
            {
                Hans = ParseFlightInfo(HANS);
                Console.WriteLine(Hans);
            }
        }
        static public string ParseFlightInfo(string info)
        {
            string[] splitInfo = info.Split(';');

            string format = "yyyyMMddhhmmssfff";
            string tag = splitInfo[0];
            string xCoord = splitInfo[1];
            string yCoord = splitInfo[2];
            string altitude = splitInfo[3];
            long date = Convert.ToInt64(splitInfo[4]);
            DateTime timestamp = new DateTime(date);
            string timestamp1 = timestamp.ToString(format);

            string text = $"\nTag: {tag}\nXCoord: {xCoord} Meters\nYCoord{yCoord} Meters\nAltitude: {altitude} Meters\nTimestamp: {timestamp1}";
            return text;

        }

    }
}
