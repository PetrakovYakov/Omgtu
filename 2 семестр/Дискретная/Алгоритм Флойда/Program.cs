using System.ComponentModel.Design;
using System.Security.Cryptography;
class Program
{
    static void Main()
    {
        int[,] matrix_all= new int[7, 7]
        {
            {0,4,int.MaxValue,int.MaxValue,4,4,int.MaxValue},
            {int.MaxValue,0,int.MaxValue,int.MaxValue,-5,4,int.MaxValue},
            {int.MaxValue,-3,0,3,int.MaxValue,3,int.MaxValue},
            {int.MaxValue,int.MaxValue,int.MaxValue,0,int.MaxValue,int.MaxValue,3},
            {int.MaxValue,int.MaxValue,9,int.MaxValue,0,int.MaxValue,int.MaxValue},
            {int.MaxValue,int.MaxValue,int.MaxValue,1,int.MaxValue,0,int.MaxValue},
            {int.MaxValue,int.MaxValue,-5,int.MaxValue,int.MaxValue,int.MaxValue,0}
        };
        for(int i=0;i<7; i++)
        {
            for (int j=0;j<7;j++)
            {
                for(int k =0; k<7;k++)
                {
                    if ((matrix_all[j, i] != int.MaxValue) && (matrix_all[i,k]!=int.MaxValue))
                        matrix_all[j, k] = Math.Min(matrix_all[j, i] + matrix_all[i, k], matrix_all[j, k]);
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j <7; j++)
            {
                if (matrix_all[i, j]==int.MaxValue)
                {
                    Console.Write("inf\t");
                }
                else
                    Console.Write(matrix_all[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.Write("\nВведите вершину, откуда будет строится путь: ");
        int start_vert = int.Parse(Console.ReadLine());
        Console.Write("\nВведите вершину, до куда будет строится путь: ");
        int finish = int.Parse(Console.ReadLine());
        start_vert--;finish--;
        if (matrix_all[start_vert, finish] >= 10000)
            Console.WriteLine("Пути не существует");
        else
        {
            Console.WriteLine($"Расстояние: {matrix_all[start_vert,finish]}");
            Console.Write("\nПуть: ");
            List<int> way = new List<int>();
            way.Add(start_vert+1);
            Console.Write(start_vert+1+" ");
            while (start_vert != finish)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (matrix_all[start_vert, finish] == matrix_all[start_vert, i] + matrix_all[i, finish]&&!way.Contains(i + 1))
                    {
                        way.Add(i+1);
                        start_vert = i;
                        Console.Write((i+1)+" ");
                        break;
                    }
                }
            }
            
        }
    }
}
