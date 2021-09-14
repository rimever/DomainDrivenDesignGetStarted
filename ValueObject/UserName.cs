using System;

namespace ValueObject
{
    public class UserName
    {
        private string _name;

        public UserName(string value)
        {
            ChangeName(value);
        }

        private void ChangeName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。", nameof(value));
            this._name = value;
        }
    }
}