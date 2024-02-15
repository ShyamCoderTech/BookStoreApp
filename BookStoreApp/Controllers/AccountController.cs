using BookStoreApp.Models;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _repository;

        public AccountController(AccountRepository repository)
        {
            _repository = repository;
        }
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
           if(ModelState.IsValid)
            {
                var data = await _repository.PasswordSignInAsync(signInModel);
                if (data.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credential");
            }
            return View();
        }
        [HttpPost]
        [Route ("SignUp")]
        public async Task<IActionResult>  SignUp(SignUpModel signUpModel)
        {
            if(ModelState.IsValid)
            {
                var data = await _repository.CreateAsyncUser(signUpModel);
                if (!data.Succeeded)
                {

                    foreach (var errorMessage in data.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> signOutAsync()
        {
            await _repository.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }
    }
}
