using WebApplication1.Models;

namespace WebApplication1.Contracts
{
	public interface IStudentService
	{
		Student GetStudent(int id);
		bool UpdateStudent(Student student); 
	}
}
