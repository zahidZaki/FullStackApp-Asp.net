using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionHelper
{
    public static class ExtensionHepler
    {
        public static void PrintElements<T>(this List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintAllConcatenated<T>(this List<T> list)
        {
            // Har item ke baad ek space add hoti hai, string.Join items ko combine karta hai
            Console.WriteLine(string.Join(" ", list));
        }
        public static void DoSomeThing(this IPrint print)
        {
            Console.WriteLine("Do some thing");
        }



    }
    public interface IPrint
    {
        
    }
    public class Print : IPrint
    {
        public void PrintAll()
        {
            Console.WriteLine("Print all");
        }
    }
    public class Print1 : IPrint
    {
        public void PrintAll()
        {
            Console.WriteLine("Print all");
        }
    }
}
