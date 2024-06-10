/*На вход подаётся данные типа: 
номер телефона с которого звонили, номер на который звонили, дата звонка, количество минут; 
определить на какой номер чаще всего звонил выбранный абонент по датам(сгрупировав данные по датам), 
определить номера с которыми наибольшее количество минут разговаривал абонент(каждый абонент)
(сгрупировав данные по дате)*/
using System.Globalization;

class Calls
{
    public string num_phon_from;
    public string num_phon_to;
    public string data;
    public int count_min;
    public Calls(string num_phon_from,string num_phon_to, string data, int count_min)
    {
        this.num_phon_from = num_phon_from;
        this.num_phon_to = num_phon_to;
        this.data = data;
        this.count_min = count_min;
    }
}
class Program
{
    static void Main()
    {
        List<Calls> calls = new List<Calls>();
        while (true)
        {
            Console.Write("введите номер телефона с которого звонили: ");
            string num_phon_from = Console.ReadLine();
            Console.Write("введите номер телефона на который звонили: ");
            string num_phon_to = Console.ReadLine();
            Console.Write("введите дату звонка: ");
            string data = Console.ReadLine();
            Console.Write("введите количество минут звонка: ");
            int count_min = int.Parse(Console.ReadLine());
            Calls call = new Calls(num_phon_from, num_phon_to, data, count_min);
            calls.Add(call);
            Console.Write("для остановки введите end");
            if (Console.ReadLine() == "end")
                break;
        }
        while (true)
        {
            Console.Write("Введите номер абонента: ");
            string num_abonent = Console.ReadLine();
            string num_often = Find_often_num(calls, num_abonent);
            Console.WriteLine("Номер, на который чаще всего звонил выбранный абонент: " + num_often);
            Dictionary<string, int> calls_often = new Dictionary<string, int>();
            For_calls(calls_often, calls, num_abonent, num_often);
            Console.WriteLine($"Информация о звонках абонента {num_abonent} абоненту {num_often} по датам: ");
            Print_Dictionary(calls_often);
            string number_max = Find_Talk_num(calls,num_abonent);
            Console.WriteLine();
            Console.WriteLine($"Абонент {num_abonent} наибоильшее количество минут разговаривал с {number_max}");
            Dictionary<string, int> calls_max_minut = new Dictionary<string, int>();
            For_calls(calls_max_minut, calls, num_abonent, number_max);
            For_calls(calls_max_minut, calls, number_max, num_abonent);
            Console.WriteLine($"Информация о разговорах абонента {num_abonent} с абонентом {number_max}");
            Print_Dictionary(calls_max_minut);
            Console.Write("введите end для остановки: ");
            if (Console.ReadLine() == "end")
                break;
        }
    }
    static string Find_often_num(List<Calls> calls, string num_from)
    {
        int count = 0;
        int count2 = 0;
        string num_often = " ";
        for (int i = 0; i < calls.Count; i++)
        {
            if (calls[i].num_phon_from == num_from)
            {
                for (int j = 0; j < calls.Count; j++)
                {
                    if (calls[j].num_phon_to == calls[i].num_phon_to)
                        count++;
                }
                if (count > count2)
                {
                    count2 = count;
                    num_often = calls[i].num_phon_to;
                }
                count = 0;
            }
        }
        return num_often;
    }
    static void Print_Dictionary(Dictionary<string, int> diction)
    {
        Console.WriteLine();
        Console.WriteLine("Дата|минуты");
        ICollection<string> list = diction.Keys;
        foreach (string s in list)
        {
            Console.WriteLine($"{s} - {diction[s]}");
        }
    }
    static string Find_Talk_num(List<Calls> calls, string num)
    {
        Dictionary<string,int> diction = new Dictionary<string,int>();
        for(int i =0; i<calls.Count; i++)
        {
            if (num == calls[i].num_phon_from)
            {
                if (!diction.ContainsKey(calls[i].num_phon_to))
                    diction.Add(calls[i].num_phon_to, calls[i].count_min);
                else
                    diction[calls[i].num_phon_to] += calls[i].count_min;
            }
            if (num == calls[i].num_phon_to)
            {
                if (!diction.ContainsKey(calls[i].num_phon_from))
                {
                    diction.Add(calls[i].num_phon_from, calls[i].count_min);
                }
                else
                    diction[calls[i].num_phon_from] += calls[i].count_min;
            }
        }
        ICollection<string> keys = diction.Keys;
        int count_min = 0;
        string max_min_num= "";
        foreach (string s in keys)
        {
            if (diction[s] > count_min)
            {
                count_min = diction[s];
                max_min_num = s;
            }
        }
        return max_min_num;
    }
    static void For_calls(Dictionary<string,int> diction, List<Calls> calls, string abonent, string number)
    {
        for(int i =0; i<calls.Count; i++)
        {
            if (calls[i].num_phon_from == abonent && calls[i].num_phon_to == number)
            {
                if (!diction.ContainsKey(calls[i].data))
                    diction.Add(calls[i].data, calls[i].count_min);
                else
                    diction[calls[i].data] += calls[i].count_min;
            }
        }
    }
}