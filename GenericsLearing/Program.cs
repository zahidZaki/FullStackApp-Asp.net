using System.Collections;
using System.Collections.Generic;

// Apne custom namespaces include kiye jahan se Book model aur GenericStore class aayi hain
using GenericsLearing.Application.Models;  // Book class yahan defined hogi
using GenericsLearing.Application.Stores;  // GenericStore class yahan defined hogi

class Program
{
    static void Main(string[] args)
    {
        // Step 1: GenericStore ka object banaya
        // GenericStore<TProduct, TKey>
        // Yahan TProduct = Book, TKey = int
        GenericStore<Book, int> store = new GenericStore<Book, int>();

        // Step 2: Ek Book ka object create kiya
        Book FourtyRuleOfLove = new Book();
        FourtyRuleOfLove.Name = "Fourty Rule Of Love";
        FourtyRuleOfLove.Description = "A book about love";
        FourtyRuleOfLove.Publisher = "Application";
        FourtyRuleOfLove.ISBN = "123456789";
        FourtyRuleOfLove.AuthorName = "Elif Shafak";

        // Step 3: store mein Book add ki uski key = 1 rakhi
        store.AddProduct(FourtyRuleOfLove, 1); // yeh method GenericStore class mein hoga

        // Step 4: Ek aur book object banake usi method se add kiya, this time key = 2
        store.AddProduct(new Book()
        {
            Name = "Fourty Rule Of Love",
            Description = "A book about love",
            Publisher = "Application",
            ISBN = "123456789",
            AuthorName = "Elif Shafak"
        }, 2);
    }
}

/*
 🧠 Generic Classes Kya Hoti Hain aur Kyun Use Karte Hain?
✅ Definition:
Generic classes ya methods woh hoti hain jismein data type ko dynamically
specify kiya jata hai jab object create karte ho.
 | Fayda                | Detail                                                              |
| -------------------- | ------------------------------------------------------------------- |
| **Code Reusability** | Har bar alag-alag product type ke liye class likhne ki zarurat nahi |
| **Type Safety**      | Compile-time par hi errors detect ho jate hain                      |
| **Performance**      | Boxing/unboxing avoid hoti hai (especially with value types)        |
| **Maintainability**  | Code easy to manage hota hai                                        |

📘 Real-life Example Use Cases:
| Scenario              | Generic Use                       |
| --------------------- | --------------------------------- |
| Book Store            | `GenericStore<Book, int>`         |
| Product Store         | `GenericStore<Product, Guid>`     |
| Student Record System | `GenericStore<Student, string>`   |
| API Repository        | `GenericRepository<TEntity, TId>` |

 
 
 
 
 */
