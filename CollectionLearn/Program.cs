using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // =============================== //
        //        List Example             //
        // =============================== //

        // List<string> ka object banaya gya
        List<string> list = new List<string>();

        // Add() method se string list me items add kiye gaye hain
        list.Add("Hello");   // O(1)
        list.Add("Hello1");  // O(1)
        list.Add("Hello2");  // O(1)
        list.Add("Hello3");  // O(1)
        list.Add("Hello4");  // O(1)

        // Dusri list banayi "fruits" naam ki
        List<string> fruits = new List<string>();
        fruits.Add("Apple");       // O(1)
        fruits.Add("Banana");      // O(1)
        fruits.Add("Cherry");      // O(1)
        fruits.Add("Date");        // O(1)
        fruits.Add("Elderberry");  // O(1)

        // AddRange() method se ek list ki tamam values dusri list me add ki
        list.AddRange(fruits);  // O(n) => n = number of items in "fruits"

        // List me ek aur value add ki
        list.Add("Hello5");  // O(1)

        // Insert() se specific index pe value insert ki (yahan index = 0)
        list.Insert(0, "Testing Insert built of List om 0 index");  // O(n) => index 0 pe insert krne pe sari items shift hongi

        // RemoveAt() se specific index wali item remove ki (index = 3)
        list.RemoveAt(3);  // O(n) => index ke baad wali sari items shift hoti hain

        // Remove() se specific value delete ki (agar wo exist karti ho to)
        list.Remove("Hello1");  // O(n) => value dhoondhne me n items scan karne pad sakte hain

        // Contains() se check kiya ke koi value list me hai ya nahi
        if (list.Contains("Hello2"))  // O(n)
        {
            Console.WriteLine("Hello2 is in the list");
        }
        else
        {
            Console.WriteLine("Hello2 is not in the list");
        }

        // Ek aur duplicate value add ki fruits list me
        fruits.Add("Elderberry");  // O(1)

        // Foreach loop se list ke tamam elements ko print kiya
        foreach (string item in list)  // O(n)
        {
            Console.WriteLine(item);
        }

        // =============================== //
        //         Commented Code          //
        // =============================== //

        // List<string> list = new List<string>();
        // list.Add("Hello");
        // list.Add("World");
        // foreach (string item in list)
        // {
        //     Console.WriteLine(item);
        // }

        // Dictionary<string, int> dictionary = new Dictionary<string, int>();
        // dictionary.Add("One", 1);  // O(1) average case
        // dictionary.Add("Two", 2);  // O(1) average case
        // foreach (KeyValuePair<string, int> kvp in dictionary)
        // {
        //     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        // }

        // HashSet<int> hashSet = new HashSet<int>();
        // hashSet.Add(1);  // O(1)
        // hashSet.Add(2);  // O(1)
        // hashSet.Add(3);  // O(1)
        // foreach (int item in hashSet)
        // {
        //     Console.WriteLine(item);
        // }
    }
}
