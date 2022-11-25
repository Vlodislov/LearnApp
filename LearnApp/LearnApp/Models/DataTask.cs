using LearnApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Models
{
    public class DataTask : IIdentifiableTask
    {
        public string Id { get; set; }
        public string Task1 { get; set; }
        public string Task2 { get; set; }
        public string Task3 { get; set; }
        public string Task4 { get; set; }
        public string Task5 { get; set; }
        public string Task6 { get; set; }
        public string Task7 { get; set; }
        public string Task8 { get; set; }
        public string Task9 { get; set; }
        public string Task10 { get; set; }
        public string Task1_comp { get; set; }
        public string Task2_comp { get; set; }
        public string Task3_comp { get; set; }
        public string Task4_comp { get; set; }
        public string Task5_comp { get; set; }

        public string Task1_answer { get; set; }
        public string Task2_answer { get; set; }
        public string Task3_answer { get; set; }
        public string Task4_answer { get; set; }
        public string Task5_answer { get; set; }

    }
}
