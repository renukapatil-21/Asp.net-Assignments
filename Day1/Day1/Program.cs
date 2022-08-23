// See https://aka.ms/new-console-template for more information
using Day1;


Console.WriteLine("------------------------------ADO.NET Assign------------------------------------");

    DepartmentDbAccess dDb = new DepartmentDbAccess();
    EmployeeDbAcess eDb = new EmployeeDbAcess();
    Reports rp = new Reports();
    string str = " " ;

    Console.WriteLine( "\n1.Department \t2.Employee" );
    int sel = Convert.ToInt32(Console.ReadLine());
     
    if(sel == 1)
    {
        Console.WriteLine("----------------Department Section-------------------");
            do
            {
                Console.WriteLine("\n1.Get \n2.Get by ID \n3.Create \n4.Update \n5.Delete \n6.Report \n7.Search Employee by criterion");
                int sel1 = Convert.ToInt32(Console.ReadLine());

                switch (sel1)
        {
            case 1:
                var res1 = dDb.GetDepartments();
                Print(res1);
                break;
            case 2:
                Console.WriteLine("Enter Department No.: ");
                int dno = Convert.ToInt32(Console.ReadLine());

                var ress = dDb.getdept(dno);
                Print(ress);

                break;
            case 3:
                Console.WriteLine("Enter Department No.: ");
                dno = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Department Name: ");
                string Deptname = Console.ReadLine();

                Console.WriteLine("Enter Location");
                string loc = Console.ReadLine();

                Console.WriteLine("Enter Capacity: ");
                int cap = Convert.ToInt32(Console.ReadLine());

                Department dept = new Department()
                {
                    DeptNo = dno,
                    DeptName = Deptname,
                    Location = loc,
                    Capacity = cap
                };

                var done = dDb.CreateDepartment(dept);

                if (done)
                {
                    res1 = dDb.GetDepartments();
                    Print(res1);
                }

                break;
            case 4:
                Console.WriteLine("Enter Department No. you want to update: ");
                int deno = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Department Name: ");
                string nDeptname = Console.ReadLine();

                Console.WriteLine("Enter Location");
                string nloc = Console.ReadLine();

                Console.WriteLine("Enter Capacity: ");
                int ncap = Convert.ToInt32(Console.ReadLine());

                Department ndept = new Department()
                {
                    DeptName = nDeptname,
                    Location = nloc,
                    Capacity = ncap
                };

                var ndone = dDb.UpdateDepartment(ndept, deno);

                if (ndone)
                {
                    res1 = dDb.GetDepartments();
                    Print(res1);
                }

                break;
            case 5:
                Console.WriteLine("Enter Department No.: ");
                dno = Convert.ToInt32(Console.ReadLine());

                dDb.DeleteDepartment(dno);
                Console.WriteLine("Deleted");
                break;
            case 6:
                Console.WriteLine("Enter Department Name: ");
                Deptname = Console.ReadLine();

                Console.WriteLine("Enter Designation Name: ");
                string design = Console.ReadLine();

                if (string.IsNullOrEmpty(Deptname) && string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("-------Both Fields are empty, return all Employess--------");
                    var result1 = rp.ListEmployees1();
                    Print1(result1);

                }
                else if (!string.IsNullOrEmpty(Deptname) && string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("------DeptName is not empty or null, returns Employees by DeptName----");
                    var result2 = rp.ListEmployees2(Deptname);
                    PrintEmp(result2);
                }
                else if (string.IsNullOrEmpty(Deptname) && !string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("------Designation is not empty or null, returns Employees by Designation----");
                    var result3 = rp.ListEmployees3(design);
                    PrintEmp(result3);
                }
                else
                {
                    Console.WriteLine("----------Return all employees----------");
                    var result4 = rp.ListEmployees4(Deptname,design);
                    PrintEmp(result4);
                }
                break;
            case 7:
                Console.WriteLine("Enter column name: ");
                string col = Console.ReadLine();
                Console.WriteLine("Enter criterion: ");
                char cri = Convert.ToChar( Console.ReadLine() );

                var result5 = rp.SearchEmployee(col, cri);
                PrintEmp(result5);

                break;
            default:
                Console.WriteLine("Invalid choice");
                break;

            }

                Console.WriteLine("\nEnter 'y' if you want to continue: ");
                str = Console.ReadLine();
            } while (str == "y");

    }
    else
    {
         Console.WriteLine("----------------Employee Section-------------------");
    do
    {
        Console.WriteLine("\n1.Get \n2.Get by ID \n3.Create \n4.Update \n5.Delete \n6.Report");
        int sel1 = Convert.ToInt32(Console.ReadLine());

        switch (sel1)
        {
            case 1:
                var res1 = eDb.GetEmployees();
                PrintEmp(res1);
                break;
            case 2:
                Console.WriteLine("Enter Employee No.: ");
                int eno = Convert.ToInt32(Console.ReadLine());

                var ress = eDb.getEmp(eno);
                PrintEmp(ress);

                break;
            case 3:
                Console.WriteLine("Enter Employee No.: ");
                eno = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Employee Name: ");
                string Empname = Console.ReadLine();

                Console.WriteLine("Enter Designation");
                string des = Console.ReadLine();

                Console.WriteLine("Enter Salary: ");
                int sal = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Dept no: ");
                int dno = Convert.ToInt32(Console.ReadLine());

                Employee emp = new Employee()
                {
                    EmpNo = eno,
                    EmpName = Empname,
                    Designation = des,
                    Salary = sal,
                    DeptNo = dno
                };

                var done = eDb.CreateEmployee(emp);

                if (done)
                {
                    res1 = eDb.GetEmployees();
                    PrintEmp(res1);
                }

                break;
            case 4:
                Console.WriteLine("Enter EMployee No. you want to update: ");
                int neno = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Employee Name: ");
                string nEmpname = Console.ReadLine();

                Console.WriteLine("Enter Designation");
                string ndes = Console.ReadLine();

                Console.WriteLine("Enter Salary: ");
                int nsal = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Dept no: ");
                int nedno = Convert.ToInt32(Console.ReadLine());

                Employee nemp = new Employee()
                {
                    EmpNo = neno,
                    EmpName = nEmpname,
                    Designation = ndes,
                    Salary = nsal,
                    DeptNo = nedno
                };

                var ndone = eDb.CreateEmployee(nemp);

                if (ndone)
                {
                    res1 = eDb.GetEmployees();
                    PrintEmp(res1);
                }

                break;
            case 5:
                Console.WriteLine("Enter Employee No.: ");
                eno = Convert.ToInt32(Console.ReadLine());

                eDb.DeleteEmployee(eno);
                Console.WriteLine("Deleted");
                break;
            case 6:
                /*Console.WriteLine("Enter Department Name: ");
                Deptname = Console.ReadLine();

                Console.WriteLine("Enter Designation Name: ");
                string design = Console.ReadLine();

                if (string.IsNullOrEmpty(Deptname) && string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("-------Both Fields are empty, return all Employess--------");
                    var result1 = rp.ListEmployees1();
                    Print1(result1);

                }
                else if (!string.IsNullOrEmpty(Deptname) && string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("------DeptName is not empty or null, returns Employees by DeptName----");
                    var result2 = rp.ListEmployees2(Deptname);
                    Print1(result2);
                }
                else if (string.IsNullOrEmpty(Deptname) && !string.IsNullOrEmpty(design))
                {
                    Console.WriteLine("------Designation is not empty or null, returns Employees by Designation----");
                    var result3 = rp.ListEmployees3(design);
                    Print1(result3);
                }
                else
                {
                    Console.WriteLine("----------Return all employees----------");
                    // rp.ListEmployees4(Deptname,design);
                }*/
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        Console.WriteLine("\nEnter 'y' if you want to continue: ");
        str = Console.ReadLine();
    } while (str == "y");

}



Console.ReadLine();

static void Print(IEnumerable<Department> departments)
{
    foreach (var item in departments)
    {
        Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity}");
    }

}

static void PrintEmp(IEnumerable<Employee> emp)
{
    foreach (var item in emp)
    {
        Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Designation} {item.Salary} {item.DeptNo}");
    }

}

static void Print1(IEnumerable<Employee> departments)
{
    foreach (var item in departments)
    {
        Console.WriteLine($"{item.DeptNo} {item.EmpName} {item.EmpNo} {item.Salary}");
    }

}

