using AutoMapper;
using SocialNetwork.BLL.Data;
using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserDTO>()
                    // Ignoring the Password property of the destination type
                    .ForMember(dest => dest.Password, act => act.Ignore())
                    .ForSourceMember(dest => dest.PasswordHash, opt => opt.DoNotValidate())
                    .ForSourceMember(dest => dest.PasswordSalt, opt => opt.DoNotValidate())
                    .ForSourceMember(dest => dest.Jwt, opt => opt.DoNotValidate())
                    .ForSourceMember(dest => dest.Expiry, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<Post, PostDTO>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}
