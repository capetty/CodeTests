using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ChadCodeTestFootball
{
    class Football
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\cpetty\Downloads\football.dat");
            int i = 0;
            int j = 0;
            string[,] data = new string[50, 50];

            foreach (var row in text.Split('\n'))
            {
                j = 0;
                foreach (var column in row.Trim().Split(' '))
                {
                    var strippedColumn = Regex.Replace(column, @"[^0-9a-zA-Z]+", "");
                    data[i, j] = strippedColumn.Trim();
                    if(data[i,j] != "")
                    {
                        j++;
                    }
                }
                i++;
            }

            int tempSpread = 100;
            string tempTeam = "";
            int garbageInt;

            for (int x = 1; x < data.GetLength(1); x++)
            {
                if (int.TryParse(data[x, 6], out garbageInt) && Math.Abs(int.Parse(data[x, 6]) - int.Parse(data[x, 7])) > 0 && Math.Abs(int.Parse(data[x, 6]) - int.Parse(data[x, 7])) < tempSpread)
                {
                    tempTeam = data[x, 1];
                    tempSpread = Math.Abs(int.Parse(data[x, 6]) - int.Parse(data[x, 7]));
                }
            }

            Console.WriteLine("Team: " + tempTeam + "; Spread: " + tempSpread);
            Console.ReadKey();

        }
    }
}
