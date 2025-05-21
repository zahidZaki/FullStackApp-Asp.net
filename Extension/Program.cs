
using ExtensionHelper;

class Program
{
    static void Main(string[] args)
    { 
    List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.PrintElements<int>();
        ExtensionHepler.PrintElements<int>(list);
        IPrint print = new Print();
        print.DoSomeThing();


    }
   

}
