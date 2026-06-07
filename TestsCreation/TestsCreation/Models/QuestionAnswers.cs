using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class QuestionAnswers
    {
        private string Question { get; set; }
        private List<Respond> Responds { get; set; }

        public QuestionAnswers(string question, List<Respond> responds)
        {
            Question = question;
            Responds = responds;
        }
    }
}
