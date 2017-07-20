public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; }
    public string Birthday { get; }

    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Birthday = birthday;
        this.Id = id;
    }
}