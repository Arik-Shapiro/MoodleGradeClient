using System;
using System.Threading.Tasks;

namespace MoodleGradeClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            Console.WriteLine("Enter the Course Module Id");
            try
            {
                int courseModule = Convert.ToInt32(Console.ReadLine());
                var moodleGradeHandler = new MoodleGradeHandler(username, password);
                var quizGrade = await moodleGradeHandler.GetQuizGrade(courseModule);
                if (quizGrade == null)
                {
                    Console.WriteLine("Failed to get grade.");
                }
                else
                {
                    Console.WriteLine(quizGrade);
                }
            }
            catch
            {
                Console.WriteLine("Bad course module id.");
            }
        }
    }
}
