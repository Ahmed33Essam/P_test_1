namespace P_test_1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MangerName { get; set; }

        public List<Employee>? emps { get; set; }
    }
}
