using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	
    public interface IProjectUserRepository
    {
        public ProjectUser GetById(Guid id);
        public IEnumerable<ProjectUser> GetAll();
        public void Add(ProjectUser budget);
        public void Update(ProjectUser budget);
        public void Delete(ProjectUser budget);
        public bool IsUserAuthorizedForProject(Guid UserId, Guid ProjectId);
    }
}

