using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI.Models
{
    public class Vendor
    {
        public Vendor()
        {

            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        [Required]
        public String VendorName { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Gender { get; set; }

        public string Adress { get; set; }

        public DateTime Date { get; set; }



        public ICollection<Tag> Tags { get; set; }
    }
}
