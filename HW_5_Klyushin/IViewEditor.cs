using System.Collections.ObjectModel;

namespace HW_5_Klyushin
{
    internal interface IViewEditor
    {
        ObservableCollection<Department> DepartmentsList { set; }

        Employee CurrentEmployee { set; }

    }
}