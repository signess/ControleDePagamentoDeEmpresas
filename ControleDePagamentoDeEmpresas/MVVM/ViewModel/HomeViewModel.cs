using ControleDePagamentoDeEmpresas.Core;
using ControleDePagamentoDeEmpresas.MVVM.Model;
using ControleDePagamentoDeEmpresas.MVVM.View;
using ControleDePagamentoDeEmpresas.Services;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
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
        public ICommand ExportarCommand { get; private set; }

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

            AddCommand = new RelayCommand(args =>
            {
                AddEmpresaWindow addEmpresaWindow = new AddEmpresaWindow(MesIndex, Loja.Motomix);
                addEmpresaWindow.Closed += (s, eventarg) =>
                {
                    GetEmpresa();
                };
                addEmpresaWindow.Show();
            });

            EditarEmpresaCommand = new RelayCommand(args =>
            {
                EditarEmpresaWindow editarEmpresaWindow = new EditarEmpresaWindow(args as EmpresaModel, MesIndex, Loja.Motomix);
                editarEmpresaWindow.Closed += (s, eventarg) =>
                {
                    GetEmpresa();
                };
                editarEmpresaWindow.Show();
            });

            ExportarCommand = new RelayCommand(o =>
            {
                DataGrid dataGrid = o as DataGrid;
                if (dataGrid != null)
                    Export(dataGrid);
                else
                    return;
            });
   

        }

        public void GetEmpresa()
        {
            if (EmpresaList.Count > 0) EmpresaList.Clear();
            EmpresaList = new ObservableCollection<EmpresaModel>(SqliteDataAccess.LoadEmpresasMotomix(MesIndex));
            Somar();
        }


        private void Somar()
        {
            CompraTotal = EmpresaList.Sum(x => x.ValorCompra);
            ImpostoTotal = EmpresaList.Sum(x => x.Imposto);
            TotalFinal = CompraTotal + ImpostoTotal;
        }

        private void Export(DataGrid dataGrid)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true; //www.yazilimkodlama.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            sheet1.Name = ChecarMes(MesIndex);

            for (int j = 0; j < dataGrid.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = dataGrid.Columns[j].Header;
            }
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                for (int j = 0; j < dataGrid.Items.Count; j++)
                {
                    TextBlock b = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
            Range myLast = sheet1.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            int myLastRow = myLast.Row;
            int myLastColumn = myLast.Column;

            Range myLine = (Range)sheet1.Cells[myLastRow + 1, 4];
            sheet1.Cells[myLastRow + 1, 4].Font.Bold = true;
            sheet1.Cells[myLastRow + 1, 4].Style = "Currency";
            myLine.Value2 = CompraTotal;
            myLine = (Range)sheet1.Cells[myLastRow + 1, 5];
            sheet1.Cells[myLastRow + 1, 5].Font.Bold = true;
            sheet1.Cells[myLastRow + 1, 5].Style = "Currency";
            myLine.Value2 = ImpostoTotal;
            myLine = (Range)sheet1.Cells[myLastRow + 1, 6];
            sheet1.Cells[myLastRow + 1, 6].Font.Bold = true;
            sheet1.Cells[myLastRow + 1, 6].Style = workbook.Styles["Currency"];
            myLine.Value2 = TotalFinal;
        }


        private string ChecarMes(int index)
        {
            if (index == 0)
                return "Janeiro";
            else if (index == 1)
                return "Fevereiro";
            else if (index == 2)
                return "Março";
            else if (index == 3)
                return "Abril";
            else if (index == 4)
                return "Maio";
            else if (index == 5)
                return "Junho";
            else if (index == 6)
                return "Julho";
            else if (index == 7)
                return "Agosto";
            else if (index == 8)
                return "Setembro";
            else if (index == 9)
                return "Outubro";
            else if (index == 10)
                return "Novembro";
            else if (index == 11)
                return "Dezembro";
            else
                return "Default";
        }
    }
}
