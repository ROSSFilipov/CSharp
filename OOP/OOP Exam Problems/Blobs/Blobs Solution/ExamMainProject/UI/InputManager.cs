namespace ExamMainProject.UI
{
    using System;
    using Interfaces;

    public class InputManager : IInputManager
    {
        private static IInputManager manager;

        private InputManager()
        {
        }

        public static IInputManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new InputManager();
                }

                return manager;
            }
        }

        public string ReadLine()
        {
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}
