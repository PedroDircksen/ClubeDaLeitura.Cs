using System;

namespace ClubeDaLeitura.Telas
{
    public class TelaBase
    {
        public string ObterOpcaoEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("Menu de Cadastros\n");
            Console.WriteLine("Digite 1 para registrar ");
            Console.WriteLine("Digite 2 para visualizar histórico ");
            Console.WriteLine("Digite 3 para visualizar empréstimos em aberto ");
            Console.WriteLine("Digite 4 para devolver revista ");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine().ToUpper();

            Console.Clear();

            return opcao;
        }
        public string ObterOpcao()
        {
            Console.Clear();

            Console.WriteLine("Menu de Cadastros\n");
            Console.WriteLine("Digite 1 para registrar ");
            Console.WriteLine("Digite 2 para visualizar histórico ");
            Console.WriteLine("Digite 3 para editar ");
            Console.WriteLine("Digite 4 para excluir ");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine().ToUpper();

            Console.Clear();

            return opcao;
        }
    }
}
