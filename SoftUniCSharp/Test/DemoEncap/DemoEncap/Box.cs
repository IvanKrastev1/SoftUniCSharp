
using System;

public class Box
    {
       private double lenght;
       private double width;
       private double height;


    public Box(double lenght,double width,double height)    
    {
        this.Lenght = lenght;
        this.Height = height;
        this.Width = width;
    }
   

    private double Lenght
    {
        
        set {

            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Lenght)} cannot be zero or negative.");
            }
            this.lenght = value;
        }
    }

    private double Width
    {

        set
        {

            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    private double Height
    {

        set
        {

            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            this.height = value;
        }
    }






    public double GetSurfaceArea()
    {
        return 2 * this.lenght * this.width + 2 * lenght * height + 2 * this.width * this.height;
    }
    public double GetLateralSurfaceArea()
    {
        return 2 * lenght * height + 2 * this.width * this.height;
    }

    public double GetVolume()
    {
        return this.lenght * this.height * this.width;
    }

    
}

