using System;

namespace ClubeDaLeitura.Dominios
{
    public class Amigo
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public bool pegouRevista;

        public Amigo()
        {
            id = GeradorId.GerarIdAmigo();
        }

        public Amigo(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Amigo a = (Amigo)obj;

            if (a != null && a.id == this.id)
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
