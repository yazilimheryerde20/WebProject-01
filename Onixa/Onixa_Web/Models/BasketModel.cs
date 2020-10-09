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
            this.ProductsDic=new Dictionary<int, int>();
            this.MyBasketbyProductList=new List<MyBasket>();
            
        }
        public Dictionary<int, int> ProductsDic { get; set; }
        public List<MyBasket> MyBasketbyProductList { get; set; }
        public MyBasket MyBasketbyProducts { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
        public int Project_ID { get; set; }
       

    }
}