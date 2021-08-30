using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<RegisterViewModel, AppUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
