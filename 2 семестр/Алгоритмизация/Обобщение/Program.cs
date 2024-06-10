using System.Runtime.CompilerServices;
class Numbers<T>
{
    public T a;
    public T b;
    public Numbers(T a, T b) {
        this.a = a;
        this.b = b;
    }
    public T Sum()
    {
        dynamic a1 = a;
        dynamic b1 = b;
        return a1 + b1;
    }
    public T Minus()
    {
        dynamic a1 = a;
        dynamic b1 = b;
        return a1 - b1;
    }
    public T Umnojenie()
    {
        dynamic a1 = a;
        dynamic b1 = b;
        return a1 * b1;
    }
    public T Delenie()
    {
        dynamic a1 = a;
        dynamic b1 = b;
        if(b1 ==0)
            throw new DivideByZeroException();
        return a1 / b1;
    }
}
class Program
{ 
    static void Main()
    { 
        while(true)
        { 
        Console.Write("Выберите действие:\n1)Работа с целыми\n2)Работа с вещественными\n3)Выход\n");
        int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    bool flag1 = false;
                    int rezult = 0;
                    while (flag1 == false)
                    {
                        Numbers<int> ints;
                        Console.Write("Выберите операцию\n1)Сложение\n2)Вычитание\n3)Произведение\n4)Деление\n5)Выход:\n");
                        int n1 = int.Parse(Console.ReadLine());
                        if (n1 == 5)
                            break;
                        Console.Clear();
                        Console.Write("\nВведите первое число:  ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("\nВведите второе число: ");
                        int b = int.Parse(Console.ReadLine());
                        ints = new Numbers<int>(a, b);
                        switch (n1)
                        {
                            case 1: rezult = ints.Sum(); break;
                            case 2: rezult = ints.Minus(); break;
                            case 3: rezult = ints.Umnojenie(); break;
                            case 4:
                                try
                                {
                                    rezult = ints.Delenie();
                                }
                                catch (DivideByZeroException)
                                {
                                    Console.WriteLine("Деление на ноль невозможно"); continue;
                                }
                                break;
                            default: flag1 = true; continue;
                        }
                        Console.WriteLine("Результат: " + rezult);
                    }
                    break;
                case 2:
                    bool flag2 = false;
                    double rezult2 = 0;
                    while (flag2 == false)
                    {
                        Numbers<double> doubles;
                        Console.Write("Выберите операцию\n1)Сложение\n2)Вычитание\n3)Произведение\n4)Деление\n5)Выход: ");
                        int n2 = int.Parse(Console.ReadLine());
                        if (n2 == 5) break;
                        Console.Clear();
                        Console.Write("\nВведите первое число:  ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("\nВведите второе число: ");
                        double b = double.Parse(Console.ReadLine());
                        doubles = new Numbers<double>(a, b);
                        switch (n2)
                        {
                            case 1: rezult2 = doubles.Sum(); break;
                            case 2: rezult2 = doubles.Minus(); break;
                            case 3: rezult2 = doubles.Umnojenie(); break;
                            case 4:
                                try
                                {
                                    rezult2 = doubles.Delenie();
                                }
                                catch (DivideByZeroException) { Console.WriteLine("Деление на ноль невозможно"); continue; }
                                break;
                            default: flag2 = true; continue;
                        }
                        Console.WriteLine("Результат: " + rezult2);
                    } break;
                    case 3: Environment.Exit(0); break;
            }
        }
    }
}
public class DivideByZeroException : ArithmeticException
{ }

