using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;
using RPGEngine;

namespace Android
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/Theme.Splash", MainLauncher = true)]
    public class MainActivity : AndroidGameActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            var rpgGame = new RPGGame();
            SetContentView(rpgGame.Services.GetService<View>());
            rpgGame.Run();
        }
    }
}