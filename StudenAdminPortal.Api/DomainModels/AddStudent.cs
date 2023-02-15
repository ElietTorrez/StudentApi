using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.DomainModels
{
    public class AddStudent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }

        //navegacion de propiedades
        public string PhysicalAddress { get; set; }

        public string PostalAddress { get; set; }
        //navegacion
        //public Gender Gender { get; set; }

        //public Address Address { get; set; }
    }
}
