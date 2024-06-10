namespace Set
{
    class Program
    {
        static void Print_set(HashSet<string> set)
        {
            foreach (string i in set)
                Console.Write(i+" ");
            
        }
        static void Set_Completion(HashSet<string> set)
        {
            bool flag = true;
            while (flag==true)
            {
                string[] s= Console.ReadLine().Split(' ');
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == "end")
                    { flag = false;  break; }
                    set.Add(s[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            HashSet<string> setA = new HashSet<string>();
            Console.Write("Заполнение множества A: ");
            Set_Completion(setA);
            HashSet<string> setB = new HashSet<string>();
            Console.Write("Заполнение множества B: ");
            Set_Completion(setB);
            HashSet<string> setC = new HashSet<string>();
            Console.Write("Заполнение множества С: ");
            Set_Completion(setC);
            HashSet<string> union = new HashSet<string>(setA); union.UnionWith(setB); union.UnionWith(setC);
            Console.WriteLine();
            Console.Write("Объединение множеств: ");
            Print_set(union);
            HashSet<string> intersct = new HashSet<string>(setA); intersct.IntersectWith(setB); intersct.IntersectWith(setC);
            Console.WriteLine();
            Console.Write("Пересечение множеств: ");
            Print_set(intersct);
            HashSet<string> Aaddition = new HashSet<string>(union); Aaddition.ExceptWith(setA); 
            Console.WriteLine();
            Console.Write("Дополнение множества А: ");
            Print_set(Aaddition);
            HashSet<string> Baddition = new HashSet<string>(union); Baddition.ExceptWith(setB);
            Console.WriteLine();
            Console.Write("Дополнение множества B: ");
            Print_set(Baddition);
            HashSet<string> Caddition = new HashSet<string>(union); Caddition.ExceptWith(setC); 
            Console.WriteLine();
            Console.Write("Дополнение множества С: ");
            Print_set(Caddition);
        }
    }
}