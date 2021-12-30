using System;

namespace Phones.Domain.Entities
{
    public class Phone
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