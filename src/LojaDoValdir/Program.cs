using LojaDoValdir.Models;

namespace LojaDoValdir;

class Program
{
    static void Main(string[] args)
    {
        var cliente1 = new Cliente();
        cliente1 = cliente1.Inserir("Nifis", "Uramfiamakh", 29, 'M', new DateOnly(1995, 01, 5));
        Console.WriteLine(cliente1.ToString());
        Console.WriteLine("");

        var contato1 = new Contato();
        contato1 = contato1.Inserir("+55", "13", "93256-1515", true);
        Console.WriteLine(contato1.ToString());
        Console.WriteLine("");

        var endereco1 = new Endereco();
        endereco1 = endereco1.Inserir("Rua Lucas Alameda", "715", "Tupy", "Itanhaém", "SP");
        Console.WriteLine(endereco1.ToString());
        Console.WriteLine("");
    }
}