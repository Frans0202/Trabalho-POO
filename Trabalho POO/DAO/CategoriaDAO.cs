using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class CategoriaDAO : IDao<Categoria>
    {
        public void Create(Categoria c)
        {
            string sql = "INSERT INTO Categoria (tipo) VALUES (@tipo)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tipo", c.Tipo);
                cmd.ExecuteNonQuery();
            }
        }

        public Categoria GetById(int id)
        {
            string sql = "SELECT * FROM Categoria WHERE Id_categoria = @id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Categoria
                        {
                            Id_categoria = dr.GetInt32("Id_categoria"),
                            Tipo = dr.GetString("tipo")
                        };
                    }
                }
            }

            return null;
        }

        public void Update(Categoria c)
        {
            string sql = "UPDATE Categoria SET tipo=@tipo WHERE Id_categoria=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tipo", c.Tipo);
                cmd.Parameters.AddWithValue("@id", c.Id_categoria);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Categoria WHERE Id_categoria=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> lista = new List<Categoria>();

            string sql = "SELECT * FROM Categoria ORDER BY tipo";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        Id_categoria = dr.GetInt32("Id_categoria"),
                        Tipo = dr.GetString("tipo")
                    });
                }
            }

            return lista;
        }
    }
}
