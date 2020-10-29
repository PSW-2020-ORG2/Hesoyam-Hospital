using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.UsersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller.UsersController
{
    class UserController : IController<User, UserID>
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        public User Create(User entity)
            => _userService.Create(entity);

        public void Delete(User entity)
            => _userService.Delete(entity);

        public IEnumerable<User> GetAll()
            => _userService.GetAll();

        public User GetByID(UserID id)
            => _userService.GetByID(id);

        public void Update(User entity)
            => _userService.Update(entity);

        public void Login(string username, string password)
            => _userService.Login(username, password);
    }
}
