﻿
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Net;
using System.Threading;

namespace TouchWalkthrough
{
    [Activity(Label = "DropDetailsActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class DropDetailsActivity : Activity
    {
        DropManager dropmanager = DropManager.Instance;
        bool imageVollbild_on = false;

        private Timer timer;
        Drop drop;

        // Interface
        RelativeLayout maplayout;
        RelativeLayout kartenlayer;
        Switch ignore_switch;
        TextView ingoreText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DropDetails);

            //Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs
            string id = Intent.GetStringExtra("ID");
            drop = dropmanager.getDrop(id);
            //Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs ENDE

            // Create your application here

            // Kategorie
            ImageView category = FindViewById<ImageView>(Resource.Id.imageView1);
            category.SetImageResource(drop.GetIconId("art"));
            // Kategorie Ende

            //Vollbild ##############################################################
            ImageView image = FindViewById<ImageView>(Resource.Id.imageView2);//nicht Vollbild
            ImageView imageVollbild = FindViewById<ImageView>(Resource.Id.imageView3);//Vollbild
            RelativeLayout vollbildlayout = FindViewById<RelativeLayout>(Resource.Id.Vollbildlayout);
            vollbildlayout.Visibility = ViewStates.Gone;

            image.Click += (object sender, EventArgs e) =>
            {
                if (imageVollbild_on == false)//Öffnet Vollbildansicht
                {
                    vollbildlayout.Visibility = ViewStates.Visible;
                    imageVollbild_on = true;
                }
            };

            vollbildlayout.Click += (object sender, EventArgs e) =>
            {
                if (imageVollbild_on == true)//Schließt Vollbildansicht
                {
                    vollbildlayout.Visibility = ViewStates.Gone;
                    imageVollbild_on = false;
                }
            };
            //Vollbild ENDE ##############################################################



            //Drop Infos anzeigen #############################################

            TextView titel = FindViewById<TextView>(Resource.Id.textView22);
            TextView raum = FindViewById<TextView>(Resource.Id.textView3);
            TextView beschreibung = FindViewById<TextView>(Resource.Id.textView1);
            TextView startdatum = FindViewById<TextView>(Resource.Id.textView39);
            TextView startzeit = FindViewById<TextView>(Resource.Id.textView28);
            TextView enddatum = FindViewById<TextView>(Resource.Id.textView29);
            TextView endzeit = FindViewById<TextView>(Resource.Id.textView27);

            titel.Text = drop.name;
            raum.Text = drop.location.name;
            beschreibung.Text = drop.description;

            if (drop.picturePath != null)
            {
                Bitmap imageBitmap = ImageStorage.Instance.getBitmap(drop.picturePath);
                image.SetImageBitmap(imageBitmap);
                imageVollbild.SetImageBitmap(imageBitmap);
            }

            startdatum.Text = drop.startTime.ToString("dd.MM.yyyy");
            startzeit.Text = drop.startTime.ToString("HH:mm");
            enddatum.Text = drop.endTime.ToString("dd.MM.yyyy");
            endzeit.Text = drop.endTime.ToString("HH:mm");
            //Drop Infos anzeigen ENDE #############################################

            // Switch
            ignore_switch = FindViewById<Switch>(Resource.Id.switch_button);

            ignore_switch.Checked = drop.ignored;

            ignore_switch.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                drop.ignored = ignore_switch.Checked;
            };
			// Switch ENDE

			//Auf Karte anzeigen
			LinearLayout aufKarteAnzeigen = FindViewById<LinearLayout>(Resource.Id.linearLayout133);
			kartenlayer = FindViewById<RelativeLayout>(Resource.Id.relativeLayout2);
			ingoreText = FindViewById<TextView>(Resource.Id.textView26);
            maplayout = FindViewById<RelativeLayout>(Resource.Id.maplayout2);

			kartenlayer.Visibility = ViewStates.Gone;
			aufKarteAnzeigen.Click += (object sender, EventArgs e) =>
			{
				kartenlayer.Visibility = ViewStates.Visible;
				ignore_switch.Visibility = ViewStates.Gone;
				ingoreText.Visibility = ViewStates.Gone;
                timer = new Timer(x => timerEvent(), null, 0, 25);
            };
			kartenlayer.Click += (object sender, EventArgs e) =>
			{
				kartenlayer.Visibility = ViewStates.Gone;
				ignore_switch.Visibility = ViewStates.Visible;
				ingoreText.Visibility = ViewStates.Visible;
			};
			//Auf Karte anzeigen
        }

        private void timerEvent()
        {
            if (timer != null)
            {
                if (maplayout.Width > 0)
                {
                    this.RunOnUiThread(() => ResetDropButtons(drop));

                    // stop timer
                    timer.Dispose();
                    timer = null;
                }
            }
        }

		//Drops auf Karte darstellen ###########################################################
		public void ResetDropButtons(Drop mapdrop)
		{
			ImageView kartenlayout = FindViewById<ImageView>(Resource.Id.imageView5);

			maplayout.RemoveAllViews();

			ImageButton drop_button = mapdrop.ToImageButton(this);

			// Position
			float left = ((float)kartenlayout.Width - ((float)1224 / (float)2176) * (float)kartenlayout.Height) / (float)2;
			float scaleX = (float)kartenlayout.Width / (float)1224;
			float scaleY = (float)kartenlayout.Height / (float)2176;

			int[] screen = new int[2];
			kartenlayout.GetLocationOnScreen(screen);
			int screenX = screen[0];
			int screenY = screen[1];
			drop_button.SetX(mapdrop.location.position.X * scaleY - drop_button.Width / 2 - screenX + 0.44f * left);
			drop_button.SetY(mapdrop.location.position.Y * scaleY - drop_button.Height / 2 - screenY);

            // Funktion
            drop_button.Click += (object sender, EventArgs e) =>
            {
                kartenlayer.Visibility = ViewStates.Gone;
                ignore_switch.Visibility = ViewStates.Visible;
                ingoreText.Visibility = ViewStates.Visible;
            };

            maplayout.AddView(drop_button);
		}
        //Drops auf Karte darstellen ENDE###########################################################
    }
}
