using System.Diagnostics;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Windows.Markup;
class Program
{
    static void Main()
    {
        int[,] edges_weight_propusk =
        {
            {int.MaxValue,20,30,10,int.MaxValue},
            {int.MaxValue,int.MaxValue,40,int.MaxValue,30},
            {int.MaxValue,int.MaxValue,int.MaxValue,10,20},
            {int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,20},
            {int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }
        };
        Stack<int> last_way = new Stack<int>();
        int size = edges_weight_propusk.GetLength(0);
        int[,] edges_weight_propucheno = new int[size, size];
        int total_flow = 0;
        int s = 0;
        int t = size-1;
        int[]way = new int[size];
        Console.WriteLine("Увеличивающие пути: ");
        while(BFS(edges_weight_propusk,s,t,way,size))
        {
            last_way.Clear();
            int flow = int.MaxValue;
            int v = t;
            foreach (int i in way)
            while(v!=s)
            {
                last_way.Push(v);
                int u = way[v];
                flow = Math.Min(flow, edges_weight_propusk[u,v]);
                v = u;
            }
            last_way.Push(v);
            v = t;
            while(v!=s)
            {
                int u = way[v];
                edges_weight_propusk[u, v] -= flow;
                edges_weight_propucheno[u,v] += flow;
                v = u;
            }
            total_flow+= flow;
            while (last_way.Count != 0)
                Console.Write(last_way.Pop() + " ");
            Console.WriteLine();
        }
        Console.WriteLine("Максимальный поток: "+total_flow);
    }
    static bool BFS(int[,] edges_weight_propusk,int s,int t,int[] way,int count)
    {
        bool[] visited = new bool[count];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(s);
        visited[s] = true;
        while(queue.Count!=0)
        {
            int v = queue.Dequeue();
            for (int i =0;i<count;i++)
            {
                if (visited[i] == false && edges_weight_propusk[v,i]>0&&edges_weight_propusk[v,i]!=int.MaxValue)
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    way[i] = v;
                }
            }
        }
        return visited[t];
    }
}
