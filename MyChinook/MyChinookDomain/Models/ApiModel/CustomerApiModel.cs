using MyChinook.Models.ApiModel;
using MyChinook.Models;
using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MyChinookDomain.Models.ApiModel
{
    public class CustomerApiModel : IConvertModel<CustomerApiModel, Customer>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SupportRepId { get; set; }
        public string SupportRepName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<InvoiceApiModel> Invoices { get; set; }
        [NotMapped]
        [JsonIgnore]
        public EmployeeApiModel SupportRep { get; set; }

        public Customer Convert() => new Customer
        {
            CustomerId = CustomerId,
            FirstName = FirstName,
            LastName = LastName,
            Company = Company,
            Address = Address,
            City = City,
            State = State,
            Country = Country,
            PostalCode = PostalCode,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            SupportRepId = SupportRepId
        };
    }
}
