using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Planner.View_Model
{
    /// <summary>
    /// Viewmodel base. Allows all viewmodels to properly use INotifyPropertyChanged that inherits from this.
    /// Reduces repetitive code.
    /// </summary>

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
