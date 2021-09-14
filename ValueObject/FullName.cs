using System;

namespace ValueObject
{
    public class FullName : IEquatable<FullName>
    {
        public FullName(Name firstName, Name lastName)
        {
            if (firstName == null) throw new ArgumentNullException();
            if (lastName == null) throw new ArgumentNullException();
            FirstName = firstName;
            LastName = lastName;
        }

        public Name LastName { get; set; }

        public Name FirstName { get; set; }


        public bool Equals(FullName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName)
                   && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullName) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^
                       (LastName != null ? LastName.GetHashCode() : 0);
            }
        }
    }
}