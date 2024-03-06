using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OptixMovies.Entities;

namespace OptixMovies.Database.InitialData
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OptixContext(
                serviceProvider.GetRequiredService<DbContextOptions<OptixContext>>()))
            {
                if (context.Movies.Any())
                    return;

                var filePath = "../OptixMovies/Database/InitialData/mymoviedb.json";
                using StreamReader reader = new(filePath);
                var json = reader.ReadToEnd();

                var settings = new JsonSerializerSettings();
                settings.DateFormatString = "YYYY-MM-DD";
                var movies = JsonConvert.DeserializeObject<List<Movie>>(json, settings);
                context.Movies.AddRange(movies);

                context.SaveChanges();
            }
        }
    }
}