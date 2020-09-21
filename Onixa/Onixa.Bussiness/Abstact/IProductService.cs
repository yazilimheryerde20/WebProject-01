using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onixa.Entity;

namespace Onixa.Bussiness.Abstact
{
   public interface IProductService
    {
        List<Products> GetAll();
        List<Products> GetbyCategoryIdAll(int? id);
        List<Styles> GetAllStyles();
        Products GetByParentId(int id);
        Products GetByCategoryId(int? id);
        Products Add(Products products);
        Products Update(Products products);
        void Delete(Products products);
    }
}
