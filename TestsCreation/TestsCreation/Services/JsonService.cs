using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TestsCreation.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestsCreation.Services
{
    public class JsonService
    {
        private Test Test { get; set; }
        private List<string> TestNames { get; set; }

        public JsonService() 
        {
            TestNames = new List<string>();
        }

        public void JsonServiceSerializeTest(Test test)
        {
            var serializedTest = JsonConvert.SerializeObject(test);
            TestNames.Add(test.ReturnTestName());
            string path = $@"D:\Program\Microsoft Visual Studio\Github\WinFormProject\TestsCreation\TestsCreation\CreatedTests\{test.ReturnTestName()}.txt";
            try
            {
                File.WriteAllText(path, serializedTest);
            }
            catch(Exception ex)
            {
                
            }
            
        }

        public Test[] JsonServiceDeSerializeTest()
        {
            string path = $@"D:\Program\Microsoft Visual Studio\Github\WinFormProject\TestsCreation\TestsCreation\CreatedTests\";
            string[] files = Directory.GetFiles(path);
            Test[] tests = new Test[files.Length];
            int count = 0;
            foreach (var items in files)
            {
                string json = File.ReadAllText(items);
                tests[count] = JsonConvert.DeserializeObject<Test>(json);
                count++;
            }
            


            return tests;

        }

        public bool AreThereTests()
        {
            string path = $@"D:\Program\Microsoft Visual Studio\Github\WinFormProject\TestsCreation\TestsCreation\CreatedTests\";

            return Directory.Exists(path) &&
            Directory.GetFiles(path).Length > 0;
        }
    }
}
