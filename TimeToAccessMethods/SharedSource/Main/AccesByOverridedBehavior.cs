using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WaveEngine.Framework;

namespace TimeToAccessMethods
{
    public class AccesByOverridedBehavior : SceneBehavior
    {
        private OverrideClass myOverrideClass;
        private MyScene myScene;
        private TimeSpan timer;
        public AccesByOverridedBehavior()
            : base()
        {
            this.myOverrideClass = new OverrideClass();
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
                    this.myOverrideClass.MyMethod();
                }
                stopWatch.Stop();
                string nanoseconds = (((double)(stopWatch.Elapsed.TotalMilliseconds * 1000 * 1000) / MyScene.ITERATIONS).ToString("0.00 ns"));
                
                this.myScene.AccesOverridedMethod.Text = "Overrided Method Time :" + nanoseconds ;                
            }
        }
    }
}
