using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A1.Models
{
    public class VenueAddViewModel
    {
        public VenueAddViewModel()
        {
            OpenDate = DateTime.Now.AddYears(-23);
        }

        [Required(ErrorMessage = "Please enter a company name.")]
        [Display(Name = "Company Name")]
        [StringLength(80)]
        public string Company { get; set; }

        [Display(Name = "Address")]
        [StringLength(70)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [StringLength(40)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(40)]
        public string State { get; set; }

        [Display(Name = "Country")]
        [StringLength(40)]
        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(24)]
        public string Fax { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        public string Email { get; set; }

        [Display(Name = "Website Address")]
        [DataType(DataType.Url)]
        [StringLength(60)]
        public string Website { get; set; }

        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OpenDate { get; set; }
    }
}