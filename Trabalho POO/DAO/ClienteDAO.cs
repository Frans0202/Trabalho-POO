using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConexaoBancodeDados.DAO
{
    internal class ClienteDAO : IDao<Cliente>
    {
        public void Create(Cliente c)
        {
            string sql = @"INSERT INTO Cliente 
                            (nome, email, telefone, fk_Id_endereco, fk_Id_genero)
                           VALUES (@n, @e, @t, @end, @gen)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@n", c.Nome);
                cmd.Parameters.AddWithValue("@e", c.Email);
                cmd.Parameters.AddWithValue("@t", c.Telefone);
                cmd.Parameters.AddWithValue("@end", c.fk_Id_endereco);
                cmd.Parameters.AddWithValue("@gen", c.fk_Id_genero);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Cliente c)
        {
            string sql = @"UPDATE Cliente SET nome=@n, email=@e, telefone=@t,
                           fk_Id_endereco=@end, fk_Id_genero=@gen
                           WHERE Id_cliente=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@n", c.Nome);
                cmd.Parameters.AddWithValue("@e", c.Email);
                cmd.Parameters.AddWithValue("@t", c.Telefone);
                cmd.Parameters.AddWithValue("@end", c.fk_Id_endereco);
                cmd.Parameters.AddWithValue("@gen", c.fk_Id_genero);
                cmd.Parameters.AddWithValue("@id", c.Id_cliente);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Cliente WHERE Id_cliente=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> GetAll()
        {
            var lista = new List<Cliente>();
            string sql = "SELECT * FROM Cliente ORDER BY nome";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id_cliente = dr.GetInt32("Id_cliente"),
                        Nome = dr.GetString("nome"),
                        Email = dr.IsDBNull("email") ? "" : dr.GetString("email"),
                        Telefone = dr.IsDBNull("telefone") ? "" : dr.GetString("telefone"),
                        fk_Id_endereco = dr.GetInt32("fk_Id_endereco"),
                        fk_Id_genero = dr.GetInt32("fk_Id_genero")
                    });
                }
            }

            return lista;
        }
    }
}
