using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Models
{
    public class Question
    {
        public string text;
        public string answer;
        public string textAnswer;
        public string[] answerArray = { "11", "22", "43", "34"};
        private int answerPosition;
        public string[] getAnswerArray()
        {
            return this.answerArray;
        }
        public string getQuestionPhrase()
        {
            return text;
        }

        public string getAnswer()
        {
            return this.answer;
        }

    }
}
