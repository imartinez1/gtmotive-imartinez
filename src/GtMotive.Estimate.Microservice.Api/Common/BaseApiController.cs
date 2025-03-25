using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Common
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController(UserManager<User> userManager) : ControllerBase
    {
        private readonly UserManager<User> _userManager = userManager;

        public Guid? UserId
        {
            get
            {
                try
                {
                    var user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
                    return user?.Id;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
        }
    }
}
