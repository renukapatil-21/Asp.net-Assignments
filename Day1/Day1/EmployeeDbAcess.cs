using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class EmployeeDbAcess : IEmpDataAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public EmployeeDbAcess()
        {
            //Conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=UCompany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=UCompany;Trusted_Connection=True;MultipleActiveResultSets=True");

        }
        public bool CreateEmployee(Employee employee)
        {
            bool inserted = false;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;

                Cmd.CommandText = $"Insert into Employee Values ({employee.EmpNo}, '{employee.EmpName}', '{employee.Designation}', {employee.Salary}, {employee.DeptNo})";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    inserted = true;
                }
            }
            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return inserted;
        }

        public bool DeleteEmployee(int empno)
        {
            bool deleted = false;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Employee where EmpNo={empno}";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    deleted = true;
                }
            }

            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return deleted;
        }

        public List<Employee> getEmp(int empno)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                // Open the Connection
                Conn.Open();
                // 2. The Command Object Instance
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from Employee where EmpNo='{empno}'";
                // 3. Execute the Statement
                SqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(reader["EmpNo"]),
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),
                              EmpName = reader["EmpName"].ToString(),
                              Designation = reader["Designation"].ToString(),
                              Salary = Convert.ToInt32(reader["Salary"])
                          }
                        );
                }
                reader.Close();
            }

            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return employees;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                // Open the Connection
                Conn.Open();
                // 2. The Command Object Instance
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from Employee";
                // 3. Execute the Statement
                SqlDataReader reader = Cmd.ExecuteReader();
                // 4. Read data using Reader anf put it in List
                while (reader.Read())
                {
                    employees.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(reader["EmpNo"]),
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),
                              EmpName = reader["EmpName"].ToString(),
                              Designation = reader["Designation"].ToString(),
                              Salary = Convert.ToInt32(reader["Salary"])
                          }
                        );
                }
                // 5. CLose the Reader Done
                reader.Close();
            }

            catch (SqlException ex)
            { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return employees;
        }

        public bool UpdateEmployee(Employee employee, int empno)
        {
            bool updated = false;
            try
            {
                Conn.Open();


                employee.DeptNo = empno;

                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Department Set EmpName='{employee.EmpName}', Designation='{employee.Designation}',Salary={employee.Salary} where EmpNo={employee.EmpNo}";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    updated = true;
                }

            }

            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return updated;
        }
    
    }
}
