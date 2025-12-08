using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class DescontoDAO : IDao<Desconto>
    {
        public void Create(Desconto d)
        {
            string sql = @"INSERT INTO Desconto (porcentagem, dataInicio, dataFim)
                           VALUES (@p, @di, @df)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@p", d.Porcentagem);
                cmd.Parameters.AddWithValue("@di", d.DataInicio);
                cmd.Parameters.AddWithValue("@df", d.DataFim);
                cmd.ExecuteNonQuery();
            }
        }

        public Desconto GetById(int id)
        {
            string sql = "SELECT * FROM Desconto WHERE Id_desconto = @id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Desconto
                        {
                            Id_desconto = dr.GetInt32("Id_desconto"),
                            Porcentagem = dr.GetDouble("porcentagem"),
                            DataInicio = dr.GetDateTime("dataInicio"),
                            DataFim = dr.GetDateTime("dataFim")
                        };
                    }
                }
            }

            return null;
        }

        public void Update(Desconto d)
        {
            string sql = @"UPDATE Desconto SET porcentagem=@p, dataInicio=@di, dataFim=@df
                           WHERE Id_desconto=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@p", d.Porcentagem);
                cmd.Parameters.AddWithValue("@di", d.DataInicio);
                cmd.Parameters.AddWithValue("@df", d.DataFim);
                cmd.Parameters.AddWithValue("@id", d.Id_desconto);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Desconto WHERE Id_desconto=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Desconto> GetAll()
        {
            List<Desconto> lista = new List<Desconto>();
            string sql = "SELECT * FROM Desconto ORDER BY porcentagem";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Desconto
                    {
                        Id_desconto = dr.GetInt32("Id_desconto"),
                        Porcentagem = dr.GetDouble("porcentagem"),
                        DataInicio = dr.GetDateTime("dataInicio"),
                        DataFim = dr.GetDateTime("dataFim")
                    });
                }
            }

            return lista;
        }
    }
}
