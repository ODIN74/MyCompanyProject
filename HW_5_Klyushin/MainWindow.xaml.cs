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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.Data;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewMain
    {
        private Presenter newPresnter;

        public ObservableCollection<Department> DepartmentsList { get; set; }

        public ObservableCollection<Employee> EmployeesList { get; set; }
        public DataTable Departments { get; set; }
        public DataTable Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.newPresnter = new Presenter(this);

            this.newPresnter.LoadData();

            //this.newPresnter.CreateDb();

            this.EmployeesViewer.DataContext = this.Employees.DefaultView;
            this.cbDepartments.DataContext = this.Departments.DefaultView;

        }

        private void cbDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.EmployeesViewer.DataContext =
                this.newPresnter.SelectEmployeesData((this.cbDepartments.SelectedItem as DataRowView).Row["Name"].ToString()).DefaultView;
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            AddDepartment DepartmentAdd = new AddDepartment();
            DepartmentAdd.ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee EmployeeAdd = new AddEmployee();
            EmployeeAdd.ShowDialog();
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            Editor editor = new Editor((this.EmployeesViewer.SelectedItem as DataRowView).Row);
            editor.ShowDialog();
        }

        private void BtnResetFilter_Click(object sender, RoutedEventArgs e)
        {
            this.EmployeesViewer.DataContext = this.Employees.DefaultView;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.newPresnter.LoadData();
        }
    }
}
