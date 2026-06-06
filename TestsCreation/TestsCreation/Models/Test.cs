using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class Test
    {
        [JsonProperty("TestName")]
        public string TestName { get; set; }
        [JsonProperty("Time")]
        public int Time { get; set; }
        [JsonProperty("Points")]
        public int Points { get; set; }
        [JsonProperty("QuestionAnswers")]
        public QuestionAnswers[] QuestionAnswers { get; set; }

        public Test(string testName, int time, int points, QuestionAnswers[] questionAnswers)
        { 
            TestName = testName;
            Time = time;
            Points = points;
            QuestionAnswers = questionAnswers;
        }

    }
}
