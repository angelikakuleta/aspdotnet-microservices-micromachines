using System;
using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Shopping.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}