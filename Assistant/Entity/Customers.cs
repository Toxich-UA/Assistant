using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistant.Entity
{
    public partial class Customers
    {
		public Customers()
		{
			Orders = new HashSet<Orders>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[Required]
		[Phone]
		[DisplayName("Phone number")]
		public string PhoneNumber { get; set; }

		[Required]
		[DisplayName("Customer address")]
		public string Address { get; set; }

		[Required]
		[EmailAddress]
		[DisplayName("E-mail")]
		public string Email { get; set; }

		public ICollection<Orders> Orders { get; set; }

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
