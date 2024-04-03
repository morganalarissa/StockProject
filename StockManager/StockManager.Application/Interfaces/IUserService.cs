using StockManager.Application.DTOs;
using StockManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task<UserDTO> Delete(int id);
        Task<UserDTO> SelectById(int id);
        Task<IEnumerable<UserDTO>> SelectAll();
    }
}
