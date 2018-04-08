using System;
using System.Globalization;

namespace AirTrafficLibrary
{
    public class Parse
    {
        public string ParseFlightInfo(string info)
        {
            string[] splitInfo = info.Split(';');

            //Jeg får disse ting ud af dll filen
            string format = "yyyyMMddHHmmssfff";
            string tag = splitInfo[0];
            long xCoord = Convert.ToInt64(splitInfo[1]);
            long yCoord = Convert.ToInt64(splitInfo[2]);
            long altitude = Convert.ToInt64(splitInfo[3]);
            string timestamp = splitInfo[4];
            DateTime date = DateTime.ParseExact(timestamp, format, CultureInfo.CreateSpecificCulture("en-US"));
            string dateformat = String.Format(new CultureInfo("en-US"), "{0:MMMM dd'th', yyyy, 'at' HH:mm:ss 'and' fff 'miliseconds'}", date);

            //Output
            string text = $"\nTag: {tag}\nXCoord: {xCoord} Meters\nYCoord: {yCoord} Meters\nAltitude: {altitude} Meters\nTimestamp: {dateformat}";


            //Rendering af at den ikke vil tage noget med hvis fly har noget specifikke coords
            //Opgave 5
            /*if (xCoord < 10000 && yCoord < 10000 || xCoord > 90000 && yCoord > 90000 || xCoord > 10000 || yCoord > 90000 || altitude < 500 || altitude > 20000)
            {
                return "";
            }
            */

            return text;

        }
    }
}