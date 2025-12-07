using System;

namespace Mercado.Models
{
    internal class Endereco
    {
        public int Id_endereco { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}
