﻿using ControleDePagamentoDeEmpresas.Core;
using ControleDePagamentoDeEmpresas.MVVM.Model;
using ControleDePagamentoDeEmpresas.MVVM.View;
using ControleDePagamentoDeEmpresas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControleDePagamentoDeEmpresas.MVVM.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<EmpresaModel> empresaList;
        public ObservableCollection<EmpresaModel> EmpresaList
        {
            get { return empresaList; }
            set
            {
                empresaList = value;
                NotifyPropertyChanged(nameof(empresaList));
            }
        }

        private int mesIndex;
        public int MesIndex
        {
            get { return mesIndex; }
            set
            {
                mesIndex = value;
                NotifyPropertyChanged(nameof(mesIndex));
            }
        }

        private decimal compraTotal;
        public decimal CompraTotal
        {
            get { return compraTotal; }
            set
            {
                compraTotal = value;
                NotifyPropertyChanged(nameof(compraTotal));
            }
        }
        private decimal impostoTotal;
        public decimal ImpostoTotal
        {
            get { return impostoTotal; }
            set
            {
                impostoTotal = value;
                NotifyPropertyChanged(nameof(impostoTotal));
            }
        }
        private decimal totalFinal;
        public decimal TotalFinal
        {
            get { return totalFinal; }
            set
            {
                totalFinal = value;
                NotifyPropertyChanged(nameof(totalFinal));
            }
        }
        public ICommand EditarEmpresaCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand JanCommand { get; private set; }
        public ICommand FevCommand { get; private set; }
        public ICommand MarCommand { get; private set; }
        public ICommand AbrCommand { get; private set; }
        public ICommand MaiCommand { get; private set; }
        public ICommand JunCommand { get; private set; }
        public ICommand JulCommand { get; private set; }
        public ICommand AgoCommand { get; private set; }
        public ICommand SetCommand { get; private set; }
        public ICommand OutCommand { get; private set; }
        public ICommand NovCommand { get; private set; }
        public ICommand DezCommand { get; private set; }

        public HomeViewModel()
        {
            EmpresaList = new ObservableCollection<EmpresaModel>();
            MesIndex = 0;
            GetEmpresa();

            RefreshCommand = new RelayCommand(o =>
            {
                GetEmpresa();
            });

            JanCommand = new RelayCommand(o =>
            {
                MesIndex = 0;
                GetEmpresa();
            });
            FevCommand = new RelayCommand(o =>
            {
                MesIndex = 1;
                GetEmpresa();
            });

            MarCommand = new RelayCommand(o =>
            {
                MesIndex = 2;
                GetEmpresa();
            });
            AbrCommand = new RelayCommand(o =>
            {
                MesIndex = 3;
                GetEmpresa();
            });
            MaiCommand = new RelayCommand(o =>
            {
                MesIndex = 4;
                GetEmpresa();
            });
            JunCommand = new RelayCommand(o =>
            {
                MesIndex = 5;
                GetEmpresa();
            });
            JulCommand = new RelayCommand(o =>
            {
                MesIndex = 6;
                GetEmpresa();
            });
            AgoCommand = new RelayCommand(o =>
            {
                MesIndex = 7;
                GetEmpresa();
            });
            SetCommand = new RelayCommand(o =>
            {
                MesIndex = 8;
                GetEmpresa();
            });
            OutCommand = new RelayCommand(o =>
            {
                MesIndex = 9;
                GetEmpresa();
            });
            NovCommand = new RelayCommand(o =>
            {
                MesIndex = 10;
                GetEmpresa();
            });
            DezCommand = new RelayCommand(o =>
            {
                MesIndex = 11;
                GetEmpresa();
            });

            EditarEmpresaCommand = new RelayCommand(args =>
            {
                AddEmpresaWindow addEmpresaWindow = new AddEmpresaWindow(args as EmpresaModel, MesIndex);
                addEmpresaWindow.Closed += (s, eventarg) =>
                {
                    GetEmpresa();
                };
                addEmpresaWindow.Show();
            });

            AddCommand = new RelayCommand(args =>
            {
                EditarEmpresaWindow editarEmpresaWindow = new EditarEmpresaWindow(args as EmpresaModel, MesIndex);
                editarEmpresaWindow.Closed += (s, eventarg) =>
                {
                    GetEmpresa();
                };
                editarEmpresaWindow.Show();
            });

        }

        public async void GetEmpresa()
        {
            if (EmpresaList.Count > 0) EmpresaList.Clear();
            await Task.Run(() => EmpresaList = new ObservableCollection<EmpresaModel>(SqliteDataAccess.LoadEmpresasMotomix(MesIndex)));
            Somar();
        }

        private void Somar()
        {
            CompraTotal = EmpresaList.Sum(x => x.ValorCompra);
            ImpostoTotal = EmpresaList.Sum(x => x.Imposto);
            TotalFinal = CompraTotal + ImpostoTotal;
        }
    }
}