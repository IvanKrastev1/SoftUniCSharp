using _7_FoodShortage.Interfaces;

public class Citizen : IBeing, IBirthable, IBuyer
{
    public string Id { get; private set; }
    public string Birthday { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Food { get; set; }

    public Citizen(string name, int age, string id, string birthday)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthday = birthday;
        Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }
}