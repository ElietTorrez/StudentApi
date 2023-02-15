using AutoMapper;
using StudenAdminPortal.Api.DomainModels;
using System;
using DataModels = StudenAdminPortal.Api.DataModels;


namespace StudenAdminPortal.Api.Profiles.AfterMaper
{
    public class AddStudentAfter : IMappingAction<AddStudent, DataModels.Student>
    {
        public void Process(AddStudent source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
