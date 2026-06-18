using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class Respond
    {
        [JsonProperty("Boolean")]
        private bool Boolean { get; set; }
        [JsonProperty("Answer")]
        private string Answer { get; set; }
        

        public Respond(bool boolean, string answer)
        {
            Boolean = boolean; 
            Answer = answer;
        }

        public bool ReturnBoolean()
        {
            return Boolean;
        }

        public string ReturnAnswer()
        {
            return Answer;
        }
    }
}
