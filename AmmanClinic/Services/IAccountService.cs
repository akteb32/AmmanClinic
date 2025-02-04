using AmmanClinic.Models;
using Microsoft.AspNetCore.Identity;

namespace AmmanClinic.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUpDTO signUpDTO);

        Task<SignInResult> SignIn(SignInDTO signInDTO);

        Task<IdentityResult> CreateRole(RoleDTO dto);

        Task<List<UserDTO>> GetUsers();

        Task<List<UserRolesDTO>> GetRoles(string UserId);

        Task UpdateUserRoles(List<UserRolesDTO> userRoles);

        Task Logout();
    }
}
