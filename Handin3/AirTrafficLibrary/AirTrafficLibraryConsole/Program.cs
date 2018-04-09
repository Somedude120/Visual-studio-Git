﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Classes;
using TransponderReceiver;

namespace AirTrafficLibrary
{
    class Program
    {
        
        static void Main()
        {
            
            //ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            //TransponderReceiver.TransponderDataReady += TransponderReceiverOnTransponderDataReady;
            EventHandling Events = new EventHandling();
            Events.TransponderEventHandler();

            while (true)
            {
                
            }
            
        }

        static private void TransponderReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            DataHandler _dataHandler = new DataHandler();
            
            //Klargøring at noget skal "formateres"
            Parse obj = new Parse();
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in rawTransponderDataEventArgs.TransponderData)
            {
                _dataHandler.UnformattedInfo(HANS);
                List<string> ParsedFlight = new List<string>();
                _dataHandler.Splitter(ParsedFlight);
                //Ta track obj
                //Parse data igennem så vi får i uformatteretstrings
                TrackConversion obj1 = new TrackConversion(HANS);

                //Formatere string til 4 forskellige strings
                ParsedFlight = obj.ParseFlightInfo(obj1.UnformattedInfo);
                //Formattere den timestamp fordi den er retarderet
                ParsedFlight[4] = DataHandler.FormatTimestamp(ParsedFlight[4]);
                //Tilsæt den nye formatteret liste med fly ind i list
                obj1.List(ParsedFlight);
                TrackObject _trackobject = new TrackObject(ParsedFlight);

                if (FlightMonitor.MonitoredFlightData(ParsedFlight))
                obj1.Print();
                //Console.WriteLine($"\nTag: {ParsedFlight[0]}\nXCoord: {ParsedFlight[1]}\nYCoord: {ParsedFlight[2]}\nAltitude: {ParsedFlight[3]}\nTimestamp: {ParsedFlight[4]}");
                //Print ud

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
