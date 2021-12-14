# Criando um App Simples de cadastro de séries em .NET

Repositório para criação um simples apps de cadastro utilizando conceitos de POO e Design Patterns

Segui o passo a passo nas vídeo aulas e produzi um programa igual o do professor produzindo o passo a passo abaixo.

Criar um outro programa que utilizando os mesmos conceitos e estrutura de programa, crie um programa que realizar controle de estoque de materiais eletrônicos.

1. Criar uma classe abstrata chamada EntidadeBase (Essa classe carrega  um Id)

```
namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}
```



2. Criar classe Serie que herda de EntidadeBase e possui atributos como Genero, Titulo, Descrição e Ano.

```
namespace DIO.Series
{
    public class Serie : EntidadeBase
    {

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string  Descrição { get; set; }
        private int Ano { get; set; }   

    }
}
```

3. Criar um Enum com os respectivos generos que serão utilizados.

```
namespace DIO.Series
{
    public enum Genero
    {
        Acao =1,
        Aventura = 2,   
        Comedia = 3,    
        Documentario  = 4,  
        Drama = 5,  
        Espionagem = 6, 
        Faroeste = 7,   
        Fantasia = 8,   
        Ficcao_Cientifica = 9,
        Musical = 10,   
        Romance = 11,
        Suspense = 12,

    }
}
```

4. Criar construtores da classe Serie

``` 
public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }
```

5. Criar método de retorno ToString() na classe série.

   ````
    public override string ToString()
           {
               string retorno = "";
               retorno += "Genero: " + this.Genero + Environment.NewLine;
               retorno +=  "Titulo: " + this.Titulo + Environment.NewLine;
               retorno += "Descrição: " + this.Descricao + Environment.NewLine;
               retorno += "Ano de Início: " + this.Descricao + Environment.NewLine; 
               return retorno;
               // usar o metodo Environme.Newline perimite que qualquer sistema operacional que esteja lendo o programa pule a linha corretamente.
           }
   ````

   6. Criar método de retorno para a consulta de parâmetros de titulo e id

      ````
              public  string retornaTitulo()
              {
                  return this.Titulo;
              }
              public int RetornaId()
              {
                  return this.Id;
              }
      ````

6. Criar Interface IRepostiorio e criar métodos usando System Collections Generic

   ```
   namespace DIO.Series.Interfaces
   {
       public interface IRepositorio<T> // Lista genérica de repositórios, ou seja, posso criar varios repostirósio a partir dessa interface
       {
           List<T> Lista();
           T RetornaPorId(int id);
           void Insere(T entidade);
           void Exclui(int id);
           void Atualiza(int id);
           int ProximoId();
       }
   ```

   //Lembrando que ao criar uma interface, eu obrigo que a classe que herda a interface implemente os códigos da interface.

7. Criar SerieRepositório para implementar a interface e criar um repositório para armazenar os dados da Serie

```
public class SerieRepositorio : IRepositorio<Serie> // Irá gerar um erro, autocompletar com alt+enter ja vai gerar os construtores do repositório, porem com uma exceção implementada dentro.  

     ex: public List<Serie> Lista()
        {
            throw new NotImplementedException();
        }


```

8. Criar instanciador para a lista

   ```   
      private List<Serie> listaSerie = new List<Serie>();
     
   ```

9. Criar um metodo que faz a leitura da série (Atualiza)

``` 
public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto; // Pega o elemento indexado no vetor.
        }
```

10. Implemtnar metodo exclui

Para implementação deste metodo devemos nos atentar para um problema ao usar o metodo de lista.
A lista recria um indice quando algum elemento central é realmente removido em espaço de memória, sendo assim, devemos fazer com que o programa faça apensar um "Asterisco" no objeto quando ele é removido, ou seja, o objeto permanecerá ná memória, mas não poderá ser acessado pelo usuário.

para isso criamos um variável/campo na classe Serie que é um booleano que controla se a série foi ou não excluída.

```
private bool Excluido  { get; set; }
```

Devemos adicionar no construtor da classe a variável excluido

```
this.Excluido = false;
```

Devemos tambem criar um novo metodo na classe que "Exclui o vetor"

```
 public void Excluir()
        {
            this.Excluido = true;
        }
```

Na classe SerieRepositiorio criar o metodo Excluir para excluir o objeto

```
 public void Exclui(int id)
        {
            listaSerie[id].Excluir(); // este método só marca que o registro foi excluido. E não remove o objeto em memória.
        }
```

11. Para inserir um item na coleção podemos utilizar o metodos padrão add da serie List.

```
 public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }
```

12. Para lista a série:

```
public List<Serie> Lista()
        {
            return listaSerie;
        }
```

13. Para saber o próximo id disponível:

```
  public int ProximoId()
        {
            return listaSerie.Count;
        }
```

14. Para saber qual é a série utilizando apenas o id dela:

```
  public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
        
```

Visão geral da classe de repositório.

```
namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}

```

15. Criar programa principal com informações de console para o usuário.

```
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
```

Conforme o botão aperta o usuário selecionará uma das opções

16. Chamar o Menu no programa principal

```
string opcaoUsuario = ObterOpcaoUsuario();
```

17. Inserir a classe repositório para manipular guardar os arquivos e manipula-los

```
SerieRepositorio repositorio = new SerieRepositorio();
```

18. Criar um menu seletor com Switch/Case no menu principal.

```
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
        Console.Clear();


    default:
        throw new ArgumentOutOfRangeException;   
        break;
```

19. Implementar Metodos do Switch Case

20. Metodo Listar Séries

    ```
    void ListarSeries()
    {
    Console.WriteLine("Listar Séries: ");
    var lista = repositorio.Lista();
    if (lista.Count==0)
    {
        Console.WriteLine("Nenhuma Lista Cadastrada");
        return;
    }
    foreach (var serie in lista)
    {
        Console.WriteLine($"#Id {serie.RetornaId}: {serie.RetornaTitulo}");
    }
    }
    ```

```
21. Metodo Inserir Serie
```

Console.WriteLine("Inserir Nova Série: ");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
    Console.WriteLine($"{i} -{Enum.GetNames(typeof(Genero))} ");
    }

```
//Faz a Varredura do Enum e mostra as opções para o usuário.

```

Console.WriteLine("Considerando as opções acima digite um gênero: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o título da Série: ");
    string entradaTitulo = Console.ReadLine();
    
    Console.WriteLine("Digite o ano de inicio da série: ");
    int entradaAno = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Digite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

```
// recebe os atributos do objeto série

22. Método Atualiza Serie

Segue o mesmo padrão do insere serie, porem ele usa o Id passado pelo usuário para inserir a série e seus parametros de repositório tambem são alterados

```

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

23. Excluir Série

```
void ExcluirSerie()
{
    Console.WriteLine("Por faovr Digite o ID da série a ser excluida: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Exclui(indiceSerie);

}
```

no toString da classe série podemos concatenar uma String para indicar que a série está Excluida

```
retorno += "Exluido: " + this.Excluido + Environment.NewLine;
```


24. Atualizar Série

```
void VisualizarSerie()
{
    int indiceSerie = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(indiceSerie);
    Console.WriteLine(serie);
    
}
```

25. Retorna Excluido
    Para melhoria do programa podemos realizar um metodo que diz se a série está excluida ou não e com base nisso fazer modificações na main

```
public bool RetornaExcluido()
        {
            return this.Excluido;
        }
```

Complementar na main no metodo de ListarSeries uma condicional que quando o item estiver excluído ele não é listado