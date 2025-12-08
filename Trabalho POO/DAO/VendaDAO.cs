using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class VendaDAO : IDao<Venda>
    {
        public void Create(Venda v)
        {
            string sql = @"INSERT INTO Venda 
                            (valorTotal, quantidade, fk_Id_cliente, fk_Id_funcionario)
                           VALUES (@vt, @qtd, @cli, @func)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@vt", v.ValorTotal);
                cmd.Parameters.AddWithValue("@qtd", v.Quantidade);
                cmd.Parameters.AddWithValue("@cli", v.fk_Id_cliente);
                cmd.Parameters.AddWithValue("@func", v.fk_Id_funcionario);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Venda v)
        {
            string sql = @"UPDATE Venda SET valorTotal=@vt, quantidade=@qtd, 
                           fk_Id_cliente=@cli, fk_Id_funcionario=@func
                           WHERE Id_venda=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@vt", v.ValorTotal);
                cmd.Parameters.AddWithValue("@qtd", v.Quantidade);
                cmd.Parameters.AddWithValue("@cli", v.fk_Id_cliente);
                cmd.Parameters.AddWithValue("@func", v.fk_Id_funcionario);
                cmd.Parameters.AddWithValue("@id", v.Id_venda);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Venda WHERE Id_venda=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Venda> GetAll()
        {
            var lista = new List<Venda>();
            string sql = "SELECT * FROM Venda ORDER BY Id_venda DESC";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Venda
                    {
                        Id_venda = dr.GetInt32("Id_venda"),
                        ValorTotal = dr.GetDecimal("valorTotal"),
                        Quantidade = dr.GetInt32("quantidade"),
                        fk_Id_cliente = dr.GetInt32("fk_Id_cliente"),
                        fk_Id_funcionario = dr.GetInt32("fk_Id_funcionario")
                    });
                }
            }

            return lista;
        }
    }
}
