using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onixa.Core.DataAccess
{
   public interface IEntityRepository<T> where T:class,new()
   {
       List<T> GetAllList(Expression<Func<T, bool>> filter = null);
       T GetList(Expression<Func<T, bool>> filter);
       T Add(T Entity);
       T Update(T Entity);
       void Delete(T Entity);
   }
}
