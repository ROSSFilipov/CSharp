namespace ExamMainProject.CustomExceptions
{
    using System;
    using ControlCenter;

    public static class CustomMessages
    {
        public const string BlobDamageMessage = "Please enter a valid integer number. Blob's damage cannot be lower than {0}";
        public const string BlobHealthMessage = "Please enter a valid integer number. Initial blob health cannot be lower than {0}";
        public const string BlobNameMessage = "Blob's name cannot be null or empty";
        public const string DuplicateBlobMessage = "Blob with the name {0} already exists";
        public const string BlobNullMessage = "Blob with name {0} does not exists or is dead.";
        public const string BehaviorAlreadyTriggeredMessage = "This blob's behavior has already been triggered";
        public const string FriendlyFireMessage = "A blob cannot attack itself";
        public const string BlobKilledMessage = "Blob {0} was killed\n";
    }
}
