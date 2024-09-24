List<string> list = new();

while (true)
{
    list.Add(GenRandomStr(10000));
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
