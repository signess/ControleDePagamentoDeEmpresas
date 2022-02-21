using ControleDePagamentoDeEmpresas.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ControleDePagamentoDeEmpresas
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        static DatabaseService database;
        public static DatabaseService Database
        {
            get
            {
                if(database == null)
                {
                    database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppDB.db3"));
                }
                return database;
            }
        }
    }
}
