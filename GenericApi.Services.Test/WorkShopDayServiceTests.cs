using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Core.Settings;
using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
    public class WorkShopDayServiceTests
    {
        private readonly IWorkShopDayService _workShopDayService;
        private readonly WorkShopDay _Day1 = new WorkShopDay
        {
            Day = Core.Enums.WeekDay.MONDAY,
            Mode = Core.Enums.WorkShopDayMode.ON_SITE,
            ModeLocation = "Solvex",
            WorkShopId = 1
        };

        private readonly WorkShopDay _Day2 = new WorkShopDay
        {
            Day = Core.Enums.WeekDay.THURSDAY,
            Mode = Core.Enums.WorkShopDayMode.VIRTUAL,
            ModeLocation = "Casa",
            WorkShopId = 1
        };

        public WorkShopDayServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");
            var context = new WorkShopContext(optionsBuilder.Options);
            context.AddRange(_Day1, _Day2);
            context.SaveChanges();

            IWorkShopDayRepository respository = new WorkShopDayRepository(context);

            #endregion

            #region Validator

            var validator = new WorkShopDayValidator();

            #endregion

            _workShopDayService = new WorkShopDayService(respository, mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveUserAsync()
        {
            //Arrange
            var requestDto = new WorkShopDayDto
            {
                Day = Core.Enums.WeekDay.MONDAY,
                Mode = Core.Enums.WorkShopDayMode.ON_SITE,
                ModeLocation = "Solvex",
                WorkShopId = 1
            };

            //Act
            var result = await _workShopDayService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetUserGeAllAsync()
        {
            //Act
            var result = await _workShopDayService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldDeleteUserAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _workShopDayService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }

        [Fact]
        public async Task ShouldUpdateUserAsync()
        {
            //Arrange
            var id = 2;

            var requestDto = new WorkShopDayDto
            {
                Id = 2,
                Day = Core.Enums.WeekDay.THURSDAY,
                Mode = Core.Enums.WorkShopDayMode.VIRTUAL,
                ModeLocation = "Casa",
                WorkShopId = 1
            };

            var result = await _workShopDayService.UpdateAsync(id, requestDto);

            //Assert

            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.Id, result.Entity.Id);

        }
    }
}   
