using StockManager.Domain.Validation;
using System;
using System.Collections.Generic;

namespace StockManager.Domain.Entities;

public class Product
{
    public int Id { get; private set; }

    public string Name { get; private set; } 

    public string Description { get; private set; } 

    public double Price { get; private set; }

    public int QuantityInStock { get; private set; }

    //public bool Deleted { get; private set; }

    public Product(int id,string name, string description, double price, int quantityInStock)
    {
        DomainExceptionValidation.When(id < 0, "The Id Must be Positive");
        Id= id;
        ValidateDomain(name, description, price, quantityInStock);
    }

    public Product(string name, string description, double price, int quantityInStock)
    {

        ValidateDomain(name, description, price, quantityInStock);
    }

    public void Update(string name, string description, double price, int quantityInStock)
    {
        ValidateDomain(name, description, price, quantityInStock);
    }

    //public void Delete()
    //{
    //    Deleted = true;
    //}

    public void ValidateDomain(string name, string description, double price, int quantityInStock)
    {
        Name = name;
        Description = description;
        Price = price;
        QuantityInStock = quantityInStock;
    }



}