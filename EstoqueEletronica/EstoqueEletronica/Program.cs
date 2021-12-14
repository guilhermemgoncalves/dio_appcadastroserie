
using EstoqueEletronica;

ComponentesRepositorio repositorio = new ComponentesRepositorio();
string opcaoUsuario = ObterOpcaoUsuario();

while (opcaoUsuario.ToUpper() != "X")
{

    switch (opcaoUsuario)
    {
        case "1":
            ListarComponentes();
            break;
        case "2":
            InserirComponentes();
            break;
        case "3":
            SomarComponentes();
            break;
        case "4":
            SubtrairComponentes();
            break;
        case "5":
            VisualizarComponente();
            break;
        


        default:
            Console.WriteLine("Valor Fornecido Inválido");
            break;


    }
    opcaoUsuario = ObterOpcaoUsuario();
}

void SubtrairComponentes()
{
    Console.WriteLine("Decrementar valores:");
    Console.WriteLine("Digite o ID do componentes que deseja subitrair quantidades: ");
    ListarComponentes();
    int indiceComponentes = int.Parse(Console.ReadLine());

    Console.WriteLine("Por favor digite o valor que deseja Decrementar: ");
    int sub = int.Parse(Console.ReadLine());

    var componenteAtual = repositorio.RetornaPorId(indiceComponentes);
    int novaQuantidade = (componenteAtual.RetornaQuantidade()) - sub;

    Componentes atualizaComponente = new Componentes(Id: indiceComponentes,
        nomeComponente: componenteAtual.RetornaNome(),
        tipo: componenteAtual.RetornaTipo(),
        infoComplementares: componenteAtual.RetornaInfos(),
        quantidade: novaQuantidade);

    repositorio.Atualiza(indiceComponentes, atualizaComponente);

}

void SomarComponentes()
{
    Console.WriteLine("Incrementar valores:");
    Console.WriteLine("Digite o ID do componentes que deseja adicionar quantidades: ");
    int indiceComponentes = int.Parse(Console.ReadLine());
    ListarComponentes();
    Console.WriteLine("Por favor digite o valor que deseja incrementar: ");
    int soma = int.Parse(Console.ReadLine());

    var componenteAtual = repositorio.RetornaPorId(indiceComponentes);
    int novaQuantidade = (componenteAtual.RetornaQuantidade())+soma;

    Componentes atualizaComponente = new Componentes(Id: indiceComponentes, 
        nomeComponente: componenteAtual.RetornaNome(),
        tipo: componenteAtual.RetornaTipo(),
        infoComplementares: componenteAtual.RetornaInfos(),
        quantidade: novaQuantidade);

    repositorio.Atualiza(indiceComponentes, atualizaComponente);

}

void VisualizarComponente()
{
    
    ListarComponentes();
    Console.WriteLine("Digite o Id do componentes que deseja pesquisar conforme a lista acima:");
    int IdComponentes = int.Parse(Console.ReadLine());
    var componente = repositorio.RetornaPorId(IdComponentes);
    Console.WriteLine(componente);
    

}

void InserirComponentes()
{
    Console.Clear();
    Console.WriteLine("-----------------------");
    Console.WriteLine("Inserir novo componente");
    Console.WriteLine("-----------------------");

    Console.WriteLine("Digite o nome do componente que deseja adicionar: ");
    Console.WriteLine("Ex: Capacitor eletrolitico 330uF");
    string entradaNomeComponente = Console.ReadLine();

    Console.WriteLine("Escolha uma opção de tipo de componente abaixo: ");
    foreach (int i in Enum.GetValues(typeof(Tipo)))
    {
        Console.WriteLine($"{i} -{Enum.GetName(typeof(Tipo), i)} ");
    }
    Console.WriteLine("Qual o tipo de dispositivo? ");
    int entradaTipo = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite a quantidade atual dos componentes: ");
    int entradaQuantidade = int.Parse(Console.ReadLine());

    Console.Write("Digite caracteristicas adicionais como: tensão, corrente, uso do dispositivo:\n");
    
    string entradaCarcateristicaAdicionais = $"Caracteristicas Adicionais do {entradaNomeComponente} .";

    Componentes novoComponente = new Componentes(Id: repositorio.ProximoId(), nomeComponente: entradaNomeComponente, tipo: (Tipo)entradaTipo, infoComplementares: entradaCarcateristicaAdicionais, quantidade: entradaQuantidade);

    repositorio.Insere(novoComponente);

    Console.WriteLine("Componente adicionado com sucesso! ");
    
    return;
}

void ListarComponentes()
{
    Console.Clear();
    Console.WriteLine("--------------------");
    Console.WriteLine("Lista de Componentes");
    Console.WriteLine("--------------------");
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        Console.WriteLine("Não existem componentes cadastrados");        
    }
    else
    {

        foreach (var nomeComponente in lista)
        {
            if (nomeComponente.RetornaQuantidade() > 0)
            {
                Console.WriteLine($"Id {nomeComponente.RetornaId()}: {nomeComponente.RetornaNome()} | Quantidade: {nomeComponente.RetornaQuantidade()}");

            }
            else
            {
                Console.WriteLine($"Id {nomeComponente.RetornaId()}: {nomeComponente.RetornaNome()} | Componente em Falta");
            }
        }
        
    }

    
    return;
}

string ObterOpcaoUsuario()
{
   
    Finaliza(); 
    
    Console.Clear();
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("Estoque de componentes:");
    Console.WriteLine("--------------------------------------");


    Console.WriteLine("1- Listar componentes disponíveis");
    Console.WriteLine("2- Adicionar componente");
    Console.WriteLine("3- Incluir quantidade de componentes");
    Console.WriteLine("4- Remover quantidade de componentes");
    Console.WriteLine("5- Verificar componentes");
    Console.WriteLine("C- Limpar tela");
    Console.WriteLine("X- Sair");
    Console.WriteLine("--------------------------------------");
  
  

    Console.WriteLine("Informe a opção desejada: ");
    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}

void Finaliza()
{
    Console.WriteLine("Pressione enter para Iniciar:");
    Console.ReadLine();
}