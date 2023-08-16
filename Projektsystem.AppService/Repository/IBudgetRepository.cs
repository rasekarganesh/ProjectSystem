using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IBudgetRepository
	{
        public Budget GetById(Guid id);
        public IEnumerable<Budget> GetAll();
        public void Add(Budget budget);
        public void Update(Budget budget);
        public void Delete(Budget budget);
    }
}

