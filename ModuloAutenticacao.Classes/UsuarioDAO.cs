using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAutenticacao.Classes
{
    public class UsuarioDAO
    {
        public string Inserir(string nome, string sobrenome,string usuario,string senha,string nomeNivel)
        {
            // Abrindo a conexao com banco de dados
            Conexao.MinhaInstancia.Open();

            // Definindo o tipo de comando
            SqlCommand comando = Conexao.MinhaInstancia.CreateCommand();

            // Definindo DML
            comando.CommandType = System.Data.CommandType.Text;

            // Iniciando DML (Data Manipulation Language)
            comando.CommandText = "INSERT INTO Usuario(nome,sobreNome,usuario,senha,codNivel)" +
                "Values(@Nome,@sobreNome,@usuario,@senha,(select codigo from nivel where nome= @nomeNivel))";

            // Adicionando parametros contra SQL Injection!            
            comando.Parameters.Add(new SqlParameter("@Nome", nome));
            comando.Parameters.Add(new SqlParameter("@sobreNome", sobrenome));
            comando.Parameters.Add(new SqlParameter("@usuario", usuario));
            comando.Parameters.Add(new SqlParameter("@senha", senha));
            comando.Parameters.Add(new SqlParameter("@nomeNivel", nomeNivel));

            // Esta tudo pronto! Vamos esxecutar o comando
            comando.ExecuteNonQuery();

            Conexao.MinhaInstancia.Close();


            return "Usuario Cadastrado com Sucesso!";

        }


        public string Atualizar(string ID, string nome)
        {

            Conexao.MinhaInstancia.Open();
            SqlCommand comando = Conexao.MinhaInstancia.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = ("update Nivel set Nome=@Nome where codigo=@ID;");
            comando.Parameters.AddWithValue("@ID", ID);
            comando.Parameters.AddWithValue("@Nome", nome);
            comando.ExecuteNonQuery();

            Conexao.MinhaInstancia.Close();

            return "Atualizado com Sucesso!";
        }


        public DataTable Pesquisar()
        {
            Conexao.MinhaInstancia.Open();
            SqlCommand comando = Conexao.MinhaInstancia.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Nivel ORDER BY codigo;";

            //datatable (cria o bando de dados na memoria;
            DataTable dataTable = new DataTable();
            SqlDataReader reader = comando.ExecuteReader();
            dataTable.Load(reader);
            Conexao.MinhaInstancia.Close();



            return dataTable;

        }

        public string Deletar(string ID)
        {
            Conexao.MinhaInstancia.Open();
            SqlCommand comando = Conexao.MinhaInstancia.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = ("DELETE Nivel WHERE codigo=@ID;");
            comando.Parameters.AddWithValue("@ID", ID);
            comando.ExecuteNonQuery();

            Conexao.MinhaInstancia.Close();
            return "Deletado com Sucesso!";
        }

        public DataTable PesquisarPorNome(string nome)
        {
            Conexao.MinhaInstancia.Open();
            SqlCommand comando = Conexao.MinhaInstancia.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = ("SELECT * from Nivel where Nome=@Nome;");
            comando.Parameters.AddWithValue("@Nome", nome);
            DataTable dataTable = new DataTable();
            SqlDataReader reader = comando.ExecuteReader();
            dataTable.Load(reader);
            Conexao.MinhaInstancia.Close();

            return dataTable;

        }
    }
}
