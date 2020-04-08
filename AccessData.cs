using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;

namespace App1
{

    public static class AccessData
    {
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;

            if (app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetApplicationId("tfgedu-6bc6f")
                    .SetApiKey("AIzaSyBRjnuEAX65axPVwdeWTERXWYiABtjdqNs")
                    .SetDatabaseUrl("https://tfgedu-6bc6f.firebaseio.com")
                    .SetStorageBucket("tfgedu-6bc6f.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
                Console.WriteLine("La bd se ha instanciado");
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
                Console.WriteLine("La bd se ha instanciado");

            }
            return database;
        }
    }
}