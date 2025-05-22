


namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implicit conversion
            int intValue = 42;
            double doubleValue = intValue; // int to double
            Console.WriteLine($"Implicit conversion: {intValue} to {doubleValue}");
            // Explicit conversion (casting)
            double anotherDoubleValue = 42.5;
            int anotherIntValue = (int)anotherDoubleValue; // double to int
            Console.WriteLine($"Explicit conversion: {anotherDoubleValue} to {anotherIntValue}");
            // Using Convert class
            string stringValue = "123";
            int convertedIntValue = Convert.ToInt32(stringValue); // string to int
            Console.WriteLine($"Convert class: {stringValue} to {convertedIntValue}");


        }
    }
}