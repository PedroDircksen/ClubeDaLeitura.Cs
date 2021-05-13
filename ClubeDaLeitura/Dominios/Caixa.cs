using System;

namespace ClubeDaLeitura.Dominios
{
    public class Caixa
    {
        public int id;
        public string cor;
        public string etiqueta;
        public int numero;
        public Revista[] revistas;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Caixa c = (Caixa)obj;

            if (c != null && c.id == this.id)
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
