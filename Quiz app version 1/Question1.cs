﻿using System;
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
        public Question1(string questionText, string correctAnswer, List<String> wrongAnswers, int points = 1)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            Points = points;
        }

        //Auto- Implemented Properties
        public string UserAnswer { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
        public int Points { get; set; }
        public bool Scored { get; set; } = false; // An initial value

        
        public List<string> AllAnswers
        {
            get
            {
                //Create a list of the correct answer and the wrong answers
                List<string> allAnswers = new List<string>();
                allAnswers.AddRange(WrongAnswers);
                allAnswers.Add(CorrectAnswer);

                //Create a random number generator
                Random random = new Random();

                //Create a new list for the shuffled answers
                List<String> shuffleAnswers = new List<String>();

                //Loop until all answers have been added to the shuffled list
                while (allAnswers.Count > 0)
                {
                    //Pick a random answer from all answers
                    int index = random.Next(allAnswers.Count);
                    //Fetch that answer, and remove from the list of all answers
                    string answer = allAnswers[index];
                    allAnswers.RemoveAt(index);
                    //Pick a random location to insert this answer into shuffled answers
                    int insertIndex = random.Next(shuffleAnswers.Count);
                    //And insert the answer
                    shuffleAnswers.Insert(insertIndex, answer);
                }
                return shuffleAnswers;
            }
        }

        public bool IsCorrect(String answer) 
        {
            return answer == CorrectAnswer;
        }
    }
}


