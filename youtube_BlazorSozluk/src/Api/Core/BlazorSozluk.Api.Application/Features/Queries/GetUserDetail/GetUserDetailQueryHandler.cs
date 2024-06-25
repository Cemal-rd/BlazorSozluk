﻿using AutoMapper;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
           
            if (request.UserId == Guid.Empty && string.IsNullOrEmpty(request.UserName))
            {
                throw new ArgumentException("Hem UserId hem de UserName boş olamaz.");
            }

            Domain.Models.User dbUser = null;

           
            if (request.UserId != Guid.Empty)
            {
                dbUser = await userRepository.GetByIdAsync(request.UserId);
            }
           
            else if (!string.IsNullOrEmpty(request.UserName))
            {
                dbUser = await userRepository.GetSingleAsync(i => i.UserName == request.UserName);
            }

         
            if (dbUser == null)
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");
            }

          
            return mapper.Map<UserDetailViewModel>(dbUser);
        }
    }
}
