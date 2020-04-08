using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Theme = "@style/AppTheme")]
    public class Layout1 : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout1);
            Button retorno = FindViewById<Button>(Resource.Id.completed);
            retorno.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                if (intent != null)
                {
                    Console.WriteLine("Aquí también");
                    StartActivity(intent);
                }

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }




    }
}