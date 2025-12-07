using System;

namespace Mercado.Models
{
    internal class Cliente
    {
        public int Id_cliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int fk_Id_endereco { get; set; }
        public int fk_Id_genero { get; set; }
    }
}
