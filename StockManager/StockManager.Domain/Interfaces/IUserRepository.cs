using StockManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
        Task<User> SelectById(int id);
        Task<IEnumerable<User>> SelectAll();
    }
}
