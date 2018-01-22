using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.Data
{
    public class TTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Task { get; set; }

        public TTask() { }
        public TTask(string task)
        {
            this.Task = task;
        }
    }
}
