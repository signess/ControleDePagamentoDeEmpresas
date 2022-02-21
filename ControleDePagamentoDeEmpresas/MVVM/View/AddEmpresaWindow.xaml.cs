using ControleDePagamentoDeEmpresas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControleDePagamentoDeEmpresas.MVVM.View
{
    /// <summary>
    /// Lógica interna para AddEmpresaWindow.xaml
    /// </summary>
    public partial class AddEmpresaWindow : Window
    {
        public ICommand AddEmpresaCommand { get; private set; }
        public AddEmpresaWindow()
        {
            InitializeComponent();
            AddEmpresaCommand = new RelayCommand(o =>
            {
                
            });
        }
    }
}
