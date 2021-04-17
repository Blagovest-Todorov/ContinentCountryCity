using System;
using System.Collections.Generic;

namespace ContinentCountryCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> countryByContinent =
                               new Dictionary<string, Dictionary<string, List<string>>>();

            //continent - > country - > cities-city1, city2,

            int countRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < countRows; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!countryByContinent.ContainsKey(continent))
                {
                    countryByContinent.Add(continent, new Dictionary<string, List<string>>());
                    countryByContinent[continent].Add(country, new List<string>());
                    countryByContinent[continent][country].Add(city);

                    
                }else if (countryByContinent.ContainsKey(continent))
                {
                    if (!countryByContinent[continent].ContainsKey(country))
                    {
                        countryByContinent[continent].Add(country, new List<string>());
                        countryByContinent[continent][country].Add(city);
                    }
                    else if (countryByContinent[continent].ContainsKey(country))
                    {
                        countryByContinent[continent][country].Add(city);
                    }                    
                }
            }

            foreach (var kvp in countryByContinent)
            {
                string continent = kvp.Key;
                
                Console.WriteLine($"{continent}:");

                foreach (var item in kvp.Value)
                {
                    string country = item.Key;
                    //string city = item.Value;
                    Console.Write($"{country} -> ");                    
                    Console.WriteLine(string.Join(", ", item.Value));                               
                }
            }
        }
    }
}
