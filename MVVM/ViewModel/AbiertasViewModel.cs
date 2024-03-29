﻿using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.MVVM.Model;

namespace Seguimiento.MVVM.ViewModel
{
    internal class AbiertasViewModel : ObservableObject
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

        #endregion

        #region comandos

        public Command CerrarComando { get; }

        public void Cerrar()
        {
            if (IncidenciaSeleccionada != null)
            
            {
                //objeto base de datos
                using var db = new IncidenciaContext();

                var result = db.Incidencias.First(b => (b.IncidenciaId == IncidenciaSeleccionada.IncidenciaId));

                if (result != null)
                {
                    result.HoraFin = DateTime.Now.ToString("HH:mm");
                    result.Estado = true;
                    db.SaveChanges();
                }

                ActualizarListado();
            } 
            

        }

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

        #endregion


        public void ActualizarListado()
        {
            if (Proyectos != null)
            {
                //objeto base de datos
                using var db = new IncidenciaContext();

                var query = db.Incidencias.Where(b => b.Proyecto == ProyectoSeleccionado && b.Estado == false);
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


        public AbiertasViewModel()
        {
            //inicializar colecciones
            Incidencias = new ObservableRangeCollection<Incidencia>();
            Proyectos = new ObservableRangeCollection<string>();

            //Comandos
            CerrarComando = new Command(Cerrar);
            BorrarComando = new Command(Borrar);

            //Popular tabla
            ActualizarListado();
            LeerProyectos();
        }
    }
}
