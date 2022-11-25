using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Models
{
    public class Task_
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Chapter { get; set; }
        public string TextTask { get; set; }
        public string Aswer { get; set; }
        public string Complited { get; set; }
        public string TaskNumber { get; set; }
        public string AnswerText { get; set; }
    }
}
