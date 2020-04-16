using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_app_version_1
{
    class Question1
    {
        //Constructor
        public Question1(string questionText, string correctAnswer, List<String> wrongAnswers)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }

        //Auto Properties
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
    }

    public List<string> AllAnswers 
    {
        get 
        {
            List<string> allAnswers = new List<string>();
            allAnswers.Add(CorrectAnswer);
            allAnswers.AddRange(WrongAnswers);
            return allAnswers;
        }
    }
}
