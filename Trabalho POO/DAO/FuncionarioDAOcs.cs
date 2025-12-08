using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConexaoBancodeDados.DAO
{
    internal class FuncionarioDAO : IDao<Funcionario>
    {
        public void Create(Funcionario f)
        {
            string sql = @"INSERT INTO Funcionario 
                            (nome, cpf, telefone, email, dataNascimento, fk_Id_endereco, fk_Id_genero)
                           VALUES (@n, @cpf, @t, @e, @dn, @end, @gen)";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@n", f.Nome);
                cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                cmd.Parameters.AddWithValue("@t", f.Telefone);
                cmd.Parameters.AddWithValue("@e", f.Email);
                cmd.Parameters.AddWithValue("@dn", f.DataNascimento);
                cmd.Parameters.AddWithValue("@end", f.fk_Id_endereco);
                cmd.Parameters.AddWithValue("@gen", f.fk_Id_genero);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Funcionario f)
        {
            string sql = @"UPDATE Funcionario SET 
                           nome=@n, cpf=@cpf, telefone=@t, email=@e, dataNascimento=@dn,
                           fk_Id_endereco=@end, fk_Id_genero=@gen
                           WHERE Id_funcionario=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@n", f.Nome);
                cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                cmd.Parameters.AddWithValue("@t", f.Telefone);
                cmd.Parameters.AddWithValue("@e", f.Email);
                cmd.Parameters.AddWithValue("@dn", f.DataNascimento);
                cmd.Parameters.AddWithValue("@end", f.fk_Id_endereco);
                cmd.Parameters.AddWithValue("@gen", f.fk_Id_genero);
                cmd.Parameters.AddWithValue("@id", f.Id_funcionario);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Funcionario WHERE Id_funcionario=@id";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Funcionario> GetAll()
        {
            var lista = new List<Funcionario>();
            string sql = "SELECT * FROM Funcionario ORDER BY nome";

            using (var conn = Conexao.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Funcionario
                    {
                        Id_funcionario = dr.GetInt32("Id_funcionario"),
                        Nome = dr.GetString("nome"),
                        Cpf = dr.GetString("cpf"),
                        Telefone = dr.IsDBNull("telefone") ? "" : dr.GetString("telefone"),
                        Email = dr.IsDBNull("email") ? "" : dr.GetString("email"),
                        DataNascimento = dr.GetDateTime("dataNascimento"),
                        fk_Id_endereco = dr.GetInt32("fk_Id_endereco"),
                        fk_Id_genero = dr.GetInt32("fk_Id_genero")
                    });
                }
            }

            return lista;
        }
    }
}
