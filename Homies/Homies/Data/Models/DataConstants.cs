using Microsoft.VisualBasic;

namespace Homies.Data.Models
{
    public static class DataConstants
    {
        public static class Event
        {
            /// <summary>
            /// Event name max length
            /// </summary>
            public const int NameMaxLength = 20;
            /// <summary>
            /// Event name min length
            /// </summary>
            public const int NameMinLength = 5;
            /// <summary>
            /// Event description max length
            /// </summary>
            public const int DescriptionMaxLength = 150;
            /// <summary>
            /// Event description min length
            /// </summary>
            public const int DescriptionMinLength = 15;           

        }

        public static class Type
        {
            /// <summary>
            /// Type name max length
            /// </summary>
            public const int NameMaxLength = 15;
            /// <summary>
            /// Type length min length
            /// </summary>
            public const int NameMinLength = 5;
        }

        public const string DateFormat = "yyyy-MM-dd H:mm";
        
    }
}
