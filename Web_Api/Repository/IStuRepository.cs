using Web_Api.Models;

namespace Web_Api.Repository
{
    public interface IStuRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> GetById(Guid empId);
        Task<Student> Create(Student student);
        Task Update(Student student);
        Task Delete(Guid empId);

    }
}
