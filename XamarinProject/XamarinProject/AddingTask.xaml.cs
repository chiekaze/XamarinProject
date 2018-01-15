using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingTask : ContentPage
	{
		public AddingTask ()
		{
			InitializeComponent ();

            saveButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new MainPage());
                // TODO: Save stuffs
            };

            backButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new MainPage());
            };
        }
	}
}