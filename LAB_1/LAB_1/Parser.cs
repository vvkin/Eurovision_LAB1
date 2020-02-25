using System.Collections.Generic;
using System.IO;

namespace LAB_1
{
    class Parser
    {
        private readonly string dirName;
        public Parser(string dirName) => this.dirName = dirName;


        public (List<string>, List<List<int>>) GetInput()
        {
            string dirPath = "../../../" + dirName;
            string[] filesList = Directory.GetFiles(dirPath);
            List<string> countries = new List<string>();
            List<List<int>> gradesMatrix = new List<List<int>>();

            foreach (var fileName in filesList)
            {
                StreamReader cr = new StreamReader(fileName);
                int countryNum = int.Parse(cr.ReadLine());
                // Waiting for ParseRow function
            }
            return (countries, gradesMatrix);
        }


    }
}
