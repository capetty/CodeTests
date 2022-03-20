using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ChadCodeTestWeather
{
    class Weather
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\cpetty\Downloads\weather.dat");
            int i = 0;
            int j = 0;
            int[,] data = new int[35, 35];
            int garbageInt;

            foreach (var row in text.Split('\n'))
            {
                j = 0;
                foreach (var column in row.Trim().Split(' '))
                {
                    var strippedColumn = Regex.Replace(column, "[^0-9]", "");
                    if (!int.TryParse(strippedColumn.Trim(), out garbageInt))
                    {
                        continue;
                    }
                    else
                    {
                        data[i, j] = int.Parse(strippedColumn.Trim());
                    }
                    j++;
                }
                i++;
            }

            int tempSpread = 100;
            int tempDay = 0;

            for (int x = 1; x < data.GetLength(1); x++){
                if(Math.Abs(data[x, 1] - data[x, 2]) > 0 && Math.Abs(data[x,1] - data[x, 2]) < tempSpread)
                {
                    tempDay = data[x, 0];
                    tempSpread = Math.Abs(data[x, 1] - data[x, 2]);
                }
            }

            Console.WriteLine("Day: " + tempDay + "; Temp Spread: " + tempSpread);
            Console.ReadKey();
        }
    }
}
