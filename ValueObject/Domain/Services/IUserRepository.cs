namespace ValueObject
{
    public interface IUserRepository
    {
        User Find(UserName userName);
        void Save(User user);
        User Find(UserId targetId);
        void Delete(User user);
    }
}