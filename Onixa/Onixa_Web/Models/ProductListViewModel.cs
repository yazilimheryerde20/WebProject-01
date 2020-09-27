using Onixa.Entity;
using System.Collections.Generic;
using Onixa.Entity.ComplexTypes;

namespace Onixa_Web.Models
{
    public class ProductListViewModel
    {
        public List<Productimages> Productimage { get; set; }
        public Products Product { get; set; }
        public List<Styles> Styleses { get; set; }
     
        public List<ProductsLite> ProductsLiteList { get; set; }
        
    }
}