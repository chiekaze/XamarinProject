using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinProject.Data;

namespace XamarinProject
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{  
            InitializeComponent();
     
            // Get task DB size
            int count = App.TaskDatabase.GetSize();

            // Create arrays for tasks and checkboxes
            Label[] taskArray = new Label[count];
            Button[] buttonArray = new Button[count];
            
            for (int i = 0; i < count; i++)
            {
                // Create task array
                TTask t = App.TaskDatabase.GetTask(i);
                taskArray[i] = new Label { Text = t.Task, HorizontalOptions = LayoutOptions.CenterAndExpand };

                // Get the task id for the button
                int id = t.Id;
                // Create checkboxes
                buttonArray[i] = new Button { BackgroundColor = Color.LightGray,Text = "Done", TextColor = Color.Green, HorizontalOptions = LayoutOptions.Center, ClassId = id.ToString() };
                buttonArray[i].Clicked += OnChecked;

                stackLayout.Children.Add(taskArray[i]);
                stackLayout.Children.Add(buttonArray[i]);
            }
 
            addTask.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new AddingTask());
            };
		}

        public void OnChecked(object sender, EventArgs args)
        {   
            Button button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            //button.Image = "Assets/CheckBoxSmall.png";
            App.TaskDatabase.DeleteTask(id);
            Navigation.PushModalAsync(new MainPage());
        }
    }
}
