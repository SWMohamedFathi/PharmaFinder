using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        [Route("uploadImage")]
        [HttpPost]
        public User UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Ahmad\\PharmaFinder-Angular\\src\\assets\\Images", fileName);
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
