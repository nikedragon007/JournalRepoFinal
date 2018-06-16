using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.Controllers
{
    public class AccountController : ApiController
    {
        // GET: Account
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            try
            {
                model.UserName = "nik";
                model.Email = "nikedragon007@gmail.com";
                model.Password = "nik";
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3
                };
                IdentityResult result = manager.Create(user, model.Password);
                return result;
            }
            catch(Exception ex)
            {
                return new IdentityResult();
            }

        }
    }
}