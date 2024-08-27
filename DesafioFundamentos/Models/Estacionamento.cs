using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string entrada = Console.ReadLine();

            if (ValidarPlaca(entrada.ToUpper()))
            {
                veiculos.Add(entrada.ToUpper());
                return;
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal horas = Convert.ToDecimal(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool ValidarPlaca(string placa)
        {
            string padraoPlaca = @"^[A-Z]{3}-[0-9][A-Z][0-9]{2}$|^[A-Z]{3}-[0-9]{4}$";
            Console.WriteLine("\nValidando placa...\n");

            if (Regex.IsMatch(placa, padraoPlaca))
            {
                Console.WriteLine("Placa cadastrada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Formato de placa inválido. Por favor, digite uma placa no formato LLL-NLNN ou LLL-NNNN(L=Letra e N=Número).");
                return false;
            }
        }
    }
}
