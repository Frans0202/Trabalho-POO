using ConexaoBanco.Utilitarios;
using ConexaoBancoDados.Interfaces;
using Mercado.Models;
using MySql.Data.MySqlClient;

namespace Mercado.DAO
{
    internal class ProdutoDAO : IDao<Produto>
    {
        public void Create(Produto produto)
        {
            try
            {
                string sql = @"
                    INSERT INTO Produto 
                    (sessao, valorUnitario, marca, descricao, fk_Id_categoria, fk_Id_desconto, fk_Id_estoque, fk_Id_fornecedor, fk_Id_venda)
                    VALUES 
                    (@sessao, @valor, @marca, @descricao, @categoria, @desconto, @estoque, @fornecedor, @venda)";

                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@sessao", produto.Sessao);
                    cmd.Parameters.AddWithValue("@valor", produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@marca", produto.Marca);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@categoria", produto.fk_Id_categoria);
                    cmd.Parameters.AddWithValue("@desconto", (object?)produto.fk_Id_desconto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estoque", produto.fk_Id_estoque);
                    cmd.Parameters.AddWithValue("@fornecedor", produto.fk_Id_fornecedor);
                    cmd.Parameters.AddWithValue("@venda", (object?)produto.fk_Id_venda ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto: " + ex.Message);
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                string sql = @"
                    UPDATE Produto SET
                        sessao=@sessao,
                        valorUnitario=@valor,
                        marca=@marca,
                        descricao=@descricao,
                        fk_Id_categoria=@categoria,
                        fk_Id_desconto=@desconto,
                        fk_Id_estoque=@estoque,
                        fk_Id_fornecedor=@fornecedor,
                        fk_Id_venda=@venda
                    WHERE Id_produto=@id";

                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@sessao", produto.Sessao);
                    cmd.Parameters.AddWithValue("@valor", produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@marca", produto.Marca);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@categoria", produto.fk_Id_categoria);
                    cmd.Parameters.AddWithValue("@desconto", (object?)produto.fk_Id_desconto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estoque", produto.fk_Id_estoque);
                    cmd.Parameters.AddWithValue("@fornecedor", produto.fk_Id_fornecedor);
                    cmd.Parameters.AddWithValue("@venda", (object?)produto.fk_Id_venda ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", produto.Id_produto);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum produto foi atualizado (verifique o ID).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Produto WHERE Id_produto=@id";

                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum produto encontrado com esse ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto: " + ex.Message);
            }
        }

        public List<Produto> GetAll()
        {
            List<Produto> lista = new List<Produto>();

            try
            {
                string sql = "SELECT * FROM Produto ORDER BY sessao";

                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Produto p = new Produto
                        {
                            Id_produto = dr.GetInt32("Id_produto"),
                            Sessao = dr.GetString("sessao"),
                            ValorUnitario = dr.GetDecimal("valorUnitario"),
                            Marca = dr.IsDBNull(dr.GetOrdinal("marca")) ? null : dr.GetString("marca"),
                            Descricao = dr.IsDBNull(dr.GetOrdinal("descricao")) ? null : dr.GetString("descricao"),
                            fk_Id_categoria = dr.GetInt32("fk_Id_categoria"),
                            fk_Id_desconto = dr.IsDBNull(dr.GetOrdinal("fk_Id_desconto")) ? null : dr.GetInt32("fk_Id_desconto"),
                            fk_Id_estoque = dr.GetInt32("fk_Id_estoque"),
                            fk_Id_fornecedor = dr.GetInt32("fk_Id_fornecedor"),
                            fk_Id_venda = dr.IsDBNull(dr.GetOrdinal("fk_Id_venda")) ? null : dr.GetInt32("fk_Id_venda")
                        };

                        lista.Add(p);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar produtos: " + ex.Message);
            }
        }
    }
}
