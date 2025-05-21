using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLearing.Application
{
    public class TestClas
    {
        public void test() { 
        // ⚠️ Yeh lines class ke andar likhi hain lekin kisi method ke andar nahi — C# mein yeh error dega.
        // Yeh sari logic hamesha kisi method (like Main or custom method) ke andar honi chahiye.
        int a = 55;
        int b = 66;
        string ab = "55";
        string ba = "66";

        Console.WriteLine($"Before swap: a = {ab}, b = {ba}");
        swap<String>(ref ab, ref ba); // Generic method ko string type ke sath call kiya
        Console.WriteLine($"After swap: a = {ab}, b = {ba}");

        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        swap<int>(ref a, ref b); // Generic method ko int type ke sath call kiya
        Console.WriteLine($"After swap: a = {a}, b = {b}");

        // ✅ Strongly typed list: sirf int values le sakti hai
        List<int> numbers = new List<int>();
        numbers.Add(1);
        //numbers.Add("2"); // ❌ Error aayega: string ko int list mein add nahi kar sakte

        // ✅ ArrayList: kisi bhi type ka data le sakti hai
        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);     // int
        arrayList.Add("2");   // string
        arrayList.Add(3.5);   // double

        // ⚠️ ArrayList object type hoti hai, isliye jab access karte hain to cast karna padta hai
        //int sum = arrayList[0]; // ❌ Error: implicit conversion not allowed
        int sum2 = (int)arrayList[0]; // ✅ Cast kiya int mein: correct
        }

        // ✅ Generic Method: Kisi bhi type ke values ko swap karne ke liye
        public static void swap<T>(ref T a, ref T b)
        {
            // Swap two values of any type
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
