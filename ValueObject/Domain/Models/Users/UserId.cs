using System;

namespace ValueObject
{
    public class UserId
    {
        public readonly string Value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            this.Value = value;
        }
    }
}