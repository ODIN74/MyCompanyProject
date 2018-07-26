using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class Model
    {
        public List<Department> departmentsList { get; set; }

        public List<Employee> employeesList { get; set; }

        private ReadAndWriteSqlDB rwsdb = new ReadAndWriteSqlDB();

        public DataTable departments { get; set; }

        public DataTable employees { get; set; }

        private string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyCompany; Integrated Security = True";

        public Model()
        {
            this.departmentsList = new List<Department>();
            this.employeesList = new List<Employee>();
        }

        public void ReadData()
        {
            this.departmentsList = DataReaderAndWriter<Department>.ReadDataFromXml("./departments.xml");

            this.employeesList = DataReaderAndWriter<Employee>.ReadDataFromXml("./employees.xml");
        }

        public void ReadDataFromSql()
        {
            this.departments = this.rwsdb.ReadDepartmentsFromSqlDb(this.connectionString);
            this.employees = this.rwsdb.ReadEmployeesFromSqlDb(this.connectionString);
        }

        public DataTable ReadEmployeesForAdd()
        {
            return this.rwsdb.ReadEmployeesFromSqlForAdd(this.connectionString);
        }

        internal void AddEmployeeToSql(Employee employee)
        {
            this.rwsdb.AddEmployeeToSqlDb(employee, this.connectionString);
        }

        public void WriteData()
        {
            DataReaderAndWriter<Department>.WriteDataToXml(this.departmentsList, "./departments.xml");

            DataReaderAndWriter<Employee>.WriteDataToXml(this.employeesList, "./employees.xml");
        }

        public void AddDepartment(string name)
        {
            this.departmentsList.Add(new Department(name));
        }

        public void AddDepartment(string name, Employee employee)
        {
            this.departmentsList.Add(new Department(name, employee));
            this.EmployeePositionUpdate(employee, this.departmentsList[this.departmentsList.Count - 1]);
        }

        public void AddDepartmentToSql(string departmentName)
        {
            this.rwsdb.AddDepartmentToSqlDb(departmentName, this.connectionString);
        }

        public void AddDepartmentToSql(string departmentName, string FIO)
        {
            this.rwsdb.AddDepartmentToSqlDb(departmentName, FIO, this.connectionString);
        }

        public void AddEmployee(
            string name,
            string lastname,
            string surname,
            string sex,
            DateTime birthday,
            Department department,
            string position,
            decimal salary,
            DateTime dateOfEmployment)
        {
            if (sex.Equals("М"))
            {
                this.employeesList.Add(
                new Employee(
                             name,
                             lastname,
                             surname,
                             Human.humanSex.Male,
                             birthday,
                             department,
                             position,
                             salary,
                             dateOfEmployment)); 
            }
            else
            {
                this.employeesList.Add(
                    new Employee(
                        name,
                        lastname,
                        surname,
                        Human.humanSex.Female,
                        birthday,
                        department,
                        position,
                        salary,
                        dateOfEmployment));
            }
        }

        internal void UpdatePositionEmployee(int employeeId)
        {
            this.rwsdb.UpdatePositionEmployee(employeeId, this.connectionString);
        }

        internal DataTable SelectEmloyeesByDepartment(string department)
        {
            return this.rwsdb.SelectEmployeesByDepartment(department, this.connectionString);
        }

        public void SaveEmployeeData(Employee currentEmployee)
        {
            int index = 0;
            for (int i = 0; i < this.employeesList.Count; i++)
            {
                if (this.employeesList[i].Id == currentEmployee.Id)
                {
                    index = i;
                    break;
                }
            }

            this.employeesList[index].Name = currentEmployee.Name;
            this.employeesList[index].Lastname = currentEmployee.Lastname;
            this.employeesList[index].Surname = currentEmployee.Surname;
            this.employeesList[index].BirthDay = currentEmployee.BirthDay;
            this.employeesList[index].Sex = currentEmployee.Sex;
            this.employeesList[index].EmployeeDepartment = currentEmployee.EmployeeDepartment; 
            this.employeesList[index].Position = currentEmployee.Position;
            this.employeesList[index].Salary = currentEmployee.Salary;
            this.employeesList[index].DateOfEmployment = currentEmployee.DateOfEmployment;
            this.employeesList[index].Employ = currentEmployee.Employ;

            this.WriteData();
        }

        public void EmployeePositionUpdate(Employee employee, Department department)
        {
            int index = 0;
            for (int i = 0; i < this.employeesList.Count; i++)
            {
                if (this.employeesList[i].Id == employee.Id)
                {
                    index = i;
                    break;
                }
            }
            this.employeesList[index].EmployeeDepartment = department;
        }

        public void CreateSqlDb()
        {
            foreach (var d in this.departmentsList)
            {
                this.rwsdb.AddDepartmenToSqlDb(d, this.connectionString);
            }

            foreach (var e in this.employeesList)
            {
                this.rwsdb.AddEmployeeToSqlDb(e, this.connectionString);
            }
        }
    }
}
