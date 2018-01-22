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

        public int DeleteTask(int id)
        {
            lock(locker)
            {
                return database.Delete<TTask>(id);
            }
        }
    }
}
