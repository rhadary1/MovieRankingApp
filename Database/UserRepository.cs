using RankingApp.Model;

namespace RankingApp.Database
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context; 

        public UserRepository(UserContext userContext)
        {
            _context = userContext;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
