﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinProject
{
	public partial class MainPage : ContentPage
	{
        bool isChecked = false;

		public MainPage()
		{
			InitializeComponent();

            addTask.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new AddingTask());
            };
		}

        void OnChecked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if(!isChecked)
            {
                button.Image = "Assets/CheckBoxSmall.png";
                isChecked = true;
            }

            else
            {
                button.Image = "Assets/CheckBoxEmptySmall.png";
                isChecked = false;
            }
        }
	}
}
