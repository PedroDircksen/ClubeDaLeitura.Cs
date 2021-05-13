using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    class Program
    {
        const int capacidadeRegistos = 100;

        static void Main(string[] args)
        {
            ControladorCaixa controladorCaixa = new ControladorCaixa(capacidadeRegistos);
            TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);

            ControladorRevista controladorRevista = new ControladorRevista(capacidadeRegistos, controladorCaixa);
            TelaRevista telaRevista = new TelaRevista(controladorRevista, telaCaixa);

            ControladorAmigo controladorAmigo = new ControladorAmigo(capacidadeRegistos);
            TelaAmigo telaAmigo = new TelaAmigo(controladorAmigo);

            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(capacidadeRegistos, controladorAmigo, controladorRevista);
            
            ICadastravel telaEmprestimos = null;
            IEditavel tela = null;
            TelaBase telaBase = new TelaBase();

            while (true)
            {
                string opcao = ApresentarMenu();

                if (opcao.Equals("S"))
                    break;

                else if (opcao == "1")
                    tela = new TelaCaixa(controladorCaixa);

                else if (opcao == "2")
                    tela = new TelaRevista(controladorRevista, telaCaixa);

                else if (opcao == "3")
                    tela = new TelaAmigo(controladorAmigo);

                else if (opcao == "4")
                    telaEmprestimos = new TelaEmprestimo(controladorEmprestimo, telaRevista, telaAmigo);

                if (opcao != "4")
                {
                    string opcaoCadastro = telaBase.ObterOpcao();

                    if (opcaoCadastro == "1")
                        tela.Registrar(0);

                    else if (opcaoCadastro == "2")
                        tela.Visualizar();

                    else if (opcaoCadastro == "3")
                        tela.Editar();

                    else if (opcaoCadastro == "4")
                        tela.Excluir();

                    else
                        break;
                }
                else
                {
                    string opcaoEmprestimo = telaBase.ObterOpcaoEmprestimo();

                    if (opcaoEmprestimo == "1")
                        telaEmprestimos.RegistrarEmprestimo(0);

                    else if (opcaoEmprestimo == "2")
                        telaEmprestimos.visualizarTodosEmprestimos();

                    else if (opcaoEmprestimo == "3")
                        telaEmprestimos.visualizarEmprestimosAbertos();

                    else if (opcaoEmprestimo == "4")
                        telaEmprestimos.RegistrarDevolucao();
                    else
                        break;
                }
            }
        }

        #region Métodos privados        
        private static string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Menu Principal\n");
            Console.WriteLine("Digite 1 para o Controle de Caixas");
            Console.WriteLine("Digite 2 para o Controle de Revistas");
            Console.WriteLine("Digite 3 para o Controle de Amiguinhos");
            Console.WriteLine("Digite 4 para o Controle de Emprestimos");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine().ToUpper();

            Console.Clear();

            return opcao;

        }
        #endregion
    }
}
