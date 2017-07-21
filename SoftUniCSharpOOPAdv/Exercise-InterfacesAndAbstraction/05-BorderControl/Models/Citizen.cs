 using System;

public class Citizen : IBeing,IBirthable,INameble
    {

        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public string Name { get; private set; }

    public Citizen(string name, int age,string id,string birthday)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthday;
        }

       
    }
