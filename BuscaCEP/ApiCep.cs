using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuscaCEP
{
    internal class ApiCep
    {
        public static async Task<string> BuscarCEP(string cep)
        {
            // Cria o cliente HTTP que vai se comunicar com o servidor
            using (HttpClient client = new HttpClient())
            {


                // Define a URL da API
                string url = $"https://viacep.com.br/ws/{cep}/json/";

                try
                {
                    // Envia a requisição GET de forma assíncrona
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verifica se a resposta foi bem-sucedida (status 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lê o conteúdo da resposta como string de forma assíncrona
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        // Mostra mensagem de erro se a resposta não for bem-sucedida
                        return $"{{\"erro\":true,\"mensagem\":\"Erro na requisição: {response.StatusCode}\"}}";
                    }
                }
                catch (Exception ex)
                {
                    // Captura e exibe qualquer exceção que ocorra durante a requisição
                    return $"{{\"erro\":true,\"mensagem\":\"{ex.Message}\"}}";
                }
            }
        }
    }
}
