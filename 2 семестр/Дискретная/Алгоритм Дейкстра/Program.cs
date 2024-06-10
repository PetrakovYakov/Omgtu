using System.Collections;
using System.Net.Http.Headers;
class Program
{
    static void Main()
    {
        List<int>[] lists_ways = new List<int>[12];
        for (int i = 0; i < 12; i++)
            lists_ways[i] = new List<int>();
        Console.Write("Введите вершину: ");
        int vert = int.Parse(Console.ReadLine());
        int vert1 = vert;
        int[] vertex = new int[12];
        int[] weight = {100,100,100,100,100,100,100,100,100,100,100,100};
        int k = 0;
        int min = 100;
        int w = 0;
        List<int> verts_list = new List<int>
        {
            vert
        };
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
        for(int i=0; i<12;i++)
        {
            for(int j =0; j<12;j++)
            {
                if (!verts_list.Contains(j + 1))
                {
                    if (matrix_w[vert - 1, j] + w < weight[j])
                    {
                        weight[j] = matrix_w[vert - 1, j] + w;
                        if (lists_ways[j].Count != 0)
                            lists_ways[j].Clear();
                        lists_ways[j].InsertRange(0, lists_ways[vert - 1]);
                        lists_ways[j].Add(j + 1);
                    }
                    if (weight[j] < min)
                    {
                        min = weight[j];
                        k = j;
                    }
                }
            }
            vert = k + 1;
            verts_list.Add(vert);
            vertex[k] = min;
            w = min;
            min = 100;
        }
        Console.WriteLine($"Кратчайшие пути от {vert1} до : ");
        for (int i = 0; i < lists_ways.Length; i++)
        {
            if (i == vert1-1)
                continue;
            Console.Write($"{i + 1} Путь: {vert1} ");
            for (int j = 0; j < lists_ways[i].Count; j++)
            {
                Console.Write(lists_ways[i][j] + " ");
            }
            Console.Write("Длина: " + weight[i]);
            Console.WriteLine();
        }
    }
}