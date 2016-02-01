namespace ExamMainProject.ControlCenter
{
    using System;
    using Interfaces;
    using UI;
    using ControlCenter.Factories;
    using System.Collections.Generic;
    using ExamMainProject.CustomExceptions;

    /// <summary>
    /// In case you would like to ugrade the engine with additional functionalities without changing the current class
    /// the Run() and Stop() methods could be overriden.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        private bool isOperational;
        private List<IBlob> blobData;

        public GameEngine()
        {
            this.isOperational = true;
            this.blobData = new List<IBlob>();
            this.ToggledEvents = new List<string>();
            this.AllEvents = new LinkedList<string>();
            this.KilledBlobs = new HashSet<string>();
        }

        /// <summary>
        /// A property which indicates if the engine is still running.
        /// </summary>
        /// <returns>Returns a boolean value.</returns>
        public bool IsOperational
        {
            get
            {
                return this.isOperational;
            }
            private set
            {
                this.isOperational = value;
            }
        }

        /// <summary>
        /// A list of all events related to activating a behavior or killing a blob during the program execution.
        /// </summary>
        public List<string> ToggledEvents { get; set; }

        public LinkedList<string> AllEvents { get; set; }

        public bool MustPrintToggledEvents { get; set; }

        public HashSet<string> KilledBlobs { get; set; }

        public IEnumerable<IBlob> BlobData
        {
            get { return this.blobData; }
        }

        public virtual void Run()
        {
            while (this.IsOperational)
            {
                this.ApplySecondaryEffects();

                string[] currentLine = InputManager.Manager.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                IGameCommand currentCommand = CommandFactory.Factory.CreateCommand(currentLine, this);
                currentCommand.Execute(currentLine);

                this.DecreaseRoundDelays(); 
            }

            if (this.MustPrintToggledEvents)
            {
                foreach (string toggledEvent in this.ToggledEvents)
                {
                    OutputManager.Manager.Write(toggledEvent);
                }
            }

            foreach (string majorEvent in this.AllEvents)
            {
                OutputManager.Manager.Write(majorEvent);
            }
        }

        public virtual void Stop()
        {
            this.IsOperational = false;
        }

        public virtual void AddBlob(IBlob blobToBeAdded)
        {
            this.blobData.Add(blobToBeAdded);
        }

        protected virtual void ApplySecondaryEffects()
        {
            foreach (IBlob currentBlob in this.BlobData)
            {
                if (!currentBlob.Behavior.IsActive && currentBlob.RoundDelay <= 0)
                {
                    currentBlob.Behavior.ApplySecondaryEffect(currentBlob);
                    if (currentBlob.Health == 0 && !this.KilledBlobs.Contains(currentBlob.Name))
                    {
                        this.ToggledEvents.Add(string.Format(CustomMessages.BlobKilledMessage, currentBlob.Name));
                        this.KilledBlobs.Add(currentBlob.Name);
                    }
                }
            }
        }

        protected virtual void DecreaseRoundDelays()
        {
            foreach (IBlob currentBlob in this.blobData)
            {
                if (!currentBlob.Behavior.IsActive && currentBlob.RoundDelay == ValidationControl.BlobRoundDelay)
                {
                    this.ToggledEvents.Add(string.Format("Blob {0} toggled {1}\n",
                        currentBlob.Name, currentBlob.Behavior.GetType().Name));
                }

                if (!currentBlob.Behavior.IsActive)
                {
                    currentBlob.RoundDelay--;
                }
            }
        }
    }
}
