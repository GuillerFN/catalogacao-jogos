using System;

namespace GUI.Jogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {  
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogos();
                        break;
                    case "3":
                        AtualizarJogos();
                        break;
                    case "4":
                        ExcluirJogos();
                        break;
                    case "5":
                        VisualizarJogos();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarJogos()
        {
            Console.WriteLine("Litar jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            foreach (var jogo in lista)
            {
                var excluido = jogo.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "Excluído*" : ""));
            }
        }

        private static void InserirJogos()
        {
            Console.WriteLine("Inserir novo jogo");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do início do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo novoJogo = new Jogo(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novoJogo);
        }

        private static void AtualizarJogos()
        {
            Console.Write("Digite o Id do Jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do início do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo atualizaJogo = new Jogo(id: indiceJogo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }

        private static void ExcluirJogos()
        {
            Console.Write("Digite o Id do Jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogo);
        }

        private static void VisualizarJogos()
        {
            Console.Write("Digite o Id do Jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            Console.WriteLine(jogo);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("GUILLER JOGOS a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Jogos");
            Console.WriteLine("2- Inserir novo Jogo");
            Console.WriteLine("3- Atualizar Jogo");
            Console.WriteLine("4- Excluir Jogo");
            Console.WriteLine("5- Visualizar Jogo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
