using ControleDePagamentoDeEmpresas.MVVM.Model;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePagamentoDeEmpresas.Services
{
    public static class SqliteDataAccess
    {
        public static List<EmpresaModel> LoadEmpresas()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EmpresaModel>("select * from Empresas", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<EmpresaModel> LoadEmpresasMotomix(int index)
        {
            if (index == 0)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from JaneiroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 1)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from FevereiroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 2)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from MarcoMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 3)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from AbrilMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 4)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from MaioMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 5)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from JunhoMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 6)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from JulhoMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 7)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from AgostoMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 8)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from SetembroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 9)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from OutubroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 10)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from NovembroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else if (index == 11)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<EmpresaModel>("select * from DezembroMotomix", new DynamicParameters());
                    return output.ToList();
                }
            }
            else
            {
                return null;
            }
        }

        public static async void SaveEmpresa(EmpresaModel empresa)
        {
            await Task.Run(() =>
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("insert into Empresas (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                }

                if (empresa.Loja == Loja.Motomix)
                {
                    if (empresa.Prioridade == Prioridade.Mensal)
                    {
                        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                        {
                            cnn.Execute("insert into JaneiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into FevereiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into MarcoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into AbrilMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into MaioMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into JunhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into JulhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into AgostoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into SetembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into OutubroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into NovembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into DezembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                        }
                    }
                    else if (empresa.Prioridade == Prioridade.DoisMeses)
                    {
                        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                        {
                            cnn.Execute("insert into JaneiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into MarcoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into MaioMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into JulhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into SetembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into NovembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                        }
                    }
                    else if (empresa.Prioridade == Prioridade.TresMeses)
                    {
                        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                        {
                            cnn.Execute("insert into JaneiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into AbrilMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into JulhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                            cnn.Execute("insert into OutubroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            });
        }

        public static void SaveEmpresa(EmpresaModel empresa, int index)
        {
            if (empresa.Loja == Loja.Motomix)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (index == 0)
                        cnn.Execute("insert into JaneiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 1)
                        cnn.Execute("insert into FevereiroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 2)
                        cnn.Execute("insert into MarcoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 3)
                        cnn.Execute("insert into AbrilMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 4)
                        cnn.Execute("insert into MaioMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 5)
                        cnn.Execute("insert into JunhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 6)
                        cnn.Execute("insert into JulhoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 7)
                        cnn.Execute("insert into AgostoMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 8)
                        cnn.Execute("insert into SetembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 9)
                        cnn.Execute("insert into OutubroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 10)
                        cnn.Execute("insert into NovembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 11)
                        cnn.Execute("insert into DezembroMotomix (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                }
            }
            else if (empresa.Loja == Loja.W4)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (index == 0)
                        cnn.Execute("insert into JaneiroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 1)
                        cnn.Execute("insert into FevereiroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 2)
                        cnn.Execute("insert into MarcoW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 3)
                        cnn.Execute("insert into AbrilW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 4)
                        cnn.Execute("insert into MaioW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 5)
                        cnn.Execute("insert into JunhoW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 6)
                        cnn.Execute("insert into JulhoW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 7)
                        cnn.Execute("insert into AgostoW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 8)
                        cnn.Execute("insert into SetembroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 9)
                        cnn.Execute("insert into OutubroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 10)
                        cnn.Execute("insert into NovembroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                    else if (index == 11)
                        cnn.Execute("insert into DezembroW4 (Nome, DataCompra, ValorCompra, Imposto, Loja, Prioridade) values (@Nome, @DataCompra, @ValorCompra, @Imposto, @Loja, @Prioridade)", empresa);
                }
            }
        }

        public static void UpdateEmpresa(EmpresaModel empresa, int index)
        {
            if (empresa.Loja == Loja.Motomix)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (index == 0)
                        cnn.Execute("update JaneiroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 1)
                        cnn.Execute("update FevereiroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 2)
                        cnn.Execute("update MarcoMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 3)
                        cnn.Execute("update AbrilMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 4)
                        cnn.Execute("update MaioMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 5)
                        cnn.Execute("update JunhoMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 6)
                        cnn.Execute("update JulhoMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 7)
                        cnn.Execute("update AgostoMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 8)
                        cnn.Execute("update SetembroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 9)
                        cnn.Execute("update OutubroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 10)
                        cnn.Execute("update NovembroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 11)
                        cnn.Execute("update DezembroMotomix set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                }
            }
            else if(empresa.Loja == Loja.W4)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (index == 0)
                        cnn.Execute("update JaneiroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 1)
                        cnn.Execute("update FevereiroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 2)
                        cnn.Execute("update MarcoW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 3)
                        cnn.Execute("update AbrilW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 4)
                        cnn.Execute("update MaioW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 5)
                        cnn.Execute("update JunhoW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 6)
                        cnn.Execute("update JulhoW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 7)
                        cnn.Execute("update AgostoW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 8)
                        cnn.Execute("update SetembroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 9)
                        cnn.Execute("update OutubroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 10)
                        cnn.Execute("update NovembroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                    else if (index == 11)
                        cnn.Execute("update DezembroW4 set Nome = @Nome, DataCompra = @DataCompra, ValorCompra = @ValorCompra, Imposto = @Imposto where Nome = @Nome and Id = @Id", empresa);
                }
            }
        }

            public static async Task<bool> DeleteEmpresa(EmpresaModel empresa)
        {
            if (empresa.Loja == Loja.Motomix)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("delete from Empresas where Nome = @Nome", empresa);
                    cnn.Execute("delete from JaneiroMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from FevereiroMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from MarcoMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from AbrilMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from MaioMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from JunhoMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from JulhoMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from AgostoMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from SetembroMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from OutubroMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from NovembroMotomix where Nome = @Nome", empresa);
                    cnn.Execute("delete from DezembroMotomix where Nome = @Nome", empresa);
                    return true;
                }
            }
            else if (empresa.Loja == Loja.W4)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("delete from Empresas where Nome = @Nome", empresa);
                    cnn.Execute("delete from JaneiroW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from FevereiroW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from MarcoW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from AbrilW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from MaioW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from JunhoW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from JulhoW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from AgostoW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from SetembroW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from OutubroW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from NovembroW4 where Nome = @Nome", empresa);
                    cnn.Execute("delete from DezembroW4 where Nome = @Nome", empresa);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> DeleteEmpresa(EmpresaModel empresa, int index)
        {
            if (empresa.Loja == Loja.Motomix)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (index == 0)
                        cnn.Execute("delete from JaneiroMotomix where Nome = @Nome", empresa);
                    else if (index == 1)
                        cnn.Execute("delete from FevereiroMotomix where Nome = @Nome", empresa);
                    else if (index == 2)
                        cnn.Execute("delete from MarcoMotomix where Nome = @Nome", empresa);
                    else if (index == 3)
                        cnn.Execute("delete from AbrilMotomix where Nome = @Nome", empresa);
                    else if (index == 4)
                        cnn.Execute("delete from MaioMotomix where Nome = @Nome", empresa);
                    else if (index == 5)
                        cnn.Execute("delete from JunhoMotomix where Nome = @Nome", empresa);
                    else if (index == 6)
                        cnn.Execute("delete from JulhoMotomix where Nome = @Nome", empresa);
                    else if (index == 7)
                        cnn.Execute("delete from AgostoMotomix where Nome = @Nome", empresa);
                    else if (index == 8)
                        cnn.Execute("delete from SetembroMotomix where Nome = @Nome", empresa);
                    else if (index == 9)
                        cnn.Execute("delete from OutubroMotomix where Nome = @Nome", empresa);
                    else if (index == 10)
                        cnn.Execute("delete from NovembroMotomix where Nome = @Nome", empresa);
                    else if (index == 11)
                        cnn.Execute("delete from DezembroMotomix where Nome = @Nome", empresa);
                    return true;
                }
            }
            else if (empresa.Loja == Loja.W4)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if(index == 0)
                    cnn.Execute("delete from JaneiroW4 where Nome = @Nome", empresa);
                    else if (index == 1)
                        cnn.Execute("delete from FevereiroW4 where Nome = @Nome", empresa);
                    else if (index == 2)
                        cnn.Execute("delete from MarcoW4 where Nome = @Nome", empresa);
                    else if (index == 3)
                        cnn.Execute("delete from AbrilW4 where Nome = @Nome", empresa);
                    else if (index == 4)
                        cnn.Execute("delete from MaioW4 where Nome = @Nome", empresa);
                    else if (index == 5)
                        cnn.Execute("delete from JunhoW4 where Nome = @Nome", empresa);
                    else if (index == 6)
                        cnn.Execute("delete from JulhoW4 where Nome = @Nome", empresa);
                    else if (index == 7)
                        cnn.Execute("delete from AgostoW4 where Nome = @Nome", empresa);
                    else if (index == 8)
                        cnn.Execute("delete from SetembroW4 where Nome = @Nome", empresa);
                    else if (index == 9)
                        cnn.Execute("delete from OutubroW4 where Nome = @Nome", empresa);
                    else if (index == 10)
                        cnn.Execute("delete from NovembroW4 where Nome = @Nome", empresa);
                    else if (index == 11)
                        cnn.Execute("delete from DezembroW4 where Nome = @Nome", empresa);
                    return true;
                }
            }
            return false;
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}