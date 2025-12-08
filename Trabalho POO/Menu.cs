using Mercado.Models;
using ConexaoBancodeDados.DAO;
using Mercado.DAO;

namespace Trabalho_POO
{
    internal class Menu
    {

        public Menu()
        {

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            DescontoDAO descontoDAO = new DescontoDAO();
            EstoqueDAO estoqueDAO = new EstoqueDAO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            GeneroDAO generoDAO = new GeneroDAO();
            FornecedorDAO fornecedorDAO = new FornecedorDAO();
            ClienteDAO clienteDAO = new ClienteDAO();
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            VendaDAO vendaDAO = new VendaDAO();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            int opcao;
            int id;
            do
            {
                Console.Clear();

                Console.WriteLine("=== SISTEMA DE CADASTRO - MERCADO ===");
                Console.WriteLine("");
                Console.WriteLine("1. Cadastrar Categoria");
                Console.WriteLine("2. Cadastrar Desconto");
                Console.WriteLine("3. Cadastrar Estoque");
                Console.WriteLine("4. Cadastrar Endereço");
                Console.WriteLine("5. Cadastrar Gênero");
                Console.WriteLine("6. Cadastrar Fornecedor");
                Console.WriteLine("7. Cadastrar Cliente");
                Console.WriteLine("8. Cadastrar Funcionário");
                Console.WriteLine("9. Cadastrar Venda");
                Console.WriteLine("10. Cadastrar Produto");

                Console.WriteLine("11. Listar Categorias");
                Console.WriteLine("12. Listar Descontos");
                Console.WriteLine("13. Listar Estoques");
                Console.WriteLine("14. Listar Endereços");
                Console.WriteLine("15. Listar Gêneros");
                Console.WriteLine("16. Listar Fornecedores");
                Console.WriteLine("17. Listar Clientes");
                Console.WriteLine("18. Listar Funcionários");
                Console.WriteLine("19. Listar Vendas");
                Console.WriteLine("20. Listar Produtos");

                Console.WriteLine("21. Alterar Categoria");
                Console.WriteLine("22. Alterar Desconto");
                Console.WriteLine("23. Alterar Estoque");
                Console.WriteLine("24. Alterar Endereço");
                Console.WriteLine("25. Alterar Gênero");
                Console.WriteLine("26. Alterar Fornecedor");
                Console.WriteLine("27. Alterar Cliente");
                Console.WriteLine("28. Alterar Funcionário");
                Console.WriteLine("29. Alterar Venda");
                Console.WriteLine("30. Alterar Produto");

                Console.WriteLine("31. Remover Categoria");
                Console.WriteLine("32. Remover Desconto");
                Console.WriteLine("33. Remover Estoque");
                Console.WriteLine("34. Remover Endereço");
                Console.WriteLine("35. Remover Gênero");
                Console.WriteLine("36. Remover Fornecedor");
                Console.WriteLine("37. Remover Cliente");
                Console.WriteLine("38. Remover Funcionário");
                Console.WriteLine("39. Remover Venda");
                Console.WriteLine("40. Remover Produto");

                Console.WriteLine("0. Sair");
                Console.WriteLine();
                Console.Write("Escolha sua opção: ");

                opcao = int.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.WriteLine();

                switch (opcao)
                {
                    // ------------------ CADASTROS ------------------

                    case 1:
                        Categoria c = new Categoria();
                        Console.Write("Tipo da categoria: ");
                        c.Tipo = Console.ReadLine();
                        categoriaDAO.Create(c);
                        Console.WriteLine("Categoria cadastrada!");
                        break;

                    case 2:
                        Desconto d = new Desconto();
                        Console.Write("Porcentagem: ");
                        d.Porcentagem = double.Parse(Console.ReadLine());
                        Console.Write("Data início (yyyy-mm-dd): ");
                        d.DataInicio = DateTime.Parse(Console.ReadLine());
                        Console.Write("Data fim (yyyy-mm-dd): ");
                        d.DataFim = DateTime.Parse(Console.ReadLine());
                        descontoDAO.Create(d);
                        Console.WriteLine("Desconto cadastrado!");
                        break;

                    case 3:
                        Estoque e = new Estoque();
                        Console.Write("Quantidade atual: ");
                        e.QuantidadeAtual = int.Parse(Console.ReadLine());
                        estoqueDAO.Create(e);
                        Console.WriteLine("Estoque cadastrado!");
                        break;

                    case 4:
                        Endereco end = new Endereco();
                        Console.Write("Bairro: ");
                        end.Bairro = Console.ReadLine();
                        Console.Write("Rua: ");
                        end.Rua = Console.ReadLine();
                        Console.Write("Número: ");
                        end.Numero = Console.ReadLine();
                        Console.Write("CEP: ");
                        end.Cep = Console.ReadLine();
                        enderecoDAO.Create(end);
                        Console.WriteLine("Endereço cadastrado!");
                        break;

                    case 5:
                        Genero g = new Genero();
                        Console.Write("Tipo do gênero: ");
                        g.Tipo = Console.ReadLine();
                        generoDAO.Create(g);
                        Console.WriteLine("Gênero cadastrado!");
                        break;

                    case 6:
                        Fornecedor f = new Fornecedor();
                        Console.Write("Nome do fornecedor: ");
                        f.NomeFornecedor = Console.ReadLine();
                        Console.Write("Telefone: ");
                        f.Telefone = Console.ReadLine();
                        Console.Write("ID do endereço: ");
                        f.fk_Id_endereco = int.Parse(Console.ReadLine());
                        fornecedorDAO.Create(f);
                        Console.WriteLine("Fornecedor cadastrado!");
                        break;

                    case 7:
                        Cliente cli = new Cliente();
                        Console.Write("Nome: ");
                        cli.Nome = Console.ReadLine();
                        Console.Write("Email: ");
                        cli.Email = Console.ReadLine();
                        Console.Write("Telefone: ");
                        cli.Telefone = Console.ReadLine();
                        Console.Write("ID do endereço: ");
                        cli.fk_Id_endereco = int.Parse(Console.ReadLine());
                        Console.Write("ID do gênero: ");
                        cli.fk_Id_genero = int.Parse(Console.ReadLine());
                        clienteDAO.Create(cli);
                        Console.WriteLine("Cliente cadastrado!");
                        break;

                    case 8:
                        Funcionario fun = new Funcionario();
                        Console.Write("Nome: ");
                        fun.Nome = Console.ReadLine();
                        Console.Write("CPF: ");
                        fun.Cpf = Console.ReadLine();
                        Console.Write("Telefone: ");
                        fun.Telefone = Console.ReadLine();
                        Console.Write("Email: ");
                        fun.Email = Console.ReadLine();
                        Console.Write("Data nascimento (yyyy-mm-dd): ");
                        fun.DataNascimento = DateTime.Parse(Console.ReadLine());
                        Console.Write("ID endereço: ");
                        fun.fk_Id_endereco = int.Parse(Console.ReadLine());
                        Console.Write("ID gênero: ");
                        fun.fk_Id_genero = int.Parse(Console.ReadLine());
                        funcionarioDAO.Create(fun);
                        Console.WriteLine("Funcionário cadastrado!");
                        break;

                    case 9:
                        Venda v = new Venda();
                        Console.Write("Valor total: ");
                        v.ValorTotal = decimal.Parse(Console.ReadLine());
                        Console.Write("Quantidade: ");
                        v.Quantidade = int.Parse(Console.ReadLine());
                        Console.Write("ID cliente: ");
                        v.fk_Id_cliente = int.Parse(Console.ReadLine());
                        Console.Write("ID funcionário: ");
                        v.fk_Id_funcionario = int.Parse(Console.ReadLine());
                        vendaDAO.Create(v);
                        Console.WriteLine("Venda cadastrada!");
                        break;

                    case 10:
                        Produto p = new Produto();
                        Console.Write("Sessão: ");
                        p.Sessao = Console.ReadLine();
                        Console.Write("Valor unitário: ");
                        p.ValorUnitario = decimal.Parse(Console.ReadLine());
                        Console.Write("Marca: ");
                        p.Marca = Console.ReadLine();
                        Console.Write("Descrição: ");
                        p.Descricao = Console.ReadLine();
                        Console.Write("ID categoria: ");
                        p.fk_Id_categoria = int.Parse(Console.ReadLine());
                        Console.Write("ID desconto (ou vazio): ");
                        string desc = Console.ReadLine();
                        p.fk_Id_desconto = string.IsNullOrEmpty(desc) ? null : int.Parse(desc);
                        Console.Write("ID estoque: ");
                        p.fk_Id_estoque = int.Parse(Console.ReadLine());
                        Console.Write("ID fornecedor: ");
                        p.fk_Id_fornecedor = int.Parse(Console.ReadLine());
                        Console.Write("ID venda (ou vazio): ");
                        string vendaStr = Console.ReadLine();
                        p.fk_Id_venda = string.IsNullOrEmpty(vendaStr) ? null : int.Parse(vendaStr);

                        produtoDAO.Create(p);
                        Console.WriteLine("Produto cadastrado!");
                        break;

                    // LISTAGENS 

                    case 11:
                        Console.WriteLine("--- CATEGORIAS ---");
                        foreach (var item in categoriaDAO.GetAll())
                            Console.WriteLine($"{item.Id_categoria} - {item.Tipo}");
                        break;

                    case 12:
                        Console.WriteLine("--- DESCONTOS ---");
                        foreach (var item in descontoDAO.GetAll())
                            Console.WriteLine($"{item.Id_desconto} - {item.Porcentagem}% ({item.DataInicio} até {item.DataFim})");
                        break;

                    case 13:
                        Console.WriteLine("--- ESTOQUE ---");
                        foreach (var item in estoqueDAO.GetAll())
                            Console.WriteLine($"ID {item.Id_estoque}: {item.QuantidadeAtual} unidades");
                        break;

                    case 14:
                        Console.WriteLine("--- ENDEREÇOS ---");
                        foreach (var item in enderecoDAO.GetAll())
                            Console.WriteLine($"{item.Id_endereco} - {item.Rua}, {item.Numero}, {item.Bairro}, CEP {item.Cep}");
                        break;

                    case 15:
                        Console.WriteLine("--- GÊNEROS ---");
                        foreach (var item in generoDAO.GetAll())
                            Console.WriteLine($"{item.Id_genero}: {item.Tipo}");
                        break;

                    case 16:
                        Console.WriteLine("--- FORNECEDORES ---");
                        foreach (var item in fornecedorDAO.GetAll())
                            Console.WriteLine($"{item.Id_fornecedor} - {item.NomeFornecedor} - Tel {item.Telefone} - End {item.fk_Id_endereco}");
                        break;

                    case 17:
                        Console.WriteLine("--- CLIENTES ---");
                        foreach (var item in clienteDAO.GetAll())
                            Console.WriteLine($"{item.Id_cliente} - {item.Nome} - {item.Email} - End {item.fk_Id_endereco}");
                        break;

                    case 18:
                        Console.WriteLine("--- FUNCIONÁRIOS ---");
                        foreach (var item in funcionarioDAO.GetAll())
                            Console.WriteLine($"{item.Id_funcionario} - {item.Nome} - CPF {item.Cpf}");
                        break;

                    case 19:
                        Console.WriteLine("--- VENDAS ---");
                        foreach (var item in vendaDAO.GetAll())
                            Console.WriteLine($"{item.Id_venda}: R$ {item.ValorTotal} - {item.Quantidade} itens");
                        break;

                    case 20:
                        Console.WriteLine("--- PRODUTOS ---");
                        foreach (var item in produtoDAO.GetAll())
                            Console.WriteLine($"{item.Id_produto} - {item.Marca} {item.Descricao} | R$ {item.ValorUnitario}");
                        break;
                    case 21:
                        Console.Write("ID da categoria para alterar: ");
                        int idCatAlt = int.Parse(Console.ReadLine());

                        Categoria catAlt = categoriaDAO.GetById(idCatAlt);
                        if (catAlt == null) { Console.WriteLine("Categoria não encontrada!"); break; }

                        Console.Write("Novo tipo: ");
                        catAlt.Tipo = Console.ReadLine();

                        categoriaDAO.Update(catAlt);
                        Console.WriteLine("Categoria alterada!");
                        break;
                    case 22:
                        Console.Write("ID do desconto para alterar: ");
                        int idDescAlt = int.Parse(Console.ReadLine());

                        Desconto descAlt = descontoDAO.GetById(idDescAlt);
                        if (descAlt == null) { Console.WriteLine("Desconto não encontrado!"); break; }

                        Console.Write("Nova porcentagem: ");
                        descAlt.Porcentagem = double.Parse(Console.ReadLine());
                        Console.Write("Nova data início: ");
                        descAlt.DataInicio = DateTime.Parse(Console.ReadLine());
                        Console.Write("Nova data fim: ");
                        descAlt.DataFim = DateTime.Parse(Console.ReadLine());

                        descontoDAO.Update(descAlt);
                        Console.WriteLine("Desconto alterado!");
                        break;
                    case 23:
                        Console.Write("ID do estoque para alterar: ");
                        int idEstAlt = int.Parse(Console.ReadLine());

                        Estoque estAlt = estoqueDAO.GetById(idEstAlt);
                        if (estAlt == null) { Console.WriteLine("Estoque não encontrado!"); break; }

                        Console.Write("Nova quantidade: ");
                        estAlt.QuantidadeAtual = int.Parse(Console.ReadLine());

                        estoqueDAO.Update(estAlt);
                        Console.WriteLine("Estoque alterado!");
                        break;
                    case 24:
                        Console.Write("ID do endereço para alterar: ");
                        int idEndAlt = int.Parse(Console.ReadLine());

                        Endereco endAlt = enderecoDAO.GetById(idEndAlt);
                        if (endAlt == null) { Console.WriteLine("Endereço não encontrado!"); break; }

                        Console.Write("Novo bairro: ");
                        endAlt.Bairro = Console.ReadLine();
                        Console.Write("Nova rua: ");
                        endAlt.Rua = Console.ReadLine();
                        Console.Write("Novo número: ");
                        endAlt.Numero = Console.ReadLine();
                        Console.Write("Novo CEP: ");
                        endAlt.Cep = Console.ReadLine();

                        enderecoDAO.Update(endAlt);
                        Console.WriteLine("Endereço alterado!");
                        break;
                    case 25:
                        Console.Write("ID do gênero para alterar: ");
                        int idGenAlt = int.Parse(Console.ReadLine());

                        Genero genAlt = generoDAO.GetById(idGenAlt);
                        if (genAlt == null) { Console.WriteLine("Gênero não encontrado!"); break; }

                        Console.Write("Novo tipo: ");
                        genAlt.Tipo = Console.ReadLine();

                        generoDAO.Update(genAlt);
                        Console.WriteLine("Gênero alterado!");
                        break;
                    case 26:
                        Console.Write("ID do fornecedor para alterar: ");
                        int idFornAlt = int.Parse(Console.ReadLine());

                        Fornecedor fornAlt = fornecedorDAO.GetById(idFornAlt);
                        if (fornAlt == null) { Console.WriteLine("Fornecedor não encontrado!"); break; }

                        Console.Write("Novo nome: ");
                        fornAlt.NomeFornecedor = Console.ReadLine();
                        Console.Write("Novo telefone: ");
                        fornAlt.Telefone = Console.ReadLine();
                        Console.Write("Novo ID de endereço: ");
                        fornAlt.fk_Id_endereco = int.Parse(Console.ReadLine());

                        fornecedorDAO.Update(fornAlt);
                        Console.WriteLine("Fornecedor alterado!");
                        break;
                    case 27:
                        Console.Write("ID do cliente para alterar: ");
                        int idCliAlt = int.Parse(Console.ReadLine());

                        Cliente cliAlt = clienteDAO.GetById(idCliAlt);
                        if (cliAlt == null) { Console.WriteLine("Cliente não encontrado!"); break; }

                        Console.Write("Novo nome: ");
                        cliAlt.Nome = Console.ReadLine();
                        Console.Write("Novo email: ");
                        cliAlt.Email = Console.ReadLine();
                        Console.Write("Novo telefone: ");
                        cliAlt.Telefone = Console.ReadLine();
                        Console.Write("Novo ID endereço: ");
                        cliAlt.fk_Id_endereco = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID gênero: ");
                        cliAlt.fk_Id_genero = int.Parse(Console.ReadLine());

                        clienteDAO.Update(cliAlt);
                        Console.WriteLine("Cliente alterado!");
                        break;
                    case 28:
                        Console.Write("ID do funcionário para alterar: ");
                        int idFunAlt = int.Parse(Console.ReadLine());

                        Funcionario funAlt = funcionarioDAO.GetById(idFunAlt);
                        if (funAlt == null) { Console.WriteLine("Funcionário não encontrado!"); break; }

                        Console.Write("Novo nome: ");
                        funAlt.Nome = Console.ReadLine();
                        Console.Write("Novo telefone: ");
                        funAlt.Telefone = Console.ReadLine();
                        Console.Write("Novo email: ");
                        funAlt.Email = Console.ReadLine();
                        Console.Write("Nova data nascimento: ");
                        funAlt.DataNascimento = DateTime.Parse(Console.ReadLine());
                        Console.Write("Novo ID endereço: ");
                        funAlt.fk_Id_endereco = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID gênero: ");
                        funAlt.fk_Id_genero = int.Parse(Console.ReadLine());

                        funcionarioDAO.Update(funAlt);
                        Console.WriteLine("Funcionário alterado!");
                        break;
                    case 29:
                        Console.Write("ID da venda para alterar: ");
                        int idVendaAlt = int.Parse(Console.ReadLine());

                        Venda vendaAlt = vendaDAO.GetById(idVendaAlt);
                        if (vendaAlt == null) { Console.WriteLine("Venda não encontrada!"); break; }

                        Console.Write("Novo valor total: ");
                        vendaAlt.ValorTotal = decimal.Parse(Console.ReadLine());
                        Console.Write("Nova quantidade: ");
                        vendaAlt.Quantidade = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID cliente: ");
                        vendaAlt.fk_Id_cliente = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID funcionário: ");
                        vendaAlt.fk_Id_funcionario = int.Parse(Console.ReadLine());

                        vendaDAO.Update(vendaAlt);
                        Console.WriteLine("Venda alterada!");
                        break;
                    case 30:
                        Console.Write("ID do produto para alterar: ");
                        int idProdAlt = int.Parse(Console.ReadLine());

                        Produto prodAlt = produtoDAO.GetById(idProdAlt);
                        if (prodAlt == null) { Console.WriteLine("Produto não encontrado!"); break; }

                        Console.Write("Nova sessão: ");
                        prodAlt.Sessao = Console.ReadLine();
                        Console.Write("Novo valor unitário: ");
                        prodAlt.ValorUnitario = decimal.Parse(Console.ReadLine());
                        Console.Write("Nova marca: ");
                        prodAlt.Marca = Console.ReadLine();
                        Console.Write("Nova descrição: ");
                        prodAlt.Descricao = Console.ReadLine();
                        Console.Write("Novo ID categoria: ");
                        prodAlt.fk_Id_categoria = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID desconto (ou vazio): ");
                        string nd = Console.ReadLine();
                        prodAlt.fk_Id_desconto = string.IsNullOrEmpty(nd) ? null : int.Parse(nd);
                        Console.Write("Novo ID estoque: ");
                        prodAlt.fk_Id_estoque = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID fornecedor: ");
                        prodAlt.fk_Id_fornecedor = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID venda (ou vazio): ");
                        string nv = Console.ReadLine();
                        prodAlt.fk_Id_venda = string.IsNullOrEmpty(nv) ? null : int.Parse(nv);

                        produtoDAO.Update(prodAlt);
                        Console.WriteLine("Produto alterado!");
                        break;
                    case 31:
                        Console.Write("Digite o ID da Categoria que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new CategoriaDAO().Delete(id);
                        Console.WriteLine("Categoria removida com sucesso!");
                        break;

                    case 32:
                        Console.Write("Digite o ID do Desconto que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new DescontoDAO().Delete(id);
                        Console.WriteLine("Desconto removido com sucesso!");
                        break;

                    case 33:
                        Console.Write("Digite o ID do Estoque que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new EstoqueDAO().Delete(id);
                        Console.WriteLine("Estoque removido com sucesso!");
                        break;

                    case 34:
                        Console.Write("Digite o ID do Endereço que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new EnderecoDAO().Delete(id);
                        Console.WriteLine("Endereço removido com sucesso!");
                        break;

                    case 35:
                        Console.Write("Digite o ID do Gênero que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new GeneroDAO().Delete(id);
                        Console.WriteLine("Gênero removido com sucesso!");
                        break;

                    case 36:
                        Console.Write("Digite o ID do Fornecedor que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new FornecedorDAO().Delete(id);
                        Console.WriteLine("Fornecedor removido com sucesso!");
                        break;

                    case 37:
                        Console.Write("Digite o ID do Cliente que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new ClienteDAO().Delete(id);
                        Console.WriteLine("Cliente removido com sucesso!");
                        break;

                    case 38:
                        Console.Write("Digite o ID do Funcionário que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new FuncionarioDAO().Delete(id);
                        Console.WriteLine("Funcionário removido com sucesso!");
                        break;

                    case 39:
                        Console.Write("Digite o ID da Venda que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new VendaDAO().Delete(id);
                        Console.WriteLine("Venda removida com sucesso!");
                        break;

                    case 40:
                        Console.Write("Digite o ID do Produto que deseja remover: ");
                        id = int.Parse(Console.ReadLine());

                        new ProdutoDAO().Delete(id);
                        Console.WriteLine("Produto removido com sucesso!");
                        break;


                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                Console.Clear();
                }

            } while (opcao != 0);

        }
    }
}
