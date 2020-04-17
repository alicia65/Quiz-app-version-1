using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_app_version_1
{
    public partial class Form1 : Form
    {
        // Store all of the RadioButton in a list,
        // to make it easier to figure out which one was checked, or to uncheck all 
        private List<RadioButton> QuizRadioButtons;

        //All of the quiz questions
        private List<Question1> QuizQuestions;

        //Keeps track of what question the app is currently asking, will be used to index QuizQuestions
        private int CurrectQuestionNumber;

        private int score = 0;

        
        public Form1()
        {
            InitializeComponent();

            //Add the four radio buttons to the list
            QuizRadioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };

            //Example questions - feel free to make up your own

            //Create new Question with variables
            string questionText = "What is fastest animal?";
            string questionAnswer = "Cheetah";
            List<string> wrongAnwers = new List<string> { "Turtle", "Deer", "Snail" };
            Question1 q1 = new Question1(questionText, questionAnswer, wrongAnwers);

            //Or create with literals
            Question1 q2 = new Question1("What color is an elephant?", "Gray", new List<string> { "Yellow", "Green", "Red" });
            Question1 q3 = new Question1("What does a cat say?", "Meom", new List<string> { "Quack", "Woof", "Hello" });

            //Add quiz questions to a list
            QuizQuestions = new List<Question1> { q1, q2, q3 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayQuestion(0);
            btnNext.Enabled = false;
            btnCheckAnswer.Focus();
        }

        private void DisplayQuestion(int questionIndex) 
        {
            //Look up the question, usig questionIndex
            Question1 question = QuizQuestions[questionIndex];

            //Read the Answers property to get all list of the answer choices
            List<string> answers = question.AllAnswers;
            
            //Deselect all the radio buttons
            foreach (RadioButton rb in QuizRadioButtons) 
            {
                rb.Checked = false;
            }

            //Set or  reset the label result so it does not show result from previous question
            lblResult.Text = "???";

            //Use the answer to set the text for each RadioButton
            for(int a  = 0; a < answers.Count; a++) 
            {
                QuizRadioButtons[a].Text = answers[a];
            }

            // And display the question text
            lblQuestion.Text = question.QuestionText;


        }
    }
}
