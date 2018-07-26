using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.Data;

    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Window, IViewEditor
    {
        private Presenter newPresenter;

        public ObservableCollection<Department> DepartmentsList { get; set; }

        public DataTable Departments { get; set; }

        public Employee CurrentEmployee { get; set; }
        public DataRow EmployeeFromDataGrid { get; set; }
        
        public Editor(Employee currentEmployee)
        {
            InitializeComponent();

            this.newPresenter = new Presenter(this);

            this.DataContext = this;
            
            this.newPresenter.EditEmployee(currentEmployee);

            this.rbMail.IsChecked = currentEmployee.Sex == "М" ? true : false;
            this.rbFemale.IsChecked = currentEmployee.Sex == "Ж" ? true : false;
        }

        public Editor(DataRow data)
        {
            InitializeComponent();

            this.newPresenter = new Presenter(this);

            this.newPresenter.EditEmployee();

            this.EmployeeFromDataGrid = data;

            this.tbName.Text = this.EmployeeFromDataGrid["Name"].ToString();
            this.tbLastname.Text = this.EmployeeFromDataGrid["Lastname"].ToString();
            this.tbSurname.Text = this.EmployeeFromDataGrid["Surname"].ToString();
            this.tbPosition.Text = this.EmployeeFromDataGrid["Position"].ToString();
            this.tbSalary.Text = this.EmployeeFromDataGrid["Salary"].ToString();
            if (this.EmployeeFromDataGrid["Sex"].ToString().Equals("М")) this.rbMail.IsChecked = true;
            else this.rbFemale.IsChecked = true;
            this.cbDepartments.DataContext = this.Departments.DefaultView;
            //this.dpBirthday.DisplayDate = this.EmployeeFromDataGrid["BirthDay"] != null ? Convert.ToDateTime(this.EmployeeFromDataGrid["BirthDay"]) : DateTime.Now;
            //this.dpDateOfEmployment.DisplayDate = this.EmployeeFromDataGrid["DateOfEmployment"] != null ? Convert.ToDateTime(this.EmployeeFromDataGrid["DateOfEmployment"]) : DateTime.Now;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.CurrentEmployee.EmployeeDepartment = this.cbDepartments.SelectedItem as Department;
            this.newPresenter.SaveEmployeeData(this.CurrentEmployee);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
