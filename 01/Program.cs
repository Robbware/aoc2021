public class Program
{
    public static void Main(string[] args)
    {
        var input = "../../../input.txt";
        var reportedValues = GetInputSlidingWindow(input);
        var report = GetReport(reportedValues);
        Console.WriteLine($"Total reported values: {report.TotalValues} | Increased values: {report.TotalIncreasedValues} | Decreased values: {report.TotalDecreasedValues}");
    }

    private static Report GetReport(IEnumerable<int> reportedValues)
    {
        var report = new Report();
        
        foreach (var value in reportedValues)
        {
            var message = $"{value} ";
            if (report.PreviousValue == Int32.MinValue)
            {
                message += "(N/A) - no previous measurement)";
            }
            else if (value > report.PreviousValue)
            {
                message += $"(increased)";
                report.TotalIncreasedValues++;
            }
            else if (value < report.PreviousValue)
            {
                message += $"(decreased)";
                report.TotalDecreasedValues++;
            }
            else
            {
                message += $"(same value)";
            }

            report.PreviousValue = value;
            report.TotalValues++;
            
            Console.WriteLine(message);
        }

        return report;
    }

    private static IEnumerable<int> GetInput(string file)
    {
        var inputList = new List<int>();
        var input = File.ReadAllLines(file);
        foreach (var line in input)
        {
            inputList.Add(Int32.Parse(line));
        }

        return inputList;
    }

    private static IEnumerable<int> GetInputSlidingWindow(string file)
    {
        var inputList = new List<int>();
        var input = File.ReadAllLines(file);
        var valuesArray = new Queue<int>();
        foreach (var line in input)
        {
            if (valuesArray.Count == 3)
            {
                inputList.Add(valuesArray.Sum());
                valuesArray.Dequeue();
            }

            var value = int.Parse(line);
            valuesArray.Enqueue(value);
        }
        inputList.Add(valuesArray.Sum());
        return inputList;
    }

    public class Report
    {
        public int PreviousValue { get; set; }
        public int TotalIncreasedValues { get; set; }
        public int TotalDecreasedValues { get; set; }
        public int TotalValues { get; set; }

        public Report()
        {
            PreviousValue = Int32.MinValue;
        }
    }
}