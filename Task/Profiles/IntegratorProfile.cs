using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DTOs;

namespace Task.Profiles
{
    public class IntegratorProfile : Profile
    {
        //!AhmedShaban: Map between Internal-domain data and the base of Messenger response
        public IntegratorProfile()
        {
            CreateMap<UserDto, ResponseDto>()
                //!AhmedShaban: 1 - first_name to title
                .ForPath(d => d.elements.title, opt => { opt.MapFrom(s => s.data.first_name); })
                //!AhmedShaban: 2 - avatar to image_url
                .ForPath(d => d.elements.image_url, opt => { opt.MapFrom(s => s.data.avatar); })
                //!AhmedShaban: last_name to subtitle
                .ForPath(d => d.elements.subtitle, opt => { opt.MapFrom(s => s.data.last_name); });
        }
    }
}
