﻿using AmmanClinic.data;
using AmmanClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace AmmanClinic.Services
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountService(UserManager<ApplicationUser> _userManager,
                              SignInManager<ApplicationUser> _signInManager,
                              RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }


        public async Task<IdentityResult> CreateAccount(SignUpDTO signUpDTO)
        {
            ApplicationUser user = new ApplicationUser();
            user.DOB = signUpDTO.DOB;
            user.UserName = signUpDTO.Email;
            user.Email = signUpDTO.Email;
            user.Name = signUpDTO.Name;
            var result = await userManager.CreateAsync(user, signUpDTO.Password); 
            return result;
        }

        public async Task<SignInResult> SignIn(SignInDTO signInDTO)
        {
            var result = await signInManager.PasswordSignInAsync(signInDTO.Username, signInDTO.Password, signInDTO.RememberMe, false);
            return result;
        }

        public async Task<IdentityResult> CreateRole(RoleDTO dto)
        {
            IdentityRole role = new IdentityRole();
            role.Name = dto.Name;
            var result = await roleManager.CreateAsync(role);
            return result;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<ApplicationUser> allusers = await userManager.Users.ToListAsync();

            List<UserDTO> users = new List<UserDTO>();
            foreach (ApplicationUser item in allusers)
            {
                UserDTO dto = new UserDTO();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.Email = item.Email;

                users.Add(dto);
            }
            return users;
        }


        public async Task<List<UserRolesDTO>> GetRoles(string UserId)
        {
            List<IdentityRole> allroles = await roleManager.Roles.ToListAsync();

            List<UserRolesDTO> userRoles = new List<UserRolesDTO>();
            foreach (IdentityRole item in allroles)
            {
                UserRolesDTO dto = new UserRolesDTO();
                dto.RoleId = item.Id;
                dto.RoleName = item.Name;
                dto.IsSelected = false;
                dto.UserId = UserId;
                userRoles.Add(dto);
            }

            var user = await userManager.FindByIdAsync(UserId);

            var Roles = await userManager.GetRolesAsync(user);

            foreach (UserRolesDTO item in userRoles)
            {
                if (Roles.Contains(item.RoleName) == true)
                {
                    item.IsSelected = true;
                }
            }

            return userRoles;
        }

        public async Task UpdateUserRoles(List<UserRolesDTO> userRoles)
        {
            foreach (UserRolesDTO item in userRoles)
            {
                ApplicationUser user = await userManager.FindByIdAsync(item.UserId);
                if (item.IsSelected == true)
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == false)
                    {
                        await userManager.AddToRoleAsync(user, item.RoleName);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == true)
                    {
                        await userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
