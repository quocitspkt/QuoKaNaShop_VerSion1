using QuoKaNaShop.Data.Infrastructure;
using QuoKaNaShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoKaNaShop.Data.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {

    }
    public class AdminRepository:RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
