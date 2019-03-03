using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using RQCore.Authorization;
using RQCore.Authorization.Roles;
using RQCore.Authorization.Users;
using RQCore.Roles.Dto;
using RQCore.Users.Dto;
using System;

using Abp.Linq.Extensions;
namespace RQCore.Users
{
    //[AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;


        private readonly IRepository<User,long> _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;



        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }
      

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();
            //input.UserName
            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(user);
        }

        public async Task<bool> CheckUserNameAsync(string Name)
        {
            var task = await _userManager.FindByNameAsync(Name);
            if (task is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public async Task<UserDto>  resetPasswordWithout(resetPasswordWithout input)
        {

            //User user = ObjectMapper.Map<User>(input);

            User user = await _userManager.FindByNameAsync(input.userName);
            var hash = _passwordHasher.HashPassword(user, input.newPassword);
            user.Password = hash;
            await _userManager.UpdateAsync(user);

            //IdentityResult x = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            //return x;

            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(user);

        }
        //public   async Task<IdentityResult> resetPassword (string userName, string currentPassword, string newPassword)
        public async Task<IdentityResult> resetPassword(resetPasswordInput input)
        { 
            string userName=input.userName;
            string currentPassword= input.currentPassword;
            string newPassword=input.newPassword;
        CheckCreatePermission();

            ////User user = ObjectMapper.Map<User>(input);
            //string userName = input.UserName;
            User user = await _userManager.FindByNameAsync(userName);
            IdentityResult x = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
           
            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            //CheckErrors(await _userManager.CreateAsync(user, input.Password));

            //if (input.RoleNames != null)
            //{
            //    CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            //}

            CurrentUnitOfWork.SaveChanges();

            //return MapToEntityDto(user);
            return x;
        }


        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            Repository.GetAllIncluding(x => x.Roles);

            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        public object GetAllIncluding(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        protected override UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.NormalizedName);
            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();
            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {


            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return user;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {


            SortedDictionary<string, object> DgDict = new SortedDictionary<string, object>();
            bool canAssignRolesFromAdmin = PermissionChecker.IsGranted(PermissionNames.Pages_Tenants);
            bool canAssignRolesFromRQAdmin = PermissionChecker.IsGranted(PermissionNames.Pages_Admin);
            bool canAssignRolesFromRQAssitant = PermissionChecker.IsGranted(PermissionNames.Pages_RQAssitant);
            //List<Role> RolescanAssigned = allRoles;
            int myTopRoleBack = 0;

            if (canAssignRolesFromAdmin) //var RolesUnderYouers = allRoles;
            {
                myTopRoleBack = 0;
                DgDict.Add("myTopRoleBack", "canAssignRolesFromAdmin");
                return query
                    .OrderBy(r => r.UserName);
            }
            else if (canAssignRolesFromRQAdmin)
            { 
                myTopRoleBack = 1;
                DgDict.Add("myTopRoleBack", "canAssignRolesFromRQAdmin"); 
                return query
                    .Where(r => Convert.ToInt32(r.Surname) >= 1000)  
                    .OrderBy(r => r.UserName)
         ;
            }
            else if (canAssignRolesFromRQAssitant)
            {
                myTopRoleBack = 2;
                DgDict.Add("myTopRoleBack", "canAssignRolesFromRQAssitant");
                return query
                    .Where(r => Convert.ToInt32(r.Surname) > 1000)
                    .OrderBy(r => r.UserName);
            }
            else
            {
                DgDict.Add("myTopRoleBack", null);
                return null;
            }
          

        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
