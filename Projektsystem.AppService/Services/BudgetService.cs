using System;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
	public class BudgetService : IBudgetRepository
	{
        private readonly AppDbContext _dbContext;

        public BudgetService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Budget GetById(Guid id)
        {
            return _dbContext.Budget.Find(id);
        }

        public IEnumerable<Budget> GetAll()
        {
            return _dbContext.Budget.ToList();
        }

        public void Add(Budget user)
        {
            _dbContext.Budget.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(Budget user)
        {
            _dbContext.Budget.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(Budget user)
        {
            _dbContext.Budget.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}

