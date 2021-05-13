using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaEmprestimo : TelaBase, ICadastravel
    {
        private ControladorEmprestimo controladorEmprestimo;
        private TelaRevista telaRevista;
        private TelaAmigo telaAmigo;

        public TelaEmprestimo(ControladorEmprestimo controlador, TelaRevista telaR, TelaAmigo telaA)
        {
            controladorEmprestimo = controlador;
            telaRevista = telaR;
            telaAmigo = telaA;
        }

        public void visualizarEmprestimosAbertos()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-15} | {2,-25} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i].emprestimoFechado == false)
                {
                    Console.Write(configuracaColunasTabela,
                       emprestimos[i].id, emprestimos[i].amigo.nome, emprestimos[i].revista.nome, emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy"), emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy"));

                    Console.WriteLine();
                }
            }
            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum empréstimo cadastrado!");
                Console.ResetColor();
            }


            Console.ReadLine();
        }

        public void RegistrarDevolucao()
        {
            visualizarEmprestimosAbertos();

            Console.WriteLine("Selecione o Id do empréstimo que deseja fechar");
            int idEscolhido = Convert.ToInt32(Console.ReadLine());

            controladorEmprestimo.Devolver(idEscolhido);
        }

        public void RegistrarEmprestimo(int id)
        {
            bool conseguiuRegistrar = false;
            bool temAmigo;
            bool temRevista;

            temAmigo = telaAmigo.Visualizar();
            if (temAmigo)
            {
                Console.Write("Digite o ID do amigo que vai retirar uma revista: ");
                int idAmigoEmprestimo = Convert.ToInt32(Console.ReadLine());

                temRevista = telaRevista.Visualizar();

                if (temRevista)
                {
                    Console.Write("Digite o ID da revista que vai retirar: ");
                    int idRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite a data de devolução da revista: ");
                    DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

                    conseguiuRegistrar = controladorEmprestimo.RegistrarEmprestimo(id, idAmigoEmprestimo, idRevistaEmprestimo, dataDevolucao);

                    if (conseguiuRegistrar)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nRegistrado com sucesso!");
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nErro ao tentar Registrar, Você precisa inserir amiguinhos e revistas válidas");
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                }
            }
        }

        public void visualizarTodosEmprestimos()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-15} | {2,-25} | {3,-25} | {4,-25}";

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            Console.WriteLine("Digite o mês dos empréstimos que deseja visualizar (Ex.: Janeiro = 01): ");
            string mesSelecionado = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Empréstimos Feitos no mês " + mesSelecionado + "\n");
            
            MontarCabecalhoTabela(configuracaColunasTabela);

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i].dataEmprestimo.ToString("MM") == mesSelecionado || emprestimos[i].dataEmprestimo.ToString("M") == mesSelecionado)
                {
                    Console.Write(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].amigo.nome, emprestimos[i].revista.nome, emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy"), emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy"));
                }
            }
            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum empréstimo cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        #region Métodos Privados
        private void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Amigo", "Revista", "Data do Empréstimo", "Data da Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
