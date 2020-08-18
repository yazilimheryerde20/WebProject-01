using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onixa.Core.DataAccess
{
    interface IQueryableRepository<T> where T:class,new()
    {
        IQueryable<T> Table { get; }
    } 
    
}
