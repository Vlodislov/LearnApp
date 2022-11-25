using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace LearnApp.Models
{
    [DataContract]
    public class Lecture
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Chapter { get; set; }
        public string Title { get; set; }
        public string Discription1 { get; set; }
        public string Image1 { get; set; }
        public string Discription2 { get; set; }
        public string Image2 { get; set; }
        public string VideoLink { get; set; }
        public string Complited { get; set; }
        public List<QuestionTrueFalse> QuestionTrueFalse { get; set; }
        public QuestionTrueFalse currentQuestion;
        public int currentindexquestion;
        public string Preload { get; set; }
        public int CorrectCount { get; set; }
        public string TestNumber { get; set; }
        public int WrongCount { get; set; }

        public Lecture()
        {
            QuestionTrueFalse = new List<QuestionTrueFalse>();
        }

        public void generateQuestion()
        {
            currentindexquestion++;
            currentQuestion = QuestionTrueFalse[currentindexquestion];
        }

        public QuestionTrueFalse getCurrentQuestion()
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
