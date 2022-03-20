using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ChadCodeTestDryFusion
{
    class DryFusion
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\cpetty\\Downloads\\weather.dat";
            int garbageInt;

            string[,] data;
            ProcessFile(path, out data);

            int tempSpread = 100;
            int tempDay = 0;

            for (int x = 1; x < data.GetLength(1); x++)
            {
                if (int.TryParse(data[x, 1], out garbageInt) && Math.Abs(int.Parse(data[x, 1]) - int.Parse(data[x, 2])) > 0 && Math.Abs(int.Parse(data[x, 1]) - int.Parse(data[x, 2])) < tempSpread)
                {
                    tempDay = int.Parse(data[x, 0]);
                    tempSpread = Math.Abs(int.Parse(data[x, 1]) - int.Parse(data[x, 2]));
                }
            }

            Console.WriteLine("Day: " + tempDay + "; Temp Spread: " + tempSpread);
            Console.ReadKey();
        }

        public static string[,] ProcessFile(string filePath, out string[,] dataFromFile)
        {
            string text = File.ReadAllText(filePath);
            int i = 0;
            int j = 0;
            dataFromFile = new string[50, 50];

            foreach (var row in text.Split('\n'))
            {
                j = 0;
                foreach (var column in row.Trim().Split(' '))
                {
                    var strippedColumn = Regex.Replace(column, @"[^0-9a-zA-Z]+", "");
                    dataFromFile[i, j] = strippedColumn.Trim();
                    if (dataFromFile[i, j] != "")
                    {
                        j++;
                    }
                }
                i++;
            }

            return dataFromFile;
        }
    }
}
