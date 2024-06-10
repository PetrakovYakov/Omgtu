using System;
using System.Diagnostics;
using System.IO.Pipes;

namespace Roberts_Flores
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = {
                {0,1,0,0,1 },
                {1,0,0,1,0 },
                {0,0,0,1,1 },
                {0,1,1,0,1 },
                {1,0,1,1,0 }
            };
            bool[]visited = new bool[matrix.GetLength(0)];
            for(int i =0; i<matrix.GetLength(0);i++)
                visited[i] = false;
            int vertex = 0;
            visited[0] = true;
            Stack<int> stack_vertex = new Stack<int>();
            stack_vertex.Push(0);
            int non_vert = 0;
            List<int>[] visit_vert = new List<int>[matrix.GetLength(0)];
            for(int i =0;i<matrix.GetLength(0);i++)
                visit_vert[i] = new List<int>();
            while(true)
            {
                Reccurent_Gamilton(matrix, vertex, visited, stack_vertex,visit_vert);
                if (stack_vertex.Count == matrix.GetLength(0))
                {
                    int[] way = new int[stack_vertex.Count];
                    stack_vertex.CopyTo(way, 0);
                    if (matrix[way[0], 0] == 1)
                    {
                        Console.WriteLine("Найден цикл!");
                        for (int j = stack_vertex.Count-1;j>=0; j--)
                        {
                            Console.Write(way[j]+" ");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Найден путь!");
                        for (int j = stack_vertex.Count - 1; j >= 0; j--)
                        {
                            Console.Write(way[j]+" ");
                        }
                        Console.WriteLine();
                    }
                }
                non_vert = stack_vertex.Pop();
                visited[non_vert] = false;
                visit_vert[non_vert].Clear();
                if (stack_vertex.Count == 0)
                    break;
                else
                {
                    vertex = stack_vertex.Peek();
                    visit_vert[vertex].Add(non_vert);
                }
            }
        }
        static void Reccurent_Gamilton(int[,] matrix, int vertex, bool[] visited, Stack<int> stack,  List<int>[] visit)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[vertex, i] == 1 && visited[i] == false && !visit[vertex].Contains(i))
                {
                    stack.Push(i);
                    visited[i] = true;
                    Reccurent_Gamilton(matrix, i, visited, stack,visit);
                    break;
                }
            }
        }
    }
}