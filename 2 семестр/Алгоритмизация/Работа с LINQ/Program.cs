namespace LINQ
{
    class Program
    {
        static void Main()
        {
            List<int> ints = new List<int> {1,276,4,6458,3,68,77,9735,29,12,52,78,4};
            var ints_with_three =
                from k in ints
                where (k % 10) % 3 == 0
                select k;
            var ints_with_even =
                from k in ints
                where Enumerable.Range(0, k.ToString().Length).Any(i => Convert.ToInt32(k.ToString()[i])%2==0)
                select k;
            Console.WriteLine("Работа со списком: ");
            Console.Write("\nЭлементы, у которых в записи присутствует хотя бы одна чётная цифра: ");
             foreach ( var i in ints_with_even )
                Console.Write(i+" ");

            Console.Write("\n\nЭлементы, у которых последняя цифра кратна 3: ");
            foreach ( var i in ints_with_three )
                Console.Write(i+" "); 
            Console.WriteLine("\n\nРабота с массивом: ");
            int[] ints2 = {2,3,86,7,23,22,63,2456,89,34,67,34};
            var ints_even1 =
                from k in ints2
                where k % 2 == 0
                select k;
            Console.Write("\nРезультат 1-ой выборки чётных элементов: ");
            foreach( var i in ints_even1 )
                Console.Write(i+" ");
            ints2 = Enumerable.Range(0, ints2.Length).Select(i=> i % 2 != 0 ? 2 : ints2[i]).ToArray();
            Console.Write("\n\nИзменённый массив: ");
            foreach (var i in ints2)
                Console.Write(i+" ");
            Console.Write("\n\nРезультат 2-ой выборки чётных элементов: ");
            var ints_even2 =
               from k in ints2
               where k % 2 == 0
               select k;
            foreach ( var i in ints_even2)
                Console.Write(i+" ");
            Console.WriteLine();
        }
    }
}