using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixa.Entity;

namespace Onixa_Web.Models
{
    public class CategoryListViewModel
    {
        public List<Categories> Categorieses { get; set; }
        public List<Styles> Styleses { get; set; }
    }
}