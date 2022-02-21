using ControleDePagamentoDeEmpresas.Core;
using ControleDePagamentoDeEmpresas.MVVM.Model;
using ControleDePagamentoDeEmpresas.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControleDePagamentoDeEmpresas.MVVM.ViewModel
{
    public class CadastroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                NotifyPropertyChanged("nome");
            }
        }

        public IEnumerable<KeyValuePair<string, string>> LojaList
        {
            get
            {
                return EnumHelper.GetAllValuesAndDescriptions<Loja>();
            }
        }

        private Loja loja;

        public Loja Loja
        {
            get { return loja; }
            set
            {
                if (loja != value)
                {
                    loja = value;
                    NotifyPropertyChanged(nameof(loja));
                }
            }
        }

        public IEnumerable<KeyValuePair<string, string>> PrioridadeList
        {
            get
            {
                return EnumHelper.GetAllValuesAndDescriptions<Prioridade>();
            }
        }

        private Prioridade prioridade;

        public Prioridade Prioridade
        {
            get { return prioridade; }
            set
            {
                if (prioridade != value)
                {
                    prioridade = value;
                    NotifyPropertyChanged(nameof(prioridade));
                }
            }
        }

        private List<EmpresaModel> empresaList;

        public List<EmpresaModel> EmpresaList
        {
            get { return empresaList; }
            set
            {
                empresaList = value;
                NotifyPropertyChanged(nameof(empresaList));
            }
        }

        public ICommand cmdAddEmpresa { get; private set; }
        public ICommand cmdExcluirEmpresa { get; private set; }
        public ICommand cmdRefresh { get; private set; }

        public bool CanExecute
        {
            get { return !string.IsNullOrEmpty(Nome); }
        }

        public CadastroViewModel()
        {
            EmpresaList = new List<EmpresaModel>();
            cmdAddEmpresa = new RelayCommand(o =>
            {
                if (CanExecute)
                {
                    AddEmpresa();
                }
            });
            cmdExcluirEmpresa = new RelayCommand(o =>
            {
                DeleteEmpresa(o as EmpresaModel);
            });
            cmdRefresh = new RelayCommand(o =>
            {
                GetEmpresa();
            });
            GetEmpresa();
        }

        private async void AddEmpresa()
        {
            EmpresaModel novaEmpresa = new EmpresaModel
            {
                Nome = Nome,
                DataCompra = "",
                ValorCompra = 0,
                Imposto = 0,
                Loja = Loja,
                Prioridade = Prioridade
            };
            await Task.Run(() =>
            {
                SqliteDataAccess.SaveEmpresa(novaEmpresa);
                GetEmpresa();
            });
        }

        private async void DeleteEmpresa(EmpresaModel empresa)
        {
            if (MessageBox.Show("Deseja excluir esse Serviço?", "Excluir Serviço", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var task = Task.Run(async () => await SqliteDataAccess.DeleteEmpresa(empresa));

                if (!task.Result)
                {
                    MessageBox.Show("Erro na conexão. Operação nâo concluida!");
                }
                else
                {
                    MessageBox.Show("Excluído com sucesso!");
                    GetEmpresa();
                }
            }
        }

        public void GetEmpresa()
        {
            if (EmpresaList.Count > 0) EmpresaList.Clear();
            EmpresaList = SqliteDataAccess.LoadEmpresas();
        }
    }
}