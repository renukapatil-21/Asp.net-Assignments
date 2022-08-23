using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Day1
{
    public class Reports
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public Reports()
        {
            
            Conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=UCompany;Trusted_Connection=True;MultipleActiveResultSets=True");

        }

        public List<Employee> ListEmployees1()
        {
            List<Employee> Employees = new List<Employee>();
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
                    Employees.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(reader["EmpNo"]),
                              EmpName = reader["EmpName"].ToString(),
                              Designation = reader["Designation"].ToString(),
                              Salary = Convert.ToInt32(reader["Salary"]),
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),    
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
            return Employees;
        }

        public List<Employee> ListEmployees2(string deptname)
        {
            List<Employee> Employees = new List<Employee>();
            try
            {
                // Open the Connection
                Conn.Open();
                // 2. The Command Object Instance
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select e.EmpNo, e.EmpName, e.Designation, e.Salary, e.DeptNo from Employee e, Department d where e.DeptNo=d.Deptno AND d.DeptName='{deptname}'";
                // 3. Execute the Statement
                SqlDataReader reader = Cmd.ExecuteReader();
                // 4. Read data using Reader anf put it in List
                while (reader.Read())
                {
                    Employees.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(reader["EmpNo"]),
                              EmpName = reader["EmpName"].ToString(),
                              Designation = reader["Designation"].ToString(),
                              Salary = Convert.ToInt32(reader["Salary"]),
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),


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
            return Employees;
        }

        
        public List<Employee> ListEmployees3(string Desig)
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
                Cmd.CommandText = $"Select * from Employee where Designation='{Desig}'";
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


        public List<Employee> ListEmployees4(string DeptName, string Desig)
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
                Cmd.CommandText = $"Select e.EmpNo, e.EmpName, e.Designation, e.Salary, e.DeptNo from Employee e, Department d where e.DeptNo=d.Deptno AND d.DeptName='{DeptName}' AND e.Designation='{Desig}'";
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

        public List<Employee> SearchEmployee(string colName, char criterion)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from Employee where {colName} LIKE '{criterion}%'";
                                    
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



    }
}
