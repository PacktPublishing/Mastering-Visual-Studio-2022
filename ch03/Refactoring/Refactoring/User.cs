namespace Refactoring
{
    public class User
    {
        public static bool canregister(int age)
        {
            if (age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
