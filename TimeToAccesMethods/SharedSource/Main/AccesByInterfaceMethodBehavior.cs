using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WaveEngine.Framework;

namespace TimeToAccesMethods
{
    public class AccesByInterfaceMethodBehavior : SceneBehavior
    {
        private IMyInterface myInterface;
        private MyScene myScene;
        private TimeSpan timer;
        public AccesByInterfaceMethodBehavior()
            : base()
        {
            var myClass = new ImplementsInterface();
            this.myInterface = myClass as IMyInterface;
            this.timer = new TimeSpan();
        }

        protected override void ResolveDependencies()
        {
            this.myScene = this.Scene as MyScene;
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (TimeSpan.FromSeconds(1) > this.timer)
            {
                this.timer += gameTime;
            }
            else
            {
                this.timer = TimeSpan.Zero;
   
                var stopWatch = Stopwatch.StartNew();
               
                for (int i = 0; i < MyScene.ITERATIONS; i++)
                {
                    this.myInterface.MyMethod();
                }
                stopWatch.Stop();
                string nanoseconds = (((double)(stopWatch.Elapsed.TotalMilliseconds * 1000 * 1000) / MyScene.ITERATIONS).ToString("0.00 ns"));

                this.myScene.AccesInterfaceMethod.Text = "Interface Method Time :" + nanoseconds;                
            }
        }
    }
}
