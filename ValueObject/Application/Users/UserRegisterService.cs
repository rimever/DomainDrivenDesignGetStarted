using System;

namespace ValueObject
{
    public class UserRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserRegisterService(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public void Handle(UserRegisterCommand command)
        {
            var userId = new UserId(command.Id);
            var userName = new UserName(command.Name);
            var mailAddress = new UserMailAddress(command.MailAddress);
            var user = new User(userId, userName, mailAddress);
            if (_userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザーはすでに存在しています");
            }

            _userRepository.Save(user);
        }

        public UserData Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = _userRepository.Find(targetId);
            // ドメインオブジェクトを直接公開すると多くの危険性があるのでDTOを用いてやりとりする
            return new UserData(user);
        }

        public void Update(UserUpdateCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = _userRepository.Find(targetId);
            if (user == null)
            {
                throw new UserNotFoundException(targetId);
            }

            if (command.Name != null)
            {
                if (_userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザーはすでに存在しています。");
                }

                user.Name.ChangeName(command.Name);
            }


            _userRepository.Save(user);
        }

        public void Delete(UserDeleteCommand command)
        {
            var targetid = new UserId(command.Id);
            var user = _userRepository.Find(targetid);
            if (user == null)
            {
                // 例外になる場合もあれば、すでに見つからないので正常終了とするケースもある
                throw new UserNotFoundException(targetid);
            }

            _userRepository.Delete(user);
        }
    }

    public class UserDeleteService
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(UserDeleteCommand command)
        {
            var userId = new UserId(command.Id);
            var user = _userRepository.Find(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            _userRepository.Delete(user);
        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(UserId targetId)
        {
            throw new NotImplementedException();
        }
    }

    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(User user, string ユーザーはすでに存在しています)
        {
            throw new NotImplementedException();
        }
    }
}