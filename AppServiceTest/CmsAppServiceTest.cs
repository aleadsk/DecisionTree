using AutoMapper;
using Moq;
using TextWebPlugIn.Interfaces.Repository;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.Model;
using TextWebPlugIn.Service;

namespace AppServiceTest;

public class CmsAppServiceTest {
    [Fact]
    public async Task GetAll_ShouldReturnListOfCmsEntityDtos() {
        // Arrange
        var mockRepository = new Mock<ICmsRepository>();
        var mockMapper = new Mock<IMapper>();

        var cmsEntities = new List<CmsEntity> {
            new CmsEntity { Id = Guid.NewGuid(), Name = "First CMS" },
            new CmsEntity { Id = Guid.NewGuid(), Name = "Second CMS" },
        };

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(cmsEntities);

        var expectedDtoList = new List<CmsEntityDto> {
            new CmsEntityDto { Id = cmsEntities[0].Id, Name = cmsEntities[0].Name },
            new CmsEntityDto { Id = cmsEntities[1].Id, Name = cmsEntities[1].Name },
        };

        mockMapper.Setup(mapper => mapper.Map<List<CmsEntityDto>>(cmsEntities)).Returns(expectedDtoList);

        var service = new CmsAppService(mockRepository.Object, mockMapper.Object);

        // Act
        var result = await service.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDtoList.Count, result.Count);
        Assert.Equal(expectedDtoList[0].Id, result[0].Id);
        Assert.Equal(expectedDtoList[0].Name, result[0].Name);
        Assert.Equal(expectedDtoList[1].Id, result[1].Id);
        Assert.Equal(expectedDtoList[1].Name, result[1].Name);
    }

    [Fact]
    public async Task GetCMSContent_ExistingId_ShouldReturnCmsEntityDto() {
        // Arrange
        var id = Guid.NewGuid();
        var cmsEntity = new CmsEntity { Id = id, Name = "Test CMS" };
        var cmsEntityDto = new CmsEntityDto { Id = id, Name = "Test CMS" };

        var mockRepository = new Mock<ICmsRepository>();
        mockRepository.Setup(repo => repo.GetById(id)).ReturnsAsync(cmsEntity);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<CmsEntityDto>(cmsEntity)).Returns(cmsEntityDto);

        var service = new CmsAppService(mockRepository.Object, mockMapper.Object);

        // Act
        var result = await service.GetCMSContent(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cmsEntityDto.Id, result.Id);
        Assert.Equal(cmsEntityDto.Name, result.Name);
    }

    [Fact]
    public async Task InsertOrUpdateCMSContent_NewEntity_ShouldCreateAndReturnCmsEntityDto() {
        // Arrange           
        var id = Guid.NewGuid();
        var cmsEntityDto = new CmsEntityDto { Id = id, Name = "New CMS" };
        var createdCmsEntity = new CmsEntity { Id = id, Name = "New CMS" };

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<CmsEntity>(cmsEntityDto)).Returns(createdCmsEntity);

        var mockRepository = new Mock<ICmsRepository>();
        mockRepository.Setup(repo => repo.Create(createdCmsEntity)).ReturnsAsync(createdCmsEntity);

        var service = new CmsAppService(mockRepository.Object, mockMapper.Object);

        // Act
        var result = await service.InsertOrUpdateCMSContent(cmsEntityDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cmsEntityDto.Name, result.Name);
        Assert.NotEqual(Guid.Empty, result.Id);

    }

    [Fact]
    public async Task InsertOrUpdateCMSContent_ExistingEntity_ShouldUpdateAndReturnCmsEntityDto() {
        // Arrange
        var id = Guid.NewGuid();
        var cmsEntityDto = new CmsEntityDto { Id = id, Name = "Updated CMS" };
        var cmsEntity = new CmsEntity { Id = id, Name = "Updated CMS" };

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<CmsEntity>(cmsEntityDto)).Returns(cmsEntity);

        var mockRepository = new Mock<ICmsRepository>();
        mockRepository.Setup(repo => repo.Update(cmsEntity)).ReturnsAsync(cmsEntity);

        var service = new CmsAppService(mockRepository.Object, mockMapper.Object);

        // Act
        var result = await service.InsertOrUpdateCMSContent(cmsEntityDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cmsEntityDto.Name, result.Name);
        Assert.Equal(cmsEntityDto.Id, result.Id);
    }
}