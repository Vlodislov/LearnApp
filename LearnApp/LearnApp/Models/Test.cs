using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Models
{
    public class Test
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Chapter { get; set; }
        public string Title { get; set; }
        public string Complited { get; set; }
        public List<Question> Questions { get; set; }
        public Question currentQuestion;
        public int currentindexquestion;
        public string Preload {get; set;}
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public string TestNumber { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }

        public void generateQuestion()
        {
            currentindexquestion++;
            currentQuestion = Questions[currentindexquestion];
        }

        public Question getCurrentQuestion()
        {
                return currentQuestion;
        }

        public Boolean checkAnswer(string answerArg)
        {
            if (answerArg == this.currentQuestion.getAnswer())
            {
                CorrectCount++;
                return true;
            }
            else
            {
                WrongCount++;
                return false;
            }
        }
    }
}
