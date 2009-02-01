using System;

namespace Tribality
{
    public static class Check
    {
        public static void NotNull(object argument, string message)
        {
            if (argument == null)
                throw new ArgumentNullException(message);
        }

        public static void NotNull(object argument, string message, string parameter)
        {
            if (argument == null)
                throw new ArgumentNullException(message, parameter);
        }
    }
}
