using System.Collections;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    { 
          
        Dictionary<int,string> dict = new Dictionary<int,string>();
        dict.Add(0,"Hello");
        dict.Add(1,"Bottle");
        dict.Add(2,"Computer");
        dict.Add(3,"Office");
        dict.Add(4,"Laptop");//simply add value
        dict.Add(15,"Bike");
        dict.Remove(3); //simply remove value
        if (dict.ContainsKey(3)) //simply check that we have that key or not //complixity O*1
        {
            Console.WriteLine("Key 3 exists");
        }
        else
        {
            Console.WriteLine("Key 3 does not exist");
        }
        if (dict.ContainsValue("Bike")) //simply check that we have that data or not //complixity O*n
        {
            Console.WriteLine("Value Bike exists");
        }
        else
        {
            Console.WriteLine("Value Bike does not exist");
        }
        if (dict.TryGetValue(2, out string value)) //simply find the data according to key
        {
            Console.WriteLine($"Key 2 exists with value: {value}");
        }
        else
        {
            Console.WriteLine("Key 2 does not exist");
        }
        dict[6] = "Bottle"; //if key exists then add otherwise update the value according to key
        foreach (var a in dict)
        {
            Console.WriteLine(a);
        }












    }
}
