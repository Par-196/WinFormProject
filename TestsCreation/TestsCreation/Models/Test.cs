using System;
using Newtonsoft.Json;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TestsCreation.Models
{
    public class Test
    {
        [JsonProperty("TestName")]
        private string TestName { get; set; }
        [JsonProperty("Time")]
        private int Time { get; set; }
        [JsonProperty("Points")]
        private int Points { get; set; }
        [JsonProperty("QuestionAnswers")]
        private List<QuestionAnswers> QuestionAnswers { get; set; }

        public Test()
        {
            QuestionAnswers = new List<QuestionAnswers>();
        }

        public string ReturnTestName()
        {
            return TestName;
        }

        public int ReturnPoints()
        {
            return Points;
        }

        public int Scoring()
        {
            return Points / QuestionAnswers.Count;
        }

        public int GetTimeForTimer()
        {
            return Time;
        }

        public List<QuestionAnswers> ReturnQuestionAndAnswers()
        {
            return QuestionAnswers;
        }

        public void AddNameTimeAndPointsToTest(string testName, int time, int points)
        {
            TestName = testName;
            Time = time;
            Points = points;
        }

        public void AddQuestionAnswersToTest(QuestionAnswers questionAnswers)
        {
            QuestionAnswers.Add(questionAnswers);
        }
    }
}
