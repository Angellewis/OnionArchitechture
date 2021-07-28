using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Mapper;
using GenericApi.Model.Entities;
using Moq;
using Xunit;

namespace GenericApi.Services.Test
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        public UserServiceTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
                .CreateMapper();
        }
        [Fact]
        public void ShouldMapperMapUsingMocking()
        {
            //Arrange
            Mock<IMapper> _mapperMock = new Mock<IMapper>();
            var result = new UserDto
            {
                PhotoFileName = "Prueba"
            };
            var model = new User
            {
                Photo = new Model.Entities.Document
                {

                    FileName = "Prueba"
                }
            };

            _mapperMock
                .Setup(setup => setup.Map<UserDto>(It.IsAny<User>()))
                .Returns(result);

            //Act
             var resultDto = _mapperMock.Object.Map<UserDto>(model);
            _mapperMock.Verify(x => x.Map<UserDto>(It.IsAny<User>()), Times.Once);

            //Assert
            Assert.NotNull(resultDto);
            Assert.Equal(resultDto.PhotoFileName, result.PhotoFileName);
        }

        [Fact]
        public void ShouldMapperMapUsingIntance()
        {
            //Arrange
            var model = new Model.Entities.User
            {
                Photo = new Model.Entities.Document
                {
                    FileName = "Prueba"
                }
            };

            //Act
            var result = _mapper.Map<UserDto>(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.PhotoFileName, model.Photo.FileName);
        }
    }
}
