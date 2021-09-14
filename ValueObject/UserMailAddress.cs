using System;

namespace ValueObject
{
    public class UserMailAddress
    {
        public readonly string Value;

        public UserMailAddress(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            this.Value = value;
        }
    }
}