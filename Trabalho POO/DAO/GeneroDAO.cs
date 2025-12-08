using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class GeneroDAO : IDao<Genero>
    {
        public void Create(Genero g)
        {
            string sql = @"INSERT INTO Genero (tipo)
                           VALUES (@t)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@t", g.Tipo);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Genero g)
        {
            string sql = @"UPDATE Genero SET tipo=@t 
                           WHERE Id_genero=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@t", g.Tipo);
                cmd.Parameters.AddWithValue("@id", g.Id_genero);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Genero WHERE Id_genero=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Genero> GetAll()
        {
            List<Genero> lista = new List<Genero>();
            string sql = "SELECT * FROM Genero ORDER BY tipo";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Genero
                    {
                        Id_genero = dr.GetInt32("Id_genero"),
                        Tipo = dr.GetString("tipo")
                    });
                }
            }

            return lista;
        }
    }
}
