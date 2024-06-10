using System.Collections;

class Call
{
    public string number_phon;
    public string data;
    public string time_start;
    public int time_min;
    public Call(string number_phon, string data, string time_start, int time_min)
    {
        this.number_phon = number_phon;
        this.data = data;
        this.time_start = time_start;
        this.time_min = time_min;
    }
}
class Programm
{
    static void Main()
    {
        Queue<Call> calls = new Queue<Call>();

        while (true)
        {
            Console.Write("номер телефона: ");
            string number = Console.ReadLine();
            Console.Write("Введите дату разговора: ");
            string data = Console.ReadLine();
            Console.Write("Введите время начала: ");
            string time_start = Console.ReadLine();
            Console.Write("введите время разговора: ");
            int time_min = int.Parse(Console.ReadLine());
            calls.Enqueue(new Call(number, data, time_start, time_min));
            Console.Write("Для остановки введите end: ");
            if (Console.ReadLine() == "end")
                break;
        }
        Dictionary<string,int> calls_min = new Dictionary<string,int>();
        Dictionary<string,int> calls_date = new Dictionary<string,int>();
        Hashtable calls_min2 = new Hashtable();
        Hashtable calls_date2 = new Hashtable();
        while(calls.Count>0)
        {
            int min = calls.Peek().time_min;
            int min_date = calls.Peek().time_min;
            string num = calls.Peek().number_phon;
            string data = calls.Peek().data;
            if (calls_min.ContainsKey(num))
            {
                calls_min[num] += min;
                calls_min2[num]= calls_min[num];
            }
            else if(!calls_min.ContainsKey(num))
            {
                calls_min.Add(num, min);
                calls_min2.Add(num, min);
            }
            if (calls_date.ContainsKey(data))
            {
                calls_date[data]+= min_date;
                calls_date2[data] = calls_date[data];
            }
            else if(!calls_date.ContainsKey(data))
            {
                calls_date.Add(data, min_date);
                calls_date2.Add(data, min_date);
            }
            calls.Dequeue();
        }
        Console.WriteLine();
        Console.WriteLine("Суммарное время разговора по номерам");
        Console.WriteLine("Номера телефона|минуты");
        Print_Dictionary(calls_min);
        Print_Hashtable(calls_min2);
        Console.WriteLine();
        Console.WriteLine("Суммарное время разговора по дням");
        Console.WriteLine("Дата|минуты");
        Print_Dictionary(calls_date);
        Print_Hashtable(calls_date2);
    }
    static void Print_Dictionary(Dictionary<string,int> calls_min)
    {
        Console.WriteLine("Месячный отчёт Dictionary");
        ICollection<string> keys = calls_min.Keys;
        foreach (string s in keys)
        {
            Console.WriteLine($"{s} - {calls_min[s]} минут");
        }
    }
    static void Print_Hashtable(Hashtable hashtable)
    {
        Console.WriteLine("Месячный отчет HashTable");
        ICollection keys = hashtable.Keys;
        foreach (string s in keys)
        {
            Console.WriteLine($"{s} - {hashtable[s]} минут");
        }
    }
}