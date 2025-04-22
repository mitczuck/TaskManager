using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Context;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Core.Enums;
using System.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SqlDbContext _context;

        public ProjectRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> GetProjects(int userId)
        {
            return _context.Projects.Where(p => _context.ProjectUsers.Any(pu => pu.ProjectId == p.Id && pu.UserId == userId)).ToList();
        }
        public Project GetProject(int id)
        {
            var Project = _context.Projects.Find(id);

            if (Project == null)
            {
                return new Project();
            }

            return Project;
        }

        public Project UpdateProject(Project Project)
        {
            _context.Entry(Project).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ProjectExists(Project.Id))
                {
                    return GetProject(Project.Id);
                }
                else
                {
                    throw new ArgumentException("Projeto não encontrado.");
                }
            }

            return GetProject(Project.Id);
        }

        public Project CreateProject(Project Project)
        {
            _context.Projects.Add(Project);
            _context.SaveChanges();

            return GetProject(Project.Id);
        }

        public bool DeleteProject(int id)
        {
            var Project = _context.Projects.Find(id);
            
            if (Project == null)
                throw new ArgumentException("Projeto não encontrado.");

            if (Project.Tasks.Any(t => t.Status == StatusTask.Pendding))
                throw new ArgumentException("Projeto não pode ser removido pois possui tarefas pendentes. Atualize as tarefas para conluídas ou remova essas tarefas do projeto.");            

            _context.Projects.Remove(Project);
            _context.SaveChanges();

            return true;
        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
