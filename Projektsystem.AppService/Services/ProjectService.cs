using System;
using Microsoft.EntityFrameworkCore;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
	public class ProjectService : IProjectRepository
    {

        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project GetById(Guid id)
        {
            return _dbContext.Project.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            
            var data = _dbContext.Project.ToList();

            return data;
        }

        public void Add(Project project)
        {
            _dbContext.Project.Add(project);
            _dbContext.SaveChanges();
        }

        public void Update(Project project)
        {
            _dbContext.Project.Update(project);
            _dbContext.SaveChanges();
        }

        public void Delete(Project project)
        {
            _dbContext.Project.Remove(project);
            _dbContext.SaveChanges();
        }

  
    }
}

