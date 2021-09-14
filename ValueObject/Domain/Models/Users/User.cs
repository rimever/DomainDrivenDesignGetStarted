using System;

namespace ValueObject
{
    public class User
    {
        public UserId Id { get; set; }
        public UserName Name { get; set; }
        public UserMailAddress MailAdress { get; set; }

        public User(UserId id, UserName name, UserMailAddress mailAddress)
        {
            Id = id ?? throw new ArgumentException(nameof(id));
            Name = name ?? throw new ArgumentException(nameof(name));
            MailAdress = mailAddress ?? throw new ArgumentException(nameof(mailAddress));
        }
    }
}