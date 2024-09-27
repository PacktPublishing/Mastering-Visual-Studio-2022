
using System.ComponentModel;
using System.Data.SqlTypes;

namespace Sandbox.Core
{
    public class User
    {
        public User()
        {
        }

        public bool ValidateMail(string email)
        {
            return email.Contains('@') &&
                !email.EndsWith('@') &&
                email.Contains('.') &&
                !email.EndsWith('.') &&
                !email.Contains("@.");

        }

        private int Do(int a, bool b)
        {
            if (a > 0)
            {
                if (b)
                {
                    if (a == 42)
                    {
                        return -1;
                    }
                    return 1;
                }

                return 2;
            }

            return 0;
        }
    }
}