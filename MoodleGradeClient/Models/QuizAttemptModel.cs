using Newtonsoft.Json;

namespace MoodleGradeClient
{
    public class QuizAttemptModel
    {
        [JsonProperty("hasgrade", Required = Required.Always)]
        public bool HasGrade { get; set; }

        [JsonProperty("warnings", Required = Required.Always)]
        public int[] Warnings { get; set; }

        [JsonProperty("grade", Required = Required.Always)]
        public double Grade { get; set; }
    }
}