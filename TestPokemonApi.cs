using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_API_C__Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // se ejecuta la prueba de la API de Pokémon
                TestPokemonApi();
            }
            catch (Exception ex)
            {
                // ocurrio un error, se imprime en la consola
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Este método realiza la prueba de la API de Pokémon
        static void TestPokemonApi()
        {
            // Definición de la URL base de la API de Pokémon y el endpoint que se va a probar
            const string pokemonApiBaseUrl = "https://pokeapi.co/api/v2/";
            const string endpoint = "pokemon/pikachu";

            // se crea una instancia del WebDriver de Chrome
            using (IWebDriver driver = new ChromeDriver())
            {
                // se crea la solicitud REST
                RestRequest request = CreateRequest(endpoint);
                // se envia la solicitud y se obtiene la respuesta
                RestResponse response = SendRequest(pokemonApiBaseUrl, request);
                // Manejo la respuesta
                HandleResponse(response);
            }
        }

        // Este método crea la solicitud REST
        static RestRequest CreateRequest(string endpoint)
        {
            //se crea una nueva solicitud REST con el endpoint y el método GET
            return new RestRequest(endpoint, Method.Get);
        }

        // Este método envía la solicitud REST
        static RestResponse SendRequest(string baseUrl, RestRequest request)
        {
            // Creo un nuevo cliente REST con la URL base
            var client = new RestClient(baseUrl);
            // Envío la solicitud y devuelve la respuesta
            return client.Execute(request);
        }

        // Este método maneja la respuesta de la solicitud REST
        static void HandleResponse(RestResponse response)
        {
            // Si la solicitud fue exitosa
            if (response.IsSuccessful)
            {
                // Deserializas la respuesta en un objeto dinámico
                dynamic pokemonData = JsonConvert.DeserializeObject(response.Content);
                // Imprimo los datos del Pokémon en la consola
                Console.WriteLine("Pokémon name: " + pokemonData.name);
                Console.WriteLine("Height: " + pokemonData.height);
                Console.WriteLine("Weight: " + pokemonData.weight);
               
            }
            else
            {
                // Si la solicitud falló, imprimo el código de estado en la consola
                Console.WriteLine("API request failed with status code: " + response.StatusCode);
            }
        }
    }
}
