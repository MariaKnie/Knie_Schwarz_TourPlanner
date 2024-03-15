using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knie_Schwarz_TourPlanner_project.Interfaces
{
    public interface ISessionContext : INotifyPropertyChanged
    {
        int EditorFontSize { get; set; }
    }
}
