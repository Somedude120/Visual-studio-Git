﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Output output = new Output();
            Display display = new Display(output);
            PowerTube powerTube = new PowerTube(output);
            Button btnStart = new Button();
            Button btnTime = new Button();
            Button btnCancel = new Button();
            Door door = new Door();
            Light light = new Light(output);


            powerTube.TurnOn(10);
            timer.Start(timer.TimeRemaining);
            display.ShowTime(10,0);
            door.Open();
            door.Close();
            
            light.TurnOn();

            
            

            //Creating cookcontroller without the ui 
            CookController CC = new CookController(timer, display, powerTube);
            //Creating userinterface using property injection
            UserInterface ui = new UserInterface(btnStart, btnTime, btnCancel, door, display, light, CC);
            CC.UI = ui;

            btnTime.Press();
            btnStart.Press();
            btnCancel.Press();

        }
    }
}
