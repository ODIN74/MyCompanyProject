
namespace HW_5_Klyushin
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;

    [Serializable]

    /// <summary>
    /// Departments class
    /// </summary>
    public class Department : INotifyPropertyChanged, IComparable
    {
        private string name;

        /// <summary>
        /// Number of Departments
        /// </summary>
        private static int numberOfDepartments = 0;

        /// <summary>
        /// Department name
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        /// <summary>
        /// Head of department
        /// </summary>
        private string headOfDepartment;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the  <see cref="Department"/> class without data
        /// </summary>
        public Department()
        {
            this.Name = String.Empty;
            this.headOfDepartment = String.Empty;
            numberOfDepartments++;
        }

        /// <summary>
        /// Initializes a new instance of the  <see cref="Department"/> class with name only
        /// </summary>
        /// <param name="name">Name of department</param>
        public Department(string name)
        {
            this.Name = name;
            this.headOfDepartment = String.Empty;
            numberOfDepartments++;
        }

        /// <summary>
        /// Initializes a new instance of the  <see cref="Department"/> class with name  and head of department
        /// </summary>
        /// <param name="name">Name of department</param>>
        /// <param name="headOfDepartment">Head of department</param>
        public Department(string name, Employee headOfDepartment)
        {
            this.Name = name;
            this.headOfDepartment = $"{headOfDepartment.Name} {headOfDepartment.Lastname} {headOfDepartment.Surname}";
            numberOfDepartments++;
        }

        /// <summary>
        /// Sets the head of department
        /// </summary>
        /// <param name="headOfDepartment">Head of department</param>
        public void SetHeadOfDepartment(string headOfDepartment)
        {
            this.headOfDepartment = headOfDepartment;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.headOfDepartment)));
        }

        /// <summary>
        /// Gets the employees
        /// </summary>
        public int NumberOfEmployees { get; set; }

        /// <summary>
        /// Method of icrementation namber of employees
        /// </summary>
        public void IncrementNumberOfEmployees()
        {
            this.NumberOfEmployees++;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.NumberOfEmployees)));
        }

        /// <summary>
        /// Method of dicrementation namber of emplyees
        /// </summary>
        public void DecrementNumberOfEmployees()
        {
            this.NumberOfEmployees--;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.NumberOfEmployees)));
        }


        public override string ToString()
        {
            return this.name;
        }

        public int CompareTo(object x)
        {
            return this.Name.CompareTo((x as Department).Name);
        }
    }
}
