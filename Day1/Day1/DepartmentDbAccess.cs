using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class DepartmentDbAccess: IDeptDataAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public DepartmentDbAccess()
        {
            Conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=UCompany;Trusted_Connection=True;MultipleActiveResultSets=True");

        }
        public bool CreateDepartment(Department department)
        {
            bool inserted = false;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;

                Cmd.CommandText = $"Insert into Department Values ({department.DeptNo}, '{department.DeptName}', '{department.Location}', {department.Capacity})";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    inserted = true;
                }
            }
            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");  }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return inserted;
        }

        public bool DeleteDepartment(int DeptNo)
        {
            bool deleted = false;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Department where DeptNo={DeptNo}";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    deleted = true;
                }
            }

            catch (SqlException ex){ Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return deleted;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                // Open the Connection
                Conn.Open();
                // 2. The Command Object Instance
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from Department";
                // 3. Execute the Statement
                SqlDataReader reader = Cmd.ExecuteReader();
                // 4. Read data using Reader anf put it in List
                while (reader.Read())
                {
                    departments.Add(
                          new Department()
                          {
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),
                              DeptName = reader["DeptName"].ToString(),
                              Location = reader["Location"].ToString(),
                              Capacity = Convert.ToInt32(reader["Capacity"])
                          }
                        );
                }
                // 5. CLose the Reader Done
                reader.Close();
            }

            catch (SqlException ex)
            { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex){ Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return departments;
        }

        public List<Department> getdept(int deptno)
        {
            List<Department> departments = new List<Department>();
            try
            {
                // Open the Connection
                Conn.Open();
                // 2. The Command Object Instance
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from Department where DeptNo='{deptno}'";
                // 3. Execute the Statement
                SqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    departments.Add(
                          new Department()
                          {
                              DeptNo = Convert.ToInt32(reader["DeptNo"]),
                              DeptName = reader["DeptName"].ToString(),
                              Location = reader["Location"].ToString(),
                              Capacity = Convert.ToInt32(reader["Capacity"])
                          }
                        );
                }
                reader.Close();
            }

            catch (SqlException ex){ Console.WriteLine($"Error Occured while Processoing Request {ex.Message}"); }
            catch (Exception ex) {Console.WriteLine($"General Error {ex.Message}"); }
            finally { Conn.Close(); }
            return departments;
        }

        public bool UpdateDepartment(Department department, int deno)
        {
            bool updated = false;
            try
            {
                Conn.Open();

                
                department.DeptNo = deno;

                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Department Set DeptName='{department.DeptName}', Location='{department.Location}',Capacity={department.Capacity} where DeptNo={department.DeptNo}";
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    updated = true;
                }

            }

            catch (SqlException ex) { Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");}
            catch (Exception ex) { Console.WriteLine($"General Error {ex.Message}");}
            finally { Conn.Close();}
            return updated;
        }
    }

}
