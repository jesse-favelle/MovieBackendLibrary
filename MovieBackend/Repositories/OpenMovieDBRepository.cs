
namespace MovieBackend.Repositorys
{
    public class OpenMovieDBRepository : IOpenMovieDbRepository
    {
        private readonly IConfiguration _configuration;

        public OpenMovieDBRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SearchByMovieTitle(string movieTitle)
        {
            using HttpClient client = new HttpClient();
            string openApiKey = _configuration["OpenMovieDBAPIKey"];
            if(openApiKey == null)
            {
                throw new Exception("API Key Missing");
            }
            string url = $"http://www.omdbapi.com/?apikey={openApiKey}&t={movieTitle}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            return jsonString;
        }

    }

    public interface IOpenMovieDbRepository
    {
         Task<string> SearchByMovieTitle(string movieTitle);
    }
}

