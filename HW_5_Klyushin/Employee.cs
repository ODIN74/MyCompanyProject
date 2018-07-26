
namespace HW_5_Klyushin
{
    using System;
    using System.ComponentModel;
    using System.Windows;

    [Serializable]

    /// <summary>
    /// Employee class
    /// </summary>
    public class Employee : Human, INotifyPropertyChanged
    {
        private static int globalId = 6;
        /// <summary>
        /// Emloyee id
        /// </summary>
        private int id;

        private Department employeeDepartment;

        private string position;

        private decimal salary;

        private DateTime dateOfEmployment;

        private string employ;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        public Employee() : base()
        {
            this.employeeDepartment = new Department();
            this.position = String.Empty;
            this.salary = 0.0m;
            this.dateOfEmployment = new DateTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <param name="lastname">Employee lastname</param>
        /// <param name="surname">Employee surname</param>
        /// <param name="humanSex">Employee sex</param>
        /// <param name="birthday">Employee birthday</param>
        /// <param name="department">Department class instance</param>
        /// <param name="position">Position employee at department</param>
        /// <param name="salary">Employee salary</param>
        /// <param name="dateOfEmployment">Date of employment</param>
        public Employee(
            string name,
            string lastname,
            string surname,
            Enum humanSex,
            DateTime birthday,
            Department department,
            string position,
            decimal salary,
            DateTime dateOfEmployment)
            : base(name, lastname, surname, humanSex, birthday)
        {
            this.employeeDepartment = department;
            this.position = position;
            this.salary = salary;
            this.dateOfEmployment = dateOfEmployment;
            department.IncrementNumberOfEmployees();
            if (this.position.Equals("Руководитель отдела"))
            {
                department.SetHeadOfDepartment($"{this.Name} {this.Lastname} {this.Surname}");
            }
            this.id = ++globalId;
            this.employ = "Работает";
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employ)));
        }

        /// <summary>
        /// Gets unique id of employee
        /// </summary>
        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        /// <summary>
        /// Gets department
        /// </summary>
        public Department EmployeeDepartment
        {
            get => this.employeeDepartment;
            set
            {
                this.employeeDepartment = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.EmployeeDepartment)));
            }
        }

        /// <summary>
        /// Gets position
        /// </summary>
        public string Position
        {
            get => this.position;
            set
            {
                this.position = value;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(this.Position)));
            }
        }

        /// <summary>
        /// Gets salary
        /// </summary>
        public decimal Salary
        {
            get => this.salary;
            set
            {
                this.salary = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Salary)));
            }
        }

        /// <summary>
        /// Gets date of employment
        /// </summary>
        public DateTime DateOfEmployment
        {
            get => this.dateOfEmployment;
            set
            {
                this.dateOfEmployment = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DateOfEmployment)));
            }
        }

        /// <summary>
        /// Gets a value indicating employee status
        /// </summary>
        public string Employ
        {
            get => this.employ;
            set
            {
                if (value.ToLower() == "работает" || value.ToLower() == "уволен")
                {
                    this.employ = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employ)));
                }
                else
                    MessageBox.Show(
                        "Недопусимое значение для статуса (допустимы: работает, уволен)!",
                        "Недопустимые данные",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method employee dismissed
        /// </summary>
        /// <param name="department">Department instance</param>
        /// <param name="curentEmployee">Employee instance</param>
        public void EmployeeDismissed(Department department, Employee curentEmployee)
        {
            curentEmployee.employ = "Уволен";
            department.DecrementNumberOfEmployees();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employ)));
        }

        /// <summary>
        /// Override method ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{this.Name} {this.Lastname} {this.Surname}";
        }
    }
}
