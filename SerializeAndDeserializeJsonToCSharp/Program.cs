// System aur JSON serialization ke liye required namespaces include kiye gaye hain
using System;
using System.Text.Json;

// Program class start hoti hai - ye main entry point hai application ka
class Program
{
    // Main method - jab program chalta hai to sabse pehle ye run hoti hai
    static void Main(string[] args)
    {
        // Yahan ek Product object banaya gaya hai aur uske properties set ki gayi hain
        var product = new Product
        {
            Id = 1,                                // Product ki ID set ki
            Name = "Laptop",                       // Product ka naam diya
            Price = 999.99m,                       // Product ki price decimal mein
            IsAvailable = true,                    // Availability true rakhi (matlab available hai)
            CreatedDate = DateTime.Now             // Current date & time set kiya gaya
        };

        // Console par product object ka custom string representation print kiya ja raha hai
        Console.WriteLine("Original Product Object:");
        Console.WriteLine(product.ObjToString()); // ObjToString() ka use karke readable format mein print

        // Product object ko JSON format mein serialize kiya ja raha hai
        string jsonFormatted = SerializeProduct(product);
        Console.WriteLine("\nSerialized JSON:");
        Console.WriteLine(jsonFormatted); // Serialized JSON console par print kiya

        // Serialized JSON ko dobara Product object mein convert (deserialize) kiya ja raha hai
        var deserializedProduct = DeserializeProduct(jsonFormatted);

        // Console par deserialized object print kiya ja raha hai
        Console.WriteLine("\nDeserialized Product:");
        if (deserializedProduct != null)
        {
            // Agar object null nahi to custom format mein print karo
            Console.WriteLine(deserializedProduct.ObjToString());
        }
        else
        {
            // Agar deserialization fail ho jae to error message do
            Console.WriteLine("Deserialization failed.");
        }
    }

    // Method jo product object ko JSON string mein convert karta hai (serialization)
    static string SerializeProduct(Product product)
    {
        // JSON ko ache readable format mein likhne ke liye options define kiye gaye hain
        var options = new JsonSerializerOptions
        {
            WriteIndented = true // JSON mein indentation ayega taake readable ho
        };
        // Object ko JSON string mein convert karte hain
        return JsonSerializer.Serialize(product, options);
    }

    // Method jo JSON string ko wapas Product object mein convert karta hai (deserialization)
    static Product? DeserializeProduct(string json)
    {
        // JSON string ko deserialize karke Product object return karta hai
        return JsonSerializer.Deserialize<Product>(json);
    }
}

// Product class define ki gayi hai jisme product ki properties hain
public class Product
{
    public int Id { get; set; }                      // Product ki unique ID
    public string Name { get; set; } = string.Empty; // Product ka naam (default empty string rakhi)
    public decimal Price { get; set; }               // Product ki price (decimal data type)
    public bool IsAvailable { get; set; }            // Availability status (true ya false)
    public DateTime CreatedDate { get; set; }        // Kab product create hua (date/time)

    // Ye method object ko ek readable string format mein return karta hai
    public string ObjToString()
    {
        // Har property ko nayi line mein print karta hai taake readable ho
        return $"Id: {Id}, \nName: {Name}, \nPrice: {Price}, \nIsAvailable: {IsAvailable}, \nCreatedDate: {CreatedDate}";
    }
}
