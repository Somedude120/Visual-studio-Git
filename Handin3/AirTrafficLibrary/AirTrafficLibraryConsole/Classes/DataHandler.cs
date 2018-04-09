using System;
using System.Collections.Generic;
using System.Globalization;

namespace AirTrafficLibraryConsole.Classes
{
    public class DataHandler
    {
        private Parse _formatter;
        private string _unformatted;
        public string UnformattedInfo(string args)
        {
            _unformatted = args;
            return args;
        }

        public List<string> Splitter(List<string> formatted)
        {
            //Formatting
            _formatter = new Parse();
            //Tilsæt format
            formatted = _formatter.ParseFlightInfo(_unformatted);
            return formatted;
        }

        public static string FormatTimestamp(string timestamp)
        {
            string format = "yyyyMMddHHmmssfff";    //Format
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