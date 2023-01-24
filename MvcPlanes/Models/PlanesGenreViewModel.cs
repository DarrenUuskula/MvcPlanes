using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcPlanes.Models
{
    public class PlanesGenreViewModel
    {
        public List<Planes>? Planes { get; set; }
        public SelectList? Genres { get; set; }
        public string? PlanesGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
