using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dictionary<int, string> ka object banaya jismein key = int, value = string
        Dictionary<int, string> dict = new Dictionary<int, string>();

        // .Add(key, value) method se values add ki
        dict.Add(0, "Hello");       // O(1) average case
        dict.Add(1, "Bottle");      // O(1)
        dict.Add(2, "Computer");    // O(1)
        dict.Add(3, "Office");      // O(1)
        dict.Add(4, "Laptop");      // O(1)
        dict.Add(15, "Bike");       // O(1)

        // .Remove(key) => specific key se value remove karta hai
        dict.Remove(3); // O(1)

        // .ContainsKey(key) => check karta hai ke key exist karti hai ya nahi
        if (dict.ContainsKey(3))  // O(1)
        {
            Console.WriteLine("Key 3 exists");
        }
        else
        {
            Console.WriteLine("Key 3 does not exist");
        }

        // .ContainsValue(value) => check karta hai ke koi value exist karti hai ya nahi
        if (dict.ContainsValue("Bike"))  // O(n), because values scan hoti hain
        {
            Console.WriteLine("Value Bike exists");
        }
        else
        {
            Console.WriteLine("Value Bike does not exist");
        }

        // .TryGetValue(key, out value) => safe way hai kisi key ka value nikalne ka
        if (dict.TryGetValue(2, out string value))  // O(1)
        {
            Console.WriteLine($"Key 2 exists with value: {value}");
        }
        else
        {
            Console.WriteLine("Key 2 does not exist");
        }

        // dict[key] = value => agar key exist karti hai to update, warna new add
        dict[6] = "Bottle";  // O(1)

        // foreach loop => dictionary ke sare key-value pairs ko print karta hai
        foreach (var a in dict)  // O(n)
        {
            Console.WriteLine(a);  // Output format: [Key, Value]
        }

        /*
         
        | Operation                     | Explanation                                           | Time Complexity |
| ----------------------------- | ----------------------------------------------------- | --------------- |
| `Add(key, value)`             | Nayi key-value pair dictionary me add karta hai       | O(1)            |
| `Remove(key)`                 | Specific key wali entry hata deta hai                 | O(1)            |
| `ContainsKey(key)`            | Check karta hai ke key exist karti hai ya nahi        | O(1)            |
| `ContainsValue(value)`        | Check karta hai ke koi value exist karti hai ya nahi  | O(n)            |
| `TryGetValue(key, out value)` | Safe way se value get karta hai without exception     | O(1)            |
| `dict[key] = value`           | Agar key hai to update, warna new value set karta hai | O(1)            |
| `foreach (var item in dict)`  | Sab key-value pairs ko loop karta hai                 | O(n)            |

         
         */
    }
}
