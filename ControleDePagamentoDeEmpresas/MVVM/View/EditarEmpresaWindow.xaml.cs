using ControleDePagamentoDeEmpresas.MVVM.Model;
using ControleDePagamentoDeEmpresas.Services;
using System;
using System.Windows;

namespace ControleDePagamentoDeEmpresas.MVVM.View
{
    /// <summary>
    /// Lógica interna para EditarEmpresaWindow.xaml
    /// </summary>
    public partial class EditarEmpresaWindow : Window
    {
        private EmpresaModel _empresa;
        private int _index;
        private Loja _loja;

        public EditarEmpresaWindow(EmpresaModel empresa, int index, Loja loja)
        {
            InitializeComponent();
            _empresa = empresa;
            _loja = loja;
            EmpresaBox.Text = empresa.Nome;
            DataCompraBox.Text = empresa.DataCompra;
            ValorCompraBox.Text = empresa.ValorCompra.ToString();
            ImpostoBox.Text = empresa.Imposto.ToString();

            _index = index;
        }

        private void ExcluirBtn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja excluir essa entrada?", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (_loja == Loja.Motomix)
                    SqliteDataAccess.DeleteEmpresaMotomix(_empresa, _index);
                else if (_loja == Loja.W4)
                    SqliteDataAccess.DeleteEmpresaW4(_empresa, _index);

                MessageBox.Show("Excluído!");
                Close();
            }
        }

        private void FinalizarBtn(object sender, RoutedEventArgs e)
        {
            EmpresaModel novaEmpresa = new EmpresaModel { Id = _empresa.Id, Nome = EmpresaBox.Text, DataCompra = DataCompraBox.Text, ValorCompra = Convert.ToDecimal(ValorCompraBox.Text), Imposto = Convert.ToDecimal(ImpostoBox.Text), Loja = _empresa.Loja, Prioridade = _empresa.Prioridade };
            SqliteDataAccess.UpdateEmpresa(novaEmpresa, _index, _loja);
            this.Close();
        }
    }
}