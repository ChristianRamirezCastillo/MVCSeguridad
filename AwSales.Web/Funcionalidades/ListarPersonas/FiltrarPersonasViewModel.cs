using System.Collections.Generic;

namespace AwSales.Web.Funcionalidades.ListarPersonas
{
    public class FiltrarPersonasViewModel
    {
        public string Filtro { get; set; }
        public IEnumerable<ListaPersonasViewModel> Personas {get; set;}

        public FiltrarPersonasViewModel()
        {
            Personas = new List<ListaPersonasViewModel>();
        }
    }
}
