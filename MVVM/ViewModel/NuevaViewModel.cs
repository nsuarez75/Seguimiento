using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
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

        public ObservableRangeCollection<string> Proyectos { get; set; }
        public ObservableRangeCollection<string> Instalaciones { get; set; }


        public NuevaViewModel()
        {
            Proyectos = new ObservableRangeCollection<string>();
            Instalaciones = new ObservableRangeCollection<string>();
        }


    }
}
