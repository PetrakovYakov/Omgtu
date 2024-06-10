using System.Security.Cryptography;

class Graph
{
    public List<int>[] values;
    public Graph(int v)
    {
        values = new List<int>[v];
        for (int i = 0; i < v; i++)
            values[i] = new List<int>();
    }
    public void AddE(int v, int w)
    {
        values[v].Add(w);
        values[w].Add(v);
    }
    static void Main()
    {
        Console.Write("Введите кол-во вершин ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите рёбра (нумерация вершин с нуля) для остановки end");
        Graph graph = new Graph(n);
        Queue<int> q_v = new Queue<int>();
        List<int> white_verts = new List<int>();
        bool[] visited = new bool[n];
        int vert = 0;
        while (true)
        {
            string[] s = Console.ReadLine().Split(' ');
            if (s[0] == "end")
                break;
            int v1 = int.Parse(s[0]);
            int v2 = int.Parse(s[1]);
            if (!white_verts.Contains(v1))
            { white_verts.Add(v1); }
            if (!white_verts.Contains(v2))
            { white_verts.Add(v2); }
            graph.AddE(v1, v2);
        }
        int g = 0;
        int v = 0;
        while(white_verts.Count!=0)
        {
            g++;
            Console.Write($"{g} подграф [ ");
            q_v.Enqueue(white_verts[0]);
            visited[white_verts[0]] = true;
            while(q_v.Count!=0)
            {
                vert = q_v.Peek();
                white_verts.Remove(vert);
                Console.Write(vert+" ");
                q_v.Dequeue();
                for(int i =0; i < graph.values[vert].Count; i++)
                {
                    v= graph.values[vert][i];
                    if (visited[v]==false)
                    {
                        visited[v] = true;
                        q_v.Enqueue(v);
                    }
                }
            }
            Console.Write("]\n");
        }
        Console.WriteLine($"Количество компонент связности: {g}");
    }
}
