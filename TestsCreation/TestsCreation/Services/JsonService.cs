using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestsCreation.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestsCreation.Services
{
    public class JsonService
    {
        private Test Test { get; set; }
        
        public JsonService() 
        {
        }

        public void JsonServiceSerializeTest(Test test)
        {
            var serializedTest = JsonConvert.SerializeObject(test);

            string path = $@"D:\Program\Microsoft Visual Studio\Github\WinFormProject\TestsCreation\TestsCreation\bin\Debug\{test.ReturnTestName()}.txt";

            try
            {
                File.WriteAllText(path, serializedTest);
            }
            catch(Exception ex)
            {
                
            }
            
        }

        public void JsonServiceDeSerializeTest()
        {

        }
    }
}
