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
using Onixa.Entity.ComplexTypes;
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

        public ActionResult Index(int? id, int? style_id)
        {

            var model = new ProductListViewModel();

            if (id.HasValue)
            {
                model.ProductsLiteList = _productService.GetProductIndexListbyCategoryID(id);

            }
            else if (!style_id.HasValue)
            {

                model.ProductsLiteList = _productService.GetProductIndexList();
            }
            else
            {
                if (style_id.HasValue)
                {
                    model.ProductsLiteList = _productService.GetProductIndexListbyStyleID(style_id);
                }

            }

            model.Styleses = _productService.GetAllStyles();
            //var  model = new ProductListViewModel
            //  {

            //      Products = _productService.GelAll(),
            //      Styleses = _productService.GelAllStyles()

            //  };
            ViewBag.Model = model;
            return View(model);
        }


        public ActionResult ProductDetails(int? id)
        {
            var model = new ProductListViewModel();
            if (id.HasValue)
            {

                model.Productimage = _productService.GetProductsImageListbyProductId(id);
                List<SelectListItem> projectList = (from pr in _productService.GetProject()
                                                    select new SelectListItem() { Text = pr.ProjectName, Value = pr.Id.ToString() }).ToList();
                model.ProjectList = projectList;
                return View(model);
            }
            else
            {
                return Index(null, null);

            }


        }


        public ActionResult Exit()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Basket()
        {
            List<BasketModel> model = (List<BasketModel>)Session["Basket"];
            
           
            if (model == null)
            {
                model = new List<BasketModel>();
            }



            return View(model);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CategoryDownTitle(int id = 0)
        {

            List<Categories> category = _categoryService.GetByParentId(id);
            List<SelectListItem> item = (from c in category
                                         select new SelectListItem { Value = c.Category_Id.ToString(), Text = c.Name_ }).ToList();
            return Json(item, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FilterCategoryMain(int id = 0)
        {
            Index(id, null);
            return PartialView("_ProductsList", ViewBag.Model);

        }

        [HttpGet]
        public ActionResult AddBasket(int id, string Room_Name, string Note, int Project_ID)
        {

            List<BasketModel> basket = null;
            if (Session["Basket"] == null)
            {
                basket = new List<BasketModel>();

            }
            else
            {
                basket = (List<BasketModel>)Session["Basket"];
            }

            if (basket.Any(x => x.MyBasketbyProducts.Product_Id == id))
            {

            }
            else
            {
                List<SelectListItem> projectList = (from pr in _productService.GetProject()
                                                    select new SelectListItem() { Text = pr.ProjectName, Value = pr.Id.ToString() }).ToList();
                var productsComplex = _productService.GetBaskets(id);
                productsComplex.Project_ID = Project_ID;
                productsComplex.Room_Name = Room_Name;
                productsComplex.Note = Note;
                
                basket.Add(new BasketModel()
                {
                    MyBasketbyProducts = productsComplex,
                    ProjectList = projectList
                });
                // basket.ProductsDic.Add(id,1);
                //basket.MyBasketbyProducts=new MyBasket{Note=Note,Project_ID=Project_ID,Room_Name=Room_Name,MyBasket_ID=id};
                // basket.MyBasketbyProductList.Add(basket.MyBasketbyProducts);


            }

            Session["Basket"] = basket;
            return RedirectToAction("Basket", "Home");
        }

        public ActionResult RemoveBasket(int id)
        {
            List<BasketModel> basket = (List<BasketModel>)Session["Basket"];
            if (basket != null)
            {
                basket.RemoveAll(x => x.MyBasketbyProducts.Product_Id == id);
                Session["Basket"] = basket;
            }

            if (id == 0)
            {
                basket.Clear();
            }



            return RedirectToAction("Basket", "Home");
        }

    }
}