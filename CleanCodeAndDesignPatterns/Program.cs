
namespace CleanCodeAndDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example of a clean code function
            int result = Add(5, 10);
            Console.WriteLine($"Result of addition: {result}");
            // Example of a design pattern (Singleton)
            Singleton singletonInstance = Singleton.GetInstance();
            singletonInstance.DoSomething();
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
    // Singleton design pattern
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton() { }
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
        public void DoSomething()
        {
            Console.WriteLine("Doing something in the singleton instance.");
        }
    }
}