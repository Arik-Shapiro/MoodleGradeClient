using Newtonsoft.Json;

namespace MoodleGradeClient
{
    public class QuizzesModel
    {
        public QuizModel[] Quizzes { get; set; }
    }
    public class QuizModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty("course", Required = Required.Always)]
        public int Course { get; set; }
        [JsonProperty("coursemodule", Required = Required.Always)]
        public int CourseModule { get; set; }
        [JsonProperty("grade", Required = Required.Always)]
        public int Grade { get; set; }
        [JsonProperty("sumgrades")]
        public double SumGrades { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; internal set; }
    }
}