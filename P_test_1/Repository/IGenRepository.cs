using P_test_1.Models;

namespace P_test_1.Repository
{
    public interface IGenRepository<T>
    {
        public string Id { set; get; }
        public void Add(T department);

        public void Update(T department);

        public void Remove(int id);

        public T GetByID(int id);

        public List<T> GetAll();

        public void Save();
    }
}
