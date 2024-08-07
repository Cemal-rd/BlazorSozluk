﻿using AutoMapper;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Common.Models.Queries;
using BlazorSozluk.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginUserViewModel>()
            .ReverseMap();
        CreateMap<CreateUserCommand,User>()
            .ReverseMap();
        CreateMap<UpdateUserCommand, User>()
            .ReverseMap();
        CreateMap<CreateEntryCommand, Entry>()
            .ReverseMap();
        CreateMap<Entry,GetEntriesViewModel>()
            .ForMember(x=>x.CommentCount,y=>y.MapFrom(z=>z.EntryComments.Count))
            .ReverseMap();
        CreateMap<CreateEntryCommentCommand, EntryComment>()
            .ReverseMap();
        CreateMap<UserDetailViewModel, User>()
            .ReverseMap();
    }
}