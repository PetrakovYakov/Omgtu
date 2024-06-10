using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

class Graph
{
    public int Vert1;
    public int Vert2;
    public int Weight;
    public Graph(int vert1, int vert2, int weight)
    {
        Vert1 = vert1;
        Vert2 = vert2;
        Weight = weight;
    }
    public void Print()
    {
        Console.WriteLine($"{Vert1} {Vert2} {Weight}");
    }
}
class Program
{
    static void Main()
    {
        List<Graph> graphs = new List<Graph>();
        int min_ostava = 0;
        int vert1, vert2, weight;
        Console.Write("Введите кол-во вершин: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Заполнение графов, введите end для остановки");
        Console.WriteLine("1 вершина| 2 вершина| вес");
        while (true)
        {
            string[] s = Console.ReadLine().Split(' ');
            if (s[0] == "end")
                break;
            vert1 = int.Parse(s[0]);
            vert2 = int.Parse(s[1]);
            weight = int.Parse(s[2]);
            graphs.Add(new Graph(vert1, vert2, weight));
        }
        List<int> vertex = new List<int>();
        List<Graph> graphs2 = new List<Graph>();
        int vrt = graphs[0].Vert1;
        while(true)
        { 
           vertex.Add(vrt);
            if (vertex.Count == n)
                break;
           int min = 1000;
           int k = vrt;
           for (int f =0; f<graphs.Count; f++)
           {
               if (graphs[f].Vert1 == vrt || graphs[f].Vert2 == vrt )
               {
                   if (vertex.Contains(graphs[f].Vert1) == false || vertex.Contains(graphs[f].Vert2) == false)
                   {
                       if (graphs[f].Weight < min)
                       {
                           min = graphs[f].Weight;
                           if (vrt == graphs[f].Vert1)
                           { k = graphs[f].Vert2; }
                           else if (vrt == graphs[f].Vert2)
                           { k = graphs[f].Vert1; }
                       }
                       graphs2.Add(graphs[f]);
                   }
               }
           }
           for (int j = 0; j < graphs2.Count; j++)
           {
                if (vertex.Contains(graphs2[j].Vert1) == false || vertex.Contains(graphs2[j].Vert2) == false)
                {
                    if (graphs2[j].Weight < min)
                    {
                        min = graphs2[j].Weight;
                        if (vertex.Contains(graphs2[j].Vert1) == false)
                        { k = graphs2[j].Vert1; }
                        else if (vertex.Contains(graphs2[j].Vert2) == false)
                        { k = graphs2[j].Vert2; }
                    }
                }
           } 
           min_ostava += min;
           vrt = k;
        }
        Console.WriteLine($"Минимальная остова графа: {min_ostava}");
    }
}