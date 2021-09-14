using System;
using System.Text.RegularExpressions;

namespace ValueObject
{
    public class Name : IEquatable<Name>
    {
        public readonly string Value;

        public Name(string value)
        {
            if (value == null) throw new ArgumentNullException();
            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$")) throw new ArgumentException("許可されていない文字が使われています。", nameof(value));
            this.Value = value;
        }

        public bool Equals(Name other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Name) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Value.GetHashCode();
            }
        }
    }
}