using System.Data.Common;

class Program
{
    static void Main()
    {
        List<Worker> workers = new List<Worker>
        { 
            new Worker("876974","Степан Деревнин Дмитриевич","дуло от танка",10000,50,100,"сварщик"),
            new Worker("456744","Акакий Акакиевич Акак","стеклянная посуда",45,200,20000,"стеклодув"),
            new Worker("34568765","Коркунов Николай Евгеньевич","конфеты",1000,100,10000000,"кондитер"),
            new Worker("345656","Дмитрий Анатолиевич Твикс","конфеты",150,44,50000,"кондитер"),
        };
        //определить количество работников которые получают зарплату меньше чем вырабатывают продукцию 
        var worker_min_salary = 
        from worker in workers
        where worker.price_of_unit*worker.count>worker.salary
        select worker;
        Console.WriteLine("Работники, которые получают зарплату меньше, чем вырабатывают продукцию");
        foreach (var worker in worker_min_salary)
            Console.WriteLine(worker.name);
        // количество единиц произведенной продукции по каждой категории 
         var count_of_category =
            workers.GroupBy(worker => worker.category)
            .Select(k => new
            {
                Category = k.Key,
                Count_of_category = k.Sum(i=>i.count)
            });
        Console.WriteLine("\nКоличество единиц произведённой продукции по каждой категории");
        foreach (var categoty in count_of_category)
            Console.WriteLine(categoty.Category+": "+categoty.Count_of_category);
        //суммарный денежный эквивалент произведенной продукции по всем товаром
        var volume_category =
            workers.GroupBy(worker => worker.category)
            .Select(k => new
            {
                Category = k.Key,
                Volume = k.Sum(i=>i.price_of_unit*i.count)
            });
        Console.WriteLine("\nCуммарный денежный эквивалент произведенной продукции по всем товаром");
        foreach(var volume in volume_category)
            Console.WriteLine(volume.Category+": "+volume.Volume);
        // кол-во работников которые получают больше 50 процентов от суммы производимого продукта
        var workers_50_salary = 
            from Worker in workers
            where Worker.salary>0.5*volume_category.Where(i=>Worker.category==i.Category).ToList().First().Volume
            select Worker;
        Console.Write("\nКол-во работников которые получают больше 50 процентов от суммы производимого продукта: ");
        Console.Write(workers_50_salary.ToList().Count+"\n");
        foreach (var worker in workers_50_salary)
            Console.WriteLine(worker.name);
    }
}
class Worker
{
    public string tabel_number;
    public string name;
    public string category;
    public int count;
    public int price_of_unit;
    public int salary;
    public string quality;
    public Worker(string tabel_number, string name, string category, int count, int price_of_unit, int salary, string quality)
    {
        this.tabel_number = tabel_number;
        this.name = name;
        this.category = category;
        this.count = count;
        this.price_of_unit = price_of_unit;
        this.salary = salary;
        this.quality = quality;
    }
}