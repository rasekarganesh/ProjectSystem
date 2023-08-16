using System;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
	public class UserService : IUserRepository
	{
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.User.ToList().Count == 0)
            {
                Add(new User()
                {
                    FirstName = "Super",
                    LastName = "User",
                    Role = "superuser",
                    Email = "superuser@gmail.com",
                    IsGoogleUser = true,
                    ProfilePicture = "/img/006m.jpg"
                });
                Add(new User()
                {
                    FirstName = "Test",
                    LastName = "1",
                    Role = "user",
                    Email = "test1@gmail.com",
                    IsFacebookUser =true,
                    ProfilePicture = "/img/002m.jpg"
                });
            }
        }

        public User GetById(Guid id)
        {
            return _dbContext.User.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            
            return _dbContext.User.ToList();
        }

        public void Add(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbContext.User.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.User.Where(i=>i.Email == email).FirstOrDefault();
        }

    }
}

