namespace SeminarHub.Data.Models
{
	public static class DataConstants
	{
		public static class Seminar
		{
			/// <summary>
			/// Seminar topic minimal length
			/// </summary>
			public const int TopicMinLength = 3;

			/// <summary>
			/// Seminar topic maximal length
			/// </summary>
			public const int TopicMaxLength = 100;

			/// <summary>
			/// Seminar lecturer minimal length
			/// </summary>
			public const int LecturerMinLength = 5;

			/// <summary>
			/// Seminar lecturer maximal length
			/// </summary>
			public const int LecturerMaxLength = 60;

			/// <summary>
			/// Seminar details minimal length
			/// </summary>
			public const int DetailsMinLength = 10;

			/// <summary>
			/// Seminar details maximal length
			/// </summary>
			public const int DetailsMaxLength = 500;

			/// <summary>
			/// Seminar duration minimal time
			/// </summary>
			public const int DurationMinTime = 30;

			/// <summary>
			/// Seminar duration maximal time
			/// </summary>
			public const int DurationMaxTime = 180;
		}

        public static class Category
        {
			/// <summary>
			/// Category name minimal length
			/// </summary>
			public const int NameMinLength = 3;

			/// <summary>
			/// Category name maximal length
			/// </summary>
			public const int NameMaxLength = 50;
        }

        public const string DateFormat = "dd/MM/yyyy HH:mm";
	}
}
