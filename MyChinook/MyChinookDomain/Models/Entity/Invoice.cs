﻿using MyChinook.Models;
using MyChinookDomain.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MyChinookDomain.Models.Entity
{
    public class Invoice : IConvertModel<Invoice, InvoiceApiModel>
    {
        private Customer _customer;

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }

        public decimal Total { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();

        [NotMapped]
        [JsonIgnore]
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public InvoiceApiModel Convert() => new InvoiceApiModel
        {
            InvoiceId = InvoiceId,
            CustomerId = CustomerId,
            InvoiceDate = InvoiceDate,
            BillingAddress = BillingAddress,
            BillingCity = BillingCity,
            BillingState = BillingState,
            BillingCountry = BillingCountry,
            BillingPostalCode = BillingPostalCode,
            Total = Total,
            CustomerName = $"{Customer.FirstName} {Customer.LastName}"
        };
    }
}
