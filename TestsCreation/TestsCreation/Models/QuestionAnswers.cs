using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class QuestionAnswers
    {
        public string Question { get; set; }
        public Respond[] Responds { get; set; }

        public QuestionAnswers(string question, Respond[] responds)
        {
            Question = question;
            Responds = responds;
        }
    }
}
