using Auth.Core.DTO.AuthDto;
using Auth.Core.Models;
using AutoMapper;

namespace Auth.Core.Utils.AutoMapper;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        CreateMap<CreateUser, AppUser>();
        CreateMap<AppUser, ReadUser>()
            .ConstructUsing(x => new ReadUser(x.UserName, x.FirstName, x.LastName, x.Age, x.Email));
    }
}