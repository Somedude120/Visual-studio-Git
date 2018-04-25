using System;
using System.Collections.Generic;
using AirTrafficLibrary.Interface;
using TransponderReceiver;

namespace AirTrafficLibraryConsole.Classes
{
    public class EventHandling : IEventHandler
    {
        public event EventHandler SomethingHappened;

        public void DoSomething(TrackObject track1, TrackObject track2)
        {
            

            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        private ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
        private List<TrackObject> tracklist = new List<TrackObject>();
        private TrackInfoPosition tracker = new TrackInfoPosition();
        private DataHandler _dataHandler;
        private Parse _parse = new Parse();
        public void TransponderEventHandler()
        {
            TransponderReceiver.TransponderDataReady += MakeTrack;
        }

        private void MakeTrack(object sender,
            RawTransponderDataEventArgs e)
        {

            _dataHandler = new DataHandler();

            Print _printinfo;
            //Klargøring at noget skal "formateres"
            
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in e.TransponderData)
            {
                var data = _parse.ParseFlightInfo(HANS);

                if (FlightMonitor.MonitoredFlightData(data))
                {
                    var track = new TrackObject(data);
                    track._formattedTime = _dataHandler.FormatTimestamp(data[4]);

                    tracklist.Add(track);
                    
                    

                    tracker.Calculation(tracklist); //Tracker
                    _printinfo = new Print(track);
                }
            }
        }
    }
}