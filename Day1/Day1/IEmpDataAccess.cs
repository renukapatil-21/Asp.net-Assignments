using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public interface IEmpDataAccess
    {
        public bool CreateEmployee(Employee employee);
        public List<Employee> GetEmployees();
        public List<Employee> getEmp(int empno);
        public bool UpdateEmployee(Employee employee, int empno);
        public bool DeleteEmployee(int DeptNo);
    }
}
