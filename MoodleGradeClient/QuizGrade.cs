using System;
using System.Collections.Generic;
using System.Text;

namespace MoodleGradeClient
{
    public class QuizGrade
    {
        public int QuizId { get; set; }
        public double Grade { get; set; }
        public double TotalQuestionsAmount { get; set; }
        public double CorrectAnswersAmount { get; set; }
        public string QuizName { get; set; }
        public QuizGrade(int quizId, string name, double grade, double totalQuestionsAmount, double correctAnswersAmount)
        {
            QuizId = quizId;
            QuizName = name;
            Grade = grade;
            TotalQuestionsAmount = totalQuestionsAmount;
            CorrectAnswersAmount = correctAnswersAmount;
        }
        public override string ToString()
        {
            return $"Your grade in the quiz \"{QuizName}\" is: {Grade}\n"+
                   $"Number of correct answers: {CorrectAnswersAmount}/{TotalQuestionsAmount}";
        }
    }
}
