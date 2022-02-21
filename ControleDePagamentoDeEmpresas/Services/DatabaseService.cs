using ControleDePagamentoDeEmpresas.MVVM.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDePagamentoDeEmpresas.Services
{
    public class DatabaseService
    {
        private readonly SQLite.SQLiteAsyncConnection _empresasDatabase;
        private readonly SQLite.SQLiteAsyncConnection[] _mesMotomixDatabase = new SQLite.SQLiteAsyncConnection[12];
        private readonly SQLite.SQLiteAsyncConnection[] _mesW4Database = new SQLite.SQLiteAsyncConnection[12];

        public DatabaseService(string dbPath)
        {
            _empresasDatabase = new SQLite.SQLiteAsyncConnection(dbPath);
            _empresasDatabase.CreateTableAsync<EmpresaModel>().Wait();
            for (int i = 0; i < 12; i++)
            {
                _mesMotomixDatabase[i] = new SQLite.SQLiteAsyncConnection(dbPath);
                _mesMotomixDatabase[i].CreateTableAsync<EmpresaModel>().Wait();

                _mesW4Database[i] = new SQLite.SQLiteAsyncConnection(dbPath);
                _mesW4Database[i].CreateTableAsync<EmpresaModel>().Wait();
            }
        }

        public Task<List<EmpresaModel>> GetEmpresaAsync()
        {
            return _empresasDatabase.Table<EmpresaModel>().OrderBy(x => x.Id).ToListAsync();
        }

        public Task<List<EmpresaModel>> GetEmpresaByMesAsync_Motomix(int index)
        {
            return _mesMotomixDatabase[index].Table<EmpresaModel>().OrderBy(x => x.Id).ToListAsync();
        }

        public Task<List<EmpresaModel>> GetEmpresaByMesAsync_W4(int index)
        {
            return _mesW4Database[index].Table<EmpresaModel>().OrderBy(x => x.Id).ToListAsync();
        }

        public Task<int> SaveEmpresaAsync(EmpresaModel empresa)
        {
            if (empresa.Loja == Loja.Motomix)
            {
                switch (empresa.Prioridade)
                {
                    case Prioridade.Mensal:
                        for (int i = 0; i < 12; i++)
                        {
                            _mesMotomixDatabase[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.DoisMeses:
                        for (int i = 0; i < 12; i += 2)
                        {
                            _mesMotomixDatabase[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.TresMeses:
                        for (int i = 0; i < 12; i += 3)
                        {
                            _mesMotomixDatabase[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.QuandoPrecisar:
                        break;
                }
            }
            else if (empresa.Loja == Loja.W4)
            {
                switch (empresa.Prioridade)
                {
                    case Prioridade.Mensal:
                        for (int i = 0; i < 12; i++)
                        {
                            _mesW4Database[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.DoisMeses:
                        for (int i = 0; i < 12; i += 2)
                        {
                            _mesW4Database[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.TresMeses:
                        for (int i = 0; i < 12; i += 3)
                        {
                            _mesW4Database[i].InsertAsync(empresa).Wait();
                        }
                        break;

                    case Prioridade.QuandoPrecisar:
                        break;
                }
            }
            return _empresasDatabase.InsertAsync(empresa);
        }

        public Task<int> DeleteEmpresaAsync(EmpresaModel empresa)
        {
            for (int i = 0; i < 12; i++)
            {
                _mesMotomixDatabase[i].DeleteAsync(empresa).Wait();
                _mesW4Database[i].DeleteAsync(empresa).Wait();
            }
            return _empresasDatabase.DeleteAsync(empresa);
        }

        public Task<int> DeleteAllAsync()
        {
            for (int i = 0; i < 12; i++)
            {
                _mesMotomixDatabase[i].DeleteAllAsync<EmpresaModel>().Wait();
                _mesW4Database[i].DeleteAllAsync<EmpresaModel>().Wait();

                _mesMotomixDatabase[i].DropTableAsync<EmpresaModel>().Wait();
                _mesMotomixDatabase[i].CreateTableAsync<EmpresaModel>().Wait();

                _mesW4Database[i].DropTableAsync<EmpresaModel>().Wait();
                _mesW4Database[i].CreateTableAsync<EmpresaModel>().Wait();
            }
            
            _empresasDatabase.DropTableAsync<EmpresaModel>().Wait();
            _empresasDatabase.CreateTableAsync<EmpresaModel>().Wait();
            return _empresasDatabase.DeleteAllAsync<EmpresaModel>();
        }
    }
}