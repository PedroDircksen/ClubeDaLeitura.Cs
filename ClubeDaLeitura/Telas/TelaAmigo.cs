using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaAmigo : TelaBase, IEditavel
    {
        private ControladorAmigo controladorAmigo;

        public TelaAmigo(ControladorAmigo controlador)
        {
            controladorAmigo = controlador;
        }

        public void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do amigo que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do amigo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmigo.ExcluirAmigo(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        public void Registrar(int id)
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o responsavel do amigo: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            controladorAmigo.RegistrarAmigo(id, nome, responsavel, telefone, endereco);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRegistrado com sucesso!");
            Console.ReadLine();
            Console.ResetColor();
        }

        public bool Visualizar()
        {
            Console.Clear();

            bool temAmigo = true;

            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amigos = controladorAmigo.SelecionarTodosAmigos();

            for (int i = 0; i < amigos.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   amigos[i].id, amigos[i].nome, amigos[i].nomeResponsavel, amigos[i].endereco);

                Console.WriteLine();
            }

            if (amigos.Length == 0)
            {
                temAmigo = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhumo amigo cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();

            return temAmigo;
        }

        #region Métodos Privados
        private void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Responsável", "Endereço");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
