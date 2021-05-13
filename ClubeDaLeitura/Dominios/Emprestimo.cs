using System;

namespace ClubeDaLeitura.Dominios
{
    public class Emprestimo
    {
        public int id;
        public Revista revista;
        public Amigo amigo;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public Emprestimo[] emprestimosFechados;
        public bool emprestimoFechado;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Emprestimo e = (Emprestimo)obj;

            if (e != null && e.id == this.id)
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
