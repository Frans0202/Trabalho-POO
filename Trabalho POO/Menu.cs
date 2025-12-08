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
            int opcaoPrincipal;
            do
            {
                Console.Clear();
                Console.WriteLine("--- SISTEMA DO MERCADO ---\n");
                Console.WriteLine("Escolha uma das opções abaixo: \n");
                Console.WriteLine("1. Cadastrar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Alterar");
                Console.WriteLine("4. Remover");
                Console.WriteLine("0. Sair");
                Console.Write("Opção selecionada: ");
                opcaoPrincipal = Convert.ToInt32(Console.ReadLine());

                switch (opcaoPrincipal)
                {
                    case 1: // CADASTRAR
                        Console.Clear();
                        Console.WriteLine("--- CADASTRAR ---");
                        Console.WriteLine("1. Categoria");
                        Console.WriteLine("2. Desconto");
                        Console.WriteLine("3. Estoque");
                        Console.WriteLine("4. Endereço");
                        Console.WriteLine("5. Gênero");
                        Console.WriteLine("6. Fornecedor");
                        Console.WriteLine("7. Cliente");
                        Console.WriteLine("8. Funcionário");
                        Console.WriteLine("9. Venda");
                        Console.WriteLine("10. Produto");
                        Console.Write("Escolha a entidade: ");
                        int opcaoCadastro = Convert.ToInt32(Console.ReadLine());

                        switch (opcaoCadastro)
                        {
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
                                d.Porcentagem = Convert.ToDouble(Console.ReadLine());
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
                                e.QuantidadeAtual = Convert.ToInt32(Console.ReadLine());
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
                                f.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());
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
                                cli.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID do gênero: ");
                                cli.fk_Id_genero = Convert.ToInt32(Console.ReadLine());
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
                                fun.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID gênero: ");
                                fun.fk_Id_genero = Convert.ToInt32(Console.ReadLine());
                                funcionarioDAO.Create(fun);
                                Console.WriteLine("Funcionário cadastrado!");
                                break;

                            case 9:
                                Venda v = new Venda();
                                Console.Write("Valor total: ");
                                v.ValorTotal = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Quantidade: ");
                                v.Quantidade = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID cliente: ");
                                v.fk_Id_cliente = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID funcionário: ");
                                v.fk_Id_funcionario = Convert.ToInt32(Console.ReadLine());
                                vendaDAO.Create(v);
                                Console.WriteLine("Venda cadastrada!");
                                break;

                            case 10:
                                Produto p = new Produto();
                                Console.Write("Sessão: ");
                                p.Sessao = Console.ReadLine();
                                Console.Write("Valor unitário: ");
                                p.ValorUnitario = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Marca: ");
                                p.Marca = Console.ReadLine();
                                Console.Write("Descrição: ");
                                p.Descricao = Console.ReadLine();
                                Console.Write("ID categoria: ");
                                p.fk_Id_categoria = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID desconto (ou vazio): ");
                                string desc = Console.ReadLine();
                                p.fk_Id_desconto = string.IsNullOrEmpty(desc) ? null : Convert.ToInt32(desc);
                                Console.Write("ID estoque: ");
                                p.fk_Id_estoque = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID fornecedor: ");
                                p.fk_Id_fornecedor = Convert.ToInt32(Console.ReadLine());
                                Console.Write("ID venda (ou vazio): ");
                                string vendaStr = Console.ReadLine();
                                p.fk_Id_venda = string.IsNullOrEmpty(vendaStr) ? null : Convert.ToInt32(vendaStr);

                                produtoDAO.Create(p);
                                Console.WriteLine("Produto cadastrado!");
                                break;
                        }
                        break;

                    case 2: // LISTAR
                        Console.Clear();
                        Console.WriteLine("--- LISTAR ---");
                        Console.WriteLine("1. Categorias");
                        Console.WriteLine("2. Descontos");
                        Console.WriteLine("3. Estoques");
                        Console.WriteLine("4. Endereços");
                        Console.WriteLine("5. Gêneros");
                        Console.WriteLine("6. Fornecedores");
                        Console.WriteLine("7. Clientes");
                        Console.WriteLine("8. Funcionários");
                        Console.WriteLine("9. Vendas");
                        Console.WriteLine("10. Produtos");
                        Console.Write("Escolha a entidade: ");
                        int opcaoListar = Convert.ToInt32(Console.ReadLine());

                        switch (opcaoListar)
                        {
                            case 1:
                                Console.WriteLine("--- CATEGORIAS ---");
                                foreach (var item in categoriaDAO.GetAll())
                                    Console.WriteLine($"{item.Id_categoria} - {item.Tipo}");
                                break;

                            case 2:
                                Console.WriteLine("--- DESCONTOS ---");
                                foreach (var item in descontoDAO.GetAll())
                                    Console.WriteLine($"{item.Id_desconto} - {item.Porcentagem}% ({item.DataInicio} até {item.DataFim})");
                                break;

                            case 3:
                                Console.WriteLine("--- ESTOQUE ---");
                                foreach (var item in estoqueDAO.GetAll())
                                    Console.WriteLine($"ID {item.Id_estoque}: {item.QuantidadeAtual} unidades");
                                break;

                            case 4:
                                Console.WriteLine("--- ENDEREÇOS ---");
                                foreach (var item in enderecoDAO.GetAll())
                                    Console.WriteLine($"{item.Id_endereco} - {item.Rua}, {item.Numero}, {item.Bairro}, CEP {item.Cep}");
                                break;

                            case 5:
                                Console.WriteLine("--- GÊNEROS ---");
                                foreach (var item in generoDAO.GetAll())
                                    Console.WriteLine($"{item.Id_genero}: {item.Tipo}");
                                break;

                            case 6:
                                Console.WriteLine("--- FORNECEDORES ---");
                                foreach (var item in fornecedorDAO.GetAll())
                                    Console.WriteLine($"{item.Id_fornecedor} - {item.NomeFornecedor} - Tel {item.Telefone} - End {item.fk_Id_endereco}");
                                break;

                            case 7:
                                Console.WriteLine("--- CLIENTES ---");
                                foreach (var item in clienteDAO.GetAll())
                                    Console.WriteLine($"{item.Id_cliente} - {item.Nome} - {item.Email} - End {item.fk_Id_endereco}");
                                break;

                            case 8:
                                Console.WriteLine("--- FUNCIONÁRIOS ---");
                                foreach (var item in funcionarioDAO.GetAll())
                                    Console.WriteLine($"{item.Id_funcionario} - {item.Nome} - CPF {item.Cpf}");
                                break;

                            case 9:
                                Console.WriteLine("--- VENDAS ---");
                                foreach (var item in vendaDAO.GetAll())
                                    Console.WriteLine($"{item.Id_venda}: R$ {item.ValorTotal} - {item.Quantidade} itens");
                                break;

                            case 10:
                                Console.WriteLine("--- PRODUTOS ---");
                                foreach (var item in produtoDAO.GetAll())
                                    Console.WriteLine($"{item.Id_produto} - {item.Marca} {item.Descricao} | R$ {item.ValorUnitario}");
                                break;
                        }
                        break;

                    case 3: // ALTERAR
                        Console.Clear();
                        Console.WriteLine("--- ALTERAR ---");
                        Console.WriteLine("1. Categorias");
                        Console.WriteLine("2. Descontos");
                        Console.WriteLine("3. Estoques");
                        Console.WriteLine("4. Endereços");
                        Console.WriteLine("5. Gêneros");
                        Console.WriteLine("6. Fornecedores");
                        Console.WriteLine("7. Clientes");
                        Console.WriteLine("8. Funcionários");
                        Console.WriteLine("9. Vendas");
                        Console.WriteLine("10. Produtos");
                        Console.Write("Escolha a entidade: ");
                        Console.Write("Escolha a entidade: ");
                        int opcaoAlterar = Convert.ToInt32(Console.ReadLine());

                        switch (opcaoAlterar)
                        {
                            case 1:
                                Console.Write("ID da categoria para alterar: ");
                                int idCatAlt = Convert.ToInt32(Console.ReadLine());

                                Categoria catAlt = categoriaDAO.GetById(idCatAlt);
                                if (catAlt == null) { Console.WriteLine("Categoria não encontrada!"); break; }

                                Console.Write("Novo tipo: ");
                                catAlt.Tipo = Console.ReadLine();

                                categoriaDAO.Update(catAlt);
                                Console.WriteLine("Categoria alterada!");

                                break;
                            case 2:
                                Console.Write("ID do desconto para alterar: ");
                                int idDescAlt = Convert.ToInt32(Console.ReadLine());

                                Desconto descAlt = descontoDAO.GetById(idDescAlt);
                                if (descAlt == null) { Console.WriteLine("Desconto não encontrado!"); break; }

                                Console.Write("Nova porcentagem: ");
                                descAlt.Porcentagem = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Nova data início: ");
                                descAlt.DataInicio = DateTime.Parse(Console.ReadLine());
                                Console.Write("Nova data fim: ");
                                descAlt.DataFim = DateTime.Parse(Console.ReadLine());

                                descontoDAO.Update(descAlt);
                                Console.WriteLine("Desconto alterado!");
                                break;
                            case 3:
                                Console.Write("ID do estoque para alterar: ");
                                int idEstAlt = Convert.ToInt32(Console.ReadLine());

                                Estoque estAlt = estoqueDAO.GetById(idEstAlt);
                                if (estAlt == null) { Console.WriteLine("Estoque não encontrado!"); break; }

                                Console.Write("Nova quantidade: ");
                                estAlt.QuantidadeAtual = Convert.ToInt32(Console.ReadLine());

                                estoqueDAO.Update(estAlt);
                                Console.WriteLine("Estoque alterado!");
                                break;
                            case 4:
                                Console.Write("ID do endereço para alterar: ");
                                int idEndAlt = Convert.ToInt32(Console.ReadLine());

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
                            case 5:
                                Console.Write("ID do gênero para alterar: ");
                                int idGenAlt = Convert.ToInt32(Console.ReadLine());

                                Genero genAlt = generoDAO.GetById(idGenAlt);
                                if (genAlt == null) { Console.WriteLine("Gênero não encontrado!"); break; }

                                Console.Write("Novo tipo: ");
                                genAlt.Tipo = Console.ReadLine();

                                generoDAO.Update(genAlt);
                                Console.WriteLine("Gênero alterado!");
                                break;
                            case 6:
                                Console.Write("ID do fornecedor para alterar: ");
                                int idFornAlt = Convert.ToInt32(Console.ReadLine());

                                Fornecedor fornAlt = fornecedorDAO.GetById(idFornAlt);
                                if (fornAlt == null) { Console.WriteLine("Fornecedor não encontrado!"); break; }

                                Console.Write("Novo nome: ");
                                fornAlt.NomeFornecedor = Console.ReadLine();
                                Console.Write("Novo telefone: ");
                                fornAlt.Telefone = Console.ReadLine();
                                Console.Write("Novo ID de endereço: ");
                                fornAlt.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());

                                fornecedorDAO.Update(fornAlt);
                                Console.WriteLine("Fornecedor alterado!");
                                break;
                            case 7:
                                Console.Write("ID do cliente para alterar: ");
                                int idCliAlt = Convert.ToInt32(Console.ReadLine());

                                Cliente cliAlt = clienteDAO.GetById(idCliAlt);
                                if (cliAlt == null) { Console.WriteLine("Cliente não encontrado!"); break; }

                                Console.Write("Novo nome: ");
                                cliAlt.Nome = Console.ReadLine();
                                Console.Write("Novo email: ");
                                cliAlt.Email = Console.ReadLine();
                                Console.Write("Novo telefone: ");
                                cliAlt.Telefone = Console.ReadLine();
                                Console.Write("Novo ID endereço: ");
                                cliAlt.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID gênero: ");
                                cliAlt.fk_Id_genero = Convert.ToInt32(Console.ReadLine());

                                clienteDAO.Update(cliAlt);
                                Console.WriteLine("Cliente alterado!");
                                break;
                            case 8:
                                Console.Write("ID do funcionário para alterar: ");
                                int idFunAlt = Convert.ToInt32(Console.ReadLine());

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
                                funAlt.fk_Id_endereco = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID gênero: ");
                                funAlt.fk_Id_genero = Convert.ToInt32(Console.ReadLine());

                                funcionarioDAO.Update(funAlt);
                                Console.WriteLine("Funcionário alterado!");
                                break;
                            case 9:
                                Console.Write("ID da venda para alterar: ");
                                int idVendaAlt = Convert.ToInt32(Console.ReadLine());

                                Venda vendaAlt = vendaDAO.GetById(idVendaAlt);
                                if (vendaAlt == null) { Console.WriteLine("Venda não encontrada!"); break; }

                                Console.Write("Novo valor total: ");
                                vendaAlt.ValorTotal = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Nova quantidade: ");
                                vendaAlt.Quantidade = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID cliente: ");
                                vendaAlt.fk_Id_cliente = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID funcionário: ");
                                vendaAlt.fk_Id_funcionario = Convert.ToInt32(Console.ReadLine());

                                vendaDAO.Update(vendaAlt);
                                Console.WriteLine("Venda alterada!");
                                break;
                            case 10:
                                Console.Write("ID do produto para alterar: ");
                                int idProdAlt = Convert.ToInt32(Console.ReadLine());

                                Produto prodAlt = produtoDAO.GetById(idProdAlt);
                                if (prodAlt == null) { Console.WriteLine("Produto não encontrado!"); break; }

                                Console.Write("Nova sessão: ");
                                prodAlt.Sessao = Console.ReadLine();
                                Console.Write("Novo valor unitário: ");
                                prodAlt.ValorUnitario = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Nova marca: ");
                                prodAlt.Marca = Console.ReadLine();
                                Console.Write("Nova descrição: ");
                                prodAlt.Descricao = Console.ReadLine();
                                Console.Write("Novo ID categoria: ");
                                prodAlt.fk_Id_categoria = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID desconto (ou vazio): ");
                                string nd = Console.ReadLine();
                                prodAlt.fk_Id_desconto = string.IsNullOrEmpty(nd) ? null : Convert.ToInt32(nd);
                                Console.Write("Novo ID estoque: ");
                                prodAlt.fk_Id_estoque = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID fornecedor: ");
                                prodAlt.fk_Id_fornecedor = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Novo ID venda (ou vazio): ");
                                string nv = Console.ReadLine();
                                prodAlt.fk_Id_venda = string.IsNullOrEmpty(nv) ? null : Convert.ToInt32(nv);

                                produtoDAO.Update(prodAlt);
                                Console.WriteLine("Produto alterado!");
                                break;
                        }
                        break;

                    case 4: // REMOVER
                        Console.Clear();
                        Console.WriteLine("--- REMOVER ---");
                        Console.WriteLine("1. Categorias");
                        Console.WriteLine("2. Descontos");
                        Console.WriteLine("3. Estoques");
                        Console.WriteLine("4. Endereços");
                        Console.WriteLine("5. Gêneros");
                        Console.WriteLine("6. Fornecedores");
                        Console.WriteLine("7. Clientes");
                        Console.WriteLine("8. Funcionários");
                        Console.WriteLine("9. Vendas");
                        Console.WriteLine("10. Produtos");
                        Console.Write("Escolha a entidade: ");
                        int opcaoRemover = Convert.ToInt32(Console.ReadLine());

                        switch (opcaoRemover)
                        {
                            case 1:
                                Console.Write("Digite o ID da Categoria que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new CategoriaDAO().Delete(id);
                                Console.WriteLine("Categoria removida com sucesso!");
                                break;

                            case 2:
                                Console.Write("Digite o ID do Desconto que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new DescontoDAO().Delete(id);
                                Console.WriteLine("Desconto removido com sucesso!");
                                break;

                            case 3:
                                Console.Write("Digite o ID do Estoque que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new EstoqueDAO().Delete(id);
                                Console.WriteLine("Estoque removido com sucesso!");
                                break;

                            case 4:
                                Console.Write("Digite o ID do Endereço que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new EnderecoDAO().Delete(id);
                                Console.WriteLine("Endereço removido com sucesso!");
                                break;

                            case 5:
                                Console.Write("Digite o ID do Gênero que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new GeneroDAO().Delete(id);
                                Console.WriteLine("Gênero removido com sucesso!");
                                break;

                            case 6:
                                Console.Write("Digite o ID do Fornecedor que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new FornecedorDAO().Delete(id);
                                Console.WriteLine("Fornecedor removido com sucesso!");
                                break;

                            case 7:
                                Console.Write("Digite o ID do Cliente que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new ClienteDAO().Delete(id);
                                Console.WriteLine("Cliente removido com sucesso!");
                                break;

                            case 8:
                                Console.Write("Digite o ID do Funcionário que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new FuncionarioDAO().Delete(id);
                                Console.WriteLine("Funcionário removido com sucesso!");
                                break;

                            case 9:
                                Console.Write("Digite o ID da Venda que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new VendaDAO().Delete(id);
                                Console.WriteLine("Venda removida com sucesso!");
                                break;

                            case 10:
                                Console.Write("Digite o ID do Produto que deseja remover: ");
                                id = Convert.ToInt32(Console.ReadLine());

                                new ProdutoDAO().Delete(id);
                                Console.WriteLine("Produto removido com sucesso!");
                                break;
                        }
                        break;


                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcaoPrincipal != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                    Console.ReadKey();
                }

            } while (opcaoPrincipal != 0);

        }

    }
}