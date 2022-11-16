// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

ECommerceDbContext db = new ECommerceDbContext();
GenerateDefaultProducts();

Console.WriteLine("1 - Menù clienti");
Console.WriteLine("2 - Menù dipendente");
Console.WriteLine("9 - Esci");
int clientOrEmployeeMenu = Convert.ToInt32(Console.ReadLine());


bool programma = true;

//switch(programma)



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