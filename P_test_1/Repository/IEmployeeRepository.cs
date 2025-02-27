using P_test_1.Models;

namespace P_test_1.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);

        public void Update(Employee obj);

        public void Remove(int id);

        public Employee GetByID(int id);

        public List<Employee> GetAll();

        public List<Employee> GetByDept(int id);

        public void Save();
        
    }
}
