namespace ExamMainProject.CustomExceptions
{
    using System;

    public class BlobHealthException : Exception
    {
        public BlobHealthException(string message)
            : base(message)
        {
        }
    }
}
