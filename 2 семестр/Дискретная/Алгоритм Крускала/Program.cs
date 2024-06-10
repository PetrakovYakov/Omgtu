
namespace Graph
{
    class Graph
    {
        public int Vertex_a;
        public int Vertex_b;
        public int Weight;
        public Graph(int verta, int vertb, int weight) {
            Vertex_a = verta;
            Vertex_b = vertb;
            Weight = weight;
        }
        public  void Print()
        {
            Console.WriteLine($"{Vertex_a}  {Vertex_b}  {Weight}");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Graph> graphs = new List<Graph>();
            Console.WriteLine("Заполнение графов, введите end для остановки");
            Console.WriteLine("1 вершина| 2 вершина| вес");
            int verta;
            int vertb;
            int weight;
            while (true)
            {
                string[] s = Console.ReadLine().Split(' ');
                if (s[0] == "end")
                    break;
                verta = int.Parse(s[0]);
                vertb = int.Parse(s[1]);
                weight = int.Parse(s[2]);
                graphs.Add(new Graph(verta, vertb, weight));
            }
            graphs.Sort(delegate (Graph x, Graph y)
            {
                return x.Weight.CompareTo(y.Weight);
            });
            List<int> vertex = new List<int>();
            List<int> vertex2= new List<int>();
            int min_ostov= 0;
            int n = 0;
            for(int i =0; i<graphs.Count; i++)
            {
                graphs[i].Print();
                if (i==0)
                {
                    min_ostov += graphs[i].Weight;
                    vertex.Add(graphs[i].Vertex_a);
                    vertex.Add(graphs[i].Vertex_b);
                    continue;
                }
                if(vertex.Contains(graphs[i].Vertex_a)==false&&vertex.Contains(graphs[i].Vertex_b) == false)
                {
                    if (vertex2.Contains(graphs[i].Vertex_b) == false || vertex2.Contains(graphs[i].Vertex_a) == false)
                    {
                        min_ostov += graphs[i].Weight;
                        vertex2.Add(graphs[i].Vertex_a);
                        vertex2.Add(graphs[i].Vertex_b);
                    }
                    continue;
                }
                if (vertex.Contains(graphs[i].Vertex_a) == false || vertex.Contains(graphs[i].Vertex_b)==false)
                {
                    if (vertex2.Contains(graphs[i].Vertex_a) )
                    {
                        while (vertex2.Contains(graphs[i].Vertex_a))
                        { 
                            n = vertex2.IndexOf(graphs[i].Vertex_a);
                            if (n % 2 == 0)
                                vertex.Add(vertex2[n + 1]);
                            else
                                vertex.Add(vertex2[n - 1]);
                            vertex2.Remove(graphs[i].Vertex_a);
                            vertex2.Remove(graphs[i].Vertex_b);
                        }
                    }
                    else if(vertex2.Contains(graphs[i].Vertex_b))
                    {
                        while (vertex2.Contains(graphs[i].Vertex_b))
                        {
                            n = vertex2.IndexOf(graphs[i].Vertex_b);
                            if (n % 2 == 0)
                                vertex.Add(vertex2[n + 1]);
                            else
                                vertex.Add(vertex2[n - 1]);
                            vertex2.Remove(graphs[i].Vertex_a);
                            vertex2.Remove(graphs[i].Vertex_b);
                        }
                    }
                    min_ostov += graphs[i].Weight;
                    vertex.Add(graphs[i].Vertex_a);
                    vertex.Add(graphs[i].Vertex_b);
                }
            }
            Console.Write($"Минимальная остова графа: {min_ostov}");

        }
    }
}
