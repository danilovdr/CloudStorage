using System;

namespace CloudStorage.BLL.Exceptions
{
    class UserUpdateException : Exception
    {
        public UserUpdateException(string message, string value)
            : base(message)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
