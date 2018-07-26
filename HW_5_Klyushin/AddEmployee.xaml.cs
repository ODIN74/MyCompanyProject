using System;
using System.Windows;
using System.Windows.Input;


namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows.Data;

    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window, IViewAdd
    {
        private Presenter newPresenter;

        public ObservableCollection<Department> DepartmentsList { get; set; }
        public DataTable Departments { get; set; }

        public AddEmployee()

        {
            InitializeComponent();

            this.newPresenter = new Presenter(this);

            this.newPresenter.LoadDataForAdd();

            this.cbDepartments.DataContext = this.Departments.DefaultView;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.newPresenter.CreateEmployeeToSql(
                new Employee(
                    this.tbName.Text,
                    this.tbLastname.Text,
                    this.tbSurname.Text,
                    Convert.ToBoolean(this.rbMail.IsChecked) ? Human.humanSex.Male:Human.humanSex.Female,
                    this.dpBirthday.DisplayDate,
                    new Department((this.cbDepartments.SelectedItem as DataRowView).Row["Name"].ToString()),
                    this.tbPosition.Text,
                    Convert.ToDecimal(this.tbSalary.Text),
                    this.dpDateOfEmployment.DisplayDate));
            this.Close();
        }
    }
}
