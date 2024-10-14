using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A1.Models
{
	public class VenueEditFormViewModel : VenueEditViewModel
	{
        [Required]
        [Display(Name = "Company Name")]
        [StringLength(80)]
        public string Company { get; set; }

        [Display(Name = "Adv Ticket Sale Password")]
        [DataType(DataType.Password)]
        [StringLength(70)]
        public string TicketSalePassword { get; set; }

        [Display(Name = "Promo Code")]
        [RegularExpression("[0-9]{2}[A-Z]{3}", ErrorMessage = "Promo Code Format: NNLLL, where “L” represents a capital letter and “N” represents a number (0-9). For example: 12XYZ")]
        [StringLength(60)]
        public string PromoCode { get; set; }

        [Range(1, 75000)]
        [Display(Name ="Capacity")]
        public int? Capacity { get; set; } //not a required field
    }
}