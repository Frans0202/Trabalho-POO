using System;

namespace Mercado.Models
{
    internal class Fornecedor
    {
        public int Id_fornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Telefone { get; set; }
        public int fk_Id_endereco { get; set; }
    }
}
