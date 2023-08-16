using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IUserRepository
	{
        public User GetById(Guid id);
        public IEnumerable<User> GetAll();
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);
        public User GetByEmail(string email);
    }
}

