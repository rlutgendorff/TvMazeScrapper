using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvMazeScrapper.Business.Connectors.TvMaze.Response;

namespace TvMazeScrapper.Business.Connectors
{
    public class TvMazeConnector : ITvMazeConnector
    {
        private readonly HttpClient _httpClient;

        public TvMazeConnector(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TvMazeResponse> GetShow(int id)
        {
            var response = await _httpClient.GetAsync($"shows/{id}?embed=cast");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TvMazeResponse>(result);
            }

            return null;
        }
    }
}
