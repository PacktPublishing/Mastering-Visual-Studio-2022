// See https://aka.ms/new-console-template for more information

LeakObject leaky = new()
{
    List = []
};


while (true)
{
    leaky.List.Add(GenRandomStr(10000));
    Thread.Sleep(1);
}


static string GenRandomStr(int length)
{
    Random rnd = new();
    var chars = new List<char>();

    for (var i = 0; i < length; i++)
    {
        var a = (char)rnd.Next(65, 122);
        chars.Add(a);
    }

    return string.Concat(chars);
}


public class LeakObject
{
    public List<string> List {  get; set; }
}