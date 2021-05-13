using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    class GeradorId
    {
        private static int idAmigo = 0;
        private static int idRevista = 0;
        private static int idCaixa = 0;
        private static int idEmprestimo = 0;

        public static int GerarIdAmigo()
        {
            return ++idAmigo;
        }

        internal static int GerarIdRevista()
        {
            return ++idRevista;
        }

        internal static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        internal static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }
    }
}
