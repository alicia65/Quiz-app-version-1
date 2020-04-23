﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_app_version_1
{
    class QuestionBank

    {
        // Fields - only used internally by a QuestionSet object
        private int currentQuestionIndex = -1;

        private string _userName;

        // Read and Write Properties
        public string UserName   // This uses the field _userName to store data
        {
            get
            {
                return _userName;
            }
            set
            {
                // value is a built-in name for the new value the Property is being set to
                if (String.IsNullOrEmpty(value))   // Validate
                {
                    throw new Exception();
                }
                _userName = value;
            }
        }

        // Auto properties. 
        // A private field is generated by the C# compiler for each auto property

        // This auto property has an initial value - a new List of Questions
        public List<Question1> Questions { get; set; } = new List<Question1>();

        // Auto properties that can be read by other code, but can only be set by this class
        // See ScoreCurrentQuestion method 
        public int Score { get; private set; }

        public int Points { get; set; }

        // Properties that compute their values from other fields/properties in the class
        public int AvailablePoints
        {
            get
            {
                int total = 0;
                foreach (Question1 question in Questions)
                {
                    total += question.Points;
                }
                return total;
            }
        }

        public Question1 CurrentQuestion
        {
            get
            {
                {
                    // Return null if currentQuestionIndex is outside the range of the Questions list
                    return Questions.ElementAtOrDefault(currentQuestionIndex);
                }
            }
        }

        public Question1 Next
        {
            get
            {
                currentQuestionIndex++;
                Question1 nextQuestion = Questions.ElementAtOrDefault(currentQuestionIndex);  // Null if currentQuestionIndex is out of range
                return nextQuestion;
            }
        }

        public bool QuizOver
        {
            get
            {
                // Quiz is over when currentQuestionIndex is out of range for elements in Questions list 
                // So if there are 10 questions, quiz is over when currentQuestionIndex gets to 9
                bool quizOver = (currentQuestionIndex + 1) >= Questions.Count;
                return quizOver;
            }
        }

        // Method
        public void ScoreCurrentQuestion()
        {
            if (!CurrentQuestion.Scored)
            {
                if (CurrentQuestion.IsCorrect)
                {
                    Score += CurrentQuestion.Points;
                }
            }
            CurrentQuestion.Scored = true;
        }

        public void IsCorrect()
        {

        }
    }
}
    

