//// See https://aka.ms/new-console-template for more information

using Simple_E_Commerce_Cart_System;

//All_in_One a = new All_in_One();

//a.Name = "Manoj";
//a.Age = 4;


//a.Display();


//PartTime pt = new PartTime();
//pt.Name = "manpj";
//pt.Salery = 1200;
//pt.Age = 14;
//pt.DisplaySalery();

time t = new time();
t.DisplayDate();


//PartTime a = new PartTime();
//while (true)
//{
//    Console.WriteLine("====== Just for practise ======");
//    Console.WriteLine("1. add employee name");
//    Console.WriteLine("2. add age");
//    Console.WriteLine("3. display");
//    Console.WriteLine("4. Exit");
//    Console.Write("Enter choice: ");

//    int choice;
//    if (!int.TryParse(Console.ReadLine(), out choice))
//    {
//        Console.WriteLine("Invalid input. Try again.\n");
//        continue;
//    }

//    if (choice == 1)
//    {
//        Console.Write("Enter name of person: ");
//        a.Name = Console.ReadLine();
//    }
//    else if (choice == 2)
//    {
//        Console.Write("Enter age of person: ");
//        a.Age = int.Parse(Console.ReadLine());
//    }
//    else if (choice == 3)
//    {
//        a.DisplaySalery();   
//    }
//    else if (choice == 4)
//    {
//        break;
//    }
//}




//using Simple_E_Commerce_Cart_System;

//Console.WriteLine("Hello, World!");

//while (true)
//{
//    Console.WriteLine("====== Simple E-Commerce System (No Cart) ======");
//    Console.WriteLine("1. Create Clothing");
//    Console.WriteLine("2. Create Grocery");
//    Console.WriteLine("3. Exit");
//    Console.Write("Enter choice: ");

//    int choice;
//    if (!int.TryParse(Console.ReadLine(), out choice))
//    {
//        Console.WriteLine("Invalid input. Try again.\n");
//        continue;
//    }

//    if (choice == 3)
//    {
//        Console.WriteLine("Goodbye!");
//        break;
//    }

//    Product p = null;

//    if (choice == 1)
//    {
//        Clothing c = new Clothing();

//        Console.Write("Enter Product ID: ");
//        c.Id = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Enter Product Name: ");
//        c.Name = Console.ReadLine();

//        Console.Write("Enter Base Price: ");
//        c.BasePrice = Convert.ToSingle(Console.ReadLine());



//        p = c; // polymorphism: store as Product
//    }
//    else if (choice == 2)
//    {
//        Grocery g = new Grocery();

//        Console.Write("Enter Product ID: ");
//        g.Id = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Enter Product Name: ");
//        g.Name = Console.ReadLine();

//        Console.Write("Enter Base Price: ");
//        g.BasePrice = Convert.ToSingle(Console.ReadLine());

//        Console.Write("Enter Expiry Date (e.g., 2026-03-10): ");
//        g.ExpiryDate = DateTime.Parse(Console.ReadLine());

//        p = g; 
//    }
//    else
//    {
//        Console.WriteLine("Invalid choice!\n");
//        continue;
//    }

//    Console.Write("Enter Quantity: ");
//    int qty = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("\n----- PRODUCT DETAILS -----");
//    p.Display();

//    float total = p.CalculateFinalPrice(qty);
//    Console.WriteLine($"Total Price (with tax) for {qty} item(s): {total}\n");
//}

