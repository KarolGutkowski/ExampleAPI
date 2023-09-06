namespace ExampleAPI.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostDbContext _dbContext;

        public UserRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll => _dbContext.Users;


        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users
                        .Where(user => user.Id == id)
                        .SingleOrDefault();
        }

        public IEnumerable<User> GetByName(string name)
        {
            return _dbContext.Users
                    .Where(user => user.Name == name);
        }
    }
}
