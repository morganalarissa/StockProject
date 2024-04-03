using StockManager.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        
        public byte[]? PasswordHash { get; private set; }
        public byte[]? PasswordSalt { get; private set; }

        public User(int id, string name, string email)
        {
            DomainExceptionValidation.When(id < 0, "Id cant be negative");
            Id = id;
            Name = name;
            Email = email;
            ValidateDomain(name, email);
        }

        public User(string name, string email)
        {       
            Name = name;
            Email = email;
            ValidateDomain(name, email);
        }

       

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        { 
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string name, string email)
        {
            DomainExceptionValidation.When(name == null, "Name is required.");
            DomainExceptionValidation.When(email == null, "Email is required");
            DomainExceptionValidation.When(name.Length > 250, "Name can't have more than 250 caracteres.");
            DomainExceptionValidation.When(email.Length > 250, "Email can't have more than 250 caracteres.");
            Name = name;
            Email = email;
            
        }
    }
}
