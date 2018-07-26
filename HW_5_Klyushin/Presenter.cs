using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Windows;
    using System.Windows.Documents;

    class Presenter
    {
        private Model data;
        private IViewMain view;
        private IViewEditor editor;

        private IViewAdd add;

        public Presenter(IViewMain View)
        {
            this.data = new Model();
            this.view = View;
        }

        public Presenter(IViewEditor editor)
        {
            this.data = new Model();
            this.editor = editor;
        }

        public Presenter(IViewAdd add)
        {
            this.data = new Model();
            this.add = add;
        }

        public void LoadData()
        {
            //this.data.ReadData();

            this.data.ReadDataFromSql();

            this.view.Departments = this.data.departments;
            this.view.Employees = this.data.employees;

            //this.view.DepartmentsList = new ObservableCollection<Department>(this.data.departmentsList);
            //this.view.EmployeesList = new ObservableCollection<Employee>(this.data.employeesList);
        }

        internal DataTable LoadEmployees()
        {
            return this.data.ReadEmployeesForAdd();
        }

        internal void CreateEmployeeToSql(Employee employee)
        {
            this.data.AddEmployeeToSql(employee);
        }

        public void LoadDataForAdd()
        {
            this.data.ReadDataFromSql();
            //this.add.DepartmentsList = new ObservableCollection<Department>(this.data.departmentsList);
            this.add.Departments = this.data.departments;
        }

        public void DataUpdate(ObservableCollection<Employee> employeesData)
        {
            this.data.WriteData();
        }

        internal void EditEmployee(Employee currentEmployee)
        {
            this.data.ReadData();

            this.editor.DepartmentsList = new ObservableCollection<Department>(this.data.departmentsList);
            this.editor.CurrentEmployee = currentEmployee;
        }

        internal void EditEmployee()
        {
            this.data.ReadDataFromSql();
            this.editor.Departments = this.data.departments;
        }

        internal IEnumerable<Employee> SelectEmployeesData(Department selector) => from n in this.data.employeesList
                                                                                   where n.EmployeeDepartment.Name == selector.Name
                                                                                   select n;

        internal DataTable SelectEmployeesData(string department)
        {
            return this.data.SelectEmloyeesByDepartment(department);
        }

        internal void EmployeePositionIsHead(Employee employee, bool? isChecked)
        {
            if ((bool)isChecked)
            {
                employee.Position = "Руководитель отдела";
                this.data.SaveEmployeeData(employee);
                this.data.WriteData();
            }
        }

        internal void EmployeePositionIsHead(int EmployeeId, bool? isChecked)
        {
            if ((bool)isChecked)
            {
                this.data.UpdatePositionEmployee(EmployeeId);
            }
        }

        internal void AddDepartment(string departmentName, Employee employee, bool? isChecked)
        {
            if ((bool)isChecked) this.data.AddDepartment(departmentName, employee);
            else this.data.AddDepartment(departmentName);
        }

        internal void AddDepartment(string departmentName, string FIO, bool? isChecked)
        {
            if ((bool)isChecked && FIO!=null) this.data.AddDepartmentToSql(departmentName, FIO);
            else this.data.AddDepartmentToSql(departmentName);
        }

        internal void SaveEmployeeData(Employee curentEmployee)
        {
            this.data.SaveEmployeeData(curentEmployee);
        }

        internal void CreateEmployee(Employee employee)
        {
            this.data.AddEmployee(
                employee.Name,
                employee.Lastname,
                employee.Surname,
                employee.Sex,
                employee.BirthDay,
                employee.EmployeeDepartment,
                employee.Position,
                employee.Salary,
                employee.DateOfEmployment);
            this.data.WriteData();
        }

        internal void CreateDb()
        {
            this.data.CreateSqlDb();
        }
    }
}
