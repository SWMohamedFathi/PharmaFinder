using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDbContext dbContext;

        public UserController(IUserService userService, IDbContext _dbContext)
        {
            _userService = userService;
            this.dbContext = _dbContext;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public ActionResult<User> GetUserById(decimal id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {


            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(decimal id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        [Route("UploadImage")]
        public User UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Amjad\\pharmafinder-frontend\\PharmaFinder-Angular\\src\\assets\\ProfilePicture");
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User item = new User();
            item.Profileimage = fileName;
            return item;
        }
    }
}
