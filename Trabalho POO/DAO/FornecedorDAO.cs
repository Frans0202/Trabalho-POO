using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace ConexaoBancodeDados.DAO
{
    internal class FornecedorDAO : IDao<Fornecedor>
    {
        public void Create(Fornecedor f)
        {
            string sql = @"INSERT INTO Fornecedor (nomeFornecedor, telefone, fk_Id_endereco)
                           VALUES (@nome, @tel, @end)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nome", f.NomeFornecedor);
                cmd.Parameters.AddWithValue("@tel", f.Telefone);
                cmd.Parameters.AddWithValue("@end", f.fk_Id_endereco);
                cmd.ExecuteNonQuery();
            }
        }

        public Fornecedor GetById(int id)
        {
            string sql = "SELECT * FROM Fornecedor WHERE Id_fornecedor = @id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Fornecedor
                        {
                            Id_fornecedor = dr.GetInt32("Id_fornecedor"),
                            NomeFornecedor = dr.GetString("nomeFornecedor"),
                            Telefone = dr.GetString("telefone"),
                            fk_Id_endereco = dr.GetInt32("fk_Id_endereco")
                        };
                    }
                }
            }

            return null;
        }
        public void Update(Fornecedor f)
        {
            string sql = @"UPDATE Fornecedor SET nomeFornecedor=@nome, telefone=@tel, 
                           fk_Id_endereco=@end WHERE Id_fornecedor=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nome", f.NomeFornecedor);
                cmd.Parameters.AddWithValue("@tel", f.Telefone);
                cmd.Parameters.AddWithValue("@end", f.fk_Id_endereco);
                cmd.Parameters.AddWithValue("@id", f.Id_fornecedor);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Fornecedor WHERE Id_fornecedor=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Fornecedor> GetAll()
        {
            List<Fornecedor> lista = new List<Fornecedor>();
            string sql = @"SELECT * FROM Fornecedor ORDER BY nomeFornecedor";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Fornecedor
                    {
                        Id_fornecedor = dr.GetInt32("Id_fornecedor"),
                        NomeFornecedor = dr.GetString("nomeFornecedor"),
                        Telefone = dr.GetString("telefone"),
                        fk_Id_endereco = dr.GetInt32("fk_Id_endereco")
                    });
                }
            }

            return lista;
        }
    }
}
