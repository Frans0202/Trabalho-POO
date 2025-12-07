using System;

namespace Mercado.Models
{
    internal class Produto
    {
        public int Id_produto { get; set; }
        public string Sessao { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
        public int fk_Id_categoria { get; set; }
        public int? fk_Id_desconto { get; set; }
        public int fk_Id_estoque { get; set; }
        public int fk_Id_fornecedor { get; set; }
        public int? fk_Id_venda { get; set; }
    }
}
