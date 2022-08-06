using AutoMapper;
using ManagerRachunkow.Models;
using ManagerRachunkow.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.Mail, map => map.MapFrom(m => m.Email))
                .ForMember(vm => vm.IsPaid, map => map.MapFrom(m => m.IsPaid))
                .ForMember(vm => vm.Password, map => map.MapFrom(m => m.PasswordHash))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.UserName))
                .ForMember(vm => vm.TelNumber, map => map.MapFrom(m => m.PhoneNumber));
            CreateMap<UserDTO, ApplicationUser>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.Email, map => map.MapFrom(m => m.Mail))
                .ForMember(vm => vm.IsPaid, map => map.MapFrom(m => m.IsPaid))
                .ForMember(vm => vm.PasswordHash, map => map.MapFrom(m => m.Password))
                .ForMember(vm => vm.UserName, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.PhoneNumber, map => map.MapFrom(m => m.TelNumber));

            CreateMap<Bill, BillDTO>()
                .ForMember(vm => vm.April, map => map.MapFrom(m => m.April))
                .ForMember(vm => vm.August, map => map.MapFrom(m => m.August))
                .ForMember(vm => vm.December, map => map.MapFrom(m => m.December))
                .ForMember(vm => vm.February, map => map.MapFrom(m => m.February))
                .ForMember(vm => vm.January, map => map.MapFrom(m => m.January))
                .ForMember(vm => vm.July, map => map.MapFrom(m => m.July))
                .ForMember(vm => vm.June, map => map.MapFrom(m => m.June))
                .ForMember(vm => vm.March, map => map.MapFrom(m => m.March))
                .ForMember(vm => vm.May, map => map.MapFrom(m => m.May))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.November, map => map.MapFrom(m => m.November))
                .ForMember(vm => vm.October, map => map.MapFrom(m => m.October))
                .ForMember(vm => vm.September, map => map.MapFrom(m => m.September))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.Year, map => map.MapFrom(m => m.Year));
            CreateMap<BillDTO, Bill>()
                .ForMember(vm => vm.April, map => map.MapFrom(m => m.April))
                .ForMember(vm => vm.August, map => map.MapFrom(m => m.August))
                .ForMember(vm => vm.December, map => map.MapFrom(m => m.December))
                .ForMember(vm => vm.February, map => map.MapFrom(m => m.February))
                .ForMember(vm => vm.January, map => map.MapFrom(m => m.January))
                .ForMember(vm => vm.July, map => map.MapFrom(m => m.July))
                .ForMember(vm => vm.June, map => map.MapFrom(m => m.June))
                .ForMember(vm => vm.March, map => map.MapFrom(m => m.March))
                .ForMember(vm => vm.May, map => map.MapFrom(m => m.May))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.November, map => map.MapFrom(m => m.November))
                .ForMember(vm => vm.October, map => map.MapFrom(m => m.October))
                .ForMember(vm => vm.September, map => map.MapFrom(m => m.September))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.Year, map => map.MapFrom(m => m.Year));

            CreateMap<Information, InformationDTO>()
                .ForMember(vm => vm.Content, map => map.MapFrom(m => m.Content))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id));
            CreateMap<InformationDTO, Information>()
                 .ForMember(vm => vm.Content, map => map.MapFrom(m => m.Content))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id));
        }
    }
}
