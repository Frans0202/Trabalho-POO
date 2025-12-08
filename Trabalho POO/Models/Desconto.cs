using System;

namespace Mercado.Models
{
    internal class Desconto
    {
        public int Id_desconto { get; set; }
        public double Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
