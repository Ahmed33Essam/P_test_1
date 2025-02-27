using P_test_1.Models;

namespace P_test_1.Repository
{
    public class DeparmentRepository : IGenRepository<Department>
    {
        ITIContext context;

        public string Id { set; get; }

        public DeparmentRepository(ITIContext _context)
        {
            context = _context; //new ITIContext();
            Id = Guid.NewGuid().ToString();
        }

        public void Add(Department department)
        {
            context.Add(department);
        }
        public void Update(Department department)
        {
            context.Update(department);
        }
        public void Remove(int id)
        {
            Department department = GetByID(id);
            context.Remove(department);
        }
        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
