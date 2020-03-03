using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace LAB_1
{
    class Worker
    {
        private readonly string dirName;
        public Worker(string dirName) => this.dirName = dirName;

        private Dictionary<string, int> DoWork()
        {
            Parser parser = new Parser(dirName);
            (List<string> countriesList, List<List<int>> gradesList) = parser.GetInput();
            int[] gradesForPlace = new int[] { 12, 10, 8, 7, 6, 5, 4, 3, 2, 1 };
            Dictionary<string, int> results = new Dictionary<string, int>();
            int upBound = (10 < countriesList.Count + 1) ? 10 : countriesList.Count + 1;

            foreach (var countryName in countriesList)
            {
                results.Add(countryName, 0);
            }

            for (int i = 0; i < gradesList.Count; ++i)
            {
                List<int> used = new List<int>();
                for (int j = 0; j < upBound; ++j)
                {
                    int currentCountryInd = GetIndexMaxInColumn(gradesList, i, used);
                    used.Add(currentCountryInd);
                    results[countriesList[currentCountryInd]] += gradesForPlace[j];
                }
            }
            return results;
        }

        private int GetIndexMaxInColumn(List<List<int>> matrix, int colIndex, List<int> used)
        {
            int max = -1;
            int index = 0;

            for (int i = 0; i < matrix.Count; ++i)
            {
                if (matrix[i][colIndex] > max && !used.Contains(i))
                {
                    max = matrix[i][colIndex];
                    index = i;
                }
            }
            return index;
        }

        private void SortDictionary(ref Dictionary<string, int> dict)
        {
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public void PrintWinnersList()
        {
            Dictionary<string, int> results = DoWork();
            SortDictionary(ref results);
            results = results.Take(Math.Min(results.Count, 10)).ToDictionary(k => k.Key, k => k.Value);

            using StreamWriter wr = new StreamWriter("../../../results.csv");

            foreach (var countryName in results.Keys)
            {
                wr.WriteLine($"{countryName} : {results[countryName]}");
            }
        }
    }
}