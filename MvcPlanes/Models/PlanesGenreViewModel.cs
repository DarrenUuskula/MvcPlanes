using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcPlanes.Models
{
    public class PlanesCategoryViewModel
    {
        public List<Planes>? Planes { get; set; }
        public SelectList? Categorys { get; set; }
        public string? PlanesCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
