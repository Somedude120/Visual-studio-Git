﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficLibraryConsole.Classes
{
    public class TrackInfoPosition
    {
        private List<TrackObject> oldList;
        private List<TrackObject> currentList;
        private CalculateCourse _course;
        private CalculateVelocity _distance = new CalculateVelocity();


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
                //Console.WriteLine("newlist: " + newlist[newlist.Count -1]._xCoord + " " + "oldlist: " + oldList[oldList.Count -1]._xCoord);
                //Console.WriteLine("Oldlist coord: " + oldList[0]._xCoord);
                List<TrackObject> local = new List<TrackObject>(newlist);
                local = SortTrackObjects(local);
                //Velocity(newlist, oldList);
                Velocity(local);
                Course(local);
                //Course(newlist, oldList);
            }

            oldList.Clear();

            foreach (var track in newlist)
                oldList.Add(track);

            //oldList = newlist;
            return currentList;
        }

        public List<TrackObject> Course(List<TrackObject> newlist)
        {
            for (int i = 0; i < oldList.Count; i++)
            {
                //Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
                double x1 = newlist[i]._xCoord;
                double x2 = oldList[i]._xCoord;
                double y1 = oldList[i]._yCoord;
                double y2 = oldList[i]._xCoord;
                _course = new CalculateCourse(x1, x2, y1, y2);
                //Console.WriteLine("Course Calc: " + _course._Angle + " tag: " + newlist[i]._tag);
                newlist[i]._direction = _course._Angle;
            }
            

            return newlist;
        }

        
        public List<TrackObject> Velocity(List<TrackObject> newlist)
        {


            for (int i = 0; i < oldList.Count; i++)
            {
                //Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
                double x1 = oldList[i]._xCoord;
                double x2 = newlist[i]._xCoord;
                double y1 = oldList[i]._yCoord;
                double y2 = oldList[i]._xCoord;
                var newTO = (newlist[i]._timestamp.Second) + newlist[i]._timestamp.Millisecond;
                var oldTO = (oldList[i]._timestamp.Second) + oldList[i]._timestamp.Millisecond;

                string difftime = Convert.ToString(newTO - oldTO);

                double diffDouble = Convert.ToDouble(difftime);
                double velocity = _distance.CalcVelocity(x1, x2, y1, y2, diffDouble);
                
                newlist[i]._hVelocity = velocity;
                Console.WriteLine("Velocity " + velocity);

                //double _distance = 
            }


            return newlist;

            //Console.WriteLine(newlist[i]._xCoord + " " + oldList[i]._xCoord);
            //double x1 = Convert.ToDouble(newlist[newlist.Count - 1]._xCoord);
            //double x2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._xCoord);
            //double y1 = Convert.ToDouble(newlist[newlist.Count - 1]._yCoord);
            //double y2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._yCoord);
            //double time1 = Convert.ToDouble(newlist[newlist.Count - 1]._timestamp.Hour + newlist[newlist.Count - 1]._timestamp.Second);
            //double time2 = Convert.ToDouble(oldlist[oldlist.Count - 1]._timestamp.Hour + oldlist[oldlist.Count - 1]._timestamp.Second);

            //var newTO = newlist[newlist.Count - 1]._timestamp;
            //var oldTO = oldlist[oldlist.Count - 1]._timestamp;

            //TimeSpan timecalc = newTO.Subtract(oldTO);
            //Console.WriteLine(timecalc);

            //_velocity = new CalculateVelocity();
            //double distance = _velocity.CalcVelocity(x1, x2, y1, y2);

            ////double velocitycalculated = distance / timecalc;

            ////Console.WriteLine("Speed " + velocitycalculated + "m/s " + " tag: " + newlist[newlist.Count - 1]._tag);
            ////newlist[]._direction = Convert.ToString(_course._Angle);
            ////Console.WriteLine("test " + newlist[i]._direction + " object: " + newlist[i]._tag);

            //return newlist;

        }

        

        public List<TrackObject> SortTrackObjects(List<TrackObject> sortList)
        {
            sortList = sortList
                .OrderBy(x => x._tag)
                .ThenBy(x => x._tag)
                .ToList();
            for (int i = 0; i < sortList.Count; i++)
            {
                //Console.WriteLine(sortList[i]._tag); //Testloop

            }
            return sortList;
        }

       
    }

}