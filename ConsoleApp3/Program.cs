using System;

[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
    public void OnMethodExecuted(Action methodToExecute)
    {
        DateTime startTime = DateTime.Now;
        methodToExecute();
        DateTime endTime = DateTime.Now;

        TimeSpan elapsedTime = endTime - startTime;
        Console.WriteLine($"Метод {methodToExecute.Method.Name} выполнен за {elapsedTime.TotalMilliseconds} мс");
    }
}

public class ExampleClass
{
    [LogExecutionTime]
    public void SlowMethod()
    {
        Thread.Sleep(2000);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExampleClass example = new ExampleClass();
        example.SlowMethod();
    }
}