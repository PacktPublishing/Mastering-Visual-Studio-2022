namespace Sandbox.Net6;

public class SampleClass
{

    public bool CheckNumber(int number)
    {
        if (number > 0 && number < 6)
        {
            return true;
        }

        return false;
    }

    public bool HasEvenValue(int? value)
    {
        if (value.HasValue)
        {
            return IsEven(value.Value);
        }
        else
        {
            return false;
        }
    }

    public bool IsEven(int value)
    {
        return value % 2 == 0;
    }
}
