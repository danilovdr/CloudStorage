using System;

namespace CloudStorage.BLL.Exceptions
{
    class UserCreateException : Exception
    {
        public UserCreateException(string message, string value)
            : base(message)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
