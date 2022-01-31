using System;

namespace MyAppDeSeries
{
    class Program
    {
        static void Main(string[] args)
        {
			//Console.WriteLine(string.Join(' ', args));


			//Console.WriteLine(new Serie("Caindo do Céu",
			//    "Uma viagem pelo mundo em um balão",
			//    2001, GenerosDeSerie.Aventura));

			Console.Clear();
			Console.WriteLine("MySeriesApp - Bem vinde!" + Environment.NewLine);


			Action[] actions = new Action[6]
			{
				() => SerieConsoleUtils.Listar(),
				() => SerieConsoleUtils.Adiciona(),
				() => SerieConsoleUtils.Atualiza(),
				() => SerieConsoleUtils.Remove(),
				() => SerieConsoleUtils.Retorna(),
				() => Console.Clear()
			};


			string opcaoUsuario;

			do
			{
				opcaoUsuario = ObterOpcaoUsuario();

				if (opcaoUsuario.StartsWith('X'))
                {
					break;
                }
				else if (opcaoUsuario.StartsWith('C'))
				{
					actions[5].Invoke();
				}
				else if (int.TryParse(opcaoUsuario, out int num))
				{
					if (num < 6 && num > 0)
					{
						actions[num - 1].Invoke();
					}
					else
					{
						Console.Clear();
						SerieConsoleUtils.MsgErr("Número fornecido está fora do " +
							"intervalo! Tente novamente.");
                        Console.WriteLine();
					}
				}
				else
				{
					Console.Clear();
					SerieConsoleUtils.MsgErr("Entrada inválida! " +
						"Tente novamente.");
                    Console.WriteLine();
				}

			} while (true);

			Console.WriteLine("Xeeeeru! Até mais!");

		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Excluir série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = string.Empty;
			try
            {
				opcaoUsuario = Console.ReadLine().ToUpper();
			}
            catch (NullReferenceException)
            {
				SerieConsoleUtils.MsgErr("Saindo... Xeru, viu?!");
				Environment.Exit(0);
            }
			catch (Exception exc)
            {
				SerieConsoleUtils.MsgErr("Olha, faço nem ideia do que aconteceu!" +
                    " Segue alguma pista: " + exc.Message);
				Environment.Exit(1);
            }
			
			Console.WriteLine();
			return opcaoUsuario;
		}

	}
}
