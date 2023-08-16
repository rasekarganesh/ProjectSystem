using System;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
	public class CompanyService : ICompanyRepository
	{
        private readonly AppDbContext _dbContext;

        public CompanyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            if (_dbContext.Company.ToList().Count == 0)
            {
                Add(new Company()
                {
                    Name = "Company 1",
                    Email = "comp1@gmail.com",
                });
                Add(new Company()
                {
                    Name = "Company 2",
                    Email = "comp2@gmail.com",
                });
                Add(new Company()
                {
                    Name = "Company 3",
                    Email = "comp3@gmail.com",
                });
                Add(new Company()
                {
                    Name = "Company 4",
                    Email = "comp4@gmail.com",
                });
            }
        }

        public Company GetById(string id)
        {
            return _dbContext.Company.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Company.ToList();
        }

        public void Add(Company company)
        {
            _dbContext.Company.Add(company);
            _dbContext.SaveChanges();
        }

        public void Update(Company company)
        {
            _dbContext.Company.Update(company);
            _dbContext.SaveChanges();
        }

        public void Delete(Company company)
        {
            _dbContext.Company.Remove(company);
            _dbContext.SaveChanges();
        }
    }
}

