using System;

namespace ClubeDaLeitura.Dominios
{
    public class Revista
    {
        public int id;
        public string tipoColecao;
        public int numeroEdicao;
        public string anoRevista;
        public Caixa caixaArmazenada;
        public string nome;
        public bool emprestado;

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Revista r = (Revista)obj;

            if (r != null && r.id == this.id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
