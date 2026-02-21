public class All_in_One
{
    public int ID { get; set; }

    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public void Display()
    {
        Console.WriteLine("Name of person: " + name);
        Console.WriteLine("Age of person: " + age);
    }
}