using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            {-1,-1,-1,-1,-1,-1,-1},
            {-1,0,0,-1,0,0,-1},
            {-1,-1,0,-1,0,-1,-1},
            {-1,0,0,-1,0,-1,-1},
            {-1,0,0,-1,0,0,-1},
            {-1,0,0,0,0,0,-1 },
            {-1,0,0,0,-1,-1,-1},
            {-1,-1,0,0,-1,0,-1},
            {-1,-1,0,0,0,0,-1},
            {-1,0,0,-1,-1,0,-1 },
            {-1,0,0,0,0,0,-1 },
            {-1,0,0,0,-1,0,-1 },
            {-1,-1,-1,-1,-1,-1,-1 }
        };
        Console.Write("Введите координаты входа: ");
        string[] s = Console.ReadLine().Split(' ');
        int CI_enter = int.Parse(s[0]);
        int CJ_enter  = int.Parse(s[1]);
        if(CI_enter<1||CI_enter>10||CJ_enter<1||CJ_enter>5)
        {
            Console.WriteLine("Координаты входа не в поле");
            Environment.Exit(0);
        }
        Console.Write("\nВведите координаты выхода: ");
        s = Console.ReadLine().Split(' ');
        int CI_exit = int.Parse(s[0]);
        int CJ_exit = int.Parse(s[1]);
        if(CI_exit < 1 || CI_exit > 11|| CJ_exit < 1 || CJ_exit > 5)
        {
            Console.WriteLine("Координаты выхода не в поле");
            Environment.Exit(0);
        }
        if (matrix[CI_enter, CJ_enter] == -1 || matrix[CI_exit, CJ_exit] == -1)
        { Console.WriteLine("Нет пути"); Environment.Exit(0); }
        int count=3;
        bool flag = false;
        int p = 1;
        while(flag!=true)
        {
            for (int i = CI_enter-p;i<CI_enter-p+count;i++)
            {
                if (flag == true)
                    break;
                if (i < 1 || i > 11)
                    continue;
                for (int j = CJ_enter-p;j<CJ_enter-p+count;j++)
                {
                    if (j<1||j>5)
                        continue;
                    if (matrix[i, j] == -1)
                        continue;
                    if (i == CI_enter && j == CJ_enter)
                        continue;
                    if (matrix[i,j]==0)
                    {
                        if(count==3)
                        {
                            matrix[i, j] += 1;
                            continue;
                        }
                        int min = 100;
                        for(int h = i-1;h<i+2;h++)
                        {
                            for (int k = j-1;k<j+2;k++)
                            {   
                                if (h>11||h<1||k>5||k<1)
                                    continue;
                                if (matrix[h, k]< min&& matrix[h, k] != -1 && matrix[h,k]!=0)
                                {
                                    min = matrix[h,k];
                                    matrix[i, j] = matrix[h,k]+1;
                                }
                            }
                        }
                    }
                    if (i == CI_exit && j == CJ_exit && matrix[i,j]!=0)
                    {
                        flag = true; break;
                    }
                }
            }
            count += 2;
            p++;
        }
        int rezult = matrix[CI_exit, CJ_exit];
        Console.WriteLine("Кратчайший путь до выхода: "+ rezult);
        List<string> way = new List<string>
        {
            Convert.ToString(CI_exit) + " " + Convert.ToString(CJ_exit)
        };
        Rec(way, CI_exit-1, CJ_exit-1,rezult,matrix);
        way.Add(Convert.ToString(CI_enter)+" "+ Convert.ToString(CJ_enter));
        way.Reverse();
        Console.Write("Путь: ");
        foreach(string l in way)
        { Console.Write(l+";"); }
        Console.WriteLine();
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    static void Rec(List<string> way, int cordi, int cordj,int min, int[,]matrix)
    {
        int cord2i =0;
        int cord2j =0;
        for(int i = cordi;i<cordi+3;i++)
        {
            for( int j = cordj; j<cordj+3;j++)
            {
                if (i > 11 || i < 1 || j > 5 || j < 1)
                    continue;
                if (matrix[i,j]<min&& matrix[i, j] != -1 && matrix[i,j]!=0)
                {
                    min = matrix[i,j];
                    cord2i = i;
                    cord2j = j;
                }
            }
        }
        way.Add(Convert.ToString(cord2i) + " " + Convert.ToString(cord2j));
        if (min != 1)
            Rec(way,cord2i-1,cord2j-1,min,matrix);
    }
}