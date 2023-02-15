using AutoMapper;
using StudenAdminPortal.Api.DomainModels;
using DataModels= StudenAdminPortal.Api.DataModels;

namespace StudenAdminPortal.Api.Profiles.AfterMaper
{
    public class UpdateStudentAfter : IMappingAction<UpdateStudent, DataModels.Student>
    {
        public void Process(UpdateStudent source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
