using ControleDePagamentoDeEmpresas.Core;

namespace ControleDePagamentoDeEmpresas.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CadastroViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CadastroViewModel CadastroVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CadastroVM = new CadastroViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            CadastroViewCommand = new RelayCommand(o =>
            {
                CurrentView = CadastroVM;
            });
        }
    }
}