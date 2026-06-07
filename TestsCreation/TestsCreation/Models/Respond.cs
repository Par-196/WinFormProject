using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCreation.Models
{
    public class Respond
    {
        private bool Boolean { get; set; }
        private string Answer { get; set; }
        

        public Respond(bool boolean, string answer)
        {
            Boolean = boolean; 
            Answer = answer;
        }
    }
}
