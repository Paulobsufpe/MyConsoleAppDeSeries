using System;
using System.Text;

namespace MyAppDeSeries
{
    public class Serie
    {
        internal string         Titulo { get; }
        private  string         Descricao;
        private  uint           Ano;
        private  GenerosDeSerie Genero;
        

        private Serie()
        {
        }

        public Serie(string titulo, string descricao, uint ano, GenerosDeSerie genero)
        {
            this.Titulo    = titulo    ?? throw new ArgumentNullException(nameof(titulo));
            this.Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.Ano       = ano;
            this.Genero    = genero;
        }

        public static string ConstroiBarra(string s, int n)
        {
            return new StringBuilder(s.Length * n)
                .AppendJoin(s, new string[n + 1])
                .ToString();
        }

        public override string ToString()
        {
            int largura = Console.WindowWidth;
            if (largura < 60)
            {
                throw new Exception("Tela muito pequena! impossível visualizar " +
                    "as informações nessa resolução.");
            }
            string nl = Environment.NewLine;
            int tam = largura < 65 ? 40 : largura - 25;
            string barra = ConstroiBarra("-", tam);

            string ret = string.Concat(
                barra                ,                 nl,
                "Título:            ", this.Titulo,    nl,
                "Descrição:         ", this.Descricao, nl,
                "Gênero:            ", this.Genero,    nl,
                "Ano de lançamento: ", this.Ano,       nl,
                barra
                );
            
            return ret;
        }
    }
}
