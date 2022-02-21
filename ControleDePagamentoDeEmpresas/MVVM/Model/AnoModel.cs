using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePagamentoDeEmpresas.MVVM.Model
{
    public enum Mes
    {
        Indefinido,
        Janeiro,
        Fevereiro,
        Marco,
        Abril,
        Maio,
        Junho,
        Julho,
        Agosto,
        Setembro,
        Outubro,
        Novembro,
        Dezembro
    }
    public class AnoModel
    {
        public int Ano { get; set; }
        public MesModel[] MesList { get; set; }
    }
}
