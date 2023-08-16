using System;
using Microsoft.EntityFrameworkCore;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
    public class ProjectUserService : IProjectUserRepository
    {
        private readonly AppDbContext _dbContext;

        public ProjectUserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectUser GetById(Guid id)
        {
            return _dbContext.ProjectUser.Find(id);
        }

        public IEnumerable<ProjectUser> GetAll()
        {
            return _dbContext.ProjectUser.ToList();
        }

        public void Add(ProjectUser user)
        {
            _dbContext.ProjectUser.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(ProjectUser user)
        {
            _dbContext.ProjectUser.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(ProjectUser user)
        {
            _dbContext.ProjectUser.Remove(user);
            _dbContext.SaveChanges();
        }

        public bool IsUserAuthorizedForProject(Guid UserId ,Guid ProjectId)
        {
            if (_dbContext.User.Find(UserId).Role == "superuser")
            {
                return true;
            }
            if (_dbContext.ProjectUser
                .Where(i => i.UserId == UserId && i.ProjectId == ProjectId).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}

