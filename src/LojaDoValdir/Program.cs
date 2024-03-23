namespace LojaDoValdir.Models;

class Program
{
    static void Main(string[] args)
    {
        // Cliente
        var cliente1 = new Cliente();

        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite seu sobrenome: ");
        string sobrenome = Console.ReadLine();

        Console.Write("Digite sua idade: ");
        int idade = int.Parse(Console.ReadLine());

        Console.Write("Digite seu sexo (F/M): ");
        char sexo = char.Parse(Console.ReadLine());


        DateOnly dataNascimento;
        bool dataValida = false;
        while (!dataValida)
        {
            Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
            string inputDataNascimento = Console.ReadLine();

            if (DateOnly.TryParseExact(inputDataNascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
            {
                if (dataNascimento <= DateOnly.FromDateTime(DateTime.Today))
                {
                    cliente1 = cliente1.Inserir(nome, sobrenome, idade, sexo, dataNascimento);
                    dataValida = true;
                }
                else
                {
                    Console.WriteLine("A data de nascimento não pode ser uma data futura. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Certifique-se de inserir no formato dd/mm/aaaa.");
            }
        }

        Console.WriteLine("");


        // Contato

        var contato1 = new Contato();

        Console.Write("Digite seu código DDI (país de origem): ");
        string codigoDDI = Console.ReadLine();

        Console.Write("Digite seu código DDD: ");
        string codigoDDD = Console.ReadLine();

        Console.Write("Digite seu número de celular/telefone: ");
        string codigoTelefone = Console.ReadLine();

        Console.Write("É o seu meio de contato principal? Digite sim ou não: ");
        string telefonePrincipal = Console.ReadLine();
        if (telefonePrincipal == "sim" || telefonePrincipal == "não")
        {
            bool principal = Contato.StringParaBool(telefonePrincipal);
            contato1 = contato1.Inserir(codigoDDI, codigoDDD, codigoTelefone, principal);
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Resposta inválida.");
            return;
        }


        // Endereço

        var endereco1 = new Endereco();

        Console.Write("Digite seu logradouro: ");
        string logradouro = Console.ReadLine();

        Console.Write("Digite o número de sua residência: ");
        string numero = Console.ReadLine();

        Console.Write("Digite o nome de seu bairro: ");
        string bairro = Console.ReadLine();

        Console.Write("Digite o nome de sua cidade: ");
        string cidade = Console.ReadLine();

        Console.Write("Digite seu UF: ");
        string uf = Console.ReadLine();

        endereco1 = endereco1.Inserir(logradouro, numero, bairro, cidade, uf);
        Console.WriteLine("");


        Console.WriteLine(cliente1.ToString());
        Console.WriteLine("");
        Console.WriteLine(contato1.ToString());
        Console.WriteLine("");
        Console.WriteLine(endereco1.ToString());
    }
}