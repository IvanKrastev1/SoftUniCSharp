public class Ferrari : ICar
{
    public string Model { get; set; }
    private string driver;

    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string Driver
    {
        get { return this.driver; }
        set { this.driver = value; }
    }

    public string PushBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }
}