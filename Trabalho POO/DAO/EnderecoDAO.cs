using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class EnderecoDAO : IDao<Endereco>
    {
        public void Create(Endereco e)
        {
            string sql = @"INSERT INTO Endereco (bairro, rua, numero, cep)
                           VALUES (@b, @r, @n, @c)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@b", e.Bairro);
                cmd.Parameters.AddWithValue("@r", e.Rua);
                cmd.Parameters.AddWithValue("@n", e.Numero);
                cmd.Parameters.AddWithValue("@c", e.Cep);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Endereco e)
        {
            string sql = @"UPDATE Endereco 
                           SET bairro=@b, rua=@r, numero=@n, cep=@c
                           WHERE Id_endereco=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@b", e.Bairro);
                cmd.Parameters.AddWithValue("@r", e.Rua);
                cmd.Parameters.AddWithValue("@n", e.Numero);
                cmd.Parameters.AddWithValue("@c", e.Cep);
                cmd.Parameters.AddWithValue("@id", e.Id_endereco);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Endereco WHERE Id_endereco=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Endereco> GetAll()
        {
            List<Endereco> lista = new List<Endereco>();
            string sql = "SELECT * FROM Endereco ORDER BY bairro";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Endereco
                    {
                        Id_endereco = dr.GetInt32("Id_endereco"),
                        Bairro = dr.GetString("bairro"),
                        Rua = dr.GetString("rua"),
                        Numero = dr.GetString("numero"),
                        Cep = dr.GetString("cep")
                    });
                }
            }

            return lista;
        }
    }
}
