using System.Collections;
using System.Collections.Generic;
using System;
using System.IO; // File aur Directory operations k liye zaroori hai

class Program
{
    static void Main(string[] args)
    {
        // Ye file aur destination folders ke paths define kiye gaye hain
        string filePath = @"C:\Users\Zahid Gul\Downloads\FileHandingLearning";
        string destinationPath = @"C:\Users\Zahid Gul\Downloads\FileHandingLearning1\";

        var dir = new DirectoryInfo(filePath); // File directory ka object banaya

        // Saare subdirectories print karo
        foreach (var file in dir.GetDirectories())
        {
            Console.WriteLine(file.Name); // Sirf subfolder ka naam print hoga
        }

        // Is block se hum filePath directory ke andar jitni bhi files hain unke names print kar rahe hain (subfolders samait)
        foreach (var file in Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories))
        {
            Console.WriteLine(Path.GetFileName(file)); // File name print hoga
        }

        // Ye bhi files ko print karta hai lekin DirectoryInfo object ka use karke
        foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories))
        {
            Console.WriteLine(file.Name);
        }

        // Ye block same hai, lekin comment kiya gaya hai
        foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories))
        {
            // Ye commented lines kaam karte agar uncomment karo:
            Console.WriteLine(Path.GetFullPath(file.FullName)); // Full path print karta
            Console.WriteLine(Path.GetFileNameWithoutExtension(file.FullName)); // File name without extension
            Console.WriteLine(Path.GetDirectoryName(file.FullName)); // Directory ka path
        }

        // Ye block har file ka naam aur size (bytes mein) print karta hai
        foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories))
        {
            var info = new FileInfo(file.FullName);
            Console.WriteLine($"File Name: {info.Name}" + "  file size  =" + info.Length);
        }

        // Check kar rahe ho ke directory exist karti hai ya nahi
        if (dir.Exists)
        {
            Console.WriteLine("Directory exists");
            foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                var info = new FileInfo(file.FullName);
                Console.WriteLine($"File Name: {info.Name}" + "  file size  =" + info.Length);
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist");
        }

        // Agar directory exist nahi karti to ye usay create karega (redundant agar already exist karti hai)
        Directory.CreateDirectory(filePath);
        Directory.CreateDirectory(destinationPath);

        // Ye block files ko ek directory se doosri directory mein copy karta hai
        foreach (var file in Directory.GetFiles(filePath))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Copy(file, destFile, true); // Overwrite = true
        }

        // Ye same files ko copy nahi balkay move kar raha hai (pehli wali jagah se hata ke nayi jagah)
        foreach (var file in Directory.GetFiles(filePath))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Move(file, destFile, true); // Overwrite = true
        }

        // Ye bhi wahi move karne ka block hai, repeat ho gaya hai (extra)
        foreach (var file in Directory.GetFiles(filePath))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Move(file, destFile, true);
        }

        // Ye loop har file ko copy karta hai aur naye naam ke sath (e.g., file0abc.txt)
        string[] PAthArray = Directory.GetFiles(filePath);
        for (int i = 0; i < PAthArray.Length; i++)
        {
            string? file = PAthArray[i];
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Copy(file, destFile + i + "abc.txt");
        }

        // Ye loop files ko move karta hai naye naam ke sath (e.g., file0abc.txt)
        string[] PAthArray2 = Directory.GetFiles(filePath);
        for (int i = 0; i < PAthArray.Length; i++)
        {
            string? file = PAthArray[i];
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Move(file, destFile + i + "abc.txt", true);
        }

        // File write, append, read operations
        string sourcePath1 = @"C:\Users\Zahid Gul\Downloads\FileHandingLearning1\test.txt";
        string destinationPath1 = @"C:\Users\Zahid Gul\Downloads\FileHandingLearning";

        var dire = new DirectoryInfo(sourcePath1); // Not needed in this context

        // File.WriteAllText: pehli baar likhta hai, agar file already ho to overwrite kar deta hai
        File.WriteAllText(sourcePath1, "Writing from code from C# code  Salam dear how are you");

        // File.AppendAllText: file mein text add karta hai bina overwrite kiye
        File.AppendAllText(sourcePath1, "\nbhai ye b add hoga ab Writing from code from C# code  Salam dear how are you");

        // File.ReadAllText: file ka poora content read karta hai
        var data = File.ReadAllText(sourcePath1);
        Console.WriteLine(data);

        Console.WriteLine("Code run successfully.");
        /*
         
        ✅ Key Concepts Recap (Roman Urdu):
        Directory.GetFiles → sari files le aata hai.

        File.Copy → file ko copy karta hai ek jagah se doosri jagah.

        File.Move → file ko move karta hai (copy + delete original).

        File.WriteAllText → file mein likhta hai (overwrite karta hai).

        File.AppendAllText → existing file mein text add karta hai.

        File.ReadAllText → file ka data read karke string mein return karta hai.

        Directory.CreateDirectory → folder create karta hai agar exist nahi karta.

         */


    }
}
