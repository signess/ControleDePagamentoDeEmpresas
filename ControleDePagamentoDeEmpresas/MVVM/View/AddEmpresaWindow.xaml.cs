using ControleDePagamentoDeEmpresas.Core;
using ControleDePagamentoDeEmpresas.MVVM.Model;
using ControleDePagamentoDeEmpresas.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControleDePagamentoDeEmpresas.MVVM.View
{
    /// <summary>
    /// Lógica interna para AddEmpresaWindow.xaml
    /// </summary>
    public partial class AddEmpresaWindow : Window
    {
        private Loja _loja;
        private List<EmpresaModel> empresaList;
        public List<EmpresaModel> EmpresaList
        {
            get => empresaList;
            private set
            {
                empresaList = value;
            }
        }
        private int _index;

        public AddEmpresaWindow(int index, Loja loja)
        {
            InitializeComponent();
            _loja = loja;
            if (loja == Loja.Motomix)
                EmpresaList = SqliteDataAccess.LoadEmpresas().Where(x => x.Loja == Loja.Motomix || x.Loja == Loja.Todas).ToList();
            else if (loja == Loja.W4)
                EmpresaList = SqliteDataAccess.LoadEmpresas().Where(x => x.Loja == Loja.W4 || x.Loja == Loja.Todas).ToList();
            Empresas.ItemsSource = EmpresaList;
            _index = index;
        }

        private void AddEmpresa(object sender, MouseButtonEventArgs e)
        {
            if (Empresas.SelectedItem == null) return;
            var selectedEmpresa = Empresas.SelectedItem as EmpresaModel;
            SqliteDataAccess.SaveEmpresa(selectedEmpresa, _index, _loja);
            this.Close();
        }
    }
}