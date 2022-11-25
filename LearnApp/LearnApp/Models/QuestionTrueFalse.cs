using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Models
{
    public class QuestionTrueFalse
    {
        public string text;
        public string answer;
        public string textAnswer;
        private string[] answerArray = { "11", "22"};
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
