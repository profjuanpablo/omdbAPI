using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "your_imdb_api_key"; // Substitua pela sua chave de API

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> SearchMoviesAsync(string title, string type, string year = null)
    {
        //var url = $"https://www.omdbapi.com/?s={title}&apikey=d0345271";
        var url = $"https://www.omdbapi.com/?s={title}&type={type}&y={year}&apikey=d0345271";
        //var url = $"https://www.omdbapi.com/?s={title}&type={type}&y={year}&apikey=d0345271";

        if (!string.IsNullOrEmpty(type))
        {
            url += $"&type={type}";
        }

        if (!string.IsNullOrEmpty(year))
        {
            url += $"&y={year}";
        }

        var response = await _httpClient.GetFromJsonAsync<ApiResponse>(url);
        return response?.Search ?? new List<Movie>();
    }
}

public record Movie(string Title, string Year, string imdbID,  string Poster, string Type);
public record ApiResponse(List<Movie> Search, string totalResults, string Response);
