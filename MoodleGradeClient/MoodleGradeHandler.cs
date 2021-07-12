using MoodleGradeClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoodleGradeClient
{
    public class MoodleGradeHandler
    {
        private HttpClient _httpClient;
        private string _username;
        private string _password;
        public MoodleGradeHandler(string username, string password)
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://moodle2.bgu.ac.il/moodle") };
            _username = username;
            _password = password;
        }

        public async Task<QuizGrade> GetQuizGrade(int courseModule)
        {
            var token = await GetFreshToken();
            if(token == null)
            {
                return null;
            }
            var quizzes = await GetUserQuizzes(token);
            var relevantQuiz = quizzes?.Quizzes?.FirstOrDefault(quiz => quiz.CourseModule.Equals(courseModule));
            if(relevantQuiz == null)
            {
                return null;
            }
            var userId = await GetUserId(token);
            if(!userId.HasValue)
            {
                return null;
            }
            var quizAttempt = await GetQuizAttempts(relevantQuiz.Id, userId.Value, token);
            return quizAttempt == null 
                ? null 
                : new QuizGrade(relevantQuiz.Id, relevantQuiz.Name, quizAttempt.Grade);
        }

        private async Task<QuizAttemptModel> GetQuizAttempts(int quizId, int userId, TokenModel token)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/webservice/rest/server.php?wstoken={token.Token}&quizid={quizId}&userid={userId}&moodlewsrestformat=json&wsfunction=mod_quiz_get_user_best_grade");
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuizAttemptModel>(jsonString);
            }
            catch
            {
                Console.WriteLine("Failed to get user quiz attempts");
                return null;
            }
        }

        private async Task<int?> GetUserId(TokenModel token)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/webservice/rest/server.php?moodlewsrestformat=json&wsfunction=core_webservice_get_site_info&wstoken={token.Token}");
                var jsonString = await response.Content.ReadAsStringAsync();
                var res = (JObject)JsonConvert.DeserializeObject(jsonString);
                return res?.Value<int>("userid");
            }
            catch
            {
                Console.WriteLine("Failed to get user id");
                return null;
            }
        }

        private async Task<QuizzesModel> GetUserQuizzes(TokenModel token)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/webservice/rest/server.php?wstoken={token.Token}&moodlewsrestformat=json&wsfunction=mod_quiz_get_quizzes_by_courses");
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuizzesModel>(jsonString);
            }
            catch
            {
                Console.WriteLine("Failed to get user quizzes");
                return null;
            }

        }

        private async Task<TokenModel> GetFreshToken()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/login/token.php?username={_username}&password={_password}&service=moodle_mobile_app");
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(jsonString);
            }
            catch
            {
                Console.WriteLine("Bad username or password, failed to get token.");
                return null;
            }
        }
    }
}
