using System.Collections.ObjectModel;

namespace HW_5_Klyushin
{
    using System.Data;

    internal interface IViewEditor
    {
        ObservableCollection<Department> DepartmentsList { set; }

        Employee CurrentEmployee { set; }

        DataTable Departments { get; set; }

        DataRow EmployeeFromDataGrid { get; set; }

    }
}