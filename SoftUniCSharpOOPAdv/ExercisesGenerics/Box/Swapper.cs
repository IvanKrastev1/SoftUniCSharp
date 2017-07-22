using System.Collections.Generic;
public  class Swapper
{
    public static void Swap<T>(List<Box<T>> listOfBoxes, int index1, int index2)
    {
        Box<T> tempElement = listOfBoxes[index1];
        listOfBoxes[index1] = listOfBoxes[index2];
        listOfBoxes[index2] = tempElement;
    }

}
