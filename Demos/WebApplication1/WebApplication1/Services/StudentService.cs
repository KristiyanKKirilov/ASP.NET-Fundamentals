using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public class StudentService : IStudentService
	{
		public Student GetStudent(int id) => Database.GetStudent(id);

		public bool UpdateStudent(Student student) => Database.UpdateStudent(student);
	}
}
