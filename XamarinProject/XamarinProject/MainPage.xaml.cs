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
        bool isChecked = false;

		public MainPage()
		{
			InitializeComponent();
		}

        void OnChecked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if(!isChecked)
            {
                button.Image = "Assets/CheckedCheckBox.png";
                isChecked = true;
            }

            else
            {
                button.Image = "Assets/EmptyCheckBox.png";
                isChecked = false;
            }
        }
	}
}
