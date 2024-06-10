using System;
using System.IO;
namespace Work_with_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr1 = File.OpenText("D:\\file_sort1.txt");
            StreamReader sr2 = File.OpenText("D:\\file_sort2.txt");
            StreamWriter file_out = File.CreateText("file_out.txt");
            string input1 = " ";
            string input2 = " ";
            string input3 = " ";
            input1 = sr1.ReadLine();
            input2 = sr2.ReadLine();
            while (true)
            {
                if (input1 != null && input2 != null)
                {
                    if (int.Parse(input1) > int.Parse(input2))
                    {
                        file_out.WriteLine(input2);
                        input3 = sr2.ReadLine();
                        if (input3 != null)
                        {
                            while (int.Parse(input3) > int.Parse(input1))
                            {
                                file_out.WriteLine(input1);
                                input1 = sr1.ReadLine();
                                if (input1 == null)
                                    break;
                            }
                            file_out.WriteLine(input3);
                        }
                        input2 = sr2.ReadLine();
                    }
                    else
                    {
                        file_out.WriteLine(input1);
                        input3 = sr1.ReadLine();
                        if (input3 != null)
                        {
                            while (int.Parse(input3) > int.Parse(input2))
                            {
                                file_out.WriteLine(input2);
                                input2 = sr2.ReadLine();
                                if(input2==null)
                                    break;
                            }
                            file_out.WriteLine(input3);
                        }
                        else
                            input2 = sr2.ReadLine();
                        input1 = sr1.ReadLine() ;
                    }
                }
                else if (input1 == null && input2 != null)
                {
                    file_out.WriteLine(input2);
                    input2 = sr2.ReadLine();
                }
                else if (input2 == null && input1 != null)
                {
                    file_out.WriteLine(input1);
                    input1 = sr1.ReadLine();
                }
                else
                    break;
            }
            file_out.Close();
            StreamReader sr_file_out = File.OpenText("file_out.txt");
            while ((input1 = sr_file_out.ReadLine()) != null)
            { Console.WriteLine(input1); }
            ///////////////////////////////////////////////////////
            StreamReader sr_file_a = File.OpenText("D:\\file_string_a.txt");
            int i = 0;
            int min_count = 0;
            string min_str_a = " ";
            while(true)
            {
                input1  = sr_file_a.ReadLine();
                if(input1==null)
                    break;
                int count = 0;
                int count2 = 0;
                int k = 0;
                for(int j = 0;j<input1.Length;j++)
                {
                    if (input1[j]=='a')
                        count++;
                    else
                    {
                        if (k == 0 && count != 0)
                        {
                            count2 = count; k++; count = 0;
                        }
                        else
                        {
                            if (count < count2&&count!=0)
                            {
                                count2 = count; count = 0;
                            }
                        }
                    }
                }
                if (i == 0&&count2!=0)
                {
                    min_count = count2; min_str_a = input1; i++;
                }
                else if (count2 < min_count&&count2!=0)
                {
                    min_count = count2;
                    min_str_a = input1;
                }
            }
            Console.WriteLine($"Строка с наименьшей длиной подпоследовательности, состоящей из символа 'a' {min_str_a}");
        }
    }
}
