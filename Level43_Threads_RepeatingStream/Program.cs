// See https://aka.ms/new-console-template for more information

var numbers = new RecentNumbers();
var running = new Thread(numbers.Running);
var check = new Thread(numbers.CheckNumbers);
running.Start();
check.Start('x');

running.Join();
check.Join();


internal class RecentNumbers
{
    private object _recentObjects = new object();
    private readonly object _numberLock = new object();
    private List<int> _recentNumList = new List<int>() { 0, 0 };
    private bool _startStop = true;

    private int FirstNumber { get; set; }
    private int SecondNumber { get; set; }


    private void RecentTwo(int n)
    {
        lock (_numberLock)
        {
            _recentNumList.Add(n);
            _recentNumList = _recentNumList.GetRange(_recentNumList.Count - 2, 2);
            _recentObjects = _recentNumList;
        }

        var recentObjects = (List<int>)_recentObjects;
        FirstNumber = recentObjects[0];
        SecondNumber = recentObjects[1];
    }

    internal void Running()
    {
        var rnd = new Random();
        while (_startStop)
        {
            var n = rnd.Next(0, 9);
            RecentTwo(n);
            Console.WriteLine($"recent two numbers: {FirstNumber}, {SecondNumber}");
            Thread.Sleep(1000);
        }
    }

    internal void CheckNumbers(object? o)
    {
        while (true)
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key != (char)(o ?? throw new ArgumentNullException(nameof(o)))) continue;
            if (FirstNumber == SecondNumber)
            {
                Console.WriteLine("good!");
                break;
            }

            Console.WriteLine("bad!");
            break;
        }

        _startStop = false;
    }
}