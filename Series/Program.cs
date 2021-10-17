using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VizualizarSerie();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VizualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int opcaoescolhida = 0;

            int indiceSerie = int.Parse(Console.ReadLine());
            if (opcaoescolhida > 0 || opcaoescolhida < 14)
            {
                var serie = repositorio.RetornaPorId(indiceSerie);
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Digite dados válidos");
                return;
            }


        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série");
            int entradaTitulo = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo.ToString(),
                                        ano: entradaAno,
                                        descricao: entradaDescricao.ToString());
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie encontrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluído*" : "");
            }

        }

        private static void InserirSerie()
        {
                Console.WriteLine("Inserir nova serie");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Digite o gênero entre as opções acima");

                int entradaGenero = int.Parse(Console.ReadLine());


                Console.Write("Digite o título da série");
                int entradaTitulo = int.Parse(Console.ReadLine());

                Console.Write("Digite o ano de inicio da série");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição da série");
                int entradaDescricao = int.Parse(Console.ReadLine());

                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo.ToString(),
                                            ano: entradaAno,
                                            descricao: entradaDescricao.ToString());
                repositorio.Insere(novaSerie);

        }
            

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("EngeSoftware : Series ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Vizualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opacaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opacaoUsuario;


        }
    }
}
