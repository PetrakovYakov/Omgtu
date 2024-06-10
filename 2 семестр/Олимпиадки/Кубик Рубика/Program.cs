using System;
class Program
{
    static void Main()
    {
        string num = Console.ReadLine();
        string path = $"D:\\Кубик Рубика\\input_s1_{num}.txt";
        string path_out = $"D:\\Кубик Рубика\\output_s1_{num}.txt";
        StreamReader input_reader = File.OpenText(path);
        string[] s = input_reader.ReadLine().Split(' ');
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);
        string[] point = input_reader.ReadLine().Split(' ');
        int x = int.Parse(point[0]);
        int y = int.Parse(point[1]);
        int z = int.Parse(point[2]);
        int change = 0;
        for (int i = 0; i < m; i++)
        {
            string[] turn = input_reader.ReadLine().Split(' ');
            string os = turn[0];
            int cords = int.Parse(turn[1]);
            int direct = int.Parse(turn[2]);
            if (os == "X")
            {
                if (x == cords)
                {
                    if (direct > 0)
                    {
                        change = z;
                        z = n + 1 - y;
                        y = change;
                    }
                    else
                    {
                        change = y;
                        y = n + 1 - z;
                        z = change;
                    }

                }
            }
            if (os == "Y")
            {
                if (y == cords)
                {
                    if (direct > 0)
                    {
                        change = z;
                        z = n + 1 - x;
                        x = change;
                    }
                    else
                    {
                        change = x;
                        x = n + 1 - z;
                        z = change;
                    }
                }
            }
            if (os == "Z")
            {
                if (z == cords)
                {
                    if (direct > 0)
                    {
                        change = y;
                        y = n + 1 - x;
                        x = change;
                    }
                    else
                    {
                        change = x;
                        x = n + 1 - y;
                        y = change;
                    }
                }
            }
        }
        Console.WriteLine($"Ответ: {x} {y} {z}");
        StreamReader streamReader_out = File.OpenText(path_out);
        Console.WriteLine("Output: "+streamReader_out.ReadLine());
    }
}
