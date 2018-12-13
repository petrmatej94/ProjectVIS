using ProjectVIS.DomainLayer;
using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.Repository
{
    public interface IRepository<T> where T : IdentityField
    {
        List<T> FindAllByID(int id);
        T FindByID(int id);
        int Save(T record);
        int Update(T obj);
    }
}
