using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloConta;
using Controle_do_Bar.ModuloGarcom;
using Controle_do_Bar.ModuloMesa;
using Controle_do_Bar.ModuloPedido;
using Controle_do_Bar.ModuloProduto;
using System;
using System.Collections;

namespace Controle_do_Bar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new(new());
            TelaGarcom telaGarcom = new(repositorioGarcom);

            RepositorioProduto repositorioProduto = new(new());
            TelaProduto telaProduto = new(repositorioProduto);

            RepositorioPedido repositorioPedido = new(new());
            TelaPedido telaPedido = new(repositorioPedido, telaProduto);

            RepositorioMesa repositorioMesa = new(new());
            TelaMesa telaMesa = new(repositorioMesa);

            RepositorioConta repositorioConta = new(new());
            TelaConta telaConta = new(repositorioConta, telaMesa, telaGarcom, telaPedido, repositorioMesa, repositorioGarcom);

            while (true)
            {
                Console.Clear(); 
                Console.WriteLine("0 - Sair\n1 - Garçom\n2 - Produto\n3 - Mesa\n4 - Conta\n");
                Console.WriteLine("Selecione a opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "0")
                    break;

                if (opcao == "1")
                {
                    string subMenu = "";

                    while (subMenu != "0")
                    {
                        subMenu = telaGarcom.ApresentarMenu();

                        if (subMenu == "1")
                        {
                            telaGarcom.InserirNovoRegistro();
                        }
                        else if (subMenu == "2")
                        {
                            telaGarcom.VisualizarRegistros(true);
                            Console.ReadLine();
                        }
                        else if (subMenu == "3")
                        {
                            telaGarcom.EditarRegistro();
                        }
                        else if (subMenu == "4")
                        {
                            telaGarcom.ExcluirRegistro();
                        }
                    }
                }else if(opcao == "2")
                {
                    string subMenu = "";

                    while (subMenu != "0")
                    {
                        subMenu = telaProduto.ApresentarMenu();
                        if (subMenu == "1")
                        {
                            telaProduto.InserirNovoRegistro();
                        }
                        else if (subMenu == "2")
                        {
                            telaProduto.VisualizarRegistros(true);
                            Console.ReadLine();
                        }
                        else if (subMenu == "3")
                        {
                            telaProduto.EditarRegistro();
                        }
                        else if (subMenu == "4")
                        {
                            telaProduto.ExcluirRegistro();
                        }
                    }
                }else if(opcao == "3")
                {
                    string subMenu = "";

                    while (subMenu != "0")
                    {
                        subMenu = telaMesa.ApresentarMenu();
                        if (subMenu == "1")
                        {
                            telaMesa.InserirNovoRegistro();
                        }
                        else if (subMenu == "2")
                        {
                            telaMesa.VisualizarRegistros(true);
                            Console.ReadLine();
                        }
                        else if (subMenu == "3")
                        {
                            telaMesa.EditarRegistro();
                        }
                        else if (subMenu == "4")
                        {
                            telaMesa.ExcluirRegistro();
                        }
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = "";

                    while (subMenu != "0")
                    {
                        subMenu = telaConta.ApresentarMenu();
                        if (subMenu == "1")
                        {
                            telaConta.InserirNovoRegistro();
                        }
                        else if (subMenu == "2")
                        {
                            telaConta.ObterNovoPedido();
                        }
                        else if (subMenu == "3")
                        {
                            telaConta.VisualizarRegistros(true);
                            Console.ReadLine();
                        }
                        else if (subMenu == "4")
                        {
                            telaConta.FecharConta();
                        }
                        else if (subMenu == "5")
                        {
                            telaConta.VisualizaTotalFaturado();
                            Console.ReadLine();
                        }
                    }

                }

            }
        }
    }
}
