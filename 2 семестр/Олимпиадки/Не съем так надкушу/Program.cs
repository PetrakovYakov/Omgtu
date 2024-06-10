namespace Ol
{
    class Graph
    {
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText("D:\\Не съем, так надкушу\\input_s1_01.txt");
            StreamReader sr_out = File.OpenText("D:\\Не съем, так надкушу\\output_s1_01.txt");
            string output = sr_out.ReadLine();
            string[] s = sr.ReadLine().Split(' ');
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);
            int[,] matrix = new int[n + 1, n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    matrix[i, j] = 1000000;
                }
            }
            int n1 = 0; int n2 = 0;
            //создаём матрицу смежности
            for (int k = 1; k <= n; k++)
            {
                s = sr.ReadLine().Split(' ');
                n1 = int.Parse(s[0]);
                n2 = int.Parse(s[1]);
                for (int i = 0; i < n + 1; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        matrix[n1, k] = matrix[k, n1] = n2;
                    }
                }
            }
            Dictionary<int, int> apple = new Dictionary<int, int>();
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split(' ');
                apple.Add(int.Parse(s[0]), int.Parse(s[1]));
            }
            s = sr.ReadLine().Split(' ');
            int worm_position = int.Parse(s[0]); //позиция червя
            if (apple.ContainsKey(worm_position))
                apple.Remove(worm_position);
            int fresh_apple = int.Parse(s[1]); // минимальная спелость яблока
            int way = 0;
            while (apple.Count!=0)
            {
                int min = 1000000;
                int[] weight = new int[n+1];
                for (int i = 0; i < n + 1; i++)
                    weight[i] = 1000000;
                bool[] visited = new bool[n+1];
                for(int i= 0; i<n+1;i++)
                {
                    visited[i] = false;
                }
                visited[worm_position] = true;
                int k = 0;
                int w = 0; //использование алгоритма Дейкстра
                for(int i =0; i<n+1;i++)
                {
                    if (apple.ContainsKey(i) && apple[i] < fresh_apple)
                    {
                        apple.Remove(i);
                        continue;
                    }
                    for(int j =0; j<n+1; j++)
                    {
                        if (visited[j]==false)
                        {
                            if (apple.ContainsKey(j) && apple[j] < fresh_apple)
                            {
                                apple.Remove(j);
                                continue;
                            }
                            else
                            {
                                if (matrix[worm_position, j] + w < weight[j])
                                    weight[j] = matrix[worm_position, j] + w;
                                if (weight[j] < min)
                                {
                                    min = weight[j];
                                    k = j;
                                }
                            }
                        }
                    }
                    worm_position= k;
                    visited[worm_position] = true;
                    w = min;
                    min = 1000000;
                }
                for(int i =0; i<n+1; i++)
                {
                    if (apple.ContainsKey(i) && apple[i] >= fresh_apple && weight[i]<min)
                    {
                        min = weight[i];
                        worm_position = i;
                    }
                }
                apple.Remove(worm_position);
                way += min;
            }
            if(way==1000000)
                Console.WriteLine(0);
            else
                Console.WriteLine(way);
            Console.WriteLine(output);
        }
    }
}