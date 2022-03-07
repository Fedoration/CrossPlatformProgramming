using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2Laputin.Data;
using System;
using System.Linq;

namespace WebApplication2Laputin.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPipeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPipeContext>>()))
            {
                // Look for any movies.
                if (context.Pipe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Pipe.AddRange(
                    new Pipe
                    {
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        length = 100,
                        diameter = 32.5M
                    },

                    new Pipe
                    {
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        length = 150,
                        diameter = 28.3M
                    },

                    new Pipe
                    {
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        length = 200,
                        diameter = 32.5M
                    },

                    new Pipe
                    {
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        length = 100,
                        diameter = 28.3M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
