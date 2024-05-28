using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string title, [FromQuery] string genre, [FromQuery] string year)
    {
        if (string.IsNullOrEmpty(title))
        {
            return BadRequest("Title is required");
        }

        var movies = await _movieService.SearchMoviesAsync(title, genre, year);
        return Ok(movies);
    }
}
