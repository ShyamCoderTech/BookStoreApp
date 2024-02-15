using BookStoreApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace BookStoreApp.Repository
{
    public class AccountRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsyncUser(SignUpModel signUpModel)
        {
            var user = new IdentityUser
            {
                Email = signUpModel.EmailAddress,
                UserName = signUpModel.EmailAddress
            };
            var result = await _userManager.CreateAsync(user,signUpModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.EmailAddress,signInModel.Password,false,false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }
}
