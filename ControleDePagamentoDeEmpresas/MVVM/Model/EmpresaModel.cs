using System.ComponentModel;

namespace ControleDePagamentoDeEmpresas.MVVM.Model
{
    public enum Prioridade 
    { 
        [Description("1- Todo Mês")]
        Mensal, 
        [Description("2- A Cada Dois Meses")]
        DoisMeses,
        [Description("3- A Cada Três Meses")]
        TresMeses,
        [Description("4- Quando Precisar")]
        QuandoPrecisar
    }
    public enum Loja
    {
        [Description("Motomix - Campo Grande")]
        Motomix,
        [Description("W4 - Dourados")]
        W4,
    }
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal Imposto { get; set; }
        public Loja Loja { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
