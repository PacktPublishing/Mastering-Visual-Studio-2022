using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCPU;
public class ConsumeCPU
{

    /**
     * Calculates the factorial of a given number.
     *
     * @param number The number to calculate the factorial of.
     * @return The factorial of the given number.
     */
    public static long Multiply(int number)
    {
        long result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    /**
     * Calculates the sum of all numbers from 1 to the given number.
     *
     * @param number The number to calculate the sum up to.
     * @return The sum of all numbers from 1 to the given number.
     */
    public static long Sum(int number)
    {
        long sum = 0;
        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }
        return sum;
    }


    public static void FindPrimes(int start, int end)
    {
        List<int> primes = [];
        for (int number = start; number <= end; number++)
        {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
        }
    }

    /**
     * Checks if a number is prime.
     *
     * @param number The number to check.
     * @return True if the number is prime, false otherwise.
     */
    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}

