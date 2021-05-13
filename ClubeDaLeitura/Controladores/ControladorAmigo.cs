using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorAmigo : ControladorBase
    {
        public ControladorAmigo(int capacidadeRegistros)
            : base(capacidadeRegistros)
        {
        }
        public void RegistrarAmigo(int id, string nome, string responsavel, string telefone, string endereco)
        {
            Amigo amigo;
            int posicao = 0;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amigo = (Amigo)registros[posicao];
            }

            amigo.nome = nome;
            amigo.nomeResponsavel = responsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            registros[posicao] = amigo;

        }

        public bool ExcluirAmigo(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }

        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] amigoAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigoAux, amigoAux.Length);

            return amigoAux;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistro(new Amigo(id));
        }
    }
}
