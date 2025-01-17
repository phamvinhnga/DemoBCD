﻿using Demo.Service.Base;
using Demo.Service.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.EntityFramework.Entities;
using Demo.UnitOfWork.interfaces;

namespace Demo.Service.Business.Managers
{
    public class UserOrganizationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<UserOrganization, Guid> _userOrganizationRepository;

        public UserOrganizationManager(
             UserManager<User> userManager,
            IRepository<UserOrganization, Guid> userOrganizationRepository
        )
        {
            _userOrganizationRepository = userOrganizationRepository;
            _userManager = userManager;
        }

        public async Task<List<UserOutputDto>> GetListUserNotDependencyUserOrganizationAsync(Guid organizationId)
        {
            var listUserId = await _userOrganizationRepository.Query.Where(w => w.OrganizationId == organizationId).Select(s => s.UserId).ToListAsync();
            
            var listUser = await _userManager.Users.Where(w => !listUserId.Contains(w.Id)).ToListAsync();

            return listUser.JsonMapTo<List<UserOutputDto>>();
        }

        public async Task<List<UserOrganizationOutputDto>> GetListUserOrganizationByOrganizationIdAsync(Guid organizationId)
        {
            var listUserOrganization = await _userOrganizationRepository.Query.Where(w => w.OrganizationId == organizationId).Include(i => i.User).Include(i => i.Title).ToListAsync();

            return listUserOrganization.JsonMapTo<List<UserOrganizationOutputDto>>();
        }

        public async Task UpdateTitleUserOrganizationByIdAsync(UpdateTitleUserOrganizationDto input)
        {
            var query = await _userOrganizationRepository.GetAsync(input.Id);

            query.TitleId = input.TitleId;

            await _userOrganizationRepository.UpdateAsync(query);
        }

    }
}
