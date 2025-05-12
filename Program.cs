
public class Program
{
    static object _locker = new object();
    static int Max = 10;
    static List<int> ints = new List<int>();
    static List<int> result = new List<int>();  
    static Random random = new Random();

    public static void Main()
    {
        Thread thread1 = new Thread(Producer);
        Thread thread2 = new Thread(Consumer);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        foreach (int i in result)
        {
            Console.WriteLine(i);
        }
    }

    public static void Producer()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (_locker)
            {

                while (ints.Count > 0)
                {
                    Monitor.Wait(_locker);
                }

                Console.WriteLine("Producer is adding numbers");
                for (int j = 0; j < Max; j++)
                {
                    int num = random.Next(100);
                    ints.Add(num);
                    Thread.Sleep(1000);
                    Console.Write(" " + num + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Producer added numbers");
                Monitor.Pulse(_locker);
            }

        }
    }

    public static void Consumer()
    {
        for (int i = 0; i < 5; i++)
        {
          lock (_locker)
            {
                if(ints.Count < Max)
                {
                    Monitor.Wait(_locker);

                }

                int sum = ints.Sum();
                result.Add(sum);
                Console.WriteLine($"The sum is {sum}");

                ints.Clear();
                Monitor.Pulse(_locker);
            }
           
        }
    }
}

