using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command = MvvmHelpers.Commands.Command;

namespace Seguimiento.MVVM.ViewModel
{
    class AjustesViewModel : MvvmHelpers.ObservableObject
    {

        #region Propiedades

        public ObservableRangeCollection<String> ContenidoLista { get;}

        public Command agregarPlantilla { get; }

        #endregion


        #region Metodos

        void AgregarPlantilla()
        {
            //Todo: Añadir plantilla a la BBDD y actualizar la lista de plantillas

            ActualizarPlantillas();
        }

        void ActualizarPlantillas()
        {
            //Todo: Actualizar la lista de plantillas con la BBDD
        }

        #endregion

        public AjustesViewModel()
        {
            ContenidoLista = new ObservableRangeCollection<string>();

            agregarPlantilla = new Command(AgregarPlantilla);

        }








    }
}
