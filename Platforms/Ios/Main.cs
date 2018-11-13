using System;
using Foundation;
using RPGEngine;
using UIKit;

namespace Ios
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static RPGGame rpgGame;

        internal static void RunGame()
        {
            rpgGame = new RPGGame();
            rpgGame.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            return UIInterfaceOrientationMask.Landscape;
        }
    }
}
