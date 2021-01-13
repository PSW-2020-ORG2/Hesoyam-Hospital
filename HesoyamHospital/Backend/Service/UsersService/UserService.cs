using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.UsersService
{
    public class UserService : IService<User, long>, IUserService<User>
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User entity)
            => _userRepository.Create(entity);

        public void Delete(User entity)
        {
            entity.Deleted = true;
            Update(entity);
        }

        public IEnumerable<User> GetAll()
            => _userRepository.GetAll();

        public User GetByID(long id)
            => _userRepository.GetByID(id);

        public User GetByUsername(string userName)
            => _userRepository.GetByUsername(userName);

        public void Login(string username, string password)
        {
            User user = GetByUsername(username);
            bool check = CheckUserCredentials(user, password);
            if (check)
                AppResources.getInstance().loggedInUser = user;
            else
                AppResources.getInstance().loggedInUser = null;
        }

        public bool CheckUserCredentials(User user, string password)
        {
            if (user == null || user.Password != password)
                return false;
            return true;
        }

        public void Update(User entity)
            => _userRepository.Update(entity);

        public void Validate(User entity)
        {
            //throw new NotImplementedException();
        }
    }
}
