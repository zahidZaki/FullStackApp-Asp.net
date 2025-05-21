using System;

class Program
{
    //// Pehla scope banaya
    //Scope scope1 = new Scope();

    //// Dusra scope banaya
    //Scope scope2 = new Scope();

    //// Transient usage – har request par naya object
    //Console.WriteLine("🔁 Transient Instances:");
    //    Console.WriteLine(scope1.TransientProvider.GetSample().ID);
    //    Console.WriteLine(scope1.TransientProvider.GetSample().ID);
    //    Console.WriteLine(scope2.TransientProvider.GetSample().ID);
    //    Console.WriteLine(scope2.TransientProvider.GetSample().ID);

    //    // Scoped usage – har scope mein ek hi object
    //    Console.WriteLine("\n🔷 Scoped Instances:");
    //    Console.WriteLine(scope1.ScopeProvider.GetSample().ID);
    //    Console.WriteLine(scope1.ScopeProvider.GetSample().ID);
    //    Console.WriteLine(scope2.ScopeProvider.GetSample().ID);
    //    Console.WriteLine(scope2.ScopeProvider.GetSample().ID);

    //    // Singleton usage – sabhi scopes mein ek hi object
    //    Console.WriteLine("\n🔒 Singleton Instances:");
    //    Console.WriteLine(scope1.SingletonProvider.GetSample().ID);
    //    Console.WriteLine(scope1.SingletonProvider.GetSample().ID);
    //    Console.WriteLine(scope2.SingletonProvider.GetSample().ID);
    //    Console.WriteLine(scope2.SingletonProvider.GetSample().ID);
    static void Main(string[] args)
    {
        // Pehla scope banaya
        Scope scope1 = new Scope();
        // Dusra scope banaya
        Scope scope2 = new Scope();

        // Scope1 se 2 transient services liye
        SampleService sampleService1a = scope1.TransientProvider.GetSample();
        SampleService sampleService1b = scope1.TransientProvider.GetSample();

        // Scope2 se 2 transient services liye
        SampleService sampleService2a = scope2.TransientProvider.GetSample();
        SampleService sampleService2b = scope2.TransientProvider.GetSample();

        // Har service ka unique ID print karenge
        Console.WriteLine($"Scope1 - Service A: {sampleService1a.ID}");
        Console.WriteLine($"Scope1 - Service B: {sampleService1b.ID}");
        Console.WriteLine($"Scope2 - Service A: {sampleService2a.ID}");
        Console.WriteLine($"Scope2 - Service B: {sampleService2b.ID}");
    }
}

// Service class jo har object ko unique ID assign karti hai
class SampleService
{
    public Guid ID { get; } = Guid.NewGuid(); // Har instance ka unique identifier
}

// Transient provider jo naya service object return karta hai
class TransientProvider
{
    public SampleService GetSample()
    {
        return new SampleService(); // Hamesha naya object return karta hai
    }
}

// Scope class jo apna TransientProvider hold karti hai
class Scope
{
    public TransientProvider TransientProvider { get; } = new TransientProvider();
}
