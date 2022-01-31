using System;
using System.Collections.Generic;

namespace MyAppDeSeries
{
    public interface IRepositorySeries
    {
        public void        Adiciona(Serie serie);
        public List<Serie> Listar();
        public Serie       Retorna(int index);
        public void        Atualizar(int index, Serie serie);
        public void        Remove(int index);
    }
}
