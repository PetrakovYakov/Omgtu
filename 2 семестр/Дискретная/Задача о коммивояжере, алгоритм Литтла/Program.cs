using System.Reflection;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        int sz1 = 6;
        int sz2 = 5;
        int[,] matrix1 =
        {
            {10000, 27,43,16,30,26},
            {7,10000,16,1,30,25 },
            {20,13,10000,35,5,0 },
            {21,16,25,10000,18,18 },
            {12,46,27,48,10000,5 },
            {23,5,5,9,5,1000 }
        };
        int[,] matrix2 =
         {
             { 10000,44,74,41,5},
             {14,10000,47,12,52 },
             {85,47,10000,65,45},
             {45,58,65,10000,75 },
             {74,63,9,75,10000}
         };
        Gamilton_Cycle(matrix1,sz1);
        Console.WriteLine("\n-----------------------------------");
        Gamilton_Cycle(matrix2,sz2);
    }
    static void Gamilton_Cycle(int[,]matrix,int sz)
    {
        List<int> full_verts = new List<int>();
        int[] min_matr = new int[sz];
        int low_mark = 0;
        int min;
        List<string> weight = new List<string>();
        for (int l = 0; l < sz - 1; l++)
        {
            for (int i = 0; i < 2 * sz; i++)
            {
                min = 10000;
                for (int j = 0; j < sz; j++)
                {
                    if ((i < sz) && (matrix[i, j] < min))
                    {
                        min = matrix[i, j];
                        min_matr[i] = min;
                    }
                    else if (i >= sz && matrix[i - sz, j] != 10000)
                    {
                        matrix[i - sz, j] -= min_matr[i - sz];
                    }
                }
                if (i >= sz)
                    low_mark += min_matr[i - sz];
            }

            for (int i = 0; i < sz; i++)
                min_matr[i] = 0;
            for (int j = 0; j < 2 * sz; j++)
            {
                min = 10000;
                for (int i = 0; i < sz; i++)
                {
                    if ((j < sz) && (matrix[i, j] < min))
                    {
                        min = matrix[i, j];
                        min_matr[j] = min;
                    }
                    else if (j >= sz && matrix[i, j - sz] != 10000)
                    {
                        matrix[i, j - sz] -= min_matr[j - sz];
                    }
                }
                if (j >= sz)
                    low_mark += min_matr[j - sz];
            }
            for (int i = 0; i < sz; i++)
                min_matr[i] = 0;
            int[,] deg_zero = new int[sz, sz];
            int min2 = 10000;
            int max_deg = 0;
            int ind_i = 0;
            int ind_j = 0;
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        min = 10000;
                        min2 = 10000;
                        for (int k = 0; k < 2 * sz; k++)
                        {
                            if ((k < sz) && (k != j) && (matrix[i, k] < min))
                            {
                                min = matrix[i, k];
                            }
                            if ((k >= sz) && (k - sz != i) && (matrix[k - sz, j] < min2))
                            {
                                min2 = matrix[k - sz, j];
                            }
                        }
                        deg_zero[i, j] = min + min2;
                        if (deg_zero[i, j] > max_deg)
                        {
                            max_deg = deg_zero[i, j];
                            ind_i = i;
                            ind_j = j;
                        }
                    }
                }
            }
            string s = Convert.ToString(ind_i + 1) + Convert.ToString(ind_j + 1);
            if (weight.Count == 0)
            {
                weight.Add(s);
                matrix[ind_j, ind_i] = 10000;
            }
            else
            {
                bool flag = true;
                while ((weight.Count >= 1) && (flag == true))
                {
                    flag = false;
                    for (int i = 0; i < weight.Count; i++)
                    {
                        if (s[s.Length - 1] == weight[i][0])
                        {
                            weight[i] = s + weight[i]; flag = true;
                        }

                        if (s[0] == weight[i][weight[i].Length - 1])
                        {
                            weight[i] = weight[i] + s; flag = true;
                        }
                        if (flag == true)
                        {
                            s = weight[i];
                            matrix[int.Parse(Convert.ToString(s[s.Length - 1])) - 1, int.Parse(Convert.ToString(s[0])) - 1] = 10000;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    weight.Add(s);
                    matrix[ind_j, ind_i] = 10000;
                }
            }
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    if (i == ind_i || j == ind_j)
                        matrix[i, j] = 10000;
                }
            }
        }
        Console.WriteLine($"Минимальная длина гамильтонова цикла: {low_mark}");
        Console.Write($"Путь: ");
        int len = weight.Count - 1;
        for (int i = 0; i < weight[len].Length; i++)
        {
            if (i % 2 != 0)
                Console.Write(weight[len][i] + " ");
            else
                Console.Write(weight[len][i]);
        }
        Console.Write($"{weight[len][weight[len].Length - 1]}{weight[len][0]}");
    }
}