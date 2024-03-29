﻿using AutoMapper;
using DataAccessLayer.Models;
using DataLayer.models.users;

namespace Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponse>();
            CreateMap<AccountRequest, User>();
            CreateMap<AccountRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if ((prop is string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                    ));
        }
    }
}
