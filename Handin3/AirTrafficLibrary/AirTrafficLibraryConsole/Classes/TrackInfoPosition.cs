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
        private CalculateVelocity _velocity;

        public TrackInfoPosition()
        {
            oldList = new List<TrackObject>();
            currentList = new List<TrackObject>();
        }

        public List<TrackObject> Calculation(List<TrackObject> newlist)
        {
            //currentList = newlist;

            //Console.WriteLine("newlist coord: " + newlist[0]._xCoord);

            currentList.Clear();

            foreach (var track in newlist)
                currentList.Add(track);




            if (oldList.Count != 0 && oldList != newlist)
            {
                Console.WriteLine("newlist: " + newlist[newlist.Count -1]._xCoord + " " + "oldlist: " + oldList[oldList.Count -1]._xCoord);
                //Console.WriteLine("Oldlist coord: " + oldList[0]._xCoord);
                List<TrackObject> local = new List<TrackObject>(newlist);
                local = SortTrackObjects(local);
                Velocity(newlist, oldList);

                Course(newlist, oldList);
            }

            oldList.Clear();

            foreach (var track in newlist)
                oldList.Add(track);

            //oldList = newlist;
            return currentList;
        }

        public List<TrackObject> Course(List<TrackObject> newlist, List<TrackObject> oldlist)
        {

            
  

                //Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
                double x1 = Convert.ToDouble(newlist[newlist.Count -1]._xCoord);
                double x2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._xCoord);
                double y1 = Convert.ToDouble(newlist[newlist.Count - 1]._yCoord);
                double y2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._yCoord);

                _course = new CalculateCourse(x1, x2, y1, y2);
                Console.WriteLine("Course Calc: " + _course._Angle + " tag: " + newlist[newlist.Count -1]._tag);
                //newlist[]._direction = Convert.ToString(_course._Angle);
                //Console.WriteLine("test " + newlist[i]._direction + " object: " + newlist[i]._tag);
            
            return newlist;

        }

        public List<TrackObject> Velocity(List<TrackObject> newlist, List<TrackObject> oldlist)
        {




            //Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
            double x1 = Convert.ToDouble(newlist[newlist.Count - 1]._xCoord);
            double x2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._xCoord);
            double y1 = Convert.ToDouble(newlist[newlist.Count - 1]._yCoord);
            double y2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._yCoord);
            double time1 = Convert.ToDouble(newlist[newlist.Count - 1]._datetime);
            double time2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._datetime);

            double timecalc = time1 - time2;


            _velocity = new CalculateVelocity();
            double distance = _velocity.CalcVelocity(x1, x2, y1, y2);

            double velocitycalculated = distance / timecalc;

            Console.WriteLine("Speed " + velocitycalculated + " tag: " + newlist[newlist.Count - 1]._tag);
            //newlist[]._direction = Convert.ToString(_course._Angle);
            //Console.WriteLine("test " + newlist[i]._direction + " object: " + newlist[i]._tag);

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