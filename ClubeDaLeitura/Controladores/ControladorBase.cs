using System;

namespace ClubeDaLeitura.Controladores
{
    public abstract class ControladorBase
    {
        protected object[] registros = null;

        public ControladorBase(int capacidadeRegistros)
        {
            registros = new object[capacidadeRegistros];
        }

        protected bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }

        protected object SelecionarRegistro(object obj)
        {
            foreach (var item in registros)
            {
                if (item.Equals(obj))
                    return item;
            }

            return null;
        }

        protected object[] SelecionarTodosRegistros()
        {
            object[] registrosAux = new object[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    registrosAux[i++] = registro;
            }

            return registrosAux;
        }

        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }

            return numeroRegistrosCadastrados;
        }

        protected int ObterPosicaoVazia()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        protected int ObterPosicaoOcupada(object objSelecionado)
        {
            int posicao = -1;

            for (int i = 0; i < registros.Length; i++)
            {
                if (objSelecionado.Equals(registros[i]))
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
    }
}
