using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
        }
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return userContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userContext.Users.Where(x => x.ID == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddUser")]

        public string AddUser(Users users)
        {
            string response = string.Empty;
            userContext.Users.Add(users);
            userContext.SaveChanges();
            return "User added";
        }

        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(Users user)
        {
            userContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges ();

            return "User Updated";
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(int id)
        {
            Users user = userContext.Users.Where(u => u.ID == id).FirstOrDefault();
            if (user != null)
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return "User Deleted";
            }
            else
            {
                return "No user found";
            }
        }

    }
}
