


namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize an array of integers
            int[] numbers = new int [15];
                       
                Random random = new Random();
               
            
            foreach (int value in numbers)
            {
                numbers[value]= random.Next(1, 150); ;
            }
            // Print the elements of the array
            Console.WriteLine("Array elements:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            // Calculate the sum of the array elements
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"Sum of array elements: {sum}");
        }
    }
}