using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.MVVM.Model;
using System.Reflection.Metadata;
using System.Windows;

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

        //Produccion
        string _Produccion = "";
        public string Produccion
        {
            get => _Produccion;
            set => SetProperty(ref _Produccion, value);
        }

        #endregion


        #region comandos

        public Command GuardarComando { get; }
        
        public void Guardar()
        {
            //objeto base de datos
            using var db = new IncidenciaContext();

            //Inicializar incidencia
            Incidencia inc = new Incidencia();

            //Rellenar valores de sus propiedades
            if (TextoIncidencia != null && Instalacion != null && Proyecto != null)
            {
                inc.Texto = TextoIncidencia;
                inc.Estado = false;
                inc.Instalacion = Instalacion;
                inc.HoraInicio = DateTime.Now.ToString("HH:mm");
                if (Proyecto != "") inc.Proyecto = Proyecto;
                else inc.Proyecto = "1";
                inc.Produccion = Produccion;

                //añadir incidencia a la base de datos
                db.Add(inc); ;
                db.SaveChanges();

                TextoIncidencia = null;
                Instalacion = null;
                Proyecto = null;
                Produccion = null;
            }
            else
            {
                MessageBox.Show("Los campos \"Proyecto\", \"Instalación\" y la incidencia no pueden estar vacios");
            }

            
        }

        #endregion


        public NuevaViewModel()
        {

            //inicialización de comandos
            GuardarComando = new Command(Guardar);
        }



    }
}
