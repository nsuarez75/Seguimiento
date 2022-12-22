using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.MVVM.Model
{
   
    public class Incidencia
    {
        public int IncidenciaId { get; set; }

        public string Texto { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFin { get; set; }

        public string Instalacion { get; set; }

        public string Proyecto { get; set; } = "1";

        public string Produccion { get; set; }

        public bool Estado { get; set; }


    }
}
