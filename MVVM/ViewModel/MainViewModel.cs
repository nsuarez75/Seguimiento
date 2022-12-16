using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Seguimiento.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        //Comandos cambio página

        public Command NuevaViewCommand { get; set; }

        public Command ListadoViewCommand { get; set; }

        public Command AbiertasViewCommand { get; set; }

        //Propiedades instancias viewmodels

        public NuevaViewModel NuevaVM { get; set; }

        public ListadoViewModel ListadoVM { get; set; }

        public AbiertasViewModel AbiertasVM { get; set; }


        //propiedad que recibe la vista actual
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            NuevaVM = new NuevaViewModel();
            ListadoVM = new ListadoViewModel();
            AbiertasVM = new AbiertasViewModel();

            //Inicializar primera vista
            CurrentView = NuevaVM;

            //Relay Commands
            NuevaViewCommand = new Command(o =>
            {
                CurrentView = NuevaVM;
            });

            ListadoViewCommand = new Command(o =>
            {
                CurrentView = ListadoVM;
            });

            AbiertasViewCommand = new Command(o =>
            {
                CurrentView = AbiertasVM;
            });

        }

    }
}
