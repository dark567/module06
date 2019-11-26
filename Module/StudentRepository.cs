using ModuleDal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ModuleDal
{
    public class StudentRepository
    {
        private readonly ModuleContext _context;

        public StudentRepository()
        {
            _context = new ModuleContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(x => x.Payments)
                .ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students
                .Include(x=>x.Payments)
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddStudents(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }

    }
}
