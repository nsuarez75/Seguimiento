using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.MVVM.Model
{
    internal class Incidencia
    {


        public string Texto { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public string Anotador { get; set; }

        public string Instalacion { get; set; } 

        public string Proyecto { get; set; }

        public string Plantilla { get; set; }

        public bool Estado { get; set; }
    }
}
