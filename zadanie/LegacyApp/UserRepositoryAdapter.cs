namespace LegacyApp;

public class UserRepositoryAdapter : IUserRepository
{
    public void Add(User user)
    {
        UserDataAccess.AddUser(user);
    }
}