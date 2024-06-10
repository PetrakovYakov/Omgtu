using System.Security.Cryptography;
class Program
{
    static void Main()
    {
        List<int>[] lists_ways = new List<int>[12];
        for (int i = 0; i < 12; i++)
            lists_ways[i] = new List<int>();
        Console.Write("Введите вершину: ");
        int vert = int.Parse(Console.ReadLine());
        int[,] matrix_w = {
            {100,7,100,100,9,2,100,100,100,100,100,100},
            {7,100,5,4,8,2,100,100,100,100,100,100},
            {100,5,100,2,9,100,100,100,100,100,100,100},
            {100,4,2,100,3,100,8,3,100,100,100,100},
            {9,8,9,3,100,3,5,1,7,100,100,100},
            {2,2,100,100,3,100,100,6,1,100,100,100},
            {100,100,100,8,5,100,100,6,100,4,4,100},
            {100,100,100,3,1,6,6,100,2,7,8,5},
            {100,100,100,100,7,1,100,2,100,100,6,1},
            {100,100,100,100,100,100,4,7,100,100,10,100},
            {100,100,100,100,100,100,4,8,6,10,100,3},
            {100,100,100,100,100,100,100,5,1,100,3,100}
        };
        int min = 100;
        int[] distance = new int[12];
        for(int i=0;i<12;i++)
        {
            if(i==vert-1)
                continue;
            distance[i] = min;
        }
        for (int h = 0; h < 12; h++)
        {
            for (int i = 0; i < 12; i++)
            {
                if (i == vert-1)
                    continue;
                for (int j = 0; j < distance.Length; j++)
                {
                    if (distance[j] + matrix_w[j, i] < min)
                    {
                        min = distance[j] + matrix_w[j, i];
                        distance[i] = min;
                        if (lists_ways[i].Count!=0)
                            lists_ways[i].Clear();
                        lists_ways[i].InsertRange(0, lists_ways[j]);
                        lists_ways[i].Add(i + 1);
                    }
                }
                min = 100;
            }
        }
        Console.WriteLine($"Кратчайшие пути от {vert} до : ");
        for (int i = 0; i < lists_ways.Length; i++)
        {
            if (i == vert - 1)
                continue;
            Console.Write($"{i + 1} Путь: {vert} ");
            for (int j = 0; j < lists_ways[i].Count; j++)
            {
                Console.Write(lists_ways[i][j] + " ");
            }
            Console.Write("Длина: " + distance[i]);
            Console.WriteLine();
        }
    }
}
