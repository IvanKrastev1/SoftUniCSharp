﻿public class Robot : IBeing, INameble
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public Robot(string name, string id)
    {
        Id = id;
        Name = name;
    }

    
}