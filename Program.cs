// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


ECommerceDbContext db = new ECommerceDbContext();
GenerateDefaultProducts();
GenerateDefaultEmployees();
GenerateDefaultCustomers();




bool programma = true;

while (programma)
{
    Console.WriteLine("1 - Menù clienti");
    Console.WriteLine("2 - Menù dipendente");
    Console.WriteLine("9 - Esci");

    int clientOrEmployeeMenu = Convert.ToInt32(Console.ReadLine());

    switch (clientOrEmployeeMenu)
    {
        case 1:
            Console.WriteLine("Benvenuto nel nostro store");
            break;
        case 2:
            bool employeeMenu = true;
            while (employeeMenu)
            {
                Console.WriteLine("1 - Creazione nuovo ordine");
                Console.WriteLine("9 - Esci");

                int employeeMenuAnswer = Convert.ToInt32(Console.ReadLine());

                switch (employeeMenuAnswer)
                {
                    case 1:
                        AddNewOrder();
                        break;
                    case 9:
                        employeeMenu = false;
                        break;
                    default:
                        Console.WriteLine("Digitare un'operazione valida!");
                        break;
                }
            }
            break;
        case 9:
            programma = false;
            break;
        default:
            Console.WriteLine("Digitare un'operazione valida!");
            break;
    }
}

void GenerateDefaultCustomers()
{
    bool CheckDefaultCustomers = db.Customers.Any();
    if (CheckDefaultCustomers)
    {
        Console.WriteLine("Registro clienti connesso");
    }
    else
    {
        Customer customer1 = new Customer() { Name = "Germano", Surname = "Mosconi", Email = "mosconi@email.it" };
        Customer customer2 = new Customer() { Name = "Francesco", Surname = "Totti", Email = "totti@email.it" };

        db.Customers.Add(customer1);
        db.Customers.Add(customer2);

        db.SaveChanges();
        Console.WriteLine("Nuovi clienti registrati");
    }
}
void GenerateDefaultEmployees()
{
    bool CheckDefaultEmployees = db.Employees.Any();
    if (CheckDefaultEmployees)
    {
        Console.WriteLine("Dipendenti connessi allo store");
    }
    else
    {
        Employee employee1 = new Employee() { Name = "Roberto", Surname = "Giacomuzzo" };
        Employee employee2 = new Employee() { Name = "Ciccio", Surname = "Pasticcio" };

        db.Employees.Add(employee1);
        db.Employees.Add(employee2);

        db.SaveChanges();
        Console.WriteLine("Nuovi dipendenti registrati");
    }
}
void GenerateDefaultProducts()
{
    bool CheckDefaultProducts = db.Products.Any();
    if (CheckDefaultProducts)
    {
        Console.WriteLine("Connesso allo store prodotti");
    }
    else
    {
        Product goatSimulator = new Product() { Name = "Goat Simulator 3", Description = "Un simulatore di capre", Price = 29.99 };
        Product spidermanMorales = new Product() { Name = "Spiderman Miles Morales ", Description = "Ennesimo gioco di spiderman", Price = 49.99 };
        Product rumbleverse = new Product() { Name = "Rumbleverse", Description = "Uno smash bros tarocco", Price = 10.99 };
        Product deadSpace = new Product() { Name = "Dead Space", Description = "Horror fantascientifico classicone", Price = 59.99 };
        Product rocketLeague = new Product() { Name = "Rocket League", Description = "Macchine, razzi e calcio", Price = 19.99 };
        Product assassinCreed = new Product() { Name = "Assassin Creed - Valhalla", Description = "Sei un assassino vichingo biondo e ubriaco", Price = 19.79 };
        Product gta = new Product() { Name = "Grand Theft Auto V ", Description = "Il gioco che non uscirà mai dallo store", Price = 29.99 };
        Product hogwarts = new Product() { Name = "Hogwarts Legacy", Description = "Il gioco del secolo di Harry Potter..forse", Price = 59.99 };
        Product fifa = new Product() { Name = "Fifa 23", Description = "Il gioco di calcio", Price = 69.99 };
        Product godOfWar = new Product() { Name = "God of War", Description = "Sangue e botte", Price = 49.99 };

        db.Products.Add(goatSimulator);
        db.Products.Add(spidermanMorales);
        db.Products.Add(rumbleverse);
        db.Products.Add(deadSpace);
        db.Products.Add(rocketLeague);
        db.Products.Add(assassinCreed);
        db.Products.Add(gta);
        db.Products.Add(hogwarts);
        db.Products.Add(fifa);
        db.Products.Add(godOfWar);

        db.SaveChanges();
    } 
}
void AddNewOrder()
{
    Console.Write("Digita il tuo ID dipendente: ");
    int employeeId = Convert.ToInt32(Console.ReadLine());
    Employee employee = db.Employees.Where(employee => employee.Id == employeeId).First();

    Console.Write("Quanti prodotti vuoi inserire nell'ordine?: ");
    int numberOfProducts = Convert.ToInt32(Console.ReadLine());

    List<Product> productsBundle = new List<Product>();
    double amountBundle = 0;

    for(int i = 0; i < numberOfProducts; i++)
    {
        Console.Write("Digitare ID prodotto: ");
        int productIdToSearch = Convert.ToInt32(Console.ReadLine());

        Product productToInsert = db.Products.Where(product => product.Id == productIdToSearch).First();

        amountBundle += productToInsert.Price;

        productsBundle.Add(productToInsert);
    }

    
    Order newOrder = new Order() { Date = DateTime.Now, Amount = amountBundle, Status = true, CustomerId = null, EmployeeId = employee.Id, Products = productsBundle };
    db.Orders.Add(newOrder);
    db.SaveChanges();
    Console.WriteLine("Ordine aggiunto!");
}