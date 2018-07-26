using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Data;
    using System.Data.SqlClient;

    using HW_5_Klyushin.Annotations;

    internal class ReadAndWriteSqlDB
    {
        

        public DataTable ReadDepartmentsFromSqlDb(string connectionString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection connection = new SqlConnection(connectionString);

            adapter.SelectCommand = new SqlCommand(@"SELECT * FROM Departments", connection);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ReadEmployeesFromSqlDb(string connectionString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection connection = new SqlConnection(connectionString);
            
            adapter.SelectCommand = new SqlCommand(@"SELECT Employees.Id, 
                                                            Employees.Name, 
                                                            Lastname, 
                                                            Surname, 
                                                            BirthDay, 
                                                            Sex, 
                                                            Departments.Name as Department, 
                                                            Position, 
                                                            Salary, 
                                                            DateOfEmployment, 
                                                            Employ 
                                                     FROM Employees LEFT JOIN Departments 
                                                     ON Employees.Department = Departments.Id", connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable ReadEmployeesFromSqlForAdd(string connectionString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection connection = new SqlConnection(connectionString);

            adapter.SelectCommand = new SqlCommand(@"SELECT Id, 
                                                            (Surname +' '+ Name +' '+ Lastname) as FIO, 
                                                            BirthDay, 
                                                            Sex, 
                                                            Department, 
                                                            Position, 
                                                            Salary, 
                                                            DateOfEmployment, 
                                                            Employ 
                                                     FROM Employees", connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            return dataTable;
        }

        public void AddEmployeeToSqlDb(Employee employee, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand($@"SELECT id FROM Departments WHERE Name= N'{employee.EmployeeDepartment.Name}'",
                connection);

            int departmentId = Convert.ToInt32(command.ExecuteScalar());


            command = new SqlCommand(
                                     $@"INSERT INTO Employees (Name, Lastname, Surname, BirthDay, Sex, Department, Position, Salary, DateOfEmployment, Employ) 
                                                           VALUES (N'{employee.Name}', 
                                                                   N'{employee.Lastname}', 
                                                                   N'{employee.Surname}',
                                                                   '{employee.BirthDay.ToString("O")}',
                                                                   N'{employee.Sex}',
                                                                   {departmentId},
                                                                   N'{employee.Position}',
                                                                   {employee.Salary},
                                                                   '{employee.DateOfEmployment.ToString("O")}',
                                                                   N'{employee.Employ}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdatePositionEmployee(int employeeId, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand($@"UPDATE Employees 
                                                   SET Position = N'Руководитель отдела' 
                                                   WHERE id = {employeeId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal DataTable SelectEmployeesByDepartment(string department, string connectionString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection connection = new SqlConnection(connectionString);

            adapter.SelectCommand = new SqlCommand($@"SELECT *
                                                     FROM
                                                            (SELECT Employees.Id, 
                                                            Employees.Name, 
                                                            Lastname, 
                                                            Surname, 
                                                            BirthDay, 
                                                            Sex, 
                                                            Departments.Name as Department, 
                                                            Position, 
                                                            Salary, 
                                                            DateOfEmployment, 
                                                            Employ 
                                                     FROM Employees LEFT JOIN Departments 
                                                     ON Employees.Department = Departments.Id)  as mytable
                                                     WHERE Department = N'{department}'", connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            return dataTable;
        }

        public void AddDepartmenToSqlDb(Department department, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"INSERT INTO Departments (Name, Head, NumberOfEmployees) 
                VALUES (N'{department.Name}', N'{department.HeadOfDepartment}', {department.NumberOfEmployees})", connection);

                command.ExecuteNonQuery();

                connection.Close();
            }      
        }

        public void AddDepartmentToSqlDb(string departmentName, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"INSERT INTO Departments (Name, NumberOfEmployees) 
                VALUES (N'{departmentName}', 0)", connection);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void AddDepartmentToSqlDb(string departmentName, string FIO, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"INSERT INTO Departments (Name, Head,NumberOfEmployees) 
                VALUES (N'{departmentName}', N'{FIO}', 1)", connection);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
