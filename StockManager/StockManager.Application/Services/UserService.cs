using AutoMapper;
using StockManager.Application.DTOs;
using StockManager.Application.Interfaces;
using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var userUpdated = await _repository.Update(user);
            return _mapper.Map<UserDTO>(userUpdated);
        }
        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            if (userDTO != null) 
            {
                using var hmac = new HMACSHA512(); 
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                byte[] passwordSalt = hmac.Key;

                user.UpdatePassword(passwordHash, passwordSalt);
            }
            var userCreated = await _repository.Create(user);
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Delete(int id)
        {
            var user = await _repository.Delete(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> SelectById(int id)
        {
            var user = await _repository.SelectById(id);
            return _mapper.Map<UserDTO>((user));
        }
        public async Task<IEnumerable<UserDTO>> SelectAll()
        {
            var users = await _repository.SelectAll();
            return _mapper.Map<IEnumerable<UserDTO>>((users));
        }



    }
}
