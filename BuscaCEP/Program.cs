using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuscaCEP
{
    internal class Program
    {
        // Metodo async para solicitação ao servidor
        static async Task Main(string[] args)
        {
            Console.Write("Digite um CEP sem traço: ");
            string cep = Console.ReadLine();

            // Chama o método para buscar o CEP
            string resposta = await ApiCep.BuscarCEP(cep);

            try
            {
                var dados = JsonSerializer.Deserialize<Cep>(resposta);

                if(dados == null || dados.erro)
                {
                    Console.WriteLine($"Erro: {dados?.mensagem ?? "CEP inválido ou não encontrado."}");
                }
                else
                {
                    Console.WriteLine("\n=== Resultado ===");
                    Console.WriteLine($"CEP: {dados.cep}");
                    Console.WriteLine($"Logradouro: {dados.logradouro}");
                    Console.WriteLine($"Bairro: {dados.bairro}");
                    Console.WriteLine($"Cidade: {dados.localidade}");
                    Console.WriteLine($"UF: {dados.uf}");
                }
            }
            catch (JsonException)
            {
                // Captura erro de conversão caso venha algo que não seja JSON
                Console.WriteLine("Erro: resposta inválida recebida da API.");
            }
        }
    }
}
