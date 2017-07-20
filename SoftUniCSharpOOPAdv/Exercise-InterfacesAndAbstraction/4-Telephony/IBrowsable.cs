using System.Collections.Generic;

public interface IBrowsable
{
  
    ICollection <string> Urls {get;}
    string Browse(string url);
}
