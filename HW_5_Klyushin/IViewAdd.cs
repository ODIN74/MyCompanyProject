using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;

    internal interface IViewAdd
    {
        ObservableCollection<Department> DepartmentsList { get; set; } 
    }
}
