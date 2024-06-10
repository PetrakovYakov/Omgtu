namespace Company
{
    public class People
    {
        public int number;
        public string name;
        public People(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
        public void Print()
        {
            Console.WriteLine($"{number} {name}");
        }
    }
    class Programm
    {
        static void Main()
        {
            List<People> people = new List<People>();
            List<People> otv = new List<People>();

            while (true)
            {
                string name = "Unknown name";
                string[] g = new string[2];
                g = Console.ReadLine().Split(' ', 2);
                if (g[0] == "END")
                    break;
                if (g[1].Length == 1)
                {
                    char b = char.Parse(g[1]);
                    if (b != ' ')
                        name = g[1];
                }
                else if (g[1].Length > 1)
                {
                    name = g[1];
                }
                int number = int.Parse(g[0]);
                people.Add(new People(number, name));
            }
            int n;
            string nachalnik = Console.ReadLine();
            if (int.TryParse(nachalnik, out n))
            {
                n = int.Parse(nachalnik);
                otv = Find(n,people);
            }
            else
            {
                for(int i=0; i<people.Count; i++)
                {
                    if (nachalnik == people[i].name)
                        n = people[i].number;
                }
                otv = Find(n,people);
                
            }
            if (otv.Count != 0)
            {
                otv.Sort(delegate (People x, People y)
                {
                    return x.number.CompareTo(y.number);
                });
                for (int i = 0; i < otv.Count; i++)
                {
                    if (otv[i].number < 10)
                        Console.WriteLine($"000{otv[i].number} {otv[i].name}");
                    if(otv[i].number >=10&& otv[i].number <100)
                        Console.WriteLine($"00{otv[i].number} {otv[i].name}");
                    if (otv[i].number >=100&& otv[i].number <1000)
                        Console.WriteLine($"0{otv[i].number} {otv[i].name}");
                    if(otv[i].number >=1000)
                        Console.WriteLine($"{otv[i].number} {otv[i].name}");
                }
            }
            else
                Console.WriteLine("NO");
        }
        static void Find_sotr(int h, List<People> people, List<People> otv)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (i == people.Count - 1)
                    break;
                if (h == people[i].number && i % 2 == 0 && h != people[i + 1].number)
                {
                    if (people[i + 1].name == "Unknown name")
                    {
                        people[i + 1].name = Find_name(people, people[i+1].number);
                    }
                    otv.Add(new People(people[i + 1].number, people[i + 1].name));
                    Find_sotr(people[i + 1].number, people, otv);
                }
            }
        }
        static string Find_name(List<People> people,int num)
        {
            string h = "Unknown name";
            for (int j = 0; j < people.Count; j++)
            {
                if (people[j].number == num && people[j].name != "Unknown name")
                {
                    h = people[j].name;
                    break;
                }
            }
            return h;
        }
        static List<People> Find(int n, List<People> people)
        {
            List<People> otv = new List<People>();
            for (int i = 0; i < people.Count; i++)
            {
                if (i == people.Count - 1)
                    break;
                if (n == people[i].number && i % 2 == 0)
                {
                    if (n != people[i + 1].number)
                    {
                        if (people[i + 1].name == "Unknown name")
                        {
                            for (int j = 0; j < people.Count; j++)
                            {
                                if (people[j].number == people[i + 1].number && people[j].name != "Unknown name")
                                {
                                    people[i + 1].name = people[j].name;
                                    break;
                                }
                            }
                        }
                        otv.Add(new People(people[i + 1].number, people[i + 1].name));
                        Find_sotr(people[i + 1].number, people, otv);
                    }
                }
            }
            return otv;
        }
    }
}
