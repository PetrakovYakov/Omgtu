using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
class Menu
{
    static Array array = new object[10] { "Hello", "world", "3456744", "OmGTU", "develop", "Algoritmisation", "math", "3456", "77775", "world" };
    static ArrayList arrayList = new ArrayList() { "Hello", "world", "3456744", "OmGTU", "develop", "Algoritmisation", "math", "3456", "77775", "world" };
    static SortedList sortedList = new SortedList();
    public void Start()
    {
        bool flag = true;
        while (flag == true)
        {
            Console.WriteLine("МЕНЮ\n1)Действия с Array\n2)Действия с ArrayList\n3)Действия с SortedList\n4)ВЫХОД");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: Activity_Array(); break;
                case 2: Activity_ArrayList(); break;
                case 3: Activity_SortedList(); break;
                case 4: flag = false; break;
            }
        }
    }
    public void Activity_Array()
    {
        Console.Clear();
        bool flag = true;
        while (flag == true)
        {
            Console.WriteLine("Действия с Array\n1)Count\n2)BinSearch\n3)Copy\n4)Find\n5)FindLast\n6)IndexOf\n7)Reverse\n8)Resize\n9)Sort\n10)Вывод массива\n11)Выход");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: Count_array(); break;
                case 2: BinSearch_array(); break;
                case 3: Copy_array(); break;
                case 4: Find_array(); break;
                case 5: FindLast_array(); break;
                case 6: IndexOF_array(); break;
                case 7: Reverse_array(); break;
                case 8: Resize_array(); break;
                case 9: Sort_array(); break;
                case 10: Print_array(array); break;
                case 11: flag = false; break;

            }
        }
    }
    static void Count_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Count");
        string[] arr = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            arr[i] = Convert.ToString(array.GetValue(i));
        }
        Print_array(array);
        while (true)
        {
            Console.WriteLine();
            Console.Write("Введите объект, количество которого в массиве хотите узнать: ");
            var obj = Console.ReadLine();
            var count = arr.Count(n => n == obj);
            Console.WriteLine($"Количество заданного объекта:{count}");
            Console.Write("введите end для завершения метода/любой символ для продолжения: ");
            if (Console.ReadLine() == "end") break;
        }
    }
    public void BinSearch_array()
    {
        Console.Clear();
        Console.WriteLine("Метод BinarySearch");
        string[] arr = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
            arr[i] = Convert.ToString(array.GetValue(i));
        Array.Sort(arr);
        while (true)
        {
            Console.WriteLine();
            Console.Write("Отсортированный массив: ");
            Print_array(arr);
            Console.WriteLine();
            Console.Write("Введите искомый элемент: ");
            object find_el = Console.ReadLine();
            int i = Array.BinarySearch(arr, find_el);
            if (i < 0)
                Console.WriteLine("Элемент не найден");
            else
                Console.WriteLine($"Индекс найденного элемента {i} ");
            Console.WriteLine();
            Console.Write("Для остановки введите end/для продолжения любой символ: ");
            if (Console.ReadLine() == "end")
                break;
        }
    }
    public void Copy_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Copy");
        while (true)
        {
            Console.WriteLine("Полученный массив будет иметь 4 элемента");
            Array arr_copy = new object[4];
            Console.WriteLine();
            Console.Write("копирование с 1 элемента(1)/копирование с определённого индекса(2)) ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введите кол-во копируемых элементов: "); int d = int.Parse(Console.ReadLine());
                    if (d > arr_copy.Length)
                    {
                        Console.WriteLine("Копирование невозможно");
                        break;
                    }
                    Array.Copy(array, arr_copy, d); Console.WriteLine(); Console.Write("Изменённый массив: "); Print_array(arr_copy); break;
                case 2:
                    Console.Write("Введите диапозон копируемых элементов через пробел(индекс источника |кол-во копируемых элементов| индекс назначения : ");
                    string[] s = Console.ReadLine().Split(' ');
                    if (int.Parse(s[1]) > arr_copy.Length || (int.Parse(s[0]) + int.Parse(s[1])) > array.Length || (int.Parse(s[1]) + int.Parse(s[2]) > arr_copy.Length))
                    {
                        Console.WriteLine("Копирование элементов невозможно"); break;
                    }
                    Array.Copy(array, int.Parse(s[0]), arr_copy, int.Parse(s[2]), int.Parse(s[1]));
                    Console.WriteLine(); Console.Write("Изменённый массив: "); Print_array(arr_copy); break;
            }
            Console.Write("Для завершения метода Copy введите end/для продолжения любой символ: ");
            if (Console.ReadLine() == "end")
                break;
        }

    }
    static void Print_array(Array array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array.GetValue(i) == null)
                Console.Write("- ");
            else
                Console.Write($"{array.GetValue(i)} ");
        }
    }
    public void Find_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Find(в данной программе выдаёт объект, длина которого больше 3)");
        string[] arr = new string[array.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToString(array.GetValue(i));
        }
        var index = Array.Find(arr, obj => obj.Length > 3);
        Console.WriteLine($"первый элемент длиной больше 3: {index}");
    }
    public void FindLast_array()
    {
        Console.Clear();
        Console.WriteLine("Метод FindLast(в данной программе выдаёт последний элемент, чья длина больше заданной)");
        string[] arr = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            arr[i] = Convert.ToString(array.GetValue(i));
        }
        while (true)
        {
            Console.Write("Введите длину для сравнения: ");
            int find_el = int.Parse(Console.ReadLine());
            var obj = Array.FindLast(arr, i => i.Length > find_el);
            Console.WriteLine($"последний элемент длиной больше {find_el}: {obj}");
            Console.WriteLine();
            Console.Write("Для выхода из метода введите end/для продолжения любой символ: ");
            if (Console.ReadLine() == "end")
                break;
        }
    }
    public void IndexOF_array()
    {
        Console.Clear();
        Console.WriteLine("Метод IndexOf");
        while (true)
        {
            Console.WriteLine("индекс первого вхождения с первого элемента(1)/индекс первого вхождения в диапозоне(2)");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine();
                        Console.Write("Введите элемент, индекс первого вхождения которого хотите узнать: ");
                        var find_el = Console.ReadLine();
                        int index = Array.IndexOf(array, find_el);
                        if (index < 0)
                            Console.WriteLine("Элемент не обнаружен");
                        else
                        {
                            Console.WriteLine($"индекс первого вхождения элмента {find_el}: {index}");
                            Console.WriteLine();
                        }
                        Console.Write("Для выхода из метода введите end/для продолжения любой символ: ");
                        if (Console.ReadLine() == "end")
                            break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine();
                        Console.Write("введите диапозон поиска и элемент (начальный индекс|кол-во элементов в диапозоне|элемент): ");
                        string[] s = Console.ReadLine().Split(' ');
                        int index = Array.IndexOf(array, s[2], int.Parse(s[0]), int.Parse(s[1]));
                        if (index < 0)
                            Console.WriteLine("Элемент не обнаружен");
                        else
                        {
                            Console.WriteLine($"индекс первого вхождения элмента {s[2]}: {index}");
                            Console.WriteLine();
                        }
                        Console.Write("Для выхода из метода введите end/для продолжения любой символ: ");
                        if (Console.ReadLine() == "end")
                            break;
                    }
                    break;
            }
            Console.Write("Для выхода из метода введите end/для продолжения любой символ: ");
            if (Console.ReadLine() == "end")
                break;
        }
    }
    public void Reverse_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Reverse");
        Console.WriteLine();
        Console.Write("начальная последовательность элементов: ");
        Print_array(array);
        Console.WriteLine();
        Array.Reverse(array);
        Console.Write("изменённая последовательность элементов: ");
        Print_array(array);
        Console.WriteLine();
    }
    public void Resize_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Resize");
        Console.WriteLine();
        Console.Write("введите новый размер массива: ");
        int size = int.Parse(Console.ReadLine()); Console.WriteLine(); Console.Write("Начальный вид массива: ");
        Print_array(array);
        Console.WriteLine();
        array = Resize1(array, size);
        Console.Write("Изменённый вид массива: ");
        Print_array(array);
        Console.WriteLine();
    }
    public object[] Resize1(Array array, int size)
    {
        object[] myArr = new object[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            myArr[i] = array.GetValue(i);
        }
        Array.Resize(ref myArr, size);
        return myArr;
    }
    public void Sort_array()
    {
        Console.Clear();
        Console.WriteLine("Метод Sort");
        Array.Sort(array);
        Console.WriteLine();
        Console.Write("Отсортированный массив: ");
        Print_array(array);

    }
    public void Activity_ArrayList()
    {
        Console.Clear();
        bool flag = true;
        while (flag == true)
        {
            Console.WriteLine("Действия с ArrayList\n1)Count\n2)BinSearch\n3)Copy\n4)IndexOf\n5)Insert\n6)Reverse\n7)Sort\n8)Вывод коллекции\n9)Add\n10)Выход");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: Console.WriteLine($"количество элементов в массиве: {arrayList.Count}"); break;
                case 2: BinarySearch_arrayList(); break;
                case 3: Copy(); break;
                case 4: IndexOf(); break;
                case 5: Insert(); break;
                case 6: Reverse_arrayList(); break;
                case 7: Sort(); break;
                case 8: Print_arrayList(arrayList); break;
                case 9: Add(); break;
                case 10: flag = false; break;
            }
        }
    }
    static void BinarySearch_arrayList()
    {
        Console.Clear();
        Console.WriteLine("Метод BinarySearch");
        arrayList.Sort();
        Console.Write("Отсортированный массив: ");
        Print_arrayList(arrayList);
        Console.Write("Введите элемент для поиска: ");
        var el = Console.ReadLine();
        int index = arrayList.BinarySearch(el);
        if (index < 0)
            Console.WriteLine("Элемент не найден");
        else
            Console.WriteLine($"индекс элемента {el}: {index}");
        Console.WriteLine();
    }
    static void Copy()
    {
        Console.Clear();
        Console.WriteLine("Метод Copy");
        int count = arrayList.Count;
        string[] array_copy = new string[count + 5];
        Console.Write("Элементы копируемой коллекции: ");
        Print_arrayList(arrayList);
        Console.WriteLine("в результате выдастся массив c 15 элементами");
        Console.Write("копирование с 1 элемента(1)/копирование с определённого индекса(2))");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                arrayList.CopyTo(array_copy); Console.WriteLine(); Console.Write("Изменённый массив: "); Print_array(array_copy); break;
            case 2:
                Console.Write("Введите диапозон копируемых элементов через пробел(индекс начала |индекс назначения| кол-во копируемых элементов: )");
                string[] s = Console.ReadLine().Split(' ');
                arrayList.CopyTo(int.Parse(s[0]), array_copy, int.Parse(s[1]), int.Parse(s[2]));
                Console.WriteLine(); Console.Write("Изменённый массив: "); Print_array(array_copy); break;
        }
    }
    static void Print_arrayList(ArrayList array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] == null)
                Console.Write("-");
            else
                Console.Write($"{array[i]} ");
        }
    }
    static void IndexOf()
    {
        Console.Clear();
        Console.WriteLine("Метод IndexOf");
        Console.Write("Элементы коллекции: ");
        Print_arrayList(arrayList);
        Console.Write("Введите объект, индекс первого вхождения которого хотите узнать: ");
        var value = Console.ReadLine();
        int index = arrayList.IndexOf(value);
        if (index == -1)
            Console.WriteLine("Элемент не обнаружен");
        else
            Console.WriteLine($"индекc первого вхождения {value}: {index}");
    }
    static void Insert()
    {
        Console.Clear();
        Console.WriteLine("Метод Insert");
        Console.Write("Элементы вызывающей коллекции: ");
        Print_arrayList(arrayList);
        ArrayList arr_insert = new ArrayList() { "class", "Program", "0987", "object", "string" };
        Console.Write("Элементы копируемой коллекции: ");
        Print_arrayList(arr_insert);
        Console.Write($"Введите индекс коллекции c которого происходит вставление элментов: ");
        int index = int.Parse(Console.ReadLine());
        arr_insert.InsertRange(index, arrayList);
        Print_arrayList(arr_insert);
    }
    static void Reverse_arrayList()
    {
        Console.Clear();
        Console.WriteLine("Метод Reverse");
        Console.Write("Исходный порядок элементов коллекиции: ");
        Print_arrayList(arrayList);
        arrayList.Reverse();
        Console.WriteLine();
        Console.Write("Изменённый порядок элементов коллекции после Reverse: ");
        Print_arrayList(arrayList);
    }
    static void Sort()
    {
        Console.Clear();
        Console.WriteLine("Метод Sort");
        Console.Write("Элементы коллекции: ");
        Print_arrayList(arrayList);
        arrayList.Sort();
        Console.WriteLine();
        Console.Write("Элементы коллекции после сортировки: ");
        Print_arrayList(arrayList);
    }
    static void Add()
    {
        Console.WriteLine("Добавление элементов");
        Console.WriteLine("для остановки введите end");
        while (true)
        {
            var obj = Console.ReadLine();
            if (obj == "end")
                break;
            arrayList.Add(obj);
        }
    }
    static void Activity_SortedList()
    {
        Console.Clear();
        Console.WriteLine();
        bool flag = true;
        while (flag == true)
        {
            Console.WriteLine("Действия с SortedList\n1)Add\n2)IndexOf\n3)вывод ключа по индексу\n4)вывод значения по индексу\n5)Вывод\n6)Выход");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: Sort_Add(); break;
                case 2: Sort_IndexOf(); break;
                case 3: Output_Key(); break;
                case 4: Output_Value(); break;
                case 5: Print_SortedList(); break;
                case 6: flag = false; break;
            }
        }
    }
    static void Sort_Add()
    {
        Console.Clear();
        Console.WriteLine("Add");
        Console.WriteLine("Для остановки введите end");
        Console.WriteLine("Ключ|значение (через пробел)");
        while (true)
        {
            string[] s = Console.ReadLine().Split(' ');
            if (s[0] == "end")
                break;
            string key = s[0];
            string value = s[1];
            sortedList.Add(key, value);
        }
    }
    static void Sort_IndexOf()
    {
        Console.Clear();
        Console.WriteLine("IndexOf");
        Console.WriteLine("Получение индекса по ключу");
        ICollection keys = sortedList.Keys;
        foreach(var c in keys)
        { Console.WriteLine($"{c}: {sortedList.IndexOfKey(c)}"); }
        Console.WriteLine("Получение индекса по значению");
        foreach(var c in keys)
        { Console.WriteLine($"{sortedList[c]}: {sortedList.IndexOfValue(sortedList[c])}"); }
    }
    static void Output_Key()
    {
        Console.Clear();
        Console.WriteLine("Вывод ключа по индексу");
        Console.Write("Введите индекс: ");
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine($"индексу {index} соответсвует ключ: {sortedList.GetKey(index)}");
    }
    static void Output_Value()
    {
        Console.Clear() ;
        Console.WriteLine("Вывод занчения по индексу");
        Console.WriteLine("Введите индекс: ");
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine($"индексу {index} соотвествует значение: {sortedList.GetByIndex(index)}");
    }
    static void Print_SortedList()
    {
        Console.Clear();
        ICollection keys = sortedList.Keys;
        Console.WriteLine("Ключ - Значение");
        foreach (var s in keys)
        {
            Console.WriteLine($"{s} - {sortedList[s]}");
        }
    }
}
class Programm
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.Start();
    }
}