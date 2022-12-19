using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.MVVM.Model;
using System.Windows.Controls;

namespace Seguimiento.MVVM.ViewModel
{
    internal class ListadoViewModel : ObservableObject
    {

        // Colecciones
        public ObservableRangeCollection<Incidencia> Incidencias { get; set; }
        public ObservableRangeCollection<string> Proyectos { get; set; }

        #region propiedades

        //Incidencia seleccionada
        Incidencia _IncidenciaSeleccionada;
        public Incidencia IncidenciaSeleccionada
        {
            get => _IncidenciaSeleccionada;
            set => SetProperty(ref _IncidenciaSeleccionada, value);
        }

        //Proyecto seleccionado
        string _ProyectoSeleccionado;
        public string ProyectoSeleccionado
        {
            get => _ProyectoSeleccionado;
            set
            {
                if (value == _ProyectoSeleccionado)
                    return;
                _ProyectoSeleccionado = value;
                OnPropertyChanged();
                ActualizarListado();
            }
        }

        //Nueva Hora Inicio
        string _NuevaHoraInicio;
        public string NuevaHoraInicio
        {
            get => _NuevaHoraInicio;
            set => SetProperty(ref _NuevaHoraInicio, value);
        }

        //Nueva Hora Fin
        string _NuevaHoraFin;
        public string NuevaHoraFin
        {
            get => _NuevaHoraFin;
            set => SetProperty(ref _NuevaHoraFin, value);
        }

        #endregion

        #region comandos

        public Command BorrarComando { get; }

        public void Borrar()
        {
            if (IncidenciaSeleccionada != null)
            {
                //objeto base de datos
                using var db = new IncidenciaContext();

                var result = db.Incidencias.First(b => (b.IncidenciaId == IncidenciaSeleccionada.IncidenciaId));

                if (result != null)
                {
                    db.Incidencias.Remove(result);
                    db.SaveChanges();
                }

                LeerProyectos();
                ActualizarListado();
            }                     
                
        }

        public Command ExportarComando { get; }

        public void Exportar()
        {
            if (ProyectoSeleccionado != null )
            {
                ExcelModel hoja = new ExcelModel();
                hoja.GenerarExcel(Incidencias);

            }

        }

        public Command ModificarComando { get; }

        public void Modificar()
        {
            if (IncidenciaSeleccionada != null)

            {
                //objeto base de datos
                using var db = new IncidenciaContext();
                
                var result = db.Incidencias.First(b => (b.IncidenciaId == IncidenciaSeleccionada.IncidenciaId));

                if (result != null)
                {
                    if (NuevaHoraInicio != null) result.HoraInicio = NuevaHoraInicio;
                    if (NuevaHoraFin != null) result.HoraFin = NuevaHoraFin;
                    db.SaveChanges();
                }

                ActualizarListado();

                NuevaHoraFin = null;
                NuevaHoraInicio = null;
            }

        }

        #endregion

        public void ActualizarListado()
        {
            if (Proyectos != null)
            {
                //objeto base de datos
                using var db = new IncidenciaContext();

                var query = db.Incidencias.Where(b => b.Proyecto == ProyectoSeleccionado);
                Incidencias.Clear();
                foreach (Incidencia Inc in query)
                {
                    Incidencias.Add(Inc);
                }
            }

        }

        public void LeerProyectos()
        {
            //objeto base de datos
            using var db = new IncidenciaContext();

            var query = db.Incidencias;
            foreach (Incidencia Inc in query)
            {
                if (Proyectos.Contains(Inc.Proyecto) != true) Proyectos.Add(Inc.Proyecto);
            }
        }

        public ListadoViewModel()
        {
            //inicializar colecciones
            Incidencias = new ObservableRangeCollection<Incidencia>();
            Proyectos = new ObservableRangeCollection<string>();

            //Comandos
            BorrarComando = new Command(Borrar);
            ExportarComando = new Command(Exportar);
            ModificarComando = new Command(Modificar);

            //Popular tabla
            ActualizarListado();
            LeerProyectos();
        }



    }
}
