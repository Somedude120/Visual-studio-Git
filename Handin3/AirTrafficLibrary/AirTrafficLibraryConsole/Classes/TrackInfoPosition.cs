using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficLibraryConsole.Classes
{
    public class TrackInfoPosition
    {
        private List<TrackObject> oldList;
        private List<TrackObject> currentList;
        private CalculateCourse _course;

        public TrackInfoPosition()
        {
            oldList = new List<TrackObject>();
            currentList = new List<TrackObject>();
        }

        public List<TrackObject> Calculation(List<TrackObject> newlist)
        {
            currentList = newlist;

            if (oldList.Count != 0 && oldList != currentList)
            {
                Console.WriteLine(oldList[0]._xCoord);
                List<TrackObject> local = new List<TrackObject>(newlist);
                local = SortTrackObjects(local);
                //CalculateSpeed(local);
                Course(local);
            }
            else
            {
                oldList = newlist;
            }

            return currentList;
        }

        public List<TrackObject> Course(List<TrackObject> newlist)
        {
            for (int i = 0; i < newlist.Count; i++)
            {
                Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
                double x1 = Convert.ToDouble(newlist[i]._xCoord);
                double x2 = Convert.ToDouble(oldList[i]._xCoord);
                double y1 = Convert.ToDouble(oldList[i]._yCoord);
                double y2 = Convert.ToDouble(newlist[i]._yCoord);

                _course = new CalculateCourse(x1, x2, y1, y2);
                newlist[i]._direction = Convert.ToString(_course._Angle);
                //Console.WriteLine("test " + newlist[i]._direction + "object: " + newlist[i]._tag);
            }
            
            return newlist;

        }
        public List<TrackObject> SortTrackObjects(List<TrackObject> sortList)
        {
            sortList.OrderBy(TrackObject => TrackObject._tag);
            oldList.OrderBy(TrackObject => TrackObject._tag);
            for (int i = 0; i < sortList.Count; i++)
            {
                try
                {
                    if (sortList[i]._tag == oldList[i]._tag)
                    {
                    }
                }
                catch (Exception e)
                {
                    if (sortList.Count > oldList.Count)
                        sortList.RemoveAt(i);
                    else if (oldList.Count > sortList.Count)
                    {
                        oldList.RemoveAt(i);
                    }
                    i--;
                }
            }
            return sortList;
        }
    }

}