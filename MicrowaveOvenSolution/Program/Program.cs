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
            Button btnTime = new Button();
            Button btnPwr = new Button();
            Button btnStartCancel = new Button();
            Door door = new Door();
            Light light = new Light(output);
           
            //Creating cookcontroller without the ui 
            CookController CC = new CookController(timer, display, powerTube);
            //Creating userinterface using property injection
            UserInterface ui = new UserInterface(btnPwr, btnTime, btnStartCancel, door, display, light, CC);
            CC.UI = ui;

            CC.StartCooking(50,1);

           

            Console.WriteLine("Microwave started!");
            Console.WriteLine("P increases power");
            Console.WriteLine("T sets the time");
            Console.WriteLine("S starts/cancels the microwave");
            Console.WriteLine("O opens the door");
            Console.WriteLine("C closes the door");
            Console.WriteLine("X closes application");

            bool working = true;

            while (working)
            {
                var key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case 'p':
                        btnPwr.Press();
                        break;
                    case 't':
                        btnTime.Press();
                        break;
                    case 's':
                        btnStartCancel.Press();
                        break;
                    case 'o':
                        door.Open();
                        break;
                    case 'c':
                        door.Close();
                        break;
                    case 'x':
                        working = false;
                        break;
                }
            }
        }
    }
}
