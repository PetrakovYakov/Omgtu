using System.ComponentModel;

class Program
{
    static void Main()
    {
        List<Customers> customers = new List<Customers>
        {
            new Customers("674357","Иван Петрович Чичиков", 4560, 3500, 345),
            new Customers("632578","Плюшкин Никита Сергеевич",5500,5600,400),
            new Customers("345673","Акакий Акакиевич Акак",6245,5000,450),
            new Customers("555673","Пушкин Александр Сергеевич",2267,3000,100),
            new Customers("446720","Кокошкин Семён Семёнович",4490,2000,258),
            new Customers("883893","Иванов Иван Иванович",7000,7590,501)
        };
        //кол-во клиентов с отр балансом 
        var customers_with_negative_balance =
            from custom in customers
            where custom.incom - custom.expenditure < 0
            select custom;
        Console.WriteLine("Кол-во клиентов с отрицательным балансом: "+customers_with_negative_balance.ToList().Count);
        //клиент с самым большим балансом
        var customer_with_max_balance =
            from custom in customers
            orderby custom.incom - custom.expenditure - custom.taxes
            select custom;
            //customers.OrderBy(i=>i.incom-i.expenditure-i.taxes).Last();
        Console.WriteLine("Клиент с самым большим балансом с учётом уплаты налогов: "+customer_with_max_balance.Last().name+", Баланс с учётом выплаты налога: "+(customer_with_max_balance.Last().incom-customer_with_max_balance.Last().expenditure-customer_with_max_balance.Last().taxes));
        //средний доход по счетам с отрицательным балансом
        var average_incom = customers_with_negative_balance.Average(i=>i.incom);
        Console.WriteLine("Средний доход по счетам с отрицательным балансом: " + average_incom);
        //Суммарная сумма налогов со всех клиентов
        var sum_taxes =
            customers.Sum(i=>i.taxes);
        Console.WriteLine("Суммарная сумма налогов со всех клиентов: " + sum_taxes);
    }
}
class Customers
{
    public string number_of_score;
    public string name;
    public int incom;
    public int expenditure;
    public int taxes;
    public Customers(string number_of_score, string name, int incom, int expenditure, int taxes)
    {
        this.number_of_score = number_of_score;
        this.name = name;
        this.incom = incom;
        this.expenditure = expenditure;
        this.taxes = taxes;
    }
}