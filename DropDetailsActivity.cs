﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TouchWalkthrough
{
	[Activity(Label = "DropDetailsActivity", Theme = "@android:style/Theme.NoTitleBar")]
	public class DropDetailsActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.DropDetails);
			// Create your application here

		}
	}
}