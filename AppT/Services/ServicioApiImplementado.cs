using AppT.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace AppT.Services
{
    public class ServicioApiImplementado: ServicioApi
    {
        private static string user;
        private static string password;
        private static string token;

        private static string url;

        public ServicioApiImplementado() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            user = builder.GetSection("ApiSettings:user").Value;
            password = builder.GetSection("ApiSettings:password").Value;
            token = builder.GetSection("ApiSettings:token").Value;

            

            url = builder.GetSection("ApiSettings:url").Value;
            

        }

        public async Task<List<Register>> Lista()
        {
            List<Register> lista = new List<Register>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);
            var response = await cliente.GetAsync("");

            if (response.IsSuccessStatusCode) { 
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConverter.DeserializeObject<ResultadoApi>(json_respuesta);
                var resultado1 = JsonConverter.De
                lista = resultado.lista;
            }
            return lista;

        }

        public async Task<Register> Obtener(string TitleRegister)
        {
            Register objeto = new Register();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);
            var response = await cliente.GetAsync($"{TitleRegister}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                objeto = resultado.objeto;
            }
            return objeto;
        }
    }
}
