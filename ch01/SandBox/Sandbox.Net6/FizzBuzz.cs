namespace kata;

public class FizzBuzz
{
    public static string[] GenerateOutput(int maxNumber)
    {
        String[] result = new String[maxNumber];
        for (int i = 1; i <= maxNumber; i++)
        {
            result[i - 1] = GetValue(i);
        }
        return result;
    }

    private static String GetValue(int i)
    {
        if (i % 15 == 0)
            return "FizzBuzz";
        else if (i % 3 == 0)
            return "Fizz";
        else if (i % 5 == 0)
            return "Buzz";

        return i.ToString();
    }
}




