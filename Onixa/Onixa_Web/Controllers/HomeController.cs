using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private ICategoryService _categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: Home

        public ActionResult Index(int? id)
        {
             
            var model= new ProductListViewModel();
           
            if (id.HasValue)
            {
                model.ProductsLiteList = _productService.GetProductIndexListbyCategoryID(id);

            }
            else
            {

                model.ProductsLiteList = _productService.GetProductIndexList();
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

                model.Productimage = _productService.GetProductsImageListbyProductId(id);
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
        [HttpPost]
        public JsonResult CategoryDownTitle(int id)
        {
            var category = _categoryService.GetByParentId(id);
            List<SelectListItem> item = (from c in category
                select new SelectListItem {Value = c.Category_Id.ToString(), Text = c.Name_}).ToList();
            return Json(item,JsonRequestBehavior.AllowGet);
        }
       
    }
}