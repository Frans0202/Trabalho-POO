using MySql.Data.MySqlClient;

namespace ConexaoBanco.Utilitarios
{
    public class Conexao
    {
        private static string connectionString =
            "server=localhost;port=3306;uid=root;pwd=root;database=Mercado;";

        public static MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(connectionString);

            try
            {
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
