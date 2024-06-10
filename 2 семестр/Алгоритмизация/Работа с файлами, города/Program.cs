using System;
using System.IO;
namespace Files_Towers
{
    struct Tower
    {
        public string name_tower;
        public string country;
        public double population;
        public Tower(string name_tower, string country, double population)
        {
            this.name_tower = name_tower;
            this.country = country;
            this.population = population;
        }
    }
    class Program
    {
        static void Main()
        {
            StreamReader sr = File.OpenText("D:\\towers.txt");
            string input = null;
            List<Tower> towers = new List<Tower>();
            double f=0;
            Console.WriteLine("\u001b[36mВывод из входного файла\u001b[0m towers.txt\n");
            while (true)
            {
                input = sr.ReadLine();
                if (input == null)
                    break;
                string[] s = input.Split(' ');
                towers.Add(new Tower(s[0], s[1], Convert.ToDouble(s[2])));
            }
            for(int i =0; i<towers.Count;i++)
            {
                Console.WriteLine(towers[i].name_tower+" " + towers[i].country+" " + towers[i].population);
            }
            Console.Write("\n\u001b[36mВведите букву (англ) для выборки:\u001b[0m ");
            char letter_choice = char.Parse(Console.ReadLine());
            var towers_with_one_letter =
                from num in towers
                where num.name_tower[0] == letter_choice
                select num;
            Console.Write("\n\u001b[36mВведите страну для выборки:\u001b[0m ");
            string country_choice = Console.ReadLine();
            var towers_with_country = 
                from num in towers
                where num.country==country_choice
                select num;
            Console.Write("\n\u001b[36mВведите численность населения для выборки:\u001b[0m ");
            double population_choice = Convert.ToDouble(Console.ReadLine());
            var towers_with_morepop =
                from num in towers
                where num.population>=population_choice
                select num;
            List<Tower> towers_with_morepop2 = towers_with_morepop.ToList();
            List<Tower> towers_with_country2 = towers_with_country.ToList();
            List<Tower> towers_with_one_letter2 = towers_with_one_letter.ToList();
            StreamWriter tow_letter = File.CreateText("tow_letter.txt");
            tow_letter.Write($"Города, начинающиеся на букву {letter_choice}: ");
            for(int i =0; i<towers_with_one_letter2.Count;i++)
            {
                tow_letter.Write(towers_with_one_letter2[i].name_tower+" ");
            }
            tow_letter.Close();
            StreamWriter tow_country = File.CreateText("tow_country.txt");
            tow_country.Write($"Города находящиеся в стране {country_choice}: ");
            for(int i =0;i<towers_with_country2.Count;i++)
            {
                tow_country.Write(towers_with_country2[i].name_tower+" ");
            }
            tow_country.Close();
            StreamWriter tow_pop = File.CreateText("tow_pop.txt");
            tow_pop.WriteLine($"Города, чья численность населения больше или равна {population_choice}");
            for(int i =0; i<towers_with_morepop2.Count;i++)
            {
                tow_pop.WriteLine(towers_with_morepop2[i].name_tower+" - " + towers_with_morepop2[i].population);
            }
            tow_pop.Close();
            StreamReader sr_tow_let = File.OpenText("tow_letter.txt");
            StreamReader sr_tow_coun = File.OpenText("tow_country.txt");
            StreamReader sr_tow_pop = File.OpenText("tow_pop.txt");
            Console.WriteLine("\n\u001b[36mДанные выходного файла\u001b[0m tow_letter.txt");
            while (true)
            {
                input = sr_tow_let.ReadLine();
                if (input == null)
                    break;
                Console.WriteLine(input);
            }
            Console.WriteLine("\n\u001b[36mДанные выходного файла\u001b[0m tow_country.txt");
            while (true)
            {
                input = sr_tow_coun.ReadLine();
                if (input == null)
                    break;
                Console.WriteLine(input);
            }
            Console.WriteLine("\n\u001b[36mДанные выходного файла\u001b[0m tow_pop.txt");
            while (true)
            {
                input = sr_tow_pop.ReadLine();
                if (input == null)
                    break;
                Console.WriteLine(input);
            }
        }

    }
}
