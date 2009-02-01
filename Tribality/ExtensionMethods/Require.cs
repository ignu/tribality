using System;

namespace Tribality
{
    public static class Require
    {
        public static void A(object requiredObject)
        {
            A("item", requiredObject);
        }

        public static void A(string itemName, object requiredObject)
        {
            if (requiredObject == null)
                throw new ArgumentException("Argument is required.", itemName);
        }
    }
}