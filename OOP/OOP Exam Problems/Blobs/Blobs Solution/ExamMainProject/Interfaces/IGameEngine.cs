namespace ExamMainProject.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IGameEngine
    {
        bool IsOperational { get; }

        IEnumerable<IBlob> BlobData { get; }

        List<string> ToggledEvents { get; set; }

        LinkedList<string> AllEvents { get; set; }

        HashSet<string> KilledBlobs { get; set; }

        bool MustPrintToggledEvents { get; set; }

        void AddBlob(IBlob blobToBeAdded);

        void Run();

        void Stop();
    }
}
