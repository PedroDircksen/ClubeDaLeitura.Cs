using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaCaixa : TelaBase, IEditavel
    {
        private ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controlador)
        {
            controladorCaixa = controlador;
        }

        public void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        public void Registrar(int id)
        {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            controladorCaixa.RegistrarCaixa(id, cor, etiqueta);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRegistrado com sucesso!");
            Console.ReadLine();
            Console.ResetColor();
        }

        public bool Visualizar()
        {
            Console.Clear();

            bool temCaixa = true;

            string configuracaColunasTabela = "{0,-10} | {1,-15} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   caixas[i].id, caixas[i].cor, caixas[i].etiqueta);

                Console.WriteLine();
            }

            if (caixas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhuma caixa cadastrada!");
                Console.ResetColor();
                temCaixa = false;
            }                      

            Console.ReadLine();

            return temCaixa;
        }

        #region Métodos Privados
        private void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
