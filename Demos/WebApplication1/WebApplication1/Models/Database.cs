namespace WebApplication1.Models
{
	static class Database
	{
		private static List<Student> _students = new List<Student>
		{
			new Student
			{
				Id = 1,
				Name = "Johny Test",
				Email = "johny@test.com"
			},
			new Student
			{
				Id = 2,
				Name = "Sophie Test",
				Email = "sophie@test.com"
			}
		};

		public static Student GetStudent(int id) => _students.FirstOrDefault(s => s.Id == id);

		public static bool UpdateStudent(Student student)
		{
			var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
			bool result = false;

			if(existingStudent != null)
			{
				existingStudent.Name = student.Name;
				existingStudent.Email = student.Email; 
				result = true;
			}

			return result;
			
		}
	}
}
