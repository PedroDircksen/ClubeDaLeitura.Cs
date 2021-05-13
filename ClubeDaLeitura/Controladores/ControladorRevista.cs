using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Controladores
{
    class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(int capacidadeRegistros, ControladorCaixa controladorC)
            : base(capacidadeRegistros)
        {
            controladorCaixa = controladorC;
        }


        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistro(new Revista(id));
        }

        public void RegistrarRevista(int id, int idCaixaRevista, string nome, string tipoColecao, int numeroEdicao, string anoRevista)
        {
            Revista revista;
            int posicao = 0;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            if (idCaixaRevista != 0)
            {
                revista.caixaArmazenada = controladorCaixa.SelecionarCaixaPorId(idCaixaRevista);
                revista.nome = nome;
                revista.tipoColecao = tipoColecao;
                revista.numeroEdicao = numeroEdicao;
                revista.anoRevista = anoRevista;
            }

            if (revista.caixaArmazenada.cor != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRegistrado com sucesso!");
                Console.ReadLine();
                Console.ResetColor();
                registros[posicao] = revista;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falha ao tentar registrar revista");
                Console.ReadLine();
                Console.ResetColor();
            }

            registros[posicao] = revista;
        }
    }
}
