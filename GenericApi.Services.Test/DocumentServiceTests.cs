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
    public class DocumentServiceTests
    {
        private readonly IDocumentService _documentService;
        private readonly Document _documento1 = new Document
        {
            FileName = "documento1",
            OriginalName = "documento1",
            ContentType = "investigaciones"
        };

        private readonly Document _documento2 = new Document
        {
            FileName = "documento2",
            OriginalName = "documento2",
            ContentType = "investigaciones"
        };

        public DocumentServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");
            var context = new WorkShopContext(optionsBuilder.Options);
            context.AddRange(_documento1, _documento2);
            context.SaveChanges();

            IDocumentRepository respository = new DocumentRepository(context);

            #endregion

            #region Validator

            var validator = new DocumentValidator();

            #endregion

            _documentService = new DocumentService(respository, mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveDocumentAsync()
        {
            //Arrange
            var requestDto = new DocumentDto
            {
                FileName = "documento1",
                OriginalName = "documento1",
                ContentType = "investigaciones"
            };

        //Act
        var result = await _documentService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllDocumentsAsync()
        {
            //Act
            var result = await _documentService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldDeleteDocumentAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _documentService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }

        
        public async Task ShouldUpdateDocumentAsync()
        {
            //Arrange
            var id = 2;

            var requestDto = new DocumentDto
            {
                FileName = "documento2",
                OriginalName = "documento2",
                ContentType = "investigaciones"
            };

            var result = await _documentService.UpdateAsync(id, requestDto);

            //Assert

            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.FileName, result.Entity.FileName);

        }
    }
}
