using P_test_1.Models;

namespace P_test_1.Repository
{
    public class EmployeeRepository : IGenRepository<Employee>, IEmployeeRepository
    {
        ITIContext context;

        public string Id { set; get; }

        public EmployeeRepository(ITIContext _context)
        {
            context = _context;// new ITIContext();
        }

        public void Add(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Remove(int id)
        {
            Employee obj = GetByID(id);
            context.Remove(obj);
        }
        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public List<Employee> GetByDept(int id)
        {
            return context.Employees.Where(x => x.DptID == id).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
