using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public interface IDeptDataAccess
    {
        public bool CreateDepartment(Department department);
        public List<Department> GetDepartments();
        public List<Department> getdept(int deptno);
        public bool UpdateDepartment(Department department, int deno);
        public bool DeleteDepartment(int DeptNo);

    }
}
