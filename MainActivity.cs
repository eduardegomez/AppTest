using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Firebase;
using Firebase.Auth;
using Android.Gms.Tasks;
using Android.Content.PM;

namespace App1
{
     [Activity(Label = "ManisesTOUR", Theme = "@style/AppTheme", MainLauncher = true)]
     public class MainActivity : AppCompatActivity
     {
         public static FirebaseApp app;
         private FirebaseAuth auth;
         public static String user, password;
         private EditText User, Password;
         private Button button;


         protected override void OnCreate(Bundle savedInstanceState)
         {
             base.OnCreate(savedInstanceState);
             Xamarin.Essentials.Platform.Init(this, savedInstanceState);

             // Set our view from the "main" layout resource
             SetContentView(Resource.Layout.activity_main);

             //Iniciamos conexión Firebase
             InitFirebaseAuth();


             button = FindViewById<Button>(Resource.Id.button_entrar);
             User = FindViewById<EditText>(Resource.Id.email);
             Password = FindViewById<EditText>(Resource.Id.contraseña);


             button.Click += Enter_Click;

         }

         private void Enter_Click(object sender, EventArgs e)
         {
           
             user = User.Text;
             password = Password.Text;
             Console.WriteLine(user);
             Console.WriteLine(password);

             Boolean logeado = LoginUser(User.Text, Password.Text);

             if (logeado)
             {
                 Intent intent = new Intent(this, typeof(Layout1));
                 StartActivity(intent);
                 button.Enabled = false;
                 Finish();

             }
             else {
                 Console.WriteLine("No logeado");

             }
             //auth.SignInWithEmailAndPassword(user, password).AddOnCompleteListener(this);

             Password.Text = "";
         }

         public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
         {
             Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

             base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
         }

         private void InitFirebaseAuth()
         {
             FirebaseOptions firebaseOptions = new FirebaseOptions.Builder()
                     .SetApplicationId("1:827796226132:android:92005fe6efc1faf20a2dc1")
                     .SetApiKey("AIzaSyBRjnuEAX65axPVwdeWTERXWYiABtjdqNs")
                     .SetDatabaseUrl("https://tfgedu-6bc6f.firebaseio.com")
                     .SetStorageBucket("tfgedu-6bc6f.appspot.com")
                     .Build();

             if (app == null)
             {
                 app = FirebaseApp.InitializeApp(this, firebaseOptions, "TFGEdu");

             }

            if (app == null) { Console.WriteLine("app sigue siendo null"); }

             auth = FirebaseAuth.GetInstance(app);

            if (auth == null) { Console.WriteLine("AUTH sigue sinedo null"); }
         }

         private Boolean LoginUser(string email, string password)
         {

             Console.WriteLine("Llego aquí");

            // try
            // {
                auth.SignInWithEmailAndPassword(email, password);
            // }
            // {
              //   return false;

             //}

             return true;
         }
     }
     
   
       
    
}
   



