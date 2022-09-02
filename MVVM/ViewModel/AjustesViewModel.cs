using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.MVVM.ViewModel
{
    class AjustesViewModel : MvvmHelpers.ObservableObject
    {

        public ObservableRangeCollection<String> ContenidoLista { get;}

        public AjustesViewModel()
        {
            ContenidoLista = new ObservableRangeCollection<string>();
            ContenidoLista.Add("prueba1");
            ContenidoLista.Add("prueba12");


        }

    }
}
