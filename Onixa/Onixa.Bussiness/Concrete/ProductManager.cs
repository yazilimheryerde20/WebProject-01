using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onixa.Bussiness.Abstact;
using Onixa.DataAccess.Abstract;
using Onixa.Entity;

namespace Onixa.Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private  IStyleDal _styledal;

        public ProductManager(IProductDal productDal, IStyleDal styleDal)
        {
            _productDal = productDal;
            _styledal = styleDal;
        }
        public Products Add(Products products)
        {
            throw new NotImplementedException();
        }

        public void Delete(Products products)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetAll()
        {
            
            return _productDal.GetAllList();
        }

        public List<Styles> GetAllStyles()
        {
            return _styledal.GetAllList();
        }

        public Products GetByCategoryId(int? id)
        {
            return _productDal.GetList(x => x.Category_Id == id);
        }

        public List<Products> GetbyCategoryIdAll(int? id)
        {
            return _productDal.GetAllList(x => x.Category_Id == id);
        }

        public Products GetByParentId(int id)
        {
            return _productDal.GetList(x=>x.Product_Id==id);
        }

        public Products Update(Products products)
        {
            throw new NotImplementedException();
        }
    }
}
