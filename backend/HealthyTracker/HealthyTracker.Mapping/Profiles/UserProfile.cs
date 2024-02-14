using AutoMapper;
using Google.Apis.Auth;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.User;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpDTO, User>()
            .ForMember(dest => dest.UserName, opt
                => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DisplayName, opt
                => opt.MapFrom(src => src.FirstName));
        
        CreateMap<GoogleJsonWebSignature.Payload, User>()
            .ForMember(dest => dest.Email, opt 
                => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt
                => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DisplayName, opt
                => opt.MapFrom(src => src.GivenName));
        
        CreateMap<UpdateUserDTO, User>()
            .ForMember(dest => dest.DisplayName, opt
                => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.HasPassword, opt 
                => opt.MapFrom(src => src.PasswordHash != null))
            .ForMember(dest => dest.Avatar, opt
                => opt.MapFrom(src => src.Avatar));
        
        
    }
}