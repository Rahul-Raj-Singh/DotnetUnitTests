using System.IO;
using System.Linq;

namespace TestNinja.Mocking.Refactored
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public int Delete(int id)
        {
            var employee = Get(id);
            _db.Employees.Remove(employee);
            return Save();
        }

        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

    }

    public interface IEmployeeRepository
    {
        int Delete(int id);
        Employee Get(int id);
        int Save();
    }
}