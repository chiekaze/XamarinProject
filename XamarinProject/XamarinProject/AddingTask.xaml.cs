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

            Label newLabel = new Label();
            newLabel.Text = "Error: Too many tasks! (Finish the old ones first!)";
            newLabel.TextColor = Color.Red;

            // Creates new task, saves it in the database and returns to main screen
            saveButton.Clicked += async (sender, args) =>
            {  
                if(taskEntry.Text == null)
                {
                    return;
                }
                else
                {
                    if(App.TaskDatabase.GetSize() < 8)
                    {
                        TTask task = new TTask(taskEntry.Text);
                        App.TaskDatabase.SaveTask(task);
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else
                    {
                        //relativeLayout.Children.Add(newLabel);
                        relativeLayout.Children.Add
                 (newLabel, Constraint.RelativeToParent((parent) =>
                { return (parent.Width - newLabel.Width) / 2; }),
                  Constraint.Constant(0)
                );
                    }
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