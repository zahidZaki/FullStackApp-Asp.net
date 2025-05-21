
public static class ExtensionHepler
{
    public static void PrintElements<T>(this List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}