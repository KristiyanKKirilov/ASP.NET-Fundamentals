Task<long> task = Task.Run(() =>
{
    long sum = 0;
    for (int i = 0; i < 10; i++)
    {
        sum += i;
    }

    return sum;
});

Console.WriteLine(task.Result);
