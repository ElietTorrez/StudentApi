using AutoMapper;
using StudenAdminPortal.Api.DomainModels;
using StudenAdminPortal.Api.Profiles.AfterMaper;
using DataModel = StudenAdminPortal.Api.DataModels;
namespace StudenAdminPortal.Api.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModel.Student, Student>().ReverseMap();

            CreateMap<DataModel.Gender, Gender>().ReverseMap();

            CreateMap<DataModel.Address, Address>().ReverseMap();

            //CreateMap<UpdateStudent, DataModels.Student>()
            //    .ForMember(x => x.Address.PhysicalAddress, y => y.MapFrom(s => s.PhysicalAddress))
            //.ForMember(x => x.Address.PostalAddress, y => y.MapFrom(s => s.PostalAddress));

            CreateMap<UpdateStudent, DataModels.Student>()
               .AfterMap<UpdateStudentAfter>();

            CreateMap<AddStudent, DataModels.Student>()
       .AfterMap<AddStudentAfter>();
        }

    }
}
