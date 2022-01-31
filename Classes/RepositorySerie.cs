using System;
using System.Collections.Generic;

namespace MyAppDeSeries
{
    public class RepositorySerieIM : IRepositorySeries
    {
        private RepositorySerieIM() {}
        private static RepositorySerieIM instance;

        public static RepositorySerieIM GetInstance()
        {
            if (instance == null)
            {
                instance = new RepositorySerieIM();
            }
            return instance;
        }

        private static readonly List<Serie> Series = new();


        public void Adiciona(Serie serie)
        {
            Series.Add(serie);
        }

        public List<Serie> Listar()
        {
            return Series;
        }

        public Serie Retorna(int index)
        {
            if (index >= 0 && index < Series.Count)
            {
                return Series[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Atualizar(int index, Serie serie)
        {
            if (index >= 0 && index < Series.Count)
            {
                Series[index] = serie;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < Series.Count)
            {
                Series.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            };
        }

        

    }
}
