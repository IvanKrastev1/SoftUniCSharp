 public class Citizen : IBeing
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Citizen(string name, int age,string id)
        {
            Id = id;
            Name = name;
            Age = age;
        }

    }
