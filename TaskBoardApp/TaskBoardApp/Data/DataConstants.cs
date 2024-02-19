namespace TaskBoardApp.Data
{
    public static class DataConstants
    {
        public static class Task
        {
            /// <summary>
            /// Task title max length
            /// </summary>
            public const int TitleMaxLength = 70;
            /// <summary>
            /// Task title min length
            /// </summary>
            public const int TitleMinLength = 5;
            /// <summary>
            /// Task description max length
            /// </summary>
            public const int DescriptionMaxLength = 1000;
            /// <summary>
            /// Task description min length
            /// </summary>
            public const int DescriptionMinLength = 10;
        }

        public static class Board
        {
            /// <summary>
            /// Board name max length
            /// </summary>
            public const int NameMaxLength = 30;
            /// <summary>
            /// Board name min length
            /// </summary>
            public const int NameMinLength = 3;

        }
        


    }
}
