﻿using System.ComponentModel.DataAnnotations;

namespace MyChinook_Web.Models.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        public string Email { get; set; } 
        public int SupportRepId { get; set; }
    }
}
