using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class EstoqueDAO : IDao<Estoque>
    {
        public void Create(Estoque e)
        {
            string sql = @"INSERT INTO Estoque (quantidadeAtual)
                           VALUES (@qtd)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@qtd", e.QuantidadeAtual);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Estoque e)
        {
            string sql = @"UPDATE Estoque SET quantidadeAtual=@qtd
                           WHERE Id_estoque=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@qtd", e.QuantidadeAtual);
                cmd.Parameters.AddWithValue("@id", e.Id_estoque);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Estoque WHERE Id_estoque=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Estoque> GetAll()
        {
            List<Estoque> lista = new List<Estoque>();

            string sql = "SELECT * FROM Estoque ORDER BY Id_estoque";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Estoque
                    {
                        Id_estoque = dr.GetInt32("Id_estoque"),
                        QuantidadeAtual = dr.GetInt32("quantidadeAtual")
                    });
                }
            }

            return lista;
        }
    }
}
