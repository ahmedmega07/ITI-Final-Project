using ITI_Final_Poject.Models;

namespace ITI_Final_Poject.Repository
{
    public interface I_DepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department item);
        void Edit(int id, Department item);
        void Delete(int id);
    }
}
