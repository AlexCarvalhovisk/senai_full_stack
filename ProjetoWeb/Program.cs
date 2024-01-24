using System.Diagnostics;

namespace ProjetoWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/cliente", () => "Cliente retardado!!!");

        //app.MapGet("/produtos", () => "Produtos para garotas de programa!!!");

        app.MapGet("/clientes", () => "Clientes no plural!!!");

        app.UseStaticFiles();

        //Deste modo usamos variáveis na URL para pegar o que o usuário digita...
        app.MapGet("/clientee", (String nome, String email) => $"O nome do cliente escolhido é {nome} \n O email é: {email}");

        //Deste modo é que usamos a URL da pasta wwwroot...
        app.MapGet("/produtos", (HttpContext contexto) =>
            {
            contexto.Response.Redirect ("produtos.html", false);
            }
        );

        //Instânciando uma Pessoa da classe Pessoa.
        Pessoa p1 = new Pessoa () {id = 1, nome = "Ana"};


        //text / plain (chama-se assim...)
        //Criando rota para usar essa Instância
        //app.MapGet("/fornecedores", () => $"O fornecedor é: {p1.id} - {p1.nome}");

        //Iniciando uma página em HTML do back para o front.
        
        app.MapGet("/fornecedores", (HttpContext contexto) => {
            //Jogamos as tags HTML dentro do back
            String pagina = "<h1> Fornecedores </h1>";
            pagina = pagina + $" <h2> ID: {p1.id} - NOME: {p1.nome} </h2>";
            contexto.Response.WriteAsync(pagina);
        });

        //Criando rota com a inserção de dados direto do front, ou seja, diretamente escrita pelo usuário
        app.MapGet("/forncedoresEnviarDados", (int id, String nome) => {

            p1.id = id;
            p1.nome = nome;
            return "Dados inseridos com sucesso...";

        });

        //Criando rota através de API
        app.MapGet("/api", (Func<object>) ( () => {

            return new {
                id = p1.id, nome = p1.nome
                };

           }
           ) );

        //Rota de banco de dados...
        Banco dba = new Banco();
        //Chamada do banco de dados na Classe.
        dba.carregarBanco();

        app.MapGet("/banco", (HttpContext contexto) => {

            var valoresDaLista = "";
            //List<Pessoa> listaAux = dba.GetLista();
            foreach (Pessoa aux in dba.GetLista())
            {
                valoresDaLista = valoresDaLista + $" <b> ID: </b> {aux.id} - <b> Nome: {aux.nome} </b> <br>>";
            }

            //return valoresLista;
            contexto.Response.WriteAsync(valoresDaLista);

        });

        app.Run();
    }
}