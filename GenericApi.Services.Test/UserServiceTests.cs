using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Core.Abstract;
using GenericApi.Core.Settings;
using GenericApi.Model.Contexts;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        public UserServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");
            var context = new WorkShopContext(optionsBuilder.Options);

            IUserRepository respository = new UserRepository(context);

            #endregion

            #region Validator

            var validator = new UserValidator();

            #endregion

            #region Option Settings

            var settings = Options.Create(new JwtSettings
            {
                ExpiresInMinutes = 10,
                Secret = "0263875b-b775-4426-938c-ab7c04c74b22"
            });

            #endregion

            _userService = new UserService(
                respository,
                mapper,
                validator,
                settings);

        }

        //[Fact]
        //public void ShouldSaveUserUsingMock()
        //{
        //    //Arrange
        //    var _userServiceMock = new Mock<IUserService>();

        //    var userToSave = new UserDto
        //    {
        //        Name = "Emmanuel",
        //        MiddleName = "Enrique",
        //        LastName = "Jimenez",
        //        SecondLastName = "Pimentel",
        //        Dob = new System.DateTime(1996, 06, 16),
        //        DocumentType = Core.Enums.DocumentType.ID,
        //        DocumentTypeValue = "22500851658",
        //        Gender = Core.Enums.Gender.MALE,
        //        UserName = "emmanuel",
        //        Password = "Hola1234,"
        //    };

        //    IEntityOperationResult<UserDto> result = null;

        //    _userServiceMock.Setup(x => x.AddAsync(It.IsAny<UserDto>()).Result)
        //        .Callback<IEntityOperationResult<UserDto>>(userDto => result = userDto);

        //    _userService.AddAsync(userToSave);

        //    _userServiceMock.Verify(x => x.AddAsync(It.IsAny<UserDto>()), Times.Once);

        //    Assert.True(result.IsSuccess);
        //    Assert.NotNull(result.Entity);
        //    Assert.Empty(result.Errors);
        //    Assert.Equal(userToSave.Gender, result.Entity.Gender);
        //}

        [Fact]
        public async Task ShouldSaveUserAsync()
        {
            //Arrange
            var requestDto = new UserDto
            {
                Name = "Emmanuel",
                MiddleName = "Enrique",
                LastName = "Jimenez",
                SecondLastName = "Pimentel",
                Dob = new System.DateTime(1996, 06, 16),
                DocumentType = Core.Enums.DocumentType.ID,
                DocumentTypeValue = "22500851658",
                Gender = Core.Enums.Gender.MALE,
                UserName = "emmanuel",
                Password = "Hola1234,"
            };

            //Act
            var operationResult = await _userService.AddAsync(requestDto);

            //Assert
            Assert.True(operationResult.IsSuccess, operationResult.Errors.FirstOrDefault());
            Assert.NotNull(operationResult.Entity);
            Assert.Empty(operationResult.Errors);
        }
    }
}
