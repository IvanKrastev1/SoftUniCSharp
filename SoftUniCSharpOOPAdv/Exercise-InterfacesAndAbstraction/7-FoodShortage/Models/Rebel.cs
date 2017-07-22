using _7_FoodShortage.Interfaces;

public class Rebel : IGroupable, IBeing, IBuyer
{
    public string GroupName { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Food { get; set; }

    public Rebel(string name, int age, string groupName)
    {
        GroupName = groupName;
        Name = name;
        Age = age;
        Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}