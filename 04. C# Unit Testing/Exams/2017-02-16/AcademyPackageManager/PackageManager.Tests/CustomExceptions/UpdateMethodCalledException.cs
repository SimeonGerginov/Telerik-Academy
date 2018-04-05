using System;

namespace PackageManager.Tests.CustomExceptions
{
    public class UpdateMethodCalledException : Exception
    {
        public UpdateMethodCalledException(string message)
            : base(message) { }
    }
}
