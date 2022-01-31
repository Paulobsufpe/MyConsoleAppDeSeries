using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppDeSeries
{
    internal static class SerieConsoleUtils
    {

        static readonly RepositorySerieIM repo = RepositorySerieIM.GetInstance();

        public static void Adiciona()
        {
            Serie serie = ObterSerie();
            repo.Adiciona(serie);
            Console.WriteLine($"O cadastro da série \"{serie.Titulo}\" foi adicionado!");
            Console.WriteLine();
        }

        public static void Listar()
        {
            List<Serie> lista = repo.Listar();

            Console.Clear();
            if (lista.Count < 1)
            {
                Console.WriteLine("Nenhuma série cadastrada."
                    + Environment.NewLine);
                return;
            }

            int digits = lista.Count.ToString().Length;
            int idigits;
            for (int i = 0; i < lista.Count; i++)
            {
                
                idigits = (i + 1).ToString().Length;
                string espaco = Serie.ConstroiBarra(" ", digits - idigits);
                Console.WriteLine($"{espaco}{i+1} - {lista[i].Titulo}");
            }
            Console.WriteLine();
        }

        public static void Retorna()
        {
            int tamLista = repo.Listar().Count;
            if (tamLista < 1)
            {
                Console.Clear();
                MsgErr("Não há nenhuma série catalogada para visualizar!");
                Console.WriteLine();
                return;
            }

            VerLista();

            do
            {
                Console.WriteLine("Digite o índice da série para ver as informações: ");

                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    MsgErr("Não foi possível ler um número! Tente novamente.");
                    continue;
                }
                else if (index < 1 || index > tamLista)
                {
                    MsgErr();
                    continue;
                }
                Console.Clear();
                try
                {
                    Console.WriteLine(repo.Retorna(index - 1));
                }
                catch (Exception ex)
                {
                    MsgErr(ex.Message + " Tente aumentar/redimensionar" +
                        " a janela da aplicação");
                    continue;
                }
                
                                                                                                                                                                                                                
                Console.WriteLine("Estas são as informações do cadastro da série");
                Console.WriteLine();
                break;

            } while (true);

        }

        public static void Atualiza()
        {
            int tamLista = repo.Listar().Count;
            if (tamLista < 1)
            {
                Console.Clear();
                MsgErr("Não há nenhuma série catalogada para atualizar!");
                Console.WriteLine();
                return;
            }

            VerLista();

            do
            {
                Console.WriteLine("Digite o índice da série para atualizar: ");

                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    MsgErr("Não foi possível ler um número! Tente novamente.");
                    continue;
                }
                else if (index < 1 || index > tamLista) 
                {
                    MsgErr();
                    continue;
                }
                Console.WriteLine("Para atualizar...");
                Serie serie = ObterSerie();
                repo.Atualizar(index - 1, serie);
                                                                                                                                                                
                Console.WriteLine($"O cadastro da série \"{serie.Titulo}\" foi atualizado!");
                Console.WriteLine();
                break;

            } while (true);

        }

        public static void Remove()
        {
            int tamLista = repo.Listar().Count;
            if (tamLista < 1)
            {
                Console.Clear();
                MsgErr("Não há nenhuma série catalogada para excluir!");
                Console.WriteLine();
                return;
            }

            VerLista();

            do
            {
                Console.WriteLine("Digite o índice da série para excluir: ");

                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    MsgErr("Não foi possível ler um número! Tente novamente.");
                    continue;
                }
                else if (index < 1 || index > tamLista)
                {
                    MsgErr();
                    continue;
                }
                Serie temp = repo.Retorna(index - 1);
                repo.Remove(index - 1);
                Console.Clear();
                                                                                                                                                                                                                                  Console.WriteLine("O cadastro da série " +
                    $"\"{temp.Titulo}\" foi removido!");
                Console.WriteLine();
                break;

            } while (true);
            
        }

        private static Serie ObterSerie()
        {
            Console.WriteLine("Digite o nome/título da série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Faça uma breve descrição da série: ");
            string descricao = Console.ReadLine();

            uint ano;
            do
            {
                Console.WriteLine("Forneça o ano de lançamento da série:");
                if (uint.TryParse(Console.ReadLine(), out ano))
                {
                    Console.Clear();
                    break;
                }
                MsgErr("Entrada invalída! Tente novamente.");

            } while (true);


            GenerosDeSerie genero;

            do
            {
                ListarGeneros();

                Console.WriteLine("Diga qual o gênero da série: ");
                bool fim = int.TryParse(Console.ReadLine(), out int generoNum);

                if (!fim)
                {
                    Console.Clear();
                    MsgErr("Entrada inválida! Tente novamente.");
                    Console.WriteLine();
                }
                else
                {
                    if (Enum.IsDefined(typeof(GenerosDeSerie), generoNum - 1))
                    {
                        genero = (GenerosDeSerie)(generoNum - 1);
                    }
                    else
                    {
                        Console.Clear();
                        MsgErr("Não está na lista!");
                        Console.WriteLine();
                        continue;
                    }
                    break;
                }

            } while (true);

            Console.Clear();
            return new Serie(titulo, descricao, ano, genero);
            
        }

        private static void ListarGeneros()
        {
            Array arrayGen = Enum.GetValues(typeof(GenerosDeSerie));

            int digits = arrayGen.Length.ToString().Length;
            int idigits;
            for (int i = 0; i < arrayGen.Length; i++)
            {
                idigits = (i + 1).ToString().Length;
                string espaco = Serie.ConstroiBarra(" ", digits - idigits);
                Console.WriteLine($"{espaco}{i+1} - {arrayGen.GetValue(i)}");
            }
            Console.WriteLine();

        }

        private static void VerLista()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.WriteLine("Deseja ver a lista das séries antes? [s/n] ");
                keyInfo = Console.ReadKey();
                
                if (keyInfo.KeyChar == 's')
                {
                    Listar();
                    break;
                }
                else if (keyInfo.KeyChar == 'n')
                {
                    Console.Clear();
                    Console.WriteLine("Pulando listagem...");
                    break;
                }
                else
                {
                    var pos = Console.GetCursorPosition();
                    if (pos.Left > 0)
                    {
                        Console.SetCursorPosition(pos.Left - 1, pos.Top);
                    }

                    MsgErr("Tecla inválida. Tente novamente.");
                    continue;
                }

            } while (true);
            
        }

        internal static void MsgErr()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine("Índice inválido. Tente novamente.");
            Console.ResetColor();
        }

        internal static void MsgErr(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine(msg);
            Console.ResetColor();
        }

        internal static void MsgErr(string msg,
            ConsoleColor? foreColor,
            ConsoleColor? backColor)
        {
            if (foreColor != null)
            {
                Console.ForegroundColor = foreColor.Value;
            }
            if (backColor != null)
            {
                Console.BackgroundColor = backColor.Value;
            }
            Console.Error.WriteLine(msg);
            Console.ResetColor();
        }

    }
}
