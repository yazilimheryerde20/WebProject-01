using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onixa.Core.DataAccess.EntityFramework;
using Onixa.DataAccess.Abstract;
using Onixa.Entity;
using Onixa.Entity.ComplexTypes;

namespace Onixa.DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Products, SitedbContext>, IProductDal
    {
        public List<ProductsLite> GetProductIndexList()
        {
            using (SitedbContext context=new SitedbContext())
            {
                var result = from p in context.Products
                    select new ProductsLite
                    {
                        Product_Id = p.Product_Id, Name = p.Name, Category_Id = p.Category_Id, MainImage = p.MainImage
                    };
                return result.ToList();
            }
        }

        public List<ProductsLite> GetProductIndexListbyCategoryID(int? id)
        {
            using (SitedbContext context = new SitedbContext())
            {
                var result = from p in context.Products where p.Category_Id==id
                    select new ProductsLite
                    {
                        Product_Id = p.Product_Id,
                        Name = p.Name,
                        Category_Id = p.Category_Id,
                        MainImage = p.MainImage
                    };
                return result.ToList();
            }
        }

        

        public List<Productimages> GetProductsImageNamesListbyProductId(int? id)
        {
            using (SitedbContext context = new SitedbContext())
            {
                var result = from urun in context.Products
                    join resim in context.ProductsImageName on urun.Product_Id equals resim.Product_Id
                    join urundetay in context.ProductDetails on urun.Product_Id equals urundetay.Product_Id 
                    where urun.Product_Id == id
                    
                    
                    select new Productimages()
                    {
                       Product_Id=urun.Product_Id,
                       Name=urun.Name,
                       Path = resim.Path,
                       AddedDate=urun.AddedDate,
                       Category_Id=urun.Category_Id,
                       Description=urun.Description,
                       IsContinued=urun.IsContinued,
                       ModifiedDate=urun.ModifiedDate,
                       Price=urun.Price,
                       StartGivenMemberCount=urun.StartGivenMemberCount,
                       StartPoint=urun.StartPoint,
                       UnıtInStock=urun.UnıtInStock,
                       UserBy=urun.UserBy,
                       Platform=urundetay.Platform,
                       Product_Tag=urundetay.Product_Tag,
                       Size=urundetay.Size,
                       Style=urundetay.Style,
                       Color=urundetay.Color
                       
                       
                    };
                return result.ToList();
            }
        }
    }
}
