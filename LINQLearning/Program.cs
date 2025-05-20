using System;
using LINQLearning;

class Program
{
    // ✅ Ye ek delegate define kiya gaya hai
    // Delegate basically ek method ka reference store karne ka tariqa hota hai
    // Tum is delegate ko kisi bhi method ko call karne ke liye use kar sakte ho bina method ka naam likhe
    public delegate void TempDelegate();

    static void Main(string[] args)
    {
        // ✅ Step 1: Sirf IT department ke employees ko filter karna aur unka data print karna
        // 👉 Kab use karte hain? Jab kisi specific department ya condition pe filter lagana ho
        // 👉 Kyun use karte hain? Taake unwanted records remove ho jaayein
        // 👉 Kaise? Where() laga ke condition do, phir ToList() aur ForEach() se print karo
        DataManageSimpleData.GetSimpleEmployees()
            .Where(e => e.Department == "IT")
            .ToList()
            .ForEach(e =>
                Console.WriteLine($"Id: {e.Id}, Name: {e.FirstName} {e.LastName}," +
                $" Department: {e.Department}, Age: {e.Age}, Salary: {e.Salary}")
            );

        // ✅ Step 2: Sab employees ke sirf FirstName ko list me lena
        // 👉 Select() ka use hota hai jab specific column chahiye ho
        // 👉 ToList() eagerly data ko memory me le aata hai
        List<string> names = DataManageSimpleData.GetSimpleEmployees()
                                  .Select(e => e.FirstName)
                                  .ToList();

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        // ✅ Step 3: Same FirstNames ko IEnumerable ke zariye lena
        // 👉 IEnumerable lazy load hota hai — runtime pe data fetch hota hai
        IEnumerable<string> names2 = DataManageSimpleData.GetSimpleEmployees()
                                         .Select(e => e.FirstName);

        foreach (var name2 in names2)
        {
            Console.WriteLine(name2);
        }

        // ✅ Step 4: Unique names lana — duplicates hata kar
        // 👉 Distinct() ka use hota hai jab same naam repeat ho rahe ho
        IEnumerable<string> uniqueNames = DataManageSimpleData.GetSimpleEmployees()
                                             .Select(e => e.FirstName)
                                             .Distinct();

        foreach (var name in uniqueNames)
        {
            Console.WriteLine(name);
        }

        // ✅ Step 5: LastName ke mutabiq sort karna aur FirstName nikalna
        IEnumerable<string> orderedNames = DataManageSimpleData.GetSimpleEmployees()
                                                    .OrderBy(e => e.LastName)
                                                    .Select(e => e.FirstName)
                                                    .Distinct();

        foreach (var name in orderedNames)
        {
            Console.WriteLine(name);
        }

        // ✅ Step 6: Full employee data ko LastName ke mutabiq sort kar ke print karna
        var employees = DataManageSimpleData.GetSimpleEmployees()
                                    .OrderBy(e => e.LastName);

        foreach (var employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 7: FirstName + LastName dono pe sorting karna
        var employees2 = DataManageSimpleData.GetSimpleEmployees()
                                   .OrderBy(e => e.FirstName)
                                   .ThenBy(e => e.LastName);

        foreach (var employee in employees2)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 8: Descending sorting (Z to A)
        var employees3 = DataManageSimpleData.GetSimpleEmployees()
                                 .OrderByDescending(e => e.FirstName)
                                 .ThenByDescending(e => e.LastName);

        foreach (var employee in employees3)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 9: Age > 20 ka filter
        var employees4 = DataManageSimpleData.GetSimpleEmployees().Where(e => e.Age > 20);

        foreach (var employee in employees4)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 10: Age + Salary ka combined filter
        var employees5 = DataManageSimpleData.GetSimpleEmployees().Where(e => e.Age > 20 && e.Salary > 25000);

        foreach (var employee in employees5)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 11: First() - pehla match return karta hai, agar na mila to error
        var employees6 = DataManageSimpleData.GetSimpleEmployees().First(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        // ✅ Step 12: FirstOrDefault() - agar na mila to null deta hai
        var employees7 = DataManageSimpleData.GetSimpleEmployees().FirstOrDefault(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        // ✅ Step 13: Last() and LastOrDefault() - list ke last matching item ke liye
        var employees8 = DataManageSimpleData.GetSimpleEmployees().Last(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        var employees9 = DataManageSimpleData.GetSimpleEmployees().LastOrDefault(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        // ✅ Step 14: Single() and SingleOrDefault() - ek hi match ho to, warna error
        var employees10 = DataManageSimpleData.GetSimpleEmployees().Single(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        var employees11 = DataManageSimpleData.GetSimpleEmployees().SingleOrDefault(e => e.FirstName == "Mike" && e.LastName == "Wilson");
        Console.WriteLine(employees6.LastName + " " + employees6.FirstName);

        // ✅ Step 15: Take() - Top N records lena
        var employees12 = DataManageSimpleData.GetSimpleEmployees().Take(1000);
        foreach (var employee in employees12)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 16: Skip() - pehle N records skip karna
        var employees13 = DataManageSimpleData.GetSimpleEmployees().Skip(2);
        foreach (var employee in employees13)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        // ✅ Step 17: Some summary methods
        // Any() — agar koi ek bhi record condition pe match kare
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Any(e => e.Age > 30));

        // All() — sab records condition pe match karte ho
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().All(e => e.Age > 30));

        // Count() — matching records kitne hain
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Count(e => e.Age > 30));

        // Sum() — total salary ka sum
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Sum(e => e.Salary));

        // Average() — age ka average
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Average(e => e.Age));

        // ❌ Incorrect: Min() and Max() me boolean expression ka use nahi hota
        // ✅ Inko aise use karo:
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Min(e => e.Age));
        Console.WriteLine(DataManageSimpleData.GetSimpleEmployees().Max(e => e.Age));

        // ✅ Step 18: MinBy() and MaxBy() — sabse chhoti aur badi age wala employee
        var smallAge = DataManageSimpleData.GetSimpleEmployees().MinBy(e => e.Age);
        Console.WriteLine(smallAge.FirstName + " " + smallAge.LastName);

        var LargeAge = DataManageSimpleData.GetSimpleEmployees().MaxBy(e => e.Age);
        Console.WriteLine(LargeAge.FirstName + " " + LargeAge.LastName);
    }
}


/*
 ✅ Important Notes:
Select() → Specific field ya fields nikalta hai (projection).

Where() → Filtering karta hai based on condition.

OrderBy() → Sorting ke liye use hota hai.

ToList() → List banane ke liye hota hai (materialize karta hai).

Distinct() → Duplicate values hata deta hai.

IEnumerable<T> → Lazy loaded collection hota hai, runtime pe evaluate hota hai.

List<T> → Eager loaded hota hai, turant memory me data le aata hai.



🔍 Summary Table
Method	Use Case	Kab Use Karna Hai
Where()	Filtering	Jab specific condition ho
Select()	Specific field chahiye ho	Jab sirf kuch columns required ho
ToList()	List banani ho	Jab data memory me chahiye ho
OrderBy()	Sorting ascending	A-Z ya low to high sorting
Distinct()	Duplicate hataane ke liye	Jab unique data chahiye ho
First(), Last()	Pehla/last item chahiye ho	Jab 1st ya last matching record chahiye
Any()	Kya koi record match karta hai?	Boolean check ke liye
Count()	Kitne records match karte hain?	Counting ke liye
Sum(), Average()	Salary ya age ka analysis	Numeric calculations ke liye

*/

