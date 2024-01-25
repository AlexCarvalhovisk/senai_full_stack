using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LHPet.Models;

namespace LHPet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        //Instância de clientes
        Cliente cliente1 = new Cliente(01, "Arthur A. Ferreira", "857.032.950-41", "arthur.antunes@sp.senai.br", "Madruga");
        Cliente cliente2 = new Cliente(02, "William Henry Gates III", "039.618.250-09", "bill.@microsoft..com", "Bug");
        Cliente cliente3 = new Cliente(03, "Ada Lovelace", "800.777.920-50", "ada@ada.language.com", "Bryon");
        Cliente cliente4 = new Cliente(04, "Linus Trovalds", "933.622.400-03", "trovalds@osdl.org", "Pinguim");
        Cliente cliente5 = new Cliente(05, "Grace Hopper", "911.702.988-00", "grace.hopper@cobol.com", "Loboc");

        //Lista de clientes
        List<Cliente> listaCliente = new List<Cliente>();
        //Inserindo dados no List
        listaCliente.Add(cliente1);
        listaCliente.Add(cliente2);
        listaCliente.Add(cliente3);
        listaCliente.Add(cliente4);
        listaCliente.Add(cliente5);

        ViewBag.listaCliente = listaCliente;

        //Instância de fornecedores
        Fornecedor fornecedor1 = new Fornecedor(01, "C# PET S/A", "14.182.102/0001-80", "c-sharp@pet.org");
        Fornecedor fornecedor2 = new Fornecedor(02, "Crtl Alt Dog", "15.836.698/0001-57", "crtl@alt.dog.br");
        Fornecedor fornecedor3 = new Fornecedor(03, "BoodsPet INC", "40.810.224/0001-83", "boots.pet@gatomaia.us");
        Fornecedor fornecedor4 = new Fornecedor(04, "Tik Tok Dogs", "87.945.350/0001-09", "noisnamidia@tiktokdogs.uk");
        Fornecedor fornecedor5 = new Fornecedor(05, "Bifnho Forever", "18.760.614/0001-37", "contato@bff.us");

        //Lista de fornecedores
        List<Fornecedor> listaFornecedor = new List<Fornecedor>();
        //Inserindo dados no List
        listaFornecedor.Add(fornecedor1);
        listaFornecedor.Add(fornecedor2);
        listaFornecedor.Add(fornecedor3);
        listaFornecedor.Add(fornecedor4);
        listaFornecedor.Add(fornecedor5);

        ViewBag.listaFornecedor = listaFornecedor;
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
