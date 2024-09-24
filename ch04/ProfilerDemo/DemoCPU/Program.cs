

using DemoCPU;

Task[] timers = new Task[10];

for(int i = 0; i < timers.Length; i++)
{
    int j = i;
    timers[i] = new Task(() => FindPrimes(i,j*9999999));
}

foreach(Task task in timers)
{
    task.Start();
}

await Task.WhenAll(timers);

Console.WriteLine("Timer has finished");

static void FindPrimes(int i, int j)
{
    ConsumeCPU.FindPrimes(i, j);
}