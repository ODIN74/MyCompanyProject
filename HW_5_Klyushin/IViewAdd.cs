using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.Data;

    internal interface IViewAdd
    {
        ObservableCollection<Department> DepartmentsList { get; set; }
        
        DataTable Departments { get; set; }
    }
}
