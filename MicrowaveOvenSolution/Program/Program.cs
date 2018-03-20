using System;
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

            door.Open();
            door.Close();
            powerTube.TurnOn(30);
            btnStart.Press();
            display.ShowTime(0,10);
            btnStart.Press();
            light.TurnOn();
           
            btnTime.Press();
            

            //Creating cookcontroller without the ui 
            CookController CC = new CookController(timer, display, powerTube);
            //Creating userinterface using property injection
            UserInterface ui = new UserInterface(btnStart, btnTime, btnCancel, door, display, light, CC);
            CC.UI = ui;

            btnTime.Press();
            btnStart.Press();
            
            //btnCancel.Press();
            //timer.Stop();
            //CC.StartCooking(10,5);

            Console.ReadLine();
        }
    }
}
