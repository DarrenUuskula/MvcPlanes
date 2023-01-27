using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPlanes.Data;
using MvcPlanes.Models;
using System;
using System.Linq;

namespace MvcPlanes.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPlanesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPlanesContext>>()))
            {
                // Look for any Planes.
                if (context.Planes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Planes.AddRange(
                    new Plane
                    {
                        Name = "Hawker Hurricane",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Category = "Turboprop commercial aircraft",
                        Safety ="S",
                        Price = 776500
                    },

                    new Plane
                    {
                        Name = "Boeing 737",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Category = "Small passenger jet aircraft",
                        Safety = "S",
                        Price = 98800
                    },

                    new Plane
                    {
                        Name = "Airbus A220",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Category = "Medium passenger aircraft",
                        Safety = "S",
                        Price = 233000
                    },

                    new Plane
                    {
                        Name = "Airbus A320",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Category = "Large passenger jet aircraft",
                        Safety = "D",
                        Price = 300000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}