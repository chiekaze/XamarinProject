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
     
            int count = App.TaskDatabase.GetSize();

            Label[] taskArray = new Label[count];
            Button[] buttonArray = new Button[count];

            for (int i = 0; i < count; i++)
            {
                // Create task array
                TTask t = App.TaskDatabase.GetTask(i);
                taskArray[i] = new Label { Text = t.Task, HorizontalOptions = LayoutOptions.CenterAndExpand };

                // Create checkboxes
                buttonArray[i] = new Button { Image = "Assets/CheckBoxEmptySmall.png", HorizontalOptions = LayoutOptions.Start, Text = (i + 1).ToString() };
                buttonArray[i].Clicked += OnChecked;

                layout.Children.Add(taskArray[i]);
                layout.Children.Add(buttonArray[i]);
            }
 
            addTask.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new AddingTask());
            };
		}

        public void OnChecked(object sender, EventArgs args)
        {            
            Button button = (Button)sender;
            int id = Int32.Parse(button.Text);
            button.Image = "Assets/CheckBoxSmall.png";
            App.TaskDatabase.DeleteTask(id);
        }
    }
}
