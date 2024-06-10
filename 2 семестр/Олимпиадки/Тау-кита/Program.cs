using System;
using System.IO;
using System.Net.WebSockets;

namespace Tau_kita
{
    class Program
    {
        static void Main(string[]args)
        {
            StreamReader sr = File.OpenText("D:\\Тау-Кита\\input_s1_01.txt");
            StreamReader sr_out = File.OpenText("D:\\Тау-Кита\\output_s1_01.txt");
           
            string[] s = sr.ReadLine().Split(' ');
            Console.Write("Было: ");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + " ");
            }
            string output = sr_out.ReadLine(); 
            char l;
            int count;
            int count2 = 1;
            string[] s_out = new string[s.Length];
            for(int i=0; i<s.Length;i++)
            {
                count = 1;
                for(int j =0;j< s[i].Length / 2; j++)
                {
                    if (s[i].Length%2==0&&j==0)
                    {
                        l = s[i][j];
                        s[i] = s[i].Remove(j,j+1) +l;
                        continue;
                    }
                    l = s[i][0];
                    s[i] = s[i].Remove(0, 1);
                    s[i] = s[i].Insert(s[i].Length-(j+count),Convert.ToString(l));
                    count++;
                }
                if (i < s.Length / 2)
                {
                    if (s.Length % 2 == 0 && i == 0)
                    {
                        s_out[s.Length - (i + 1)] = s[i];
                    }
                    else
                    {
                        s_out[s.Length - (i + count2) - 1] = s[i]; count2++;
                    }
                }
                else
                {
                    for(int j =0; j<s.Length;j++)
                    {
                        if (s_out[j] == null)
                        {
                            s_out[j] = s[i]; break;
                        }
                    }
                }
            }
            Console.Write("\n\nРезультат: ");
            for (int i =0; i<s.Length;i++)
            {
                Console.Write(s_out[i]+" ");
            }
            Console.Write("\n\nСравнение: ");
            Console.Write(output+"\n");
        }
        
    }

}
