//Steam API KEY 918C234B784FB4E107AB85AD1B378A48
//Llamada a la API de Steam para obtener información de los juegos recientes de usuario
//https://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=F3F6ACBAA0917A02F212CD938A572799&steamid=76561198101847888&format=json
//llamada detalles juego, necesit id juego
//https://store.steampowered.com/api/appdetails?appids=2933760


using System.Net.Http.Json;
using System.Text.Json;

namespace SteamAPITest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string call = "https://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=F3F6ACBAA0917A02F212CD938A572799&steamid=76561198101847888&format=json\r\n";
            HttpClient client = new HttpClient();
            var opciones = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };

            string json = await client.GetStringAsync(call);
            //damos formato al string para que se muestre por consola como un JSON

            var jsonDocument = JsonDocument.Parse(json);


            Console.WriteLine(jsonDocument.ToString());
        }


        
    }
}
