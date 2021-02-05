using Newtonsoft.Json;

namespace MoodleGradeClient
{
    public class QuizAttemptsModel
    {
        [JsonProperty("attempts")]
        public QuizAttemptModel[] QuizzAttempts { get; set; }
    }
    public class QuizAttemptModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("quiz", Required = Required.Always)]
        public int QuizId { get; set; }

        [JsonProperty("sumgrades", Required = Required.Always)]
        public double SumGrades { get; set; }
    }
}