using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaRevista : TelaBase, IEditavel
    {
        private ControladorRevista controladorRevista;
        private TelaCaixa telaCaixa;

        public TelaRevista(ControladorRevista controlador, TelaCaixa telaC)
        {
            controladorRevista = controlador;
            telaCaixa = telaC;
        }

        public void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número da Revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        public void Registrar(int id)
        {
            bool temCaixa = telaCaixa.Visualizar();

            if (temCaixa)
            {
                Console.Write("Digite o ID da caixa que deseja armazenar a revista: ");
                int idCaixaRevista = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o nome da revista: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o tipo de coleção da revista: ");
                string tipoColecao = Console.ReadLine();

                Console.Write("Digite número de edição da revista: ");
                int numeroEdicao = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o ano da revista: ");
                string anoRevista = Console.ReadLine();

                controladorRevista.RegistrarRevista(id, idCaixaRevista, nome, tipoColecao, numeroEdicao, anoRevista);
            }
            
        }

        public bool Visualizar()
        {
            Console.Clear();

            bool temRevista = true;

            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].emprestado == false)
                {
                    Console.Write(configuracaColunasTabela,
                       revistas[i].id, revistas[i].nome, revistas[i].tipoColecao, revistas[i].anoRevista, revistas[i].caixaArmazenada.cor);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A revista " + revistas[i].nome + " está emprestada");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            if (revistas.Length == 0)
            {
                temRevista = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhuma revista cadastrada!");
                Console.ResetColor();
            }
            Console.ReadLine();

            return temRevista;
        }

        #region Métodos Privados
        private void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Revista", "Tipo de Coleção", "Ano da Revista", "Caixa");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
