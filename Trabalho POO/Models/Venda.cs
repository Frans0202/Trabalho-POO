using System;

namespace Mercado.Models
{
    internal class Venda
    {
        public int Id_venda { get; set; }
        public decimal ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public int fk_Id_cliente { get; set; }
        public int fk_Id_funcionario { get; set; }
    }
}
