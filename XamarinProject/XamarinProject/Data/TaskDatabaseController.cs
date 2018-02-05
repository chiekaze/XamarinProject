using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinProject.Data
{
    public class TaskDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public TaskDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TTask>();
        }

        public int GetSize()
        {
            if(database.Table<TTask>() == null)
            {
                return 0;
            }
            else
                return database.Table<TTask>().Count();
        }

        public TTask GetTask()
        {
            lock(locker)
            {
                if(database.Table<TTask>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<TTask>().First();
                }
            }
        }

        public TTask GetTask(int index)
        {
            lock (locker)
            {
                if (database.Table<TTask>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<TTask>().ElementAt(index);
                }
            }
        }

        public int SaveTask(TTask task)
        {
            lock(locker)
            {
                if(task.Id != 0)
                {
                    database.Update(task);
                    return task.Id;
                }
                else
                {
                    return database.Insert(task);
                }
            }
        }

        private void UpdateTasks()
        {
            for(int i = database.Table<TTask>().First().Id; i < database.Table<TTask>().First().Id + database.Table<TTask>().Count(); i++)
            {
                database.Table<TTask>().ElementAt(i - database.Table<TTask>().First().Id).Id = i - database.Table<TTask>().First().Id;
            }
        }

        public int DeleteTask(int id)
        {
            lock(locker)
            {
                UpdateTasks();
                return database.Delete<TTask>(id);
                //return database.Table<TTask>().Delete(); //fuggin helll
            }
        }
    }
}
