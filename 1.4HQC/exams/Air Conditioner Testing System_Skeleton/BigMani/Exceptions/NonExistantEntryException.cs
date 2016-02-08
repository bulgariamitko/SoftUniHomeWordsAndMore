namespace BigMani.Exceptions
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException()
        {
        }

        public NonExistantEntryException(string message)
            : base(message)
        {
        }

        public NonExistantEntryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}