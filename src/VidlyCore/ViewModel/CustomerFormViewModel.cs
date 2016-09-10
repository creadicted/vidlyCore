using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidlyCore.Models;

namespace VidlyCore.ViewModel
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}
