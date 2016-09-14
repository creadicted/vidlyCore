using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;

namespace VidlyCore.ViewModel
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
        }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        
        [HiddenInput]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Customer";
                }

                return "New Customer";
            }
        }
    }
}
