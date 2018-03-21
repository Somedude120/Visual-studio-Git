using System;
using MicrowaveOvenClasses.Interfaces;

namespace MicrowaveOvenClasses.Controllers
{
    public class CookController : ICookController
    {
        // Since there is a 2-way association, this cannot be set until the UI object has been created
        // It also demonstrates property dependency injection
        public IUserInterface UI { set; get; }

        private bool isCooking = false;

        private IDisplay myDisplay;
        private IPowerTube myPowerTube;
        private ITimer myTimer;

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube,
            IUserInterface ui) : this(timer, display, powerTube)
        {
            UI = ui;
        }

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube)
        {
            myTimer = timer;
            myDisplay = display;
            myPowerTube = powerTube;

            timer.Expired += new EventHandler(OnTimerExpired);
            timer.TimerTick += new EventHandler(OnTimerTick);
        }

        //Beregn procenten af power inden den bliver tændt, da det er i procenter
        public void StartCooking(int power, int time)
        {
            //Dette skulle give 50 hvis der kommer 350 WATT ind
            double tempPower = ((power / 700.0) * 100.0);
            //Husk at skrive 350 for at få 50 procent
            power = Convert.ToInt32(tempPower);

            myPowerTube.TurnOn(power);
            myTimer.Start(time);
            isCooking = true;
        }

        public void Stop()
        {
            isCooking = false;
            myPowerTube.TurnOff();
            myTimer.Stop();
        }

        public void OnTimerExpired(object sender, EventArgs e)
        {
            if (isCooking)
            {
                myPowerTube.TurnOff();
                UI.CookingIsDone();
                isCooking = false;
            }
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            int remaining = myTimer.TimeRemaining;
            myDisplay.ShowTime(remaining/60, remaining % 60);
        }
    }
}