using System;
using Phones.Domain.Entities;

namespace Phones.Domain.DTOs.Brands
{
    public class PhoneDto
    {
        
        public Guid Id { get; set; }
        
        public string  Model { get; set; }
        
        public Brand Brand { get; set; }
        
        public decimal Price { get; set; }
        
        public OSType OSType { get; set; }
        
        public PhoneType Type { get; set; }
        
        public string Color { get; set; }
    }
}