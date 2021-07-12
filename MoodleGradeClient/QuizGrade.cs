using System;
using System.Collections.Generic;
using System.Text;

namespace MoodleGradeClient
{
    public class QuizGrade
    {
        public int QuizId { get; set; }
        public double Grade { get; set; }
        public string QuizName { get; set; }
        public QuizGrade(int quizId, string name, double grade)
        {
            QuizId = quizId;
            QuizName = name;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"Your grade in the quiz \"{QuizName}\" is: {Grade}\n";
        }
    }
}
