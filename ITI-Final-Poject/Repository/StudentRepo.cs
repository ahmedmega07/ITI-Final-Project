using ITI_Final_Poject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Final_Poject.Repository
{
    public class StudentRepo : I_StudentRepo
    {
        //CRUD

        ApplicationContext context;

        public Guid id { get; set; }
        public StudentRepo(ApplicationContext _context)
        {
            id = Guid.NewGuid();
            context = _context;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public List<Student> GetAllStudentsWithDepartmentData()
        {
            return context.Students.Include(s => s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Student item)
        {
            context.Students.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id, Student item)
        {
            Student oldStudent = GetById(id);
            oldStudent.Name = item.Name;
            oldStudent.Dept_Id = item.Dept_Id;
            oldStudent.Age = item.Age;
            oldStudent.Address = item.Address;

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Student oldStudent = GetById(id);
            context.Students.Remove(oldStudent);
            context.SaveChanges();
        }
    }
}

