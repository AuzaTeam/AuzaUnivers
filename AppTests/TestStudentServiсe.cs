
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Moq;
using Xunit;

namespace AppTests;

public class TestStudentServi�e
{
    private readonly IStudentRepository _studentRepository;
    public TestStudentServi�e(IStudentRepository? studentRepository = null) 
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
        // ��������� �������� ��� �������� ������ � ����������
        var students = new List<Student>
        {
            new Student { Email = "sdfsdf", FirstName = "dan", Id = 1, IsDeleted = false, LastName = "danon" },
        };
        repObj.Setup(obj => obj.GetAllAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(students);

        var service = new TestStudentServi�e(repObj.Object);

        //act
        var Result = await service.GetAllStudTest();

        //assert
        Assert.NotNull(Result);
        Assert.NotEmpty(Result);
        //Assert.Empty(Result);
    }
}

