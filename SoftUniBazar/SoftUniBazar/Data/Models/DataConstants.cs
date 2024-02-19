namespace SoftUniBazar.Data.Models
{
	public static class DataConstants
	{
		public static class Ad
		{
			/// <summary>
			/// Ad name min length
			/// </summary>
			public const int NameMinLength = 5;
			/// <summary>
			/// Ad name max length
			/// </summary>
			public const int NameMaxLength = 25;
			/// <summary>
			/// Ad description min length
			/// </summary>
			public const int DescriptionMinLength = 15;
			/// <summary>
			/// Ad description max length
			/// </summary>
			public const int DescriptionMaxLength = 250;
		}

		public static class Category
		{
			/// <summary>
			/// Category name min length
			/// </summary>
			public const int NameMinLength = 3;
			/// <summary>
			/// Category name max length
			/// </summary>
			public const int NameMaxLength = 15;
		}

		public const string DateFormat = "yyyy-MM-dd H:mm";
	}

}
