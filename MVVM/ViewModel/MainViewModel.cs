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
        public Command HomeViewCommand { get; set; }

        public Command NuevaViewCommand { get; set; }

        public Command AjustesViewCommand { get; set; }

        //Propiedades instancias viewmodels
        public HomeViewModel HomeVM { get; set; }

        public NuevaViewModel NuevaVM { get; set; }

        public AjustesViewModel AjustesVM { get; set; }

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
            HomeVM = new HomeViewModel();
            NuevaVM = new NuevaViewModel();
            AjustesVM = new AjustesViewModel();

            //Inicializar primera vista
            CurrentView = NuevaVM;

            //Relay Commands
            HomeViewCommand = new Command(o => 
            {
                CurrentView = HomeVM;
            });

            NuevaViewCommand = new Command(o =>
            {
                CurrentView = NuevaVM;
            });

            AjustesViewCommand = new Command(o =>
            {
                CurrentView = AjustesVM;
            });
        }

    }
}
