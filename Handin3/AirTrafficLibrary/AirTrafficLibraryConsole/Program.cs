using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
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
            

            while (true)
            {
                System.Threading.Thread.Sleep(1500);

            
            }

            //string timetest = "20151006213456789";



            //DateTime time = new DateTime(2015,10,06,21,34,56,789);
            ////string timestamp = DateTime.Parse("20151006213456789", null).ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
            //string format = "MMMM MM, yyyy, HH:mm:ss fff";
            //DateTime myDate = DateTime.ParseExact(timetest, "yyyyMMddHHmmssfff", new CultureInfo("en-US",true));
            ////string time1 = time.ToString(format, CultureInfo.CurrentUICulture);
            //string dateformat = String.Format(new CultureInfo("en-US"),"{0:MMMM MM'th', yyyy, 'at' HH:mm:ss 'and' fff 'miliseconds'}", myDate);
            //string secondsformat = String.Format(new CultureInfo("en-US"), "{0:fff}", myDate);
            //Console.WriteLine(dateformat);
            //Console.WriteLine(secondsformat);
            //while (true)
            //{
            //}
        }

        static private void TransponderReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            Parse obj = new Parse();
            //string Hans;
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in rawTransponderDataEventArgs.TransponderData)
            {
                List<string> ParsedFlight = new List<string>();
                //Ta track obj
                //Parse data igennem så vi får i uformatteretstrings
                Track obj1 = new Track(HANS);
                //Formatere string til 4 forskellige strings
                ParsedFlight = obj.ParseFlightInfo(obj1.UnformattedInfo);
                //Formattere den timestamp fordi den er retarderet
                ParsedFlight[4] = Parse.FormatTimestamp(ParsedFlight[4]);
                //sæt det ind i anden constructor til Track
                //TrackObject obj3 = new TrackObject(ParsedFlight);
                

                //Print ud
                Console.WriteLine($"\nTag: {ParsedFlight[0]}\nXCoord: {ParsedFlight[1]}\nYCoord: {ParsedFlight[2]}\nAltitude: {ParsedFlight[3]}\nTimestamp: {ParsedFlight[4]}");
                //Hans = obj.ParseFlightInfo(HANS);


            }
        }

        static public long Velocity(int hour, int minutes, int seconds, int miliseconds)
        {
            int oldhour = hour - hour;
            int oldminute = minutes - minutes;
            int oldseconds = seconds - seconds;
            long result = 0;


            return result;
        }

    }
}
