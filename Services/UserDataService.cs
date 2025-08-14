using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Benedict.Services
{
    public class UserDataService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider; 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly NavigationManager _navigation;

        public UserDataService(
            AuthenticationStateProvider authenticationStateProvider,
            UserManager<ApplicationUser> userManager,
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            SignInManager<ApplicationUser> signInManager,
            NavigationManager navigation)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;
            _dbContextFactory = dbContextFactory;
            _signInManager = signInManager;
            _navigation = navigation;
        }
        public async Task<ApplicationUser?> GetCurrentUserAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity?.IsAuthenticated == true)
            {
                return await _userManager.GetUserAsync(user);
            }
            return null;
        }        

        public async Task<bool> IsAdminAsync() {
            var user = await GetCurrentUserAsync();
            if (user == null) {
                return false;
            }
            return await _userManager.IsInRoleAsync(user, "Admin");
        }
        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            user.AdminConfirmed = false;
            user.EmailConfirmed = false;
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<string> GetUserIdAsync() {
            var user = await GetCurrentUserAsync();
            if (user == null) {
                return "";
            }
            return user.Id;
        }
        public async Task SignInUserAsync(ApplicationUser user) {
            await _signInManager.SignInAsync(user, isPersistent: false);
            _navigation.NavigateTo("/", forceLoad: true);
        }
        public async Task<IList<string>> GetUserRoles(ApplicationUser user) {
            
            return await _userManager.GetRolesAsync(user);           
        }


    }
}
