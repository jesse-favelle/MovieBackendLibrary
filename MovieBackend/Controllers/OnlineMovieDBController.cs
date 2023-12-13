using System;

public class OnlineMovieDBController
{
    static HttpClient client = new HttpClient();
	public OnlineMovieDBController()
	{
    


    }

    public async Task<string> GetMovie(string title)
    {
        string openApiKey = Environment.GetEnvironmentVariable("OpenMovieDBAPIKey");
        string url = "http://www.omdbapi.com/?apikey={openApiKey}&t={title}";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return response.Content.ToString();    




    }
}
