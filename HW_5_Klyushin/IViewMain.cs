using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    internal interface IViewMain
    {
        ObservableCollection<Department> DepartmentsList { set; }

        ObservableCollection<Employee> EmployeesList { set; }
    }
}
