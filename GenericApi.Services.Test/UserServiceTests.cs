using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Core.Settings;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
    public class UserServiceTests
    {
        private IUserService _userService;

        [Fact]
        public async Task ShouldSaveUserAsync()
        {
            #region Arrange

            const string password = "Hola1234,";

            var dto = new UserDto
            {
                Name = "Emmanuel",
                UserName = "Emma",
                Password = password
            };
            var user = new User
            {
                Name = dto.Name,
                UserName = dto.UserName,
                Password = dto.Password
            };

            var validatorMock = new Mock<IValidator<UserDto>>();
            validatorMock
                .Setup(x => x.Validate(dto))
                .Returns(new FluentValidation.Results.ValidationResult());

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<UserDto>()))
               .Returns(user);

            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user.Id = 1;
                    user.Password = x.Password;
                })
                .ReturnsAsync(user);

            mapperMock
                .Setup(x => x.Map(It.IsAny<User>(), It.IsAny<UserDto>()))
                .Callback<User, UserDto>((x, y) =>
                {
                    dto.Id = x.Id;
                    dto.Password = x.Password;
                })
                .Returns(dto);

            var optionMock = new Mock<IOptions<JwtSettings>>();

            _userService = new UserService(
                repositoryMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                optionMock.Object
                );

            #endregion

            //Act
            var result = await _userService.AddAsync(dto);


            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(result.Entity, dto);
            Assert.Equal(result.Entity.UserName, user.UserName);
            Assert.NotEqual(result.Entity.Password, password);
        }
    }
}
