using AutoMapper;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Employee;

namespace CarPark.User.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeProfileInfo>().ReverseMap();
        }
    }
}
