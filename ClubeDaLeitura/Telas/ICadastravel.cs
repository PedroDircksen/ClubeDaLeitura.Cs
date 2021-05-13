using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    interface ICadastravel
    {
        void RegistrarEmprestimo(int id);
        void RegistrarDevolucao();
        void visualizarTodosEmprestimos();
        void visualizarEmprestimosAbertos();
    }
}
