using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDbRazorApp;
public class SearchModel(MovieService movieService) : PageModel
{
    private readonly MovieService _movieService = movieService;

    public List<Movie> Movies { get; private set; } = new List<Movie>();

    [BindProperty(SupportsGet = true)]
    public string Title { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Type { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Year { get; set; }

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrEmpty(Title))
        {
            Movies = await _movieService.SearchMoviesAsync(Title, Type, Year);
        }
    }
}
