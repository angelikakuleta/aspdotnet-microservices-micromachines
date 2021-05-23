using System;
using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Basket.API.Commands
{
    public class BasketCheckoutCommand
    {        
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public Guid AccountFromId { get; set; }
    }
}
