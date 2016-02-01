namespace ExamMainProject.UI
{
    using System;
    using Interfaces;

    public class OutputManager : IOutputManager
    {
        private static IOutputManager manager;

        private OutputManager()
        {
        }

        public static IOutputManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new OutputManager();
                }

                return manager;
            }
        }

        public void Write(string currentLine)
        {
            Console.Write(currentLine);
        }

        public void WriteLine(string currentLine)
        {
            Console.WriteLine(currentLine);
        }
    }
}
