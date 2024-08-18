using ITI_Final_Poject.Models;

namespace ITI_Final_Poject.Repository
{
    public interface I_StudentRepo
    {
        Guid id { get; set; }
        List<Student> GetAll();
        List<Student> GetAllStudentsWithDepartmentData();
        Student GetById(int id);
        void Insert(Student item);
        void Edit(int id, Student item);
        void Delete(int id);

    }
}
