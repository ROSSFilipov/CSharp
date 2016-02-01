namespace ExamMainProject.CustomExceptions
{
    using System;

    public class BlobNameException : Exception
    {
        public BlobNameException(string message)
            : base(message)
        {
        }
    }
}
