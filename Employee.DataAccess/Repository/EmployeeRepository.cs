using Employee.DataAccess.Repository.IRepository;
using Employee.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employees obj)
        {
            _db.Employees.Update(obj);
        }
    }
}