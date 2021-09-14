using System;

namespace ValueObject
{
    public class UserName
    {
        public string Value { private set; get; }

        public UserName(string value)
        {
            ChangeName(value);
        }

        public void ChangeName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。", nameof(value));
            this.Value = value;
        }
    }
}