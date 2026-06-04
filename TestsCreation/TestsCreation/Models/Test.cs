using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class Test
    {
        public string TestName { get; set; }
        public int Time { get; set; }
        public int Points { get; set; }
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
