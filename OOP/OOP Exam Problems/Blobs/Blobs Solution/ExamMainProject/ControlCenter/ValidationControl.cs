namespace ExamMainProject.ControlCenter
{
    using System;

    /// <summary>
    /// This class allows you to maintain control of the whole project.
    /// 1. You can easily turn on/off property integer and string validations when needed.
    /// 2. Here Regex validation patterns could be implemented and changed.
    /// 3. The global round delay can also be changed here.
    /// </summary>
    public static class ValidationControl
    {
        public const bool GlobalNameValidation = true;
        public const bool GlobalHealthValidation = true;
        public const bool GlobalDamageValidation = true;

        public const int BlobDamageMinValue = 0;
        public const int BlobHealthMinValue = 0;

        public const int AggressiveBehaviorDamageMultiplyIndex = 2;
        public const int AggressiveBehaviorDamageDecrease = 5;

        public const int InflatedBehaviorHealthIncrease = 50;
        public const int InflatedBehaviorHealthDecrease = 10;

        public const string AliveBlobStringFormat = "{0} {1}: {2} HP, {3} Damage";
        public const string DeadBlobStringFormat = "{0} {1} KILLED";

        public const string BehaviorStringPostFix = "Behavior";
        public const string CommandStringPostFix = "command";

        public const int BlobRoundDelay = 2;
    }
}
