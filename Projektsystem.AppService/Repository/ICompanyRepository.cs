using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface ICompanyRepository
	{
        public Company GetById(string id);
        public IEnumerable<Company> GetAll();
        public void Add(Company company);
        public void Update(Company company);
        public void Delete(Company company);
    }
}

