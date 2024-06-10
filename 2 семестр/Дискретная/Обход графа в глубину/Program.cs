using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography;
class Graph
{
    public List<int>[] values;
    public Graph(int v)
    {
        values = new List<int>[v];
        for(int i=0; i<v;i++)
            values[i]=new List<int>();
    }
    public void AddE(int v,int w)
    {
        values[v].Add(w);
        values[w].Add(v);
    }
    public void dfs(int v, bool[]visited, List<int> white)
    {
        white.Remove(v);
        visited[v] = true;
        Console.Write(v+" ");
        foreach (int i in values[v])
        {
            if (visited[i] == false)
                dfs(i,visited,white);
        }
    }
    static void Main()
    {
        Console.Write("Введите кол-во вершин ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите рёбра (нумерация вершин с нуля) для остановки end");
        Graph graph = new Graph(n);
        List<int> white_verts = new List<int>(); 
        bool[] visited = new bool[n];
        while (true)
        {
            string[] s = Console.ReadLine().Split(' ');
            if (s[0] == "end")
                break;
            int v1 = int.Parse(s[0]);
            int v2 = int.Parse(s[1]);
            if(!white_verts.Contains(v1))
            { white_verts.Add(v1); }
            if(!white_verts.Contains(v2))
            { white_verts.Add(v2); }
            graph.AddE(v1,v2);
        }
        int i = 0;
        while (white_verts.Count != 0)
        {
            i++;
            Console.Write($"вершины {i}-го связного подграфа [ ");
            graph.dfs(white_verts[0], visited, white_verts);
            Console.Write("]\n");
        }
        Console.WriteLine($"Количество компонент связности: {i}");
    }
}