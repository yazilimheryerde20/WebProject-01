using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixa.Bussiness.Abstact;
using Onixa.Bussiness.Concrete;
using Onixa.DataAccess.Concrete.EntityFramework;
using Onixa.Entity;
using Onixa_Web.Models;

namespace Onixa_Web.Controllers
{
    public class HomeController : BaseController
    {
        private IProductService _productService;
        public HomeController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            _productService = productService;
        }

        // GET: Home

        public ActionResult Index(int? id)
        {
            var model= new ProductListViewModel();
           
            if (id.HasValue)
            {
                model.Products = _productService.GetbyCategoryIdAll(id);
            }
            else
            {
                model.Products = _productService.GetAll();
            }

            model.Styleses = _productService.GetAllStyles();
          //var  model = new ProductListViewModel
          //  {
               
          //      Products = _productService.GelAll(),
          //      Styleses = _productService.GelAllStyles()
                
          //  };
            return View(model);
        }

        
        public ActionResult ProductDetails(int? id)
        {
            var model = new ProductListViewModel();
            if (id.HasValue)
            {
                model.Product = _productService.GetByCategoryId(id);
                return View(model);
            }
            else
            {
                return Index(null);

            }

           
        }

      
        public ActionResult Exit()
        {
            return View();
        }

        public ActionResult Basket()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

       
    }
}