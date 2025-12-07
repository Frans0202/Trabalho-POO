using System;

namespace Mercado.Models
{
    internal class Funcionario
    {
        public int Id_funcionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int fk_Id_endereco { get; set; }
        public int fk_Id_genero { get; set; }
    }
}
