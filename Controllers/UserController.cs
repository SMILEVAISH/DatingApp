using API.Data;
using API.Modals.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(DataContext context) : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<IEnumerable<AppUser>> GetUserList([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var user = context.Users.Find(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            else
            {
                var userList = context.Users.OrderBy(x => x.Id).ToList();
                return Ok(userList);
            }
        }
    }
}