using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                for (int i = 0; i < countryNum; ++i)
                {
                    (string currentName, List<int> currentGrades) = ParseRow(cr.ReadLine());
                    if (!countries.Contains(currentName))
                    {
                        countries.Add(currentName);
                        gradesMatrix.Add(currentGrades);
                    }
                }
            }
            return (countries, gradesMatrix);
        }

        public (string, List<int>) ParseRow(string row)
        {
            string[] splittedRow = row.Split(",");
            string countryName = splittedRow[0];
            splittedRow = splittedRow.Where(val => val != countryName).ToArray();
            int[] grades = Array.ConvertAll(splittedRow, s => int.Parse(s));
            List<int> gradesList = new List<int>();
            gradesList.AddRange(grades);
            return (countryName, gradesList);
        }
    }
}
