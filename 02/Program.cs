using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        var submarine = ParseFile(); ;
        Console.WriteLine($"Submarine total: {submarine.GetTotalPart2()}");
        Console.Write($"Aim: {submarine.Position.Aim} | Depth : {submarine.Position.Depth} | Horizontal: {submarine.Position.Horizontal}");
    }

    private static Submarine ParseFile()
    {
        var submarine = new Submarine();
        var file = "input/input2.txt";
        var commands = File.ReadAllLines(file);
        foreach (var command in commands)
        {
            var commandContent = command.Split(" ");
            var direction = commandContent[0];
            var value = int.Parse(commandContent[1]);
            switch (direction)
            {
                case "forward":
                    submarine.Forward(value);
                    break;
                case "up":
                    submarine.Up(value);
                    break;
                case "down":
                    submarine.Down(value);
                    break;
            }

            Console.WriteLine($"Command: {command} | Position: {submarine.Position.ToString()}");
        }

        return submarine;
    }
}


public class Submarine
{
    public Position Position { get; }

    public Submarine()
    {
        Position = new Position();
    }
    
    public void Forward(int value)
    {
        Position.Horizontal += value;
        Position.Depth += value * Position.Aim;
    }
    
    public void Up(int value)
    {
        Position.Aim -= value;
    }
    
    public void Down(int value)
    {
        Position.Aim += value;
    }

    public long GetTotalPart2()
    {
        return Position.Depth * Position.Horizontal;
    }

    public long GetTotalPart1()
    {
        return Position.Aim * Position.Horizontal;
    }
}

public class Position
{
    public long Aim { get; set; }
    public long Horizontal { get; set; }
    public long Depth { get; set; }

    public Position()
    {
        Horizontal = 0;
        Aim = 0;
    }

    public override string ToString()
    {
        return $"Aim:  {Aim} | Depth: {Depth} |  Horizontal: {Horizontal}";
    }
}

