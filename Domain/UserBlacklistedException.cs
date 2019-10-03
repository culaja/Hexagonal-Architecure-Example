using System;

namespace Domain
{
    public sealed class UserBlacklistedException : Exception
    {
        public UserBlacklistedException(string userName)
            : base($"Can't borrow book to blacklisted user '{userName}'")
        {
        }
    }
}