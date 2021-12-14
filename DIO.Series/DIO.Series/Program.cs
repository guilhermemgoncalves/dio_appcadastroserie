


using DIO.Series;

SerieRepositorio repositorio = new SerieRepositorio();
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
            VisualizarSerie();
            break;
        case "C":
            //Console.Clear();
            break;


        default:
            throw new ArgumentOutOfRangeException();
            break;


    }
    opcaoUsuario = ObterOpcaoUsuario();
}

void VisualizarSerie()
{
    int indiceSerie = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(indiceSerie);
    Console.WriteLine(serie);
    
}

void ExcluirSerie()
{
    Console.WriteLine("Por faovr Digite o ID da série a ser excluida: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Exclui(indiceSerie);

}

void AtualizarSerie()
{
    Console.WriteLine("Atualizar Série: ");
    Console.WriteLine("Digite o Ide da Serie que deseja atualizar: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine($"{i} -{Enum.GetName(typeof(Genero), i)} ");
    }
    Console.WriteLine("Considerando as opções acima digite um gênero: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o título da Série: ");
    string entradaTitulo = Console.ReadLine();

    Console.WriteLine("Digite o ano de inicio da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

    repositorio.Atualiza(indiceSerie, atualizaSerie);

}

void InserirSerie()
{
    Console.WriteLine("Inserir Nova Série: ");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine($"{i} -{Enum.GetName(typeof(Genero), i)} ");
    }
    Console.WriteLine("Considerando as opções acima digite um gênero: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o título da Série: ");
    string entradaTitulo = Console.ReadLine();

    Console.WriteLine("Digite o ano de inicio da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

    repositorio.Insere(novaSerie);
}

void ListarSeries()
{
    Console.WriteLine("Listar Séries: ");
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhuma Lista Cadastrada");
        return;
    }
    foreach (var serie in lista)
    {
        var excluido = serie.RetornaExcluido();
        if (!excluido)
        {
            Console.WriteLine($"#Id {serie.RetornaId()}: {serie.RetornaTitulo()}");
        }
    }
}

string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("Dio Series ao seu dispor");
    Console.WriteLine("Informe a opção desejada: ");

    Console.WriteLine("1- Listar séries");
    Console.WriteLine("2- Inserir nova séries");
    Console.WriteLine("3- Atualizar série");
    Console.WriteLine("4- Excluir série");
    Console.WriteLine("5- Visualizar série:");
    Console.WriteLine("C- Limpar tela");
    Console.WriteLine("X- Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}







