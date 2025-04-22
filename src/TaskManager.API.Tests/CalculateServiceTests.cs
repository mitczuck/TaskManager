using TaskManager.Application.Implementations;
using TaskManager.Infrastructure.Interfaces;
using Moq;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _projectRepositoryMock;
    
    private readonly ProjectService _projectService;

    public ProjectServiceTests()
    {
        _projectRepositoryMock = new Mock<IProjectRepository>();
        
    }
}
