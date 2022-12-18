using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.MVVM.Model;
using System.Reflection.Metadata;

namespace Seguimiento.MVVM.ViewModel
{
    class NuevaViewModel : ObservableObject
    {
          

        #region propiedades

        //Texto de la incidencia
        string _Texto = "";
        public string TextoIncidencia
        {
            get => _Texto;
            set => SetProperty(ref _Texto, value);
        }

        //Instalacion
        string _Instalacion = "";
        public string Instalacion
        {
            get => _Instalacion;
            set => SetProperty(ref _Instalacion, value);
        }

        //Proyecto
        string _Proyecto = "";
        public string Proyecto
        {
            get => _Proyecto;
            set => SetProperty(ref _Proyecto, value);
        }

        #endregion


        #region comandos

        public Command GuardarComando { get; }
        
        public void Guardar()
        {
            //objeto base de datos
            using var db = new IncidenciaContext();

            //añadir incidencia a la base de datos
            db.Add(new Incidencia 
            {   Texto =  TextoIncidencia, 
                Estado = false, 
                Instalacion = Instalacion, 
                HoraInicio = DateTime.Now.ToString("HH:mm"),
                Proyecto = Proyecto
                });
            db.SaveChanges();

        }

        #endregion


        public NuevaViewModel()
        {

            //inicialización de comandos
            GuardarComando = new Command(Guardar);
        }



    }
}
