using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.Marshalling;

namespace ProjetoLista;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ClientesPF cl1 = new ClientesPF();
        cl1.id = 1;
        cl1.nome = "Anna";

       List<ClientesPF> lista = new List<ClientesPF>();

       lista.Add(new ClientesPF());

       lista.Add(cl1);

       lista.Add(new ClientesPF(){id = 2, nome = "Carlos"});
       foreach(ClientesPF aux in lista){
        
            System.Console.WriteLine("Clientes: {0} ", aux.nome);

       }

    }
}
