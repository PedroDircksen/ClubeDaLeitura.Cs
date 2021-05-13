using ClubeDaLeitura.Dominios;
using System;

namespace ClubeDaLeitura.Controladores
{
    class ControladorEmprestimo : ControladorBase
    {
        private ControladorAmigo controladorAmigo;
        private ControladorRevista controladorRevista;
        public ControladorEmprestimo(int capacidadeRegistros, ControladorAmigo controladorA, ControladorRevista controladorR)
           : base(capacidadeRegistros)
        {
            controladorAmigo = controladorA;
            controladorRevista = controladorR;
        }
        public bool RegistrarEmprestimo(int id, int idAmigoEmprestimo, int idRevistaEmprestimo, DateTime dataDevolucao)
        {
            bool conseguiuRegistrar = false;
            Emprestimo emprestimo;
            int posicao = 0;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amigo = controladorAmigo.SelecionarAmigoPorId(idAmigoEmprestimo);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);

            if (emprestimo.amigo.pegouRevista == false && emprestimo.revista.emprestado == false)
            {
                emprestimo.dataDevolucao = dataDevolucao;
                emprestimo.dataEmprestimo = DateTime.Now;
                emprestimo.revista.emprestado = true;
                emprestimo.amigo.pegouRevista = true;
                emprestimo.emprestimoFechado = false;
                conseguiuRegistrar = true;

                registros[posicao] = emprestimo;
            }
            else
            {
                conseguiuRegistrar = false;
            }

            return conseguiuRegistrar;
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimoAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimoAux, emprestimoAux.Length);

            return emprestimoAux;
        }

        public void Devolver(int id)
        {
            Emprestimo emprestimo;
            int posicao = 0;

            posicao = ObterPosicaoOcupada(new Emprestimo(id));
            emprestimo = (Emprestimo)registros[posicao];

            emprestimo.revista.emprestado = false;
            emprestimo.amigo.pegouRevista = false;
            emprestimo.emprestimoFechado = true;
            emprestimo.dataDevolucao = DateTime.Now;
        }

        //public void Teste()
        //{
        //    Emprestimo emprestimo = new Emprestimo();
        //    Emprestimo emprestimo1 = new Emprestimo();
        //    Emprestimo emprestimo2 = new Emprestimo();
        //    Emprestimo emprestimo3 = new Emprestimo();
        //    Emprestimo emprestimo4 = new Emprestimo();
        //    Emprestimo emprestimo5 = new Emprestimo();

        //    DateTime mes2 = Convert.ToDateTime("13/02/2021");
        //    DateTime mes3 = Convert.ToDateTime("13/03/2021");
        //    DateTime mes4 = Convert.ToDateTime("13/04/2021");
        //    DateTime mes5 = Convert.ToDateTime("13/05/2021");
        //    DateTime mes6 = Convert.ToDateTime("13/06/2021");
        //    DateTime mes7 = Convert.ToDateTime("13/07/2021");

        //    Amigo amiguinho = new Amigo();
        //    amiguinho.nome = "pedrinho";
        //    Amigo amiguinho1 = new Amigo();
        //    amiguinho1.nome = "joao";
        //    Amigo amiguinho2 = new Amigo();
        //    amiguinho2.nome = "carlos";
        //    Amigo amiguinho3 = new Amigo();
        //    amiguinho3.nome = "rech";
        //    Amigo amiguinho4 = new Amigo();
        //    amiguinho4.nome = "artur";
        //    Amigo amiguinho5 = new Amigo();
        //    amiguinho5.nome = "inacio";

        //    Revista revista = new Revista();
        //    revista.nome = "Turma da monica";
        //    Revista revista1 = new Revista();
        //    revista1.nome = "Turma da monica";
        //    Revista revista2 = new Revista();
        //    revista2.nome = "Turma da monica";
        //    Revista revista3 = new Revista();
        //    revista3.nome = "Turma da monica";
        //    Revista revista4 = new Revista();
        //    revista4.nome = "Turma da monica";
        //    Revista revista5 = new Revista();
        //    revista5.nome = "Turma da monica";

        //    emprestimo.amigo = amiguinho;
        //    emprestimo.revista = revista;
        //    emprestimo.dataEmprestimo = mes2;
        //    emprestimo.dataDevolucao = DateTime.Now;
        //    registros[0] = emprestimo;

        //    emprestimo1.amigo = amiguinho1;
        //    emprestimo1.revista = revista1;
        //    emprestimo1.dataEmprestimo = mes3;
        //    emprestimo1.dataDevolucao = DateTime.Now;
        //    registros[1] = emprestimo1;

        //    emprestimo2.amigo = amiguinho2;
        //    emprestimo2.revista = revista2;
        //    emprestimo2.dataEmprestimo = mes4;
        //    emprestimo2.dataDevolucao = DateTime.Now;
        //    registros[2] = emprestimo2;

        //    emprestimo3.amigo = amiguinho3;
        //    emprestimo3.revista = revista3;
        //    emprestimo3.dataEmprestimo = mes5;
        //    emprestimo3.dataDevolucao = DateTime.Now;
        //    registros[3] = emprestimo3;

        //    emprestimo4.amigo = amiguinho4;
        //    emprestimo4.revista = revista4;
        //    emprestimo4.dataEmprestimo = mes6;
        //    emprestimo4.dataDevolucao = DateTime.Now;
        //    registros[4] = emprestimo4;

        //    emprestimo5.amigo = amiguinho;
        //    emprestimo5.revista = revista;
        //    emprestimo5.dataEmprestimo = mes7;
        //    emprestimo5.dataDevolucao = DateTime.Now;
        //    registros[5] = emprestimo5;
        //}
    }
}
