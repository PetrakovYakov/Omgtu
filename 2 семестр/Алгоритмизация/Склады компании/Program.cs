class Product
{
   public string article;
   public string name;
   public string category;
   public int count;
   public int prise_of_unit;
   public string store;
   public Product(string article, string name, string category, int count, int prise_of_unit, string store) 
    { 
        this.article = article;
        this.name = name;
        this.category = category;
        this.count = count;
        this.prise_of_unit = prise_of_unit;
        this.store = store;
    }
}
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("445663","Тетради 64 листа","Канцелярия",100,45,"Склад 23, ул. пионерский переулок, д.18"),
            new Product("3456765", "Шариковая ручка","Канцелярия",2000, 30,"Склад 23, ул. пионерский переулок, д.18"),
            new Product("448790","Тетради 64 листа","Канцелярия",402,52,"Склад 488, ул. степная, д.24"),
            new Product("345655","Пенал","Канцелярия",47,200,"Склад 488, ул. степная, д.24"),
            new Product("34556790","Тетради 64 листа","Канцелярия",1000,49,"Склад 221, ул. светлая, д.6"),
            new Product("3455456","Пенал","Канцелярия",100,150,"Склад 221, ул. светлая, д.6"),
            new Product("567654","Пылесос Dyson, 2000Вт","Бытовая техника",33,7500,"Склад 23, ул. пионерский переулок, д.18"),
            new Product("3457654567","Пылесос Dyson, 2000Вт","Бытовая техника",90,6800,"Склад 488, ул. степная, д.24"),
            new Product("2345676543","Пылесос Dyson, 2000Вт","Бытовая техника",120,6333,"Склад 221, ул. светлая, д.6")

        };
        //объём товара в денежном эквиваленте на каждом складе
        var product_volume =
            products.Select(k => new
            {
                name_of_product = k.name,
                shop_of_product = k.store,
                volume = k.prise_of_unit * k.count
            });
        Console.WriteLine("склад\tпродукт\tобъём");
        foreach (var product in product_volume )
            Console.WriteLine($"{product.shop_of_product} {product.name_of_product} {product.volume}");
        //максимальная цена товара по каждой категории(для каждого склада)
        var max_price_of_kategory =
             products.GroupBy(k => k.store)
             .Select(i => new
             {
                 Name_store = i.Key,
                 max_price_kategory = i.GroupBy(j=>j.category)
                 .Select(h => new 
                 {
                     category = h.Key,
                     max_price = h.Max(l=>l.prise_of_unit)
                 })
             }).ToList();
        foreach(var store in max_price_of_kategory)
        {
            Console.Write("\n"+store.Name_store+" ");
            foreach (var product in store.max_price_kategory)
            {
                Console.Write(product.category + " " + product.max_price + " ");
            }
        }
       
        //средняя цена товаров по каждой категории
        var avverage_price_of_category =
            products.GroupBy(k => k.category)
            .Select(j => new
            {
                Category = j.Key,
                avverage_price_of_product = j.GroupBy(k => k.name)
                .Select(k => new
                {
                    Name = k.Key,
                    avverage_price = k.Average(i=>i.prise_of_unit)
                })
            }).ToList();
        Console.WriteLine();
        foreach (var category in avverage_price_of_category)
        {
            Console.WriteLine("\n"+category.Category+"\n");
            foreach (var product in category.avverage_price_of_product)
            {
                Console.Write("Средняя цена товара " + product.Name + ": " + product.avverage_price+"\n");
            }
        }
        //самый дешёвый товар по каждому складу 
        var most_cheap_product_on_store =
            products.GroupBy(k => k.store).
            Select(s => new
            {
                Name = s.Key,
                most_cheap_product_price = s.OrderBy(i=>i.prise_of_unit).First(),
            }).ToList();
        Console.WriteLine();
        foreach (var min_price in most_cheap_product_on_store)
            Console.WriteLine(min_price.Name+" | "+min_price.most_cheap_product_price.name+" | "+min_price.most_cheap_product_price.prise_of_unit);
        //общее количество товаров по категории
        var count_products_of_category =
            products.GroupBy(k => k.store)
            .Select(j => new
            {
                Name = j.Key,
                category_count = j.GroupBy(h => h.category).Select(h => new
                {
                    Category = h.Key,
                    count_product = h.Sum(i=>i.count)
                })
            }).ToList();
        Console.WriteLine();
        foreach(var store in count_products_of_category)
        {
            Console.WriteLine("\n"+store.Name);
            foreach (var category in store.category_count)
            {
                Console.Write(category.Category + ": " + category.count_product+" ");
            }
        }

    }
}
