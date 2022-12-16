using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Repository
{

    public class StudentRepo : IStuRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> Create(Student student)
        {
            _context.stu.Add(student); 
            await _context.SaveChangesAsync();
            return student;

        }

        public async Task Delete(Guid empId)
        {
            var stu = _context.stu.FirstOrDefault(x => x.Id == empId);
            _context.stu.Remove(stu);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.stu.ToListAsync();
        }

        public async Task<Student> GetById(Guid empId)
        {
            
            return _context.stu.FirstOrDefault(x => x.Id == empId);
        }

        public async Task Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
