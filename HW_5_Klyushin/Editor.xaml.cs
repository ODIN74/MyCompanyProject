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

    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Window, IViewEditor
    {
        private Presenter newPresenter;

        public ObservableCollection<Department> DepartmentsList { get; set; }

        public Employee CurrentEmployee { get; set; }

        public Editor(Employee currentEmployee)
        {
            InitializeComponent();

            this.newPresenter = new Presenter(this);

            this.DataContext = this;
            
            this.newPresenter.EditEmployee(currentEmployee);

            this.rbMail.IsChecked = currentEmployee.Sex == "М" ? true : false;
            this.rbFemale.IsChecked = currentEmployee.Sex == "Ж" ? true : false;
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
