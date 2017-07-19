public class Seat : ICar
    {
        public Seat(string model, string color)
        {
           this.Model = model;
           this.Color = color;
        }
        public string Model { get; }
        public string Color { get; }
        public string Start()
        {
            return "Engine Start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
