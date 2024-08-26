using System.Reflection.Emit;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = null;

int opcao = 0;

while(opcao != 4){

Console.WriteLine("Bem Vindo ao sistema do Hotel!");
Console.WriteLine("1 - Cadastrar novo hospede.");
Console.WriteLine("2 - Cadastrar nova suite.");
Console.WriteLine("3 - Cadastrar nova reserva.");
Console.WriteLine("4 - Sair do programa.");
Console.Write("Escolha uma opção: ");

    // Usando TryParse para garantir que a entrada seja um número válido
    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Opção inválida! Por favor, insira um número.\n");
        continue;
    }

switch(opcao)
{
    case 1:
     Console.WriteLine("Digite o nome do hospede: ");
     string nomeHospede = Console.ReadLine();
     hospedes.Add(new Pessoa(nome: nomeHospede));
     Console.WriteLine("Hospede cadastrado com sucesso!");
    break;
    
    case 2:
     Console.WriteLine("Digite o tipo da suite: ");
     string tiposuite = Console.ReadLine();
     Console.WriteLine("Digite a capacidade da suite: ");
     int capacidadeSuite = Int32.Parse(Console.ReadLine());
     Console.WriteLine("Digite o valor da diaria: ");
     decimal valor = decimal.Parse(Console.ReadLine());
    suite = new Suite(tipoSuite: tiposuite, capacidade: capacidadeSuite, valorDiaria: valor);
     break;

     case 3:
     if(hospedes.Count == 0 || suite == null){
        Console.WriteLine("Você precisa cadastrar hospedes e uma suite antes de fazer uma reserva!");
     } else{
        Console.Write("Digite a quantidade de dias reservados: ");
                int diasReservados = Int32.Parse(Console.ReadLine());
                Reserva reserva = new Reserva(diasReservados: diasReservados);
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);

                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
     }
      break;

     case 4:
      Console.WriteLine("Saindo...");
      break;

      default:
       Console.WriteLine("Opção inválida. Tente novamente!");
       break;
    
}
Console.WriteLine();
}



/*
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
*/