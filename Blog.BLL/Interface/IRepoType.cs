using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Interface
{
    public interface IRepoType<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T model);
        void Update(T model);
        void Delete(T model);
        Task<int> Save();
    }
}
