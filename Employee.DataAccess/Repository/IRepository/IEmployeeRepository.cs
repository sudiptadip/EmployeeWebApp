﻿using Employee.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        void Update(Employees employee);
    }
}
