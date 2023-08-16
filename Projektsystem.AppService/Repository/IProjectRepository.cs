using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IProjectRepository
	{
        public Project GetById(Guid id);
        public IEnumerable<Project> GetAll();
        public void Add(Project project);
        public void Update(Project project);
        public void Delete(Project project);

        //public int GetNewProjectsCount();
        //public int GetClosedProjectsCount();
        //public int GetOpenProjectsCount();
        //public int GetHoldProjectsCount();
    }
}

