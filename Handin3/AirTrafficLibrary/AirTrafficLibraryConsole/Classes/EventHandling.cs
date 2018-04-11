using System;
using System.Collections.Generic;
using AirTrafficLibrary.Interface;
using TransponderReceiver;

namespace AirTrafficLibraryConsole.Classes
{
    public class EventHandling : IEventHandler
    {
        private ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

        public void TransponderEventHandler()
        {
            TransponderReceiver.TransponderDataReady += TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
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
    }
}