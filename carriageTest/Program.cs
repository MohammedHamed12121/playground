Console.WriteLine("Progress.....");

for (int i = 0; i < 100; i++)
{
    System.Threading.Thread.Sleep(100);
    Console.Write($"\rProgress: {i}%");
}
Console.WriteLine("\nDone");