using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinProject
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            addTask.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new AddingTask());
            };
		}
	}
}
