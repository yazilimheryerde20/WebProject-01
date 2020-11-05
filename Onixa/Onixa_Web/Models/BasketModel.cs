using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixa.Entity;
using Onixa.Entity.ComplexTypes;

namespace Onixa_Web.Models
{
    public class BasketModel
    {
       
        public BasketModel()
        {
            
           this.Productses=new List<Products>();
            
        }
      
        public List<Products> Productses { get; set; }
        public MyBasket MyBasketbyProducts { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
    
       

    }
}