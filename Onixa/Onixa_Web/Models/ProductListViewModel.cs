using Onixa.Entity;
using System.Collections.Generic;

namespace Onixa_Web.Models
{
    public class ProductListViewModel
    {
        public List<Products> Products { get; set; }
        public Products Product { get; set; }
        public List<Styles> Styleses { get; set; }
    }
}