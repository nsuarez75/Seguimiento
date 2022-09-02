using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.MVVM.ViewModel
{
    class NuevaViewModel : ObservableObject
    {

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set 
            { 
                _texto = value;
                OnPropertyChanged();         
            }
        }




        public NuevaViewModel()
        {

        }


    }
}
