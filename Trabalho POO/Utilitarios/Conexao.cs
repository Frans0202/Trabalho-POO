using MySql.Data.MySqlClient;


namespace ConexaoBanco.Utilitarios
{
    public class Conexao
    {
        private MySqlConnection conexao;

        // STRING DE CONEXÃO — coloque seus dados!
        private string connectionString =
            "server=localhost;port=3360;uid=root;pwd=root;database=Mercado;";

        public static MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(strconexao);
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