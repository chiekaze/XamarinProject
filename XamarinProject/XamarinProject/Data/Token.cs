using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.Data
{
    public class Token
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }

        public Token() { }
    }
}
