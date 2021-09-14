namespace ValueObject
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Exists(User user)
        {
            var found = _userRepository.Find(user.Name);
            return found != null;
        }
    }

    public class UserRepository : IUserRepository
    {
        public User Find(UserName userName)
        {
            // 略
            return null;
        }

        public void Save(User user)
        {
            // 略
        }

        public User Find(UserId targetId)
        {
            // 略
            return null;
        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}