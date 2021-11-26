using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Subscriber
    {
        [Key]
        public int SubscriberID { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Name")]
        public string SubscriberName { get; set; }

        [Required(ErrorMessage ="Email Address is required")]
        [Display(Name ="Email Address")]
        public string SubscriberEmail { get; set; }

        [Display(Name = "Age")]
        public string SubscriberAge { get; set; }

        [Required(ErrorMessage ="Username is required")]
        [Display(Name ="Username")]
        public string SubscriberUsername { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string SubscriberPassword { get; set; }
    }
}