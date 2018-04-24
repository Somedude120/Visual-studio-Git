using System;
using System.Collections.Generic;
using AirTrafficLibrary.Interface;
using TransponderReceiver;

namespace AirTrafficLibraryConsole.Classes
{
    public class EventHandling : IEventHandler
    {
        private ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
        private List<TrackObject> tracklist = new List<TrackObject>();

        public void TransponderEventHandler()
        {
            TransponderReceiver.TransponderDataReady += TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            TrackInfoPosition tracker = new TrackInfoPosition();
            DataHandler _dataHandler = new DataHandler();
 
            Print _printinfo;
            //Klargøring at noget skal "formateres"
            Parse parse = new Parse();
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in rawTransponderDataEventArgs.TransponderData)
            {
                _dataHandler.UnformattedInfo(HANS);
                List<string> ParsedFlight = new List<string>();
                _dataHandler.Splitter(ParsedFlight);
                //Ta track obj
                //Parse data igennem så vi får i uformatteretstrings
                TrackConversion trackConversion = new TrackConversion(HANS);

                //Formatere string til 4 forskellige strings
                ParsedFlight = parse.ParseFlightInfo(trackConversion.UnformattedInfo);
                //Formattere den timestamp
                ParsedFlight[4] = DataHandler.FormatTimestamp(ParsedFlight[4]);
                //Tilsæt den nye formatteret liste med fly ind i list
                trackConversion.List(ParsedFlight);
                TrackObject _trackobject = new TrackObject(ParsedFlight);
                tracklist.Add(_trackobject);

                if (FlightMonitor.MonitoredFlightData(ParsedFlight))
                _printinfo = new Print(_trackobject);;
                
            }
            
            tracklist = tracker.Calculation(tracklist);
            if (tracklist.Count != 0)
            {
                tracker.Course(tracklist);
            }
        }
    }
}