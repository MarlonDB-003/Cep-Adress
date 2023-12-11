using MinhaApi.Data;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Service;

public class CepValidarService{
    public async Task<Endereco> ConsultarCEP([FromBody] CreateEnderecoDto dto)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"https://viacep.com.br/ws/{dto.Cep}/json/";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Endereco>(data);
            }

            return null;
        }
    }
}