using ControleDePagamentoDeEmpresas.Core;

namespace ControleDePagamentoDeEmpresas.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand W4ViewCommand { get; set; }
        public RelayCommand CadastroViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public W4ViewModel W4VM { get; set; }
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
            W4VM = new W4ViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(_ =>
            {
                HomeVM = new HomeViewModel();
                CurrentView = HomeVM;
            });
            W4ViewCommand = new RelayCommand(_ =>
            {
                W4VM = new W4ViewModel();
                CurrentView = W4VM;
            });
            CadastroViewCommand = new RelayCommand(_ =>
            {
                CadastroVM = new CadastroViewModel();
                CurrentView = CadastroVM;
            });
        }
    }
}