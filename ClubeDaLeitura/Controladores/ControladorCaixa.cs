using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public ControladorCaixa(int capacidadeRegistros)
            : base(capacidadeRegistros)
        {
        }

        public void RegistrarCaixa(int id, string cor, string etiqueta)
        {
            Caixa caixa;
            int posicao = 0;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }
            caixa.cor = cor;
            caixa.etiqueta = etiqueta;

            registros[posicao] = caixa;

        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistro(new Caixa(id));
        }
    }
}
