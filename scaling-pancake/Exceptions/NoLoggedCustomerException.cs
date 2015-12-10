using System;

namespace scaling_pancake
{
    public class NoLoggedCustomerException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NoLoggedCustomerException() { }

        public NoLoggedCustomerException(string message) : base(message) { }

        public NoLoggedCustomerException(string message, Exception inner) : base(message, inner) { }
    }
}