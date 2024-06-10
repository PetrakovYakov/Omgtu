using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

class Programm
{
    static void Main()
    {
        List<string> list = new List<string>();
        string k="-";
        bool flag = true;
        while (flag ==true)
        {
            string[] s = Console.ReadLine().Split(' ');
            switch (s[0])
            {
                case "DUST":
                    k = "DT"+ Find_k(list, s) + "TD";
                    list.Add(k);
                    break;
                case "WATER":
                    k = "WT" + Find_k(list, s) + "TW";
                    list.Add(k);
                    break;
                case "MIX":
                    k = "MX" + Find_k(list, s) + "XM";
                    list.Add(k);
                    break;
                case "FIRE":
                    k = "FR" + Find_k(list, s) + "RF";
                    list.Add(k);
                    break;
                default :
                    flag = false;
                    break;
            }
        }
        Console.WriteLine(k);
    }
    static string Find_k(List<string> list, string[] s)
    {
        string k = "";
        int n;
        for (int i =1; i<s.Length; i++)
        {
            if (int.TryParse(s[i], out n))
            {
                k += list[n-1];
            }
            else
            { k += s[i]; }
        }
        return k;
    }
}