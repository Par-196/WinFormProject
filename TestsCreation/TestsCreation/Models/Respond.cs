using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class Respond
    {
        public string Answer { get; set; }
        public bool Boolean { get; set; }

        public Respond(string answer, bool boolean)
        {
            Answer = answer;
            Boolean = boolean;
        }
    }
}
