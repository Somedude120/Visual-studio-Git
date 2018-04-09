using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AirTrafficLibrary
{
    public class Parse
    {
        
        public List<string> ParseFlightInfo(string info)
        {
            List<string> planeList = new List<string>();
            planeList = info.Split(';').ToList();


            //Jeg får disse ting ud af dll filen
            string format = "yyyyMMddHHmmssfff";
            //string tag = planeList[0];
            //long xCoord = Convert.ToInt64(planeList[1]);
            //long yCoord = Convert.ToInt64(planeList[2]);
            //long altitude = Convert.ToInt64(planeList[3]);
            string timestamp = planeList[4];
            DateTime date = DateTime.ParseExact(timestamp, format, CultureInfo.CreateSpecificCulture("en-US"));
            string dateformat = String.Format(new CultureInfo("en-US"), "{0:MMMM d}{1}{0:, yyyy, 'at' HH:mm:ss 'and' fff 'miliseconds'}", date, GetDaySuffix(date));   //Format date correctly

            //Output
            //string text = $"\nTag: {tag}\nXCoord: {xCoord} Meters\nYCoord: {yCoord} Meters\nAltitude: {altitude} Meters\nTimestamp: {dateformat}";


            //Rendering af at den ikke vil tage noget med hvis fly har noget specifikke coords
            //Opgave 5
            /*if (xCoord < 10000 && yCoord < 10000 || xCoord > 90000 && yCoord > 90000 || xCoord > 10000 || yCoord > 90000 || altitude < 500 || altitude > 20000)
            {
                return "";
            }
            */

            return planeList;

        }
        public static string FormatTimestamp(string timestamp)
        {
            string format = "yyyyMMddHHmmssfff";    //Format givet af t
            DateTime date = DateTime.ParseExact(timestamp, format, CultureInfo.CreateSpecificCulture("en-US"));
            string dateformat = String.Format(new CultureInfo("en-US"), "{0:MMMM d}{1}{0:, yyyy, 'at' HH:mm:ss 'and' fff 'miliseconds'}", date, GetDaySuffix(date));   //Format date correctly

            return dateformat;
        }

        private static string GetDaySuffix(DateTime timeStamp)
        {
            //returns "st", "nd", "rd" or "th"
            return (timeStamp.Day % 10 == 1 && timeStamp.Day != 11) ? "st"
                : (timeStamp.Day % 10 == 2 && timeStamp.Day != 12) ? "nd"
                : (timeStamp.Day % 10 == 3 && timeStamp.Day != 13) ? "rd"
                : "th";
        }
    }
}