using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Interfaces
{
    public interface IRepo<TYPE,KEY,RET>
    {
        IEnumerable<TYPE> Get();
        TYPE Get(Expression<Func<TYPE, bool>> filter);
        IEnumerable<TYPE> IncludeProp<TProperty>(Expression<Func<TYPE, TProperty>> property);
        RET Add(TYPE obj);
        RET Update(TYPE obj);
        bool Remove(KEY primaryKey);

        bool RemoveRange(IEnumerable<TYPE> obj);
    }
}
