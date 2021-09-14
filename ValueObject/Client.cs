namespace ValueObject
{
    public class Client
    {
        private UserRegisterService _userRegisterService;

        public void ChangeName(string id, string name)
        {
            var target = _userRegisterService.Get(id);
//            target.Name.ChangeName(name);
        }

        public void Register(string name)
        {
            var command = new UserRegisterCommand() {Name = name};
            _userRegisterService.Handle(command);
        }
    }
}