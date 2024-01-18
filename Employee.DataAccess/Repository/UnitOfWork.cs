using Employee.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Employee.DataAccess.Repository.UnitOfWork;

namespace Employee.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IEmployeeRepository Employee { get; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db); ;
        }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
