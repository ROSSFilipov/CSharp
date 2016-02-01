namespace ExamMainProject.Interfaces
{
    using System;

    public interface IOutputManager
    {
        void Write(string currentLine);

        void WriteLine(string currentLine);
    }
}
