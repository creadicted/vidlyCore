﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;

namespace VidlyCore.Dtos
{
    public class CustomerDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        // [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}
