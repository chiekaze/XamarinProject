using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinProject.Data;

namespace XamarinProject
{
	public partial class App : Application
	{
        static TokenDatabaseController tokenDatabase;
        static TaskDatabaseController taskDatabase;

		public App ()
		{
			InitializeComponent();

            MainPage = new XamarinProject.MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static TaskDatabaseController TaskDatabase
        {
            get
            {
                if(taskDatabase == null)
                {
                    taskDatabase = new TaskDatabaseController();
                }
                return taskDatabase;     
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }
    }
}
