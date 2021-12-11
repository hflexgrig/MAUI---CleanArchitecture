using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IEnumerable _errors;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public IEnumerable Errors
        {
            get => _errors; set
            {
                _errors = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable _customErrors;

        public IEnumerable CustomErrors
        {
            get { return _customErrors; }
            set { _customErrors = value; OnPropertyChanged(); }
        }

    }
}
