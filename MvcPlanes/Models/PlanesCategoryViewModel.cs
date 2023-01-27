using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcPlanes.Models
{
    public class PlanesCategoryViewModel
    {
        public List<Plane>? Planes { get; set; }
        public SelectList? Categorys { get; set; }
        public string? PlanesCategory { get; set; }
        public SelectList? Name { get; set; }
        public string? PlanesName { get; set; }
        public string? SearchString { get; set; }
    }
}
