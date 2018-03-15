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

            CookController CC = new CookController(timer, display, powerTube);
            UserInterface ui = new UserInterface(btnStart, btnTime, btnCancel, door, display, light, CC);
            CC.UI = ui;

            btnStart.Press();
            CC.StartCooking(20, 1);
        }
    }
}
