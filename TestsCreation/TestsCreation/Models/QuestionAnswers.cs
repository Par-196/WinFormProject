using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class QuestionAnswers
    {
        [JsonProperty("Question")]
        private string Question { get; set; }
        [JsonProperty("Responds")]
        private List<Respond> Responds { get; set; }

        public QuestionAnswers(string question, List<Respond> responds)
        {
            Question = question;
            Responds = responds;
        }
    }
}
