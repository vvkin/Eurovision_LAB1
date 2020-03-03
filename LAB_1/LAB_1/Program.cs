namespace LAB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Type the name of input directory");
            Worker newWorker = new Worker(System.Console.ReadLine());
            newWorker.PrintWinnersList();
        }
    }
}
