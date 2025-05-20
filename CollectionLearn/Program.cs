using System.Collections;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        //Array List Example
        //ArrayList arrayList = new ArrayList();
        //  arrayList.Add(1);
        //  arrayList.Add("Hello");
        //  arrayList.Add(true);
        //  foreach(var item in arrayList)
        //  {
        //      Console.WriteLine(item);
        //  }

        //List Example
        List<string> list = new List<string>() 

        //list.Add(1);
        list.Add("Hello"); //simple way to add item at the end  in list
        list.Add("Hello1"); //complixity O*1
        list.Add("Hello2");
        list.Add("Hello3");
        list.Add("Hello4");
        //list.Add(true);

        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Cherry");
        fruits.Add("Date");
        fruits.Add("Elderberry");
       
        list.AddRange(fruits); //add list add other list items at the end of the list
        list.Add("Hello5");
        list.Insert(0, "Testing Insert built of List om 0 index");//simple way to add item at where you want , by index provide   in list //complixity O*n

        list.RemoveAt(3); //simple way to remove item at where from you  want to remove , by index provide   in list
        list.Remove("Hello1");//simple way to remove data,it will find the data and delete the first one which is finded 
        if (list.Contains("Hello2")) // that is checking that ,where data is exites are not.
        {

            Console.WriteLine("Hello2 is in the list");
        }
        else
        {
            Console.WriteLine("Hello2 is not in the list");
        }
    

            fruits.Add("Elderberry");
        foreach (string item in list)
        {
            Console.WriteLine(item);
        }


































        // List
        //List<string> list = new List<string>();
        //list.Add("Hello");
        //list.Add("World");
        //foreach (string item in list)
        //{
        //    Console.WriteLine(item);
        //}
        //// Dictionary
        //Dictionary<string, int> dictionary = new Dictionary<string, int>();
        //dictionary.Add("One", 1);
        //dictionary.Add("Two", 2);
        //foreach (KeyValuePair<string, int> kvp in dictionary)
        //{
        //    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        //}
        //// HashSet
        //HashSet<int> hashSet = new HashSet<int>();
        //hashSet.Add(1);
        //hashSet.Add(2);
        //hashSet.Add(3);
        //foreach (int item in hashSet)
        //{
        //    Console.WriteLine(item);
        //}
    }
}