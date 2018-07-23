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
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window, IViewMain
    {
        private Presenter newPresenter;

        public ObservableCollection<Department> DepartmentsList { get; set; }

        public ObservableCollection<Employee> EmployeesList { get; set; }

        public AddDepartment()
        {
            InitializeComponent();

            this.newPresenter = new Presenter(this);

            this.newPresenter.LoadData();

            this.DataContext = this;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.cbEmployees.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if(this.cbEmployees != null)
                this.cbEmployees.IsEnabled = false;
        }

        private void tbNameOfDepartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!this.tbNameOfDepartment.Text.Equals(String.Empty)) this.btnAdd.IsEnabled = true;
            else this.btnAdd.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.newPresenter.AddDepartment(this.tbNameOfDepartment.Text, this.cbEmployees.SelectionBoxItem as Employee, this.withHead.IsChecked);
            this.newPresenter.EmployeePositionIsHead(
                this.cbEmployees.SelectedItem as Employee,
                this.withHead.IsChecked);
            this.Close();
        }
    }
}
