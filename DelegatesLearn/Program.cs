using System;
using static Program;

class Program
{
    public delegate void TempDelegate();
    static void Main(string[] args)
    {

        PrintPageDelegate printDel = PrintPage;






    }


    private static void PrintPage()
    {
        Console.WriteLine("Page printed.");
    }


}

public class TempTest()
{
    public static void TempMethod(TempDelegate tempDelegate)
    {
        tempDelegate();
    }
}
