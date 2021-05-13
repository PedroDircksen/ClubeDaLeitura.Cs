using System;

namespace ClubeDaLeitura.Telas
{
    public interface IEditavel
    {
        void Registrar(int id);
        bool Visualizar();
        void Editar();
        void Excluir();
    }
}
