using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Data;

namespace XamarinProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingTask : ContentPage
	{
		public AddingTask ()
		{
			InitializeComponent ();

            // Creates new task, saves it in the database and returns to main screen
            saveButton.Clicked += async (sender, args) =>
            {  
                if(taskEntry.Text == null)
                {
                    return;
                }
                else
                {
                    TTask task = new TTask(taskEntry.Text);
                    App.TaskDatabase.SaveTask(task);
                    await Navigation.PushModalAsync(new MainPage());
                }
            };

            // Returns to the main screen
            backButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new MainPage());
            };
        }
	}
}