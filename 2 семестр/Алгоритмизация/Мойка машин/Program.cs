using System.Threading.Channels;

public delegate void Clean(Cars car);
class Garage
{
    public List<Cars> cars = new List<Cars>();
    public void Add_car(Cars car)
    {
        cars.Add(car);
    }
    public void Cleaning_Car_All(Clean clean)
    {
        Cleaning clean_car= new Cleaning();
        foreach (Cars car in cars)
            clean_car.cleaning_cars(clean, car);
    }
}
public class Cars
{
    public string name;
    public string number;
    public Cars(string name, string number)
    {
        this.name = name;
        this.number = number;
    }
}
class Program
{
    static void Main()
    {
        Garage cars = new Garage();
        cars.Add_car(new Cars("BMW","tu788ro"));
        cars.Add_car(new Cars("AUDI", "gr675bs"));
        cars.Add_car(new Cars("LADA", "kj222poi"));
        cars.Add_car(new Cars("Ferrari", "tu538ro"));
        cars.Cleaning_Car_All(car=>Console.WriteLine(car.name+" "+car.number + ": помыта"));
    }
}
class Cleaning
{
    public void cleaning_cars(Clean clean,Cars car)
    {
        clean(car);
    }
}
