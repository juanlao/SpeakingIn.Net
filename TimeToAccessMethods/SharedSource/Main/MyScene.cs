#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace TimeToAccessMethods
{
    public class MyScene : Scene
    {
        public static int ITERATIONS = 100000000;
        public TextBlock AccesNormalMethod;
        public TextBlock AccesInterfaceMethod;
        public TextBlock AccesOverridedMethod;

        protected override void CreateScene()
        {
            this.Load(WaveContent.Scenes.MyScene);

            this.AccesNormalMethod = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -20, 0, 0)
            };

            this.EntityManager.Add(this.AccesNormalMethod);

            this.AccesInterfaceMethod = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };

            this.EntityManager.Add(this.AccesInterfaceMethod);

            this.AccesOverridedMethod = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };

            this.EntityManager.Add(AccesOverridedMethod);

            this.AddSceneBehavior(new AccesNormalMethodBehavior(), SceneBehavior.Order.PostUpdate);
            this.AddSceneBehavior(new AccesByOverridedBehavior(), SceneBehavior.Order.PostUpdate);
            this.AddSceneBehavior(new AccesByInterfaceMethodBehavior(), SceneBehavior.Order.PostUpdate);


        }
    }
}
