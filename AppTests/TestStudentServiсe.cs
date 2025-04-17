
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Moq;
using Xunit;

namespace AppTests;

public class TestStudentServiсe
{
    private readonly IStudentRepository _studentRepository;
    public TestStudentServiсe(IStudentRepository? studentRepository = null) 
    {
        _studentRepository = studentRepository ?? new Mock<IStudentRepository>().Object;
    }
    public async Task<IEnumerable<Student>> GetAllStudTest()
    {
        return await _studentRepository.GetAllAsync();
    }

    [Fact]
    public async Task GetAllStudentsSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();
        // Настройте заглушку для возврата списка с элементами
        var students = new List<Student>
        {
            new Student { Email = "sdfsdf", FirstName = "dan", Id = 1, IsDeleted = false, LastName = "danon" },
        };
        repObj.Setup(obj => obj.GetAllAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(students);

        var service = new TestStudentServiсe(repObj.Object);

        //act
        var Result = await service.GetAllStudTest();

        //assert
        Assert.NotNull(Result);
        Assert.NotEmpty(Result);
        //Assert.Empty(Result);
    }
}

