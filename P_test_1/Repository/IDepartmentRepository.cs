using P_test_1.Models;

namespace P_test_1.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department department);

        public void Update(Department department);

        public void Remove(int id);

        public Department GetByID(int id);

        public List<Department> GetAll();

        public void Save();
        
    }
}
