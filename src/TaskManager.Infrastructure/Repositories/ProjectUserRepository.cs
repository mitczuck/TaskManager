using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Context;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Interfaces;
using System.Linq;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        private readonly SqlDbContext _context;

        public ProjectUserRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectUser> GetProjectUsers()
        {
            return _context.ProjectUsers.ToList();
        }

        public IEnumerable<ProjectUser> GetProjectUsers(int projectId)
        {
            return _context.ProjectUsers.Where(pu => pu.ProjectId == projectId).ToList();
        }

        public ProjectUser GetProjectUser(int projectId, int userId)
        {
            var projectUser = _context.ProjectUsers.Find(projectId, userId);

            if (projectUser == null)
            {
                return new ProjectUser();
            }

            return projectUser;
        }

        public ProjectUser CreateProjectUser(ProjectUser projectUser)
        {
            _context.ProjectUsers.Add(projectUser);
            _context.SaveChanges();

            return GetProjectUser(projectUser.ProjectId, projectUser.UserId);
        }

        public bool DeleteProjectUser(int projectId, int userId)
        {
            var projectUser = _context.ProjectUsers.Find(projectId, userId);
            if (projectUser == null)
            {
                return false;
            }

            _context.ProjectUsers.Remove(projectUser);
            _context.SaveChanges();

            return true;
        }

        public bool ProjectUserExists(int projectId, int userId)
        {
            return _context.ProjectUsers.Any(e => e.ProjectId == projectId && e.UserId == userId);
        }
    }
}
