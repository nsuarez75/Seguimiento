using Seguimiento.Core;
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
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand NuevaViewCommand { get; set; }

        //Propiedades instancias viewmodels
        public HomeViewModel HomeVM { get; set; }

        public NuevaViewModel NuevaVM { get; set; }

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

            //Inicializar primera vista
            CurrentView = HomeVM;

            //Relay Commands
            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            NuevaViewCommand = new RelayCommand(o =>
            {
                CurrentView = NuevaVM;
            });
        }

    }
}
