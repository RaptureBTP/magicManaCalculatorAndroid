using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace magicManaCalculatorAndroid
{
    [Activity(Label = "Magic Mana Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string deckType = "Standard";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.deckTypeSpinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.decktypes_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            deckType = spinner.GetItemAtPosition(e.Position).ToString();
            string toast = string.Format("The decktype is {0}", deckType);
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}

