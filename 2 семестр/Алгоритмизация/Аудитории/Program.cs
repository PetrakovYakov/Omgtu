using System;
namespace Auditori_BD
{
    class Programm
    {
        static Auditory[] auditories;
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
            Console.WriteLine();
            Console.WriteLine("ВЫХОД...");
        }
        public class Menu
        {
            public void Start()
            {
                int d = 0;
                bool flag = true;
                while(flag ==true)
                {
                    Console.WriteLine("МЕНЮ: ");
                    Console.WriteLine(" 1)Создание базы данных\n 2)Добавление в базу \n 3)Изменить данные об аудитории по заданному номеру " +
                        "\n 4)Выборка аудиторий с количеством посадочных мест \n 5)Выборка аудиторий с проектором \n " +
                        "6)Выборка аудиторий с пк и заданным количеством мест \n " +
                        "7)Выборка аудиторий по номеру этажа \n 8)Вывод всех данных по аудиториям \n 9)Выход");
                    Console.Write("Выберите действие:");
                    int n;
                    while(true)
                    {
                        string s = Console.ReadLine();
                        if(int.TryParse(s, out n))
                        {
                            break;
                        }
                        Console.Write("Число не распознано, введите повторно: ");
                    }
                    while (n < 1 || n > 9)
                    {
                        Console.Write("Введите корректный номер действия в меню:");
                        n = int.Parse(Console.ReadLine());
                    }
                    if (d == 0 && n > 1 && n != 9)
                    {
                        while (n > 1 && n != 9)
                        {
                            Console.Write("Для работы с базой данных, её необходимо создать, введите '1' или выйдeте из программы '9' :");
                            n = int.Parse(Console.ReadLine());
                        }
                    }
                    if(d>0&&n==1)
                    {
                        Console.WriteLine("База данных уже создана");
                        while(d > 0 && n == 1)
                        {
                            Console.Write("Введите другое действие: ");
                            n= int.Parse(Console.ReadLine());
                        }
                    }
                    switch (n)
                    {
                        case 1: Auditory.Create(); break;
                        case 2: Auditory.AddAuditory(); break;
                        case 3: Auditory.ChangeAuditory(); break;
                        case 4: Auditory.ViborkaCount(); break;
                        case 5: Auditory.ViborkaProector(); break;
                        case 6: Auditory.ViborkaPC(); break;
                        case 7: Auditory.ViborkaLevel(); break;
                        case 8: Auditory.Print2(); break;
                        case 9: flag =false; break;
                    }
                    d++;
                } 
            }
        }
        public class Auditory
        {
            public int number_auditorii;
            public int count;
            public bool proector;
            public bool est_computeri;

            public Auditory(int number_auditorii, int count, bool proector, bool est_computeri)
            {
                this.number_auditorii = number_auditorii;
                this.count = count;
                this.proector = proector;
                this.est_computeri = est_computeri;
            }
            public static void Print(int i)
            {
                Console.WriteLine();
                string pr;
                string comp;
                switch (auditories[i].proector)
                {
                    case false: pr = "нет"; break;
                    case true: pr = "да"; break;
                }
                switch (auditories[i].est_computeri)
                {
                    case false: comp = "нет"; break;
                    case true: comp = "да"; break;
                }
                Console.WriteLine($"*1*Номер аудитории: {auditories[i].number_auditorii}\t\n*2*Количество мест в аудитории:" +
                    $" {auditories[i].count}\t\n*3*Наличие проектора: {pr}\t\n*4*Наличие компьтеров: {comp}");
                Console.WriteLine();
            }
            public static void Create()
            {
                Console.Clear();
                Console.WriteLine("СОЗДАНИЕ БАЗЫ ДАННЫХ");
                Console.WriteLine("==============================");
                Console.Write("Введите количество аудиторий:\t");
                int n;
                while(true)
                {
                    string s= Console.ReadLine();
                    if(int.TryParse(s, out n))
                    {
                        break;
                    }
                    Console.Write("Число не распознано, введите снова: ");
                }
                auditories = new Auditory[n];
                Aud(0, n);
            }
            static void Aud(int value, int n)
            {
                Console.Clear();
                int[] delta = new int[n];
                for (int i = value; i < n; i++)
                {
                    Console.WriteLine();
                    Console.Write("Номер аудитории:\t");
                    int number_auditorii;
                    while(true)
                    {
                        string d = Console.ReadLine();
                        if (int.TryParse(d, out number_auditorii)&&delta.Contains(number_auditorii)==false)
                        {
                            delta[i] = number_auditorii;
                            break;
                        }
                        Console.Write("Номер не распознан или совпадает с предыдыщими, введите повторно: ");
                    }
                    if (number_auditorii <= 10 || number_auditorii >= 100)
                    {
                        while (number_auditorii <= 10 || number_auditorii >= 100)
                        {
                            Console.Write("Введите корректный номер аудитории(вторая цифра от 10 до 99):\t");
                            number_auditorii = int.Parse(Console.ReadLine());
                        }
                    }
                    Console.Write("Количество мест в аудитории: ");
                    int count;
                    while (true)
                    {
                        string d = Console.ReadLine();
                        if (int.TryParse(d, out count))
                            break;
                        Console.Write("Количество не распознано, введите повторно: ");
                    }
                    Console.Write("Наличие проектора(да/нет): ");
                    string s = "a";
                    bool proector = false;
                    bool flag = false;
                    while (flag == false)
                    {
                        s = Console.ReadLine();
                        if (s == "да" || s == "Да") { proector = true; flag = true; }
                        else if (s == "нет" || s == "Нет") { proector = false; flag = true; }
                        else
                        { flag = false; Console.Write("Введите корректные данные: "); }
                    }
                    Console.Write("Наличие компьютеров:\t");
                    string c = "d";
                    bool est_computeri = false;
                    bool flag2 = false;
                    while (flag2 == false)
                    {

                        c = Console.ReadLine();
                        if (c == "да" || c == "Да") { est_computeri = true; flag2 = true; }
                        else if (c == "нет" || c == "Нет") { est_computeri = false; flag2 = true; }
                        else
                        { flag2 = false; Console.Write("Введите корректные данные: "); }
                    }
                    auditories[i] = new Auditory(number_auditorii, count, proector, est_computeri);
                }
            }
            public static void AddAuditory()
            {
                Console.Clear();
                Console.WriteLine("ДОБАВЛЕНИЕ В БАЗУ");
                Console.WriteLine("========================");
                Console.Write("Введите количество новых аудиторий:\t");
                int len = auditories.Length;
                int k;
                while (true)
                {
                    string d = Console.ReadLine();
                    if (int.TryParse(d, out k))
                        break;
                    Console.Write("Количество не распознано, введите повторно: ");
                }
                int n = len + k;
                if (len > n)
                {
                    while (len > n)
                    {
                        Console.WriteLine("Количество аудиторий с добавленными должно быть большое текущего");
                        Console.Write("Введите корректное кол-во новых аудиторий:\t");
                        k = int.Parse(Console.ReadLine());
                        n = len + k;
                    }
                }
                Array.Resize(ref auditories, n);
                Aud(len, n);
            }
            public static void ChangeAuditory()
            {
                Console.Clear();
                Console.WriteLine("ИЗМЕНЕНИЕ ДАННЫХ ПО ЗАДАННОМУ НОМЕРУ");
                Console.WriteLine("======================================");
                int a = 1;
                while (a != 0)
                {
                    Console.Write("Cписок аудиторий:\t");
                    for (int i = 0; i < auditories.Length; i++)
                    {
                        Console.Write($"{auditories[i].number_auditorii}  ");
                    }
                    Console.WriteLine();
                    Console.Write($"Введите номер аудитории, данные которой нужно поменять:\t");
                    int num;
                    while (true)
                    {
                        string d = Console.ReadLine();
                        if (int.TryParse(d, out num))
                            break;
                        Console.Write("Номер не распознан, введите повторно: ");
                    }
                    for (int i = 0; i < auditories.Length; i++)
                    {
                        if (auditories[i].number_auditorii == num)
                        {
                            Console.WriteLine("Данные аудитории: ");
                            Print(i);
                            num = i;
                        }
                    }
                    Console.WriteLine("Если желаете поменять все данные, введите 0, если данные пункта - 1");
                    int k;
                    while (true)
                    {
                        string d = Console.ReadLine();
                        if (int.TryParse(d, out k))
                            break;
                        Console.Write("Цифра  не распознана, введите повторно: ");
                    }
                    if (k != 0 && k != 1)
                    {
                        while (k != 0 && k != 1) { Console.Write("Введите или 0 или 1:\t");
                            while (true)
                            {
                                string f = Console.ReadLine();
                                    if (int.TryParse(f, out k))
                                        break;
                                    Console.Write("Цифра не распознана, введите повторно: ");
                            }
                        }
                    }
                    if (k == 0)
                    {
                        Aud(num, num + 1);
                    }
                    while (k != 0)
                    {
                        Console.Write("Номер данных, которые хотите поменять:\t");
                        int number = int.Parse(Console.ReadLine());
                        if (number < 1 || number > 4)
                        {
                            while (number < 1 || number > 4)
                            {
                                Console.Write("Введите корректный номер:\t");
                                number = int.Parse(Console.ReadLine());
                            }
                        }
                        switch (number)
                        {
                            case 1:
                                Console.Write("Введите  номер аудитории:\t");
                                auditories[num].number_auditorii = int.Parse(Console.ReadLine());
                                if (auditories[num].number_auditorii <= 10 || auditories[num].number_auditorii >= 100)
                                {
                                    while (auditories[num].number_auditorii <= 10 || auditories[num].number_auditorii >= 100)
                                    {
                                        Console.Write("Введите корректный номер аудитории(2 цифры):\t");
                                        auditories[num].number_auditorii = int.Parse(Console.ReadLine());
                                    }
                                }
                                break;
                            case 2:
                                Console.Write("Введите кол-во мест в аудитории");
                                auditories[num].count = int.Parse(Console.ReadLine()); break;
                            case 3:
                                Console.Write("Наличие проектора(да/нет): ");
                                string s = "a";
                                auditories[num].proector = false;
                                bool flag = false;
                                while (flag == false)
                                {
                                    s = Console.ReadLine();
                                    if (s == "да" || s == "Да") { auditories[num].proector = true; flag = true; }
                                    else if (s == "нет" || s == "Нет") { auditories[num].proector = false; flag = true; }
                                    else
                                    { flag = false; Console.Write("Введите корректные данные: "); }
                                }
                                break;
                            case 4:
                                Console.Write("Наличие компьютеров:\t");
                                string c = "a";
                                auditories[num].est_computeri = false;
                                bool flag2 = false;
                                while (flag2 == false)
                                {
                                    c = Console.ReadLine();
                                    if (c == "да" || c == "Да") { auditories[num].proector = true; flag2 = true; }
                                    else if (c == "нет" || c == "Нет") { auditories[num].proector = false; flag2 = true; }
                                    else
                                    { flag2 = false; Console.Write("Введите корректные данные: "); }
                                }
                                break;

                        }
                        Console.Write("Изменение данных в текущей аудитории (0-остановить/1-продолжить)\t");
                        k = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Изменение данных в аудиториях по номеру (0-остановить/1-продолжить)\t");
                    a = int.Parse(Console.ReadLine());
                }
            }
            public static void ViborkaPC()
            {
                Console.Clear();
                Console.WriteLine("ВЫБОРКА АУДИТОРИЙ С КОМПЬЮТЕРАМИ,БОЛЬШЕ ЛИБО РАВНОМУ ЗАДАННОМУ КОЛИЧЕСТВУ МЕСТ");
                Console.WriteLine("====================================");
                int f = 1;
                while (f != 0)
                {
                    int a = 0;
                    Console.Write("Введите число для выборки:\t");
                    int b;
                    while(true)
                    {
                        string s = Console.ReadLine();
                        if (int.TryParse(s, out b))
                            break;
                        Console.Write("Число не распознано, введите повторно:\t");
                    }
                    Console.WriteLine();
                    Console.Write($"Номера аудиторий, в которых есть компьютеры и мест больше {b}:\t");
                    for (int i = 0; i < auditories.Length; i++)
                    {
                        if (auditories[i].est_computeri == true && auditories[i].count>=b)
                        {
                            Console.Write($"{auditories[i].number_auditorii}  ");
                            a++;
                        }
                    }
                    if (a == 0)
                        Console.WriteLine("Таких аудиторий нет");
                    Console.WriteLine();
                    Console.Write("0-остановить/1-продолжить");
                    f = int.Parse(Console.ReadLine());
                }

            }
            public static void ViborkaProector()
            {
                Console.Clear();
                Console.WriteLine("ВЫБОРКА АУДИТОРИЙ С ПРОЕКТОРАМИ");
                Console.WriteLine("================================");
                Console.WriteLine("Аудитории выборки:");
                int a = 0;
                for (int i = 0; i < auditories.Length; i++)
                {
                    if (auditories[i].proector == true)
                    {
                        Console.Write($"{auditories[i].number_auditorii}  ");
                        a++;
                    }
                }
                if (a == 0)
                    Console.WriteLine("Таких аудиторий нет");
                Console.ReadKey();
                Console.Clear();
            }

            public static void ViborkaCount()
            {
                Console.Clear();
                Console.WriteLine("ВЫБОРКА АУДИТОРИЙ С КОЛ-ВОМ МЕСТ БОЛЬШИМ/РАВНЫМ ЗАДАННОГО");
                Console.WriteLine("=======================================================");
                int a = 1;
                while (a != 0)
                {
                    Console.Write("Введите число для выборки\t");
                    int b = int.Parse(Console.ReadLine());
                    int g = 0;
                    Console.WriteLine($"Аудитории c количеством мест больше {b}:\t");
                    for (int i = 0; i < auditories.Length; i++)
                    {
                        if (auditories[i].count >= b)
                        {
                            Console.Write($"{auditories[i].number_auditorii}  ");
                            g++;
                        }
                    }
                    if (g == 0)
                        Console.Write("Таких аудиторий нет");
                    Console.WriteLine();
                    Console.Write("0-остановить/1-продолжить\t");
                    a = int.Parse(Console.ReadLine());
                }
            }
            
            static public void Print2()
            {
                Console.Clear();
                Console.WriteLine("ВЫВОД");
                Console.WriteLine("==========");
                for (int i = 0; i < auditories.Length; i++)
                {
                    Print(i);
                }
            }
            static public void ViborkaLevel()
            {
                Console.Clear();
                Console.WriteLine("ВЫБОРКА АУДИОРИЙ ПО НОМЕРУ ЭТАЖА");
                Console.WriteLine("==================================");
                int a = 1;
                int k;
                int b;
                while (a != 0)
                {
                    Console.Write("Введите номер этажа для выборки:\t");
                    k =int.Parse(Console.ReadLine());
                    if(k<1||k>9)
                    {
                        while(k < 1 || k > 9)
                        {
                            Console.Write("Введите корректный номер этажа:\t");
                            k=int.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine();
                    int f = 0;
                    Console.Write($"Аудитории, находящиеся на {k} этаже:\t");
                    for (int i = 0; i<auditories.Length; i++)
                    {
                        b = auditories[i].number_auditorii / 10;
                        if(k ==b)
                        {
                            f++;
                            Console.Write($"{auditories[i].number_auditorii} ");
                        }
                    }
                    if (f == 0)
                        Console.WriteLine("Таких аудиторий нет");
                    Console.WriteLine();
                    Console.Write("0-остановить/1-продолжить\t");
                    a = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}