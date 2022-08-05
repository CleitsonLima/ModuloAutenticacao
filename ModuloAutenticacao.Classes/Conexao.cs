using System.Data.Common;
using System.Data.SqlClient;

namespace ModuloAutenticacao.Classes
{
    public class Conexao
    {
        public static SqlConnection _conn;

        public static SqlConnection MinhaInstancia
        {
            get
            {
                //se não existe conexão.
                if (_conn == null)
                {
                    //criar a conexão com SQL Server  //nos parênteses -connection string

                    //pra conectar um banco de dados so definir o caminho, nome do banco, login e senha;

                    //conexao banco computador senai
                    //_conn = new SqlConnection(@"Server = Lab206_16\SQLEXPRESS; Database = ProjetoEstoquev; Uid = sa; Pwd = teste*123;");

                    //conexao banco notebook
                    _conn = new SqlConnection(@"Server = CLEISSIM; Database = ProjetoEstoquev; Uid = sa; Pwd = cleissim;");
                }
                //retorna a conexão
                return _conn;
            }
        }



    }
}
